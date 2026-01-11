using MediaProgressBusinessLayer;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProgressWindowsForms
{
    public partial class Main : Form
    {
        int _ID;
        clsMedia _Movie;
        clsSeries _Series;

        public double durationInHours { get; set; }

        public Main()
        {
            InitializeComponent();
        }

     
       

        private void _RefreshAllMediaList()
        {
            dgvAll.DataSource = clsMedia.GetAllMedia();
        }

        private void _RefreshMoviesList()
        {
            dgvAll.DataSource = clsMedia.getAllMovies();
        }

        private void _RefreshSeriesList()
        {
            dgvAll.DataSource = clsSeries.GetAllSeriesFromIMDB();
        }

        private void _RefreshGamesList()
        {
            dgvAll.DataSource = clsMedia.GetAllGames();
        }

        private void _RefreshBooksList()
        {
            dgvAll.DataSource = clsMedia.GetAllBooks();
        }

       



        private void Main_Load(object sender, EventArgs e)
        {
            _RefreshMoviesList();
          
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            int Duration = Convert.ToInt32(hoursComboBox.Text) * 60 + (Convert.ToInt32(minutesComboBox.Text));
            char Difficulty = ' '; // Default value

            if (!string.IsNullOrEmpty(DifficultyComboBox.Text))
            {
                Difficulty = DifficultyComboBox.Text[0];
            }
            dgvAll.AutoGenerateColumns = true;
            if (Duration < 240)
                categoryComboBox.Items.Remove("Games");

           

            List<string> selectedPlatforms = new List<string>();

            string Choices = "NULL";

            if (chkNetflix.Checked) selectedPlatforms.Add("Netflix");
           
            if (chkOSN.Checked) selectedPlatforms.Add("OSN");
            if (chkTOD.Checked) selectedPlatforms.Add("TOD");
            if (chkShahid.Checked) selectedPlatforms.Add("Shahid");
            if (chkDisney.Checked) selectedPlatforms.Add("Disney+");
            if (chkStarzOn.Checked) selectedPlatforms.Add("StarzOn");
            if (chkThamanya.Checked) selectedPlatforms.Add("Thamanya");
            if (chkAJ.Checked) selectedPlatforms.Add("AJ+");
            if (chkAlAraby.Checked) selectedPlatforms.Add("AlAraby");
            if (chkCrunchyRoll.Checked) selectedPlatforms.Add("CrunchyRoll");
            if (chkPS.Checked) selectedPlatforms.Add("PlayStation");
            if(chkPC.Checked) selectedPlatforms.Add("PC");

            Choices = string.Join(",", selectedPlatforms);

            List<string> selectedScreenResolution = new List<string>();

            string screenResolution = "NULL";

            if (chkHD.Checked) selectedScreenResolution.Add("HD");
            if (chk4K.Checked) selectedScreenResolution.Add("4K");

            screenResolution = string.Join(",", selectedScreenResolution);




            switch (categoryComboBox.SelectedIndex)
            {
               
                case 0:
                    dgvAll.DataSource = clsMedia.getAllMediaWithinAvailableTime(Duration, Choices, Difficulty);
                    break;
                case 1:
                    dgvAll.DataSource = clsMedia.getAllMoviesWithinAvailableTime(Duration);
                    break;
                case 2:
                    dgvAll.DataSource = clsSeries.getAllSeriesWithinAvailableTime(Duration);
                    break;
                case 3:
                    dgvAll.DataSource = clsEpisode.getAllEpisodesWithinAvailableTime(Duration, Choices, screenResolution, Difficulty);
                    break;
                case 4:
                    dgvAll.DataSource = clsMedia.GetAllGamesWithinAvailableTime(Duration, Difficulty);
                    break;
                case 5:
                    dgvAll.DataSource = clsBook.GetAllBooksWithinAvailableTime(Duration, Difficulty);
                    break;

                default:
                    dgvAll.DataSource = clsMedia.getAllMediaWithinAvailableTime(Duration,Choices, Difficulty);
                    break;
                }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditMedia frm = new frmAddEditMedia((int)dgvAll.CurrentRow.Cells[0].Value);
            frm.ShowDialog();


            //_RefreshMoviesList();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Media [" + dgvAll.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsMedia.DeleteMedia((int)dgvAll.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Media Deleted Successfully.");
                    _RefreshMoviesList();
                }

                else
                    MessageBox.Show("Media is not deleted.");

            }
        }

        private void btnAddMovies_Click(object sender, EventArgs e)
        {
            frmAddEditMedia frm = new frmAddEditMedia(-1);
            frm.ShowDialog();
            _RefreshMoviesList();
        }

       

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (categoryComboBox.SelectedIndex)
            {
                case 0:
                    _RefreshMoviesList();
                    break;
                    case 1:
                    _RefreshSeriesList();
                    break;
                    case 2:
                    _RefreshGamesList();
                    break;
                
                
                    default:
                    _RefreshMoviesList();
                    break;
            }
        }

       

        private void hoursComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hoursComboBox.Text.ToString()))
            {
                e.Cancel = true;
                hoursComboBox.Focus();
                errorProvider1.SetError(hoursComboBox, "You should choose hours from 0");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(hoursComboBox, "");
            }
        }

        private void minutesComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(minutesComboBox.Text.ToString()))
            {
                e.Cancel = true;
                minutesComboBox.Focus();
                errorProvider1.SetError(minutesComboBox, "You should choose minutes 0 - 15 - 30 - 45");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(minutesComboBox, "");
            }
        }

        private void categoryComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(categoryComboBox.Text.ToString()))
            {
                e.Cancel = true;
                categoryComboBox.Focus();
                errorProvider1.SetError(categoryComboBox, "You should choose the category Movies - Series - Episodes - Games - Books");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(categoryComboBox, "");
            }
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            string textToFind = txtFind.Text;
            dgvAll.DataSource = clsMedia.getAllMediaWithinName(textToFind);
            //_RefreshMoviesList();
        }

        private void btnMovies_Click(object sender, EventArgs e)
        {
            frmAddEditMedia frm = new frmAddEditMedia(-1);
            frm.ShowDialog();
            _RefreshMoviesList();
        }

        private void btnShowMovies_Click(object sender, EventArgs e)
        {
           
            _RefreshMoviesList();
            dgvAll.DataSource = clsMedia.getAllMovies();
        }

        private void btnShowSeries_Click(object sender, EventArgs e)
        {
            _RefreshSeriesList();
            dgvAll.DataSource = clsMedia.getAllSeriesFromIMDB();
        }

        private void hoursComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnShowGames_Click(object sender, EventArgs e)
        {
            _RefreshGamesList();
            dgvAll.DataSource = clsMedia.GetAllGames();
        }

        private void btnShowBooks_Click(object sender, EventArgs e)
        {
            _RefreshBooksList();
            dgvAll.DataSource = clsMedia.GetAllBooks();
        }

        // Commit checkbox edits immediately so CellValueChanged fires
        private void dgvAll_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAll.IsCurrentCellDirty)
            {
                dgvAll.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // Handle checkbox changes and push to DB
        private void dgvAll_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Only handle CheckBox columns
            var col = dgvAll.Columns[e.ColumnIndex] as DataGridViewCheckBoxColumn;
            if (col == null)
                return;

            // Read the new checkbox value safely
            object cellObj = dgvAll.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            bool isChecked = (cellObj != null && cellObj != DBNull.Value) && Convert.ToBoolean(cellObj);

            // Determine the DB column name to update:
            // Prefer DataPropertyName (bound column), fall back to column Name
            string columnName = !string.IsNullOrWhiteSpace(col.DataPropertyName) ? col.DataPropertyName : col.Name;

            // If you don't have matching DB column names, set columnName explicitly here:
            // columnName = "WatchAgain"; // example

            // Find the Media_Name (or MediaName) column in the grid
            DataGridViewColumn mediaCol = dgvAll.Columns
                .Cast<DataGridViewColumn>()
                .FirstOrDefault(c =>
                    string.Equals(c.DataPropertyName, "seriesName", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(c.Name, "seriesName", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(c.DataPropertyName, "seriesName", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(c.Name, "seriesName", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(c.HeaderText, "seriesName", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(c.HeaderText, "seriesName", StringComparison.OrdinalIgnoreCase));

            if (mediaCol == null)
            {
                // Can't find media name column; abort
                MessageBox.Show("Media name column not found in grid. Update aborted.");
                return;
            }

            object mediaNameObj = dgvAll.Rows[e.RowIndex].Cells[mediaCol.Index].Value;
            if (mediaNameObj == null || mediaNameObj == DBNull.Value)
                return;

            string mediaName = mediaNameObj.ToString();

            string connectionString = "Data Source=LT-4312\\SQLEXPRESS;Initial Catalog=MovieData;Integrated Security=True";

            // Update by Media_Name column instead of ID
            string updateQuery = $"UPDATE Basics SET [{columnName}] = @BitValue WHERE [seriesName] = @MediaName";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@BitValue", SqlDbType.Bit).Value = isChecked;
                    cmd.Parameters.Add("@MediaName", SqlDbType.NVarChar, 250).Value = mediaName;

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    // Optionally show feedback if rows == 0
                }

                // Accept change in bound DataRow so the grid state is clean
                if (dgvAll.Rows[e.RowIndex].DataBoundItem is DataRowView drv)
                {
                    drv.Row.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating database: " + ex.Message);
                // Optionally reload the row value from DB to undo the change in UI
            }
        }

        private void btnStarted_Click(object sender, EventArgs e)
        {
            int Duration = Convert.ToInt32(hoursComboBox.Text) * 60 + (Convert.ToInt32(minutesComboBox.Text));
            dgvAll.DataSource = clsMedia.GetAllStartedMedia(Duration);
        }

        private void btnEpisodes25_Click(object sender, EventArgs e)
        {

            int Duration = Convert.ToInt32(hoursComboBox.Text) * 60 + (Convert.ToInt32(minutesComboBox.Text));
            dgvAll.AutoGenerateColumns = true;
            if (Duration < 240)
                categoryComboBox.Items.Remove("Games");
            List<string> selectedPlatforms = new List<string>();

            string Choices = "NULL";

            if (chkNetflix.Checked) selectedPlatforms.Add("Netflix");

            if (chkOSN.Checked) selectedPlatforms.Add("OSN");
            if (chkTOD.Checked) selectedPlatforms.Add("TOD");
            if (chkShahid.Checked) selectedPlatforms.Add("Shahid");
            if (chkDisney.Checked) selectedPlatforms.Add("Disney+");
            if (chkStarzOn.Checked) selectedPlatforms.Add("StarzOn");
            if (chkThamanya.Checked) selectedPlatforms.Add("Thamanya");
            if (chkAJ.Checked) selectedPlatforms.Add("AJ+");
            if (chkAlAraby.Checked) selectedPlatforms.Add("AlAraby");
            if (chkCrunchyRoll.Checked) selectedPlatforms.Add("CrunchyRoll");
            if (chkPS.Checked) selectedPlatforms.Add("PlayStation");
            if (chkPC.Checked) selectedPlatforms.Add("PC");

            Choices = string.Join(",", selectedPlatforms);


            dgvAll.DataSource = clsEpisode.GetAllEpisodes2025(Duration, Choices);
        }

        private void btnCompleted_Click(object sender, EventArgs e)
        {
            MarkCompletedEpisode frm = new MarkCompletedEpisode(-1);
            frm.ShowDialog();
        }

        private void dgvAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}