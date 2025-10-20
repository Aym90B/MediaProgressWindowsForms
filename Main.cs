using MediaProgressBusinessLayer;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            dgvAll.AutoGenerateColumns = true;
            if (Duration < 240)
                categoryComboBox.Items.Remove("Games");
            if (Duration < 60)
                categoryComboBox.Items.Remove("Books");

            switch (categoryComboBox.SelectedIndex)
            {
               
            

                case 0:
                    dgvAll.DataSource = clsMedia.getAllMediaWithinAvailableTime(Duration);
                    break;
                case 1:
                    dgvAll.DataSource = clsMedia.getAllMoviesWithinAvailableTime(Duration);
                    break;
                case 2:
                    dgvAll.DataSource = clsSeries.getAllSeriesWithinAvailableTime(Duration);
                    break;
                case 3:
                    dgvAll.DataSource = clsEpisode.getAllEpisodesWithinAvailableTime(Duration);
                    break;
                case 4:
                    dgvAll.DataSource = clsMedia.GetAllGamesWithinAvailableTime(Duration);
                    break;
                case 5:
                    dgvAll.DataSource = clsBook.GetAllBooksWithinAvailableTime(Duration);
                    break;

                default:
                    dgvAll.DataSource = clsMedia.getAllMediaWithinAvailableTime(Duration);
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
    }
}
