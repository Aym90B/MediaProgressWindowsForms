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
    public partial class frmListSeries : Form
    {
        public frmListSeries()
        {
            InitializeComponent();
        }

        private void _RefreshSeriesList()
        {
            dgvAllSeries.DataSource = clsSeries.GetAllSeries();
        }



        private void dgvAllSeries_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //  MessageBox.Show(dgvAllContacts.CurrentRow.Cells[0].Value.ToString());
        }









        private void frmListSeries_Load(object sender, EventArgs e)
        {
            _RefreshSeriesList();
        }

        private void btnAddNewSeries_Click(object sender, EventArgs e)
        {
            frmAddEditSeries frm = new frmAddEditSeries(-1);
            frm.ShowDialog();
            _RefreshSeriesList();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAddEditSeries frm = new frmAddEditSeries((int)dgvAllSeries.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshSeriesList();
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete series [" + dgvAllSeries.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsSeries.DeleteSeries((int)dgvAllSeries.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Series Deleted Successfully.");
                    _RefreshSeriesList();
                }

                else
                    MessageBox.Show("Series is not deleted.");

            }
        }
    }
}
