using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Internal;
using MediaProgressBusinessLayer;


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
            if (.ValidateUser(txtUser.Text, txtPassword.Text))
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
