using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
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
        string _Name;
        clsMedia _Media;
        clsSeries _Series;
        clsBook _Book;
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
                _Book = new clsBook();
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
            // Check if media exists by name and set mode
            if (clsMedia.IsMediaExistInMain(_Media.Name))
                _Mode = enMode.Update;
            else
                _Mode = enMode.AddNew;



            if (cbCategory.SelectedIndex == 1)
            {
                _Media.Save((clsMedia.enMode)_Mode);
                _Series.NumberOfSeasons = Convert.ToInt32(txtNumberOfSeasons.Text);
                _Series.NumberOfEpisodes = Convert.ToInt32(txtNumberOfEpisodes.Text);
                _Series.SaveSeries(_Media.ID);
                MessageBox.Show("Series Data Saved Successfully.");
            }
            else if (cbCategory.SelectedIndex == 3)
            {
                
                _Media.Save((clsMedia.enMode)_Mode);
               
                    
                _Media.ID = clsMedia.getMediaIDByName(_Media.Name);
                _Book.NumberOfPages = Convert.ToInt32(txtNumberOfPages.Text);
                _Book.CurrentPage = Convert.ToInt32(txtCurrentPage.Text);
                _Book.Author = txtAuthor.Text;
                _Book.ISBN = txtISBN.Text;
                if(_Mode == enMode.AddNew)
                    _Book.SaveBook(_Media.ID, (clsMedia.enMode)_Mode);
                else
                    _Book.SaveBook(_Media.ID, (clsMedia.enMode)_Mode);
                MessageBox.Show("Book Data Saved Successfully.");
            }
            else
            {
                if (_Media.Save((clsMedia.enMode)_Mode))
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
                    lblCurrentPage.Visible = true;
                    txtCurrentPage.Visible = true;
                    lblAuthor.Visible = true;
                    txtAuthor.Visible = true;
                    lblISBN.Visible = true;
                    txtISBN.Visible = true;
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

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text.ToString()))
            {
                e.Cancel = true;
                txtName.Focus();
                ep1.SetError(txtName, "Enter Media's Name");
            }
            else
            {
                e.Cancel = false;
                ep1.SetError(txtName, "");
            }
        }

        private void txtRating_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRating.Text.ToString()))
            {
                e.Cancel = true;
                txtRating.Focus();
                ep1.SetError(txtRating, "Enter Media's Rating");
            }
            else
            {
                e.Cancel = false;
                ep1.SetError(txtRating, "");
            }
        }

        private void txtDuration_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDuration.Text.ToString()))
            {
                e.Cancel = true;
                txtDuration.Focus();
                ep1.SetError(txtDuration, "Enter Media's Duration");
            }
            else
            {
                e.Cancel = false;
                ep1.SetError(txtDuration, "");
            }
        }

        private void txtWhereToWatch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWhereToWatch.Text.ToString()))
            {
                e.Cancel = true;
                txtWhereToWatch.Focus();
                ep1.SetError(txtWhereToWatch, "Enter Where to Watch");
            }
            else
            {
                e.Cancel = false;
                ep1.SetError(txtWhereToWatch, "");
            }
        }

        private void cbCategory_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbCategory.Text.ToString()))
            {
                e.Cancel = true;
                cbCategory.Focus();
                ep1.SetError(cbCategory, "Choose Media's Category");
            }
            else
            {
                e.Cancel = false;
                ep1.SetError(cbCategory, "");
            }
        }

        private void txtNumberOfSeasons_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumberOfSeasons.Text.ToString()))
            {
                e.Cancel = true;
                txtNumberOfSeasons.Focus();
                ep1.SetError(txtNumberOfSeasons, "Enter Series Number of Seasons");
            }
            else
            {
                e.Cancel = false;
                ep1.SetError(txtNumberOfSeasons, "");
            }
        }

        private void txtNumberOfEpisodes_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumberOfEpisodes.Text.ToString()))
            {
                e.Cancel = true;
                txtNumberOfEpisodes.Focus();
                ep1.SetError(txtNumberOfEpisodes, "Enter Series Number of Episodes");
            }
            else
            {
                e.Cancel = false;
                ep1.SetError(txtNumberOfEpisodes, "");
            }
        }

        private void txtNumberOfPages_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumberOfPages.Text.ToString()))
            {
                e.Cancel = true;
                txtNumberOfPages.Focus();
                ep1.SetError(txtNumberOfPages, "Enter Book's Number of Pages");
            }
            else
            {
                e.Cancel = false;
                ep1.SetError(txtNumberOfPages, "");
            }
        }

        private void txtCurrentPage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPage.Text.ToString()))
            {
                e.Cancel = true;
                txtCurrentPage.Focus();
                ep1.SetError(txtCurrentPage, "Enter Book's Current Page");
            }
            else
            {
                e.Cancel = false;
                ep1.SetError(txtCurrentPage, "");
            }
        }

        private void txtAuthor_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAuthor.Text.ToString()))
            {
                e.Cancel = true;
                txtAuthor.Focus();
                ep1.SetError(txtAuthor, "Enter Book's Author");
            }
            else
            {
                e.Cancel = false;
                ep1.SetError(txtAuthor, "");
            }
        }

        private void txtISBN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtISBN.Text.ToString()))
            {
                e.Cancel = true;
                txtISBN.Focus();
                ep1.SetError(txtISBN, "Enter Book's ISBN");
            }
            else
            {
                e.Cancel = false;
                ep1.SetError(txtISBN, "");
            }
        }

        //private void txtName_Leave(object sender, EventArgs e)
        //{
        //    _Media.Name = txtName.Text;
        //    if (clsMedia.IsMediaExistInMain(_Media.Name))
        //        _Mode = enMode.Update;
        //        else
        //            _Mode = enMode.AddNew;

        //}
    }
}
