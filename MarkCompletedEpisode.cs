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
    public partial class MarkCompletedEpisode : Form
    {
        public MarkCompletedEpisode(int ID)
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (clsEpisode.MarkEpisodeAsCompleted(txtSeriesName.Text, Convert.ToInt32(txtSeason.Text), Convert.ToInt32(txtEpisodeNumber.Text)))
            {
                MessageBox.Show("Episode marked as completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            {
                MessageBox.Show("Failed to mark episode as completed. Please check the details and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
