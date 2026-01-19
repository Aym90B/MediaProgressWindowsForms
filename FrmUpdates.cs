using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaProgressBusinessLayer;
using MediaProgressDataAccessLayer;

namespace MediaProgressWindowsForms
{
    public partial class FrmUpdates : Form
    {
        clsMovieDataAccess clsMovieDataAccess = new clsMovieDataAccess();
        public FrmUpdates()
        {
            InitializeComponent();
            txtYear.Text = DateTime.Now.Year.ToString();
            cmbType.SelectedIndex = 0; // Default to 'movie'
        }

        private void chkDeepScan_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = chkDeepScan.Checked;
            numRating.Enabled = enabled;
            txtGenre.Enabled = enabled;
            chkAdult.Enabled = enabled;
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            btnScan.Enabled = false;
            dgvResults.DataSource = null;

            try
            {
                int year;
                if (!int.TryParse(txtYear.Text, out year))
                {
                    MessageBox.Show("Please enter a valid year.");
                    return;
                }

                string type = cmbType.SelectedItem.ToString();
                string searchTerm = string.IsNullOrWhiteSpace(txtSearch.Text) ? "a" : txtSearch.Text;

                // 1. Basic Search
                var results = await ImdbService.GetNewMediaByYearAsync(year, type, searchTerm);

                if (chkDeepScan.Checked)
                {
                    // 2. Deep Scan Logic
                    var detailedResults = new List<ImdbService>();
                    decimal minRating = numRating.Value;
                    string genreFilter = txtGenre.Text.Trim();
                    bool includeAdult = chkAdult.Checked;

                    foreach (var item in results)
                    {
                        var details = await ImdbService.GetMediaDetailsAsync(item.Tconst);
                        if (details != null)
                        {
                            // Filter by Adult
                            if (!includeAdult && details.IsAdult) continue;

                            // Filter by Rating (Only filter if it HAS a rating and it's less than min)
                            if (decimal.TryParse(details.ImdbRating, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal rating))
                            {
                                if (rating < minRating) continue;
                            }
                            // Note: We no longer skip if rating is N/A - many new series won't have ratings yet.

                            // Filter by Genre
                            if (!string.IsNullOrEmpty(genreFilter))
                            {
                                if (details.Genres == null || 
                                    details.Genres.IndexOf(genreFilter, StringComparison.OrdinalIgnoreCase) == -1)
                                {
                                    continue;
                                }
                            }

                            detailedResults.Add(details);
                        }
                    }
                    dgvResults.DataSource = detailedResults;
                }
                else
                {
                    dgvResults.DataSource = results;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during scan: {ex.Message}");
            }
            finally
            {
                btnScan.Enabled = true;
            }
        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0 && dgvResults.CurrentRow == null)
            {
                MessageBox.Show("Please select a valid row (click the row header).");
                return;
            }

            // Support importing currently selected row (or rows if MultiSelect is on, but simplified here)
            var row = dgvResults.CurrentRow;
            if (row == null) return;

            var item = row.DataBoundItem as ImdbService;
            if (item == null) return;

            // If we didn't deep scan, we might need to fetch details now to insert full record
            if (string.IsNullOrEmpty(item.Genres) && string.IsNullOrEmpty(item.ImdbRating))
            {
                 var details = await ImdbService.GetMediaDetailsAsync(item.Tconst);
                 if (details != null) item = details;
            }

            try
            {
                decimal? rating = decimal.TryParse(item.ImdbRating, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal dRating) ? (decimal?)dRating : null;

                bool success = await clsMovieDataAccess.InsertImdbDataAsync(
                    item.Tconst, 
                    item.Type, 
                    item.Title, 
                    item.IsAdult, 
                    item.Year, 
                    item.RuntimeMinutes, 
                    item.Genres,
                    rating,
                    item.ImdbVotes
                );

                if (success)
                    MessageBox.Show($"Imported: {item.Title}");
                else
                    MessageBox.Show($"Skipped (Already Exists): {item.Title}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing: {ex.Message}");
            }
        }

        private async void btnDailyUpdates_Click(object sender, EventArgs e)
        {
            btnDailyUpdates.Enabled = false;
            int addedCount = 0;
            int processedCount = 0;
            int currentYear = DateTime.Now.Year;
            int startYear = 2025; // Go back to 2000

            // Expanded types including Series and Episodes
            string[] types = { "movie", "series", "episode", "tvEpisode", "tvSeries", "tvSpecial", "tvMovie","tvPilot","tvShort","tvMiniSeries","videoGame","Video","short" };
            string searchTerm = "a"; 

            try
            {
                // Loop through years from current back to startYear
                for (int year = currentYear; year >= startYear; year--)
                {
                    foreach (string type in types)
                    {
                        // Use a more specific search term than "a" to avoid "Too many results"
                        // Searching for the type itself or common prefixes
                        string currentSearchTerm = (type == "movie") ? "movie" : (type == "series" ? "series" : "a");

                        for (int page = 1; page <= 2; page++)
                        {
                            List<ImdbService> results;
                            try {
                                results = await ImdbService.AymanGetNewMediaByYearAsync(year, type, currentSearchTerm, page);
                            } catch { 
                                break; // Skip if too many results or API error for this combination
                            }
                            
                            if (results == null || results.Count == 0) break;

                            foreach (var item in results)
                            {
                                processedCount++;
                                
                                // Optimization: Check local DB existence BEFORE fetching details to save API calls
                                // Since we don't have a direct "Exists" check exposed in this specific class context easily without details,
                                // we'll use a lightweight check if possible. 
                                // However, clsMovieDataAccess methods like InsertImdbDataAsync do a check, but that requires full data.
                                // We can use IsMediaExistInMain or similar if we had Tconst check exposed globally.
                                // For now, we continue with the Fetch-then-Insert pattern but rely on the SP to handle 'IF NOT EXISTS'.
                                // Ideally we should check existence by Tconst first to save the Detail API call.

                                var details = await ImdbService.GetMediaDetailsAsync(item.Tconst);
                                if (details != null)
                                {
                                    decimal? rating = decimal.TryParse(details.ImdbRating, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal dRating) ? (decimal?)dRating : null;

                                    bool success = await clsMovieDataAccess.InsertImdbDataAsync(
                                        details.Tconst,
                                        details.Type,
                                        details.Title,
                                        details.IsAdult,
                                        details.Year,
                                        details.RuntimeMinutes,
                                        details.Genres,
                                        rating,
                                        details.ImdbVotes
                                    );

                                    if (success) addedCount++;
                                }
                            }
                        }
                    }
                }

                MessageBox.Show($"Deep Update Complete.\nScanned: {processedCount} items.\nNew Items Added: {addedCount}", 
                    "Daily Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during update: {ex.Message}");
            }
            finally
            {
                btnDailyUpdates.Enabled = true;
            }
        }
        private async void btnImportEpisodes_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0) return;

            var selectedItem = (ImdbService)dgvResults.SelectedRows[0].DataBoundItem;
            if (selectedItem.Type != "series" && selectedItem.Type != "tvSeries")
            {
                MessageBox.Show("Please select a Series to import its episodes.");
                return;
            }

            btnImportEpisodes.Enabled = false;
            try
            {
                var episodes = await ImdbService.GetEpisodesBySeriesIdAsync(selectedItem.Tconst);
                if (episodes == null || episodes.Count == 0)
                {
                    MessageBox.Show("No episodes found for this series.");
                    return;
                }

                int importedCount = 0;
                foreach (var ep in episodes)
                {
                    // Basic import to Episodes table
                    if (await clsEpisode.InsertEpisodeDataAsync(ep.Tconst, selectedItem.Tconst, ep.Season, ep.EpisodeNumber))
                    {
                        // Also ensure the episode exists in Basics table for titles/ratings to work
                        // We'll do a minimal insert for now, a deep scan would fill the rest
                        await MediaProgressDataAccessLayer.clsMovieDataAccess.InsertImdbDataAsync(
                            ep.Tconst, "tvEpisode", ep.Title, false, null, null, null);
                        
                        importedCount++;
                    }
                }

                MessageBox.Show($"Successfully imported {importedCount} episodes for '{selectedItem.Title}'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing episodes: " + ex.Message);
            }
            finally
            {
                btnImportEpisodes.Enabled = true;
            }
        }
    }
}
