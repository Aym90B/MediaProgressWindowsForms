using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaProgressBusinessLayer;

namespace MediaProgressWindowsForms
{
    public partial class frmMovies : Form
    {
        public frmMovies()
        {
            InitializeComponent();
        }
      

        private void btnAddMovies_Click(object sender, EventArgs e)
        {
            frmAddEditMedia frm = new frmAddEditMedia(-1);
            frm.ShowDialog();
           
        }
    }
}
