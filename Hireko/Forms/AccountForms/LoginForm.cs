using System;
using System.Windows.Forms;
using Hireko.Database;
using Hireko.Model;

namespace Hireko.Forms
{
    internal partial class LoginForm : BaseForm
    {
        private AccountDB accountDB;

        public LoginForm(HirekoForm form) : base(form)
        {
            InitializeComponent();
            accountDB = new AccountDB();
            btnLogin.Click += BtnLogin_Click;
            linkRegister.LinkClicked += LinkRegister_LinkClicked;
            txtUserPass.UseSystemPasswordChar = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtUserPass.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtUserPass.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowError("Please fill in both fields.");
                return;
            }

            if (accountDB.IsAdmin(username, password))
            {
                CurrentUser.Username = username;
                PlayAudio("Log In.mp3");
                base.ShowForm(new MainAdminForm(hirekoForm));
            }
            else
            {
                int userId = accountDB.Login(username, password);
                if (userId > 0)
                {
                    PlayAudio("Log In.mp3");
                    CurrentUser.UserId = userId;
                    CurrentUser.Username = username;
                    base.ShowForm(new MainForm(hirekoForm));
                }
                else
                {
                    ShowError("Invalid username or password!");
                }
            }
        }

        private void ShowError(string message)
        {
            textBox1.Text = message;
            PlayAudio("Error.mp3");
        }

        private void LinkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.ShowForm(new RegisterForm(hirekoForm));
        }
    }
}
