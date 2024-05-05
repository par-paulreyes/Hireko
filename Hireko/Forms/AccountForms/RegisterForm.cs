using System;
using System.Windows.Forms;
using Hireko.Database;

namespace Hireko.Forms
{
    public partial class RegisterForm : Form
    {
        private AccountDB accountDB;

        public RegisterForm()
        {
            InitializeComponent();
            accountDB = new AccountDB();
            bntRegister.Click += BtnRegister_Click;
            linkLogin.LinkClicked += LinkLogin_LinkClicked;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmedPassword = txtConfirmedPass.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;

            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmedPassword) ||
                string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            if (password != confirmedPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return;
            }

            int userId = accountDB.Register(username, password, firstName, lastName, email, address, phone);

            if (userId > 0)
            {
                MessageBox.Show("Registration successful!");
            }
            else if (userId == -1)
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }

        private void LinkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
