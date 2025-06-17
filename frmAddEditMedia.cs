using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaProgressBusinessLayer;

namespace MediaProgressWindowsForms
{
    public partial class frmAddEditMedia : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _ID;
        clsMedia _Media;
        public frmAddEditMedia(int ID)
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

            DataTable dtCategories = clsCategory.GetAllCategories();
            foreach (DataRow row in dtCategories.Rows)
            {
                cbCategory.Items.Add(row["Name"]);
            }
        }


        private void _LoadData()
        {

            _FillSeriesInComboBox();
            cbSeries.SelectedIndex = 0;
            cbCategory.SelectedIndex = 0;

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Media";
                _Media = new clsMedia();
                return;
            }

            _Media = clsMedia.Find(_ID);

            if (_Media == null)
            {
                MessageBox.Show("This form will be closed because No Media with ID = " + _Media);
                this.Close();

                return;
            }

            lblMode.Text = "Edit Media ID = " + _ID;
            lblMovieID.Text = _ID.ToString();
            txtName.Text = _Media.Name;
            txtRating.Text = _Media.Rating.ToString();
            txtSeason.Text = _Media.Season.ToString();
            txtEpisodeNumber.Text = _Media.EpisodeNumber.ToString();
            txtDuration.Text = _Media.Duration.ToString();
            checkBoxCompleted.Checked = _Media.Completed;
            cbSeries.SelectedIndex = cbSeries.FindString(clsSeries.Find(_Media.SeriesID).Name);
            cbCategory.SelectedIndex = cbCategory.FindString(clsCategory.Find(_Media.CategoryID).Name);



        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            int SeriesID = clsSeries.Find(cbSeries.Text).ID;
            int CategoryID = clsCategory.Find(cbCategory.Text).ID;

            _Media.Name = txtName.Text;
            _Media.Rating = Convert.ToDouble(txtRating.Text);
            _Media.Season = Convert.ToInt32(txtSeason.Text);
            _Media.EpisodeNumber = Convert.ToInt32(txtEpisodeNumber.Text);
            _Media.Duration = Convert.ToInt32(txtDuration.Text);
            _Media.Completed = checkBoxCompleted.Checked;
            _Media.SeriesID = SeriesID;
            _Media.CategoryID = CategoryID;   

            if (_Media.Save())
                MessageBox.Show("Data Saved Successfully.");
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            _Mode = enMode.Update;
            lblMode.Text = "Edit Media ID = " + _Media.ID;
            lblMovieID.Text = _Media.ID.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditMovie_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
