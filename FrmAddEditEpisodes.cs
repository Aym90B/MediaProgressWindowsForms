using MediaProgressBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MediaProgressWindowsForms
{
    public partial class FrmAddEditEpisodes : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _ID;
        
        clsEpisode _Episode;
        public FrmAddEditEpisodes(int ID)
        {


            InitializeComponent();

            _ID = ID;

            if (_ID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private void _FillSeriesInComboBox()
        {
            DataTable dtSeries = clsSeries.GetAllSeries();
            foreach (DataRow row in dtSeries.Rows)
            {
                cbSeries.Items.Add(row["Name"]);
               
            }

            DataTable dtEpisodes = clsEpisode.GetAllEpisodes();
            foreach (DataRow row in dtEpisodes.Rows)
            {
                seasonsComboBox.Items.Add(row["Season"]);
            }
        }

        
        private void _LoadData()
        {

            _FillSeriesInComboBox();
            cbSeries.SelectedIndex = 0;

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
            lblEpisodeID.Text = _ID.ToString();
            txtEpisodeNumber.Text = _Episode.EpisodeNumber.ToString();
            txtEpisodeName.Text = _Episode.Name;
          
            txtEpisodeRating.Text = _Episode.Rating.ToString();
            txtEpisodeDuration.Text = _Episode.Duration.ToString();
            checkBoxCompleted.Checked = _Episode.Completed;

            //this will select the country in the combobox.
            cbSeries.SelectedIndex = cbSeries.FindString(clsSeries.Find(_Episode.SeriesID).Name);

        }


        private void FrmAddEditEpisodes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int SeriesID = clsSeries.Find(cbSeries.Text).ID;
            _Episode.Name = txtEpisodeName.Text;
            _Episode.SeriesID = SeriesID;
            _Episode.Rating = Convert.ToDouble(txtEpisodeRating.Text);
            _Episode.Season = Convert.ToInt16(seasonsComboBox.Text); 
            _Episode.EpisodeNumber = Convert.ToInt32(txtEpisodeNumber.Text);
            _Episode.Duration = Convert.ToInt16(txtEpisodeDuration.Text);

        
            _Episode.Completed = checkBoxCompleted.Checked;

            if (_Episode.Save())
                MessageBox.Show("Data Saved Successfully.");
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            _Mode = enMode.Update;
            lblMode.Text = "Edit Episode ID = " + _Episode.EpisodeID;
            lblEpisodeID.Text = _Episode.EpisodeID.ToString();
            //this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
