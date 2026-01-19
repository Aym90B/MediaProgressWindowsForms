using MediaProgressBusinessLayer;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MediaProgressWindowsForms
{


    public partial class Login : Form
    {

        clsUser User = new clsUser();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (User.ValidateUser(txtUser.Text, txtPassword.Text))
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

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Username and Password cannot be empty!");
                return;
            }
            else if (User.ValidateUser(txtUser.Text, txtPassword.Text))
            {


                MessageBox.Show("User already exists!");
                return;


            }
            else
            {
                User.CreateUser(txtUser.Text, txtPassword.Text);
              MessageBox.Show("User created successfully!");
                txtUser.Clear();
                txtPassword.Clear();
            }
        }
    }
}

