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
        clsSeries _Series;
        public frmAddEditMedia(int ID)
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
                lblMode.Text = "Add New Media";
                _Media = new clsMedia();
                _Series = new clsSeries();
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
           cbCategory.SelectedIndex = _Media.CategoryID;
            txtDuration.Text = _Media.Duration.ToString();
            checkBoxCompleted.Checked = _Media.Completed;
            chkbxWatchAgain.Checked = _Media.WatchAgain;
            txtWhereToWatch.Text = _Media.WhereToWatch;
            txtNumberOfSeasons.Text = _Series.NumberOfSeasons.ToString();
            txtNumberOfEpisodes.Text = _Series.NumberOfEpisodes.ToString();
            CkBxStartWatching.Checked = _Series.startWatching;
            PbPercentageOfCompletion.Value = (int) Convert.ToSingle (clsSeries. GetSeriesPercentageCompletion(_Series.ID));



        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
          
          
           
            _Media.Name = txtName.Text;
            _Media.Rating = Convert.ToDouble(txtRating.Text);
          
           
            _Media.Duration = Convert.ToInt32(txtDuration.Text);
            _Media.CategoryID = Convert.ToInt32(_Media.CategoryID);
            _Media.Completed = checkBoxCompleted.Checked;
            _Media.WatchAgain = chkbxWatchAgain.Checked;
          _Media.WhereToWatch = txtWhereToWatch.Text;
          
            if(cbCategory.SelectedIndex == 1)
            {
                _Media.Save();
                _Series.NumberOfSeasons = Convert.ToInt32(txtNumberOfSeasons.Text);
                _Series.NumberOfEpisodes = Convert.ToInt32(txtNumberOfEpisodes.Text);

                _Series.SaveSeries(_Media.ID);
                MessageBox.Show("Series Data Saved Successfully.");
             

            }

            else
            {
                if (_Media.Save())
                    MessageBox.Show("Media Data Saved Successfully.");
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.");
            }



        

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

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbCategory.SelectedIndex)
            {
                case 0:
                    _Media.CategoryID = 1;
                    break;
                    case 1:
                    _Media.CategoryID = 2;
                    lblNumberOfSeasons.Visible = true;
                    txtNumberOfSeasons.Visible = true;
                    lblNumberOfEpisodes.Visible = true;
                    txtNumberOfEpisodes.Visible = true;
                    btnAddEpisodes.Visible = true;

                    break;
                    case 2:
                    _Media.CategoryID = 3;
                    break;
                    case 3:
                        _Media.CategoryID = 4;
                    lblNumberOfPages.Visible = true;
                    txtNumberOfPages.Visible = true;
                    break;
                default:
                    _Media.CategoryID = 1;
                    break;
            }
        }

        private void btnAddEpisodes_Click(object sender, EventArgs e)
        {
            frmAddEditEpisodes frm = new frmAddEditEpisodes(-1);
            frm.ShowDialog();
        }
    }
}
