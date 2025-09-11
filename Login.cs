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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "Ayman" && txtPassword.Text == "12345")
            {
                new Main().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Your credentials are invalid, please try again!");
                txtUser.Clear();
                txtPassword.Clear();
            }
        }
    }
}
