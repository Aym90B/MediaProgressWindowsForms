using MediaProgressBusinessLayer;
using System;
using System.Windows.Forms;

namespace MediaProgressWindowsForms
{
    public partial class frmAddEditSeries : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _ID;
        clsSeries _Series;
        public frmAddEditSeries(int ID)
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



            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Series";
                _Series = new clsSeries();
                return;
            }

            _Series = clsSeries.Find(_ID);

            if (_Series == null)
            {
                MessageBox.Show("This form will be closed because No Series with ID = " + _Series);
                this.Close();

                return;
            }

            lblMode.Text = "Edit Series ID = " + _ID;
            lblSeriesID.Text = _ID.ToString();
            txtName.Text = _Series.Name;
            txtRating.Text = _Series.Rating.ToString();
            txtDuration.Text = _Series.Duration.ToString();
            checkBoxCompleted.Checked = _Series.Completed;
            txtSeasons.Text = _Series.Seasons.ToString();






        }







        private void btnSave_Click(object sender, EventArgs e)
        {
            _Series.Name = txtName.Text;
            _Series.Rating = Convert.ToDouble(txtRating.Text);
            _Series.Seasons = Convert.ToInt32(txtSeasons.Text);

            _Series.Duration = Convert.ToInt32(txtDuration.Text);
            _Series.Completed = checkBoxCompleted.Checked;

            if (_Series.Save())
                MessageBox.Show("Data Saved Successfully.");
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            _Mode = enMode.Update;
            lblMode.Text = "Edit Contact ID = " + _Series.ID;
            lblSeriesID.Text = _Series.ID.ToString();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditSeries_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

       
    }
}
