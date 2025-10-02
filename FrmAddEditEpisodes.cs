using MediaProgressBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MediaProgressWindowsForms
{
    public partial class frmAddEditEpisodes : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

       
        int _ID;
        clsEpisode _Episode;

        public frmAddEditEpisodes(int ID)
        {
            InitializeComponent();

            _ID = ID;

            if (_ID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private void _LoadData()
        {
            _FillSeriesInComboBox();
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Episode";
                _Episode = new clsEpisode();
                return;
            }
            _Episode = clsEpisode.Find(_ID);
            if (_Episode == null)
            {
                MessageBox.Show("This form will be closed because No Episode with ID = " + _Episode);
                this.Close();

                return;
            }

            lblMode.Text = "Edit Episode ID = " + _ID;
            
            txtEpisodeName.Text = _Episode.Name;
            txtEpisodeNumber.Text =  _Episode.EpisodeNumber.ToString();
            txtEpisodeRating.Text = _Episode.Rating.ToString();
            txtEpisodeDuration.Text = _Episode.Duration.ToString();
            chkCompleted.Checked = _Episode.Completed;
            chkWatchAgain.Checked = _Episode.WatchAgain;
         
        }


        private void frmAddEditEpisodes_Load(object sender, EventArgs e)
        {
          

            _LoadData();
        }

        private void _FillSeriesInComboBox()
        {
            DataTable dtSeries = clsSeries.GetAllSeries();
            foreach (DataRow row in dtSeries.Rows)
            {
                cbxSeriesNames.Items.Add(row["Name"]);
            }
        }

        private void _FillSeasonsInComboBox(string SeriesName)
        {
            cbxSeasons.Items.Clear();
            DataTable dtSeasons = clsSeries.GetAllSeasons(SeriesName);
            foreach (DataRow row in dtSeasons.Rows)
            {
               
                cbxSeasons.Items.Add(row["SeasonNumber"]);
              
            }
           
        }

        private void cbxSeriesNames_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string SeriesName = cbxSeriesNames.SelectedItem.ToString();
            _FillSeasonsInComboBox(SeriesName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Episode.SeriesID = clsSeries.GetSeriesIDByName(cbxSeriesNames.SelectedItem.ToString());
            _Episode.Season = Convert.ToInt32(cbxSeasons.SelectedItem.ToString());
            _Episode.EpisodeNumber = Convert.ToInt32(txtEpisodeNumber.Text);
            _Episode.Name = txtEpisodeName.Text;
            _Episode.Rating = Convert.ToDouble(txtEpisodeRating.Text);
            _Episode.Duration = Convert.ToInt16(txtEpisodeDuration.Text);
            _Episode.Completed = chkCompleted.Checked;
            _Episode.WatchAgain = chkWatchAgain.Checked;

            // Check if media exists by name and set mode
            if (clsEpisode.IsEpisodeExist(_Episode.Name))
                _Mode = enMode.Update;
            else
                _Mode = enMode.AddNew;

            //_Episode.Save((clsEpisode.enMode)_Mode, _Episode.SeriesID);

            if (_Episode.Save((clsEpisode.enMode)_Mode, _Episode.SeriesID))
                MessageBox.Show("Episode Data Saved Successfully.");
            else
                MessageBox.Show("Error: Episode Data Is not Saved Successfully.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbxSeriesNames.SelectedIndex = -1;
            cbxSeasons.SelectedIndex = -1;
            txtEpisodeNumber.Clear();
            txtEpisodeName.Clear();
            txtEpisodeRating.Clear();
            txtEpisodeDuration.Clear();
            chkCompleted.Checked = false;
            chkWatchAgain.Checked = false;
            cbxSeriesNames.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxSeriesNames_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbxSeriesNames.Text.ToString()))
            {
                e.Cancel = true;
                cbxSeriesNames.Focus();
                errorProvider1.SetError(cbxSeriesNames, "Choose Series");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cbxSeriesNames, "");
            }
        }

        private void cbxSeasons_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbxSeasons.Text.ToString()))
            {
                e.Cancel = true;
                cbxSeasons.Focus();
                errorProvider1.SetError(cbxSeasons, "Choose Season");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cbxSeasons, "");
            }
        }

        private void txtEpisodeNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEpisodeNumber.Text.ToString()))
            {
                e.Cancel = true;
                txtEpisodeNumber.Focus();
                errorProvider1.SetError(txtEpisodeNumber, "Enter Episode's Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEpisodeNumber, "");
            }
        }

        private void txtEpisodeName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEpisodeName.Text.ToString()))
            {
                e.Cancel = true;
                txtEpisodeName.Focus();
                errorProvider1.SetError(txtEpisodeName, "Enter Episode's Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEpisodeName, "");
            }
        }

        private void txtEpisodeRating_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEpisodeRating.Text.ToString()))
            {
                e.Cancel = true;
                txtEpisodeRating.Focus();
                errorProvider1.SetError(txtEpisodeRating, "Enter Episode's Rating");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEpisodeRating, "");
            }
        }

        private void txtEpisodeDuration_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEpisodeDuration.Text.ToString()))
            {
                e.Cancel = true;
                txtEpisodeDuration.Focus();
                errorProvider1.SetError(txtEpisodeDuration, "Enter Episode's Duration");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEpisodeDuration, "");
            }
        }
    }
}
