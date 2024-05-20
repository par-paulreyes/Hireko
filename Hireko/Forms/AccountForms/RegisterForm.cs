using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Hireko.Database;

namespace Hireko.Forms
{
    internal partial class RegisterForm : BaseForm
    {
        private AccountDB accountDB;
        private TermsAndConditionsForm termsForm;

        public RegisterForm(HirekoForm form) : base(form)
        {
            InitializeComponent();
            accountDB = new AccountDB();
            bntRegister.Click += BtnRegister_Click;
            linkLogin.LinkClicked += LinkLogin_LinkClicked;
            linkTerms.LinkClicked += LinkTerms_LinkClicked;
            bntRegister.Enabled = checkBoxAgree.Checked;
            checkBoxAgree.CheckedChanged += CheckBoxAgree_CheckedChanged;

            SetPretext(txtUsername, "Username");
            SetPretext(txtPassword, "Password");
            SetPretext(txtConfirmedPass, "Confirm Password");
            SetPretext(txtFirstName, "First Name");
            SetPretext(txtLastName, "Last Name");
            SetPretext(txtEmail, "Email");
            SetPretext(txtAddress, "Address");
            SetPretext(txtPhone, "Phone Number");

            label3.Text = "";
        }

        private void SetPretext(TextBox textBox, string pretext)
        {
            textBox.Text = pretext;
            textBox.Tag = pretext;
            textBox.ForeColor = Color.FromArgb(192, 192, 192);
            textBox.GotFocus += TextBox_GotFocus;
            textBox.LostFocus += TextBox_LostFocus;
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.ForeColor = Color.FromArgb(192, 192, 192);
            }
        }

        private void CheckBoxAgree_CheckedChanged(object sender, EventArgs e)
        {
            bntRegister.Enabled = checkBoxAgree.Checked;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (!checkBoxAgree.Checked)
            {
                MessageBox.Show("Please agree to the terms and conditions before registering.");
                return;
            }

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
                PlayAudio("Error.mp3");
                label3.Text = "Please fill in all the fields.";
                return;
            }
            if (password != confirmedPassword)
            {
                PlayAudio("Error.mp3");
                label3.Text = "Passwords do not match.";
                return;
            }
            if (!IsValidUsername(username))
            {
                PlayAudio("Error.mp3");
                label3.Text = "Username should contain\nonly letters, numbers,\nunderscores, and be between\n3 to 20 characters long.";
                return;
            }

            if (!IsValidEmail(email))
            {
                PlayAudio("Error.mp3");
                label3.Text = "Invalid E-mail address.";
                return;
            }

            if (!IsValidPhoneNumber(phone))
            {
                PlayAudio("Error.mp3");
                label3.Text = "Invalid Phone Number.";
                return;
            }

            if (accountDB.UsernameExists(username))
            {
                PlayAudio("Error.mp3");
                label3.Text = "Username is already taken.";
                return;
            }

            accountDB.Register(username, password, firstName, lastName, email, address, phone);
            label3.Text = "";
            PlayAudio("Register.mp3");
            base.ShowForm(new LoginForm(hirekoForm));
        }

        private bool IsValidUsername(string username)
        {
            var regex = new Regex("^[a-zA-Z0-9_]{3,20}$");
            return regex.IsMatch(username);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phone)
        {
            var regex = new Regex(@"^[0-9]+$");
            return regex.IsMatch(phone);
        }

        private void LinkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.ShowForm(new LoginForm(hirekoForm));
        }

        private void LinkTerms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            termsForm = new TermsAndConditionsForm();
            termsForm.ShowDialog();
        }
    }
}
