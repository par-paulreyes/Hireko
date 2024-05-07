using System;
using System.Windows.Forms;
using Hireko.Database;

namespace Hireko.Forms
{
    public partial class LoginForm : Form
    {
        private AccountDB accountDB;

        public LoginForm()
        {
            InitializeComponent();
            accountDB = new AccountDB();
            btnLogin.Click += BtnLogin_Click;
            linkRegister.LinkClicked += LinkRegister_LinkClicked;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtUserPass.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            int userId = accountDB.Login(username, password);

            if (userId > 0)
            {
                User.CurrentUserId = userId;
                User.CurrentUser = username;
                MessageBox.Show("Login successful!");
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private void LinkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
    }
}
