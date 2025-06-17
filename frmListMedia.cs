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
    public partial class frmListMedia : Form
    {
        public frmListMedia()
        {
            InitializeComponent();
        }

        private void _RefreshMoviesList()
        {
            dgvAllMovies.DataSource = clsMedia.GetAllMedia();
        }

        private void _RefreshSeriesList()
        {
            dgvAllMovies.DataSource = clsSeries.GetAllSeries();
        }



        private void dgvAllMovies_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //  MessageBox.Show(dgvAllContacts.CurrentRow.Cells[0].Value.ToString());
        }

       

        

       

        

        private void frmListMovies_Load(object sender, EventArgs e)
        {
            _RefreshMoviesList();
        }

        private void btnAddNewMovie_Click(object sender, EventArgs e)
        {
            frmAddEditMedia frm = new frmAddEditMedia(-1);
            frm.ShowDialog();
            _RefreshMoviesList();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAddEditMedia frm = new frmAddEditMedia((int)dgvAllMovies.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshMoviesList();
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete movie [" + dgvAllMovies.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsMedia.DeleteMedia((int)dgvAllMovies.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Movie Deleted Successfully.");
                    _RefreshMoviesList();
                }

                else
                    MessageBox.Show("Movie is not deleted.");

            }
        }

        private void btnAddNewSeries_Click(object sender, EventArgs e)
        {
            frmAddEditSeries frm = new frmAddEditSeries(-1);
            frm.ShowDialog();
            _RefreshSeriesList();
        }
    }
}
