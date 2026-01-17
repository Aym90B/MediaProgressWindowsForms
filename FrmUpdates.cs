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

                            // Filter by Rating
                            if (decimal.TryParse(details.ImdbRating, out decimal rating))
                            {
                                if (rating < minRating) continue;
                            }
                            else if (minRating > 0) 
                            { 
                                // If rating is N/A and we require a min rating, skip or keep? 
                                // Let's skip if minRating > 0
                                continue; 
                            }

                            // Filter by Genre
                            if (!string.IsNullOrEmpty(genreFilter))
                            {
                                if (string.IsNullOrEmpty(details.Genres) || 
                                    !details.Genres.IndexOf(genreFilter, StringComparison.OrdinalIgnoreCase).Equals(-1))
                                {
                                    // Genre doesn't match
                                    // Wait, IndexOf != -1 means it matches. 
                                    // !Equals(-1) is correct for match. 
                                    // So if it DOESN'T match (Equals -1), continue.
                                    if (details.Genres == null || details.Genres.IndexOf(genreFilter, StringComparison.OrdinalIgnoreCase) == -1)
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
                bool success = await clsMovieDataAccess.InsertImdbDataAsync(
                    item.Tconst, 
                    item.Type, 
                    item.Title, 
                    item.IsAdult, 
                    item.Year, 
                    item.RuntimeMinutes, 
                    item.Genres
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
            int startYear = 2000; // Go back to 2000

            // Expanded types including Series and Episodes
            string[] types = { "movie", "series", "episode" };
            string searchTerm = "a"; 

            try
            {
                // Loop through years from current back to startYear
                for (int year = currentYear; year >= startYear; year--)
                {
                    foreach (string type in types)
                    {
                        // Limit pages to avoid hitting API limits too hard
                        // We check the first 2 pages of "popular" results (matched by 'a') for each year/type
                        for (int page = 1; page <= 2; page++)
                        {
                            var results = await ImdbService.GetNewMediaByYearAsync(year, type, searchTerm, page);
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
                                    bool success = await clsMovieDataAccess.InsertImdbDataAsync(
                                        details.Tconst,
                                        details.Type,
                                        details.Title,
                                        details.IsAdult,
                                        details.Year,
                                        details.RuntimeMinutes,
                                        details.Genres
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
    }
}
