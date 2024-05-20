using System;
using System.Drawing;
using System.Windows.Forms;
using Hireko.Database;
using Hireko.Model;
using static System.Net.Mime.MediaTypeNames;

namespace Hireko.Forms
{
    internal partial class EditProfileForm : Form
    {
        private AccountDB accountDB;
        private ProfileForm profileForm;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;

        // Placeholder texts
        private const string PlaceholderFName = "First Name";
        private const string PlaceholderLName = "Last Name";
        private const string PlaceholderEmail = "Email";
        private const string PlaceholderAddress = "Address";
        private const string PlaceholderPhone = "Phone Number";

        public EditProfileForm(ProfileForm form)
        {
            profileForm = form;
            InitializeComponent();
            accountDB = new AccountDB();
            InitializeTextBoxPlaceholders();
            DisplayUserInfo();
            InitializeMediaPlayer();
        }

        private void InitializeMediaPlayer()
        {
            mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            mediaPlayer.CreateControl();
            mediaPlayer.Visible = false;
            mediaPlayer.settings.autoStart = false;
            Controls.Add(mediaPlayer);
        }

        protected void PlayAudio(string filePath)
        {
            mediaPlayer.URL = filePath;
            mediaPlayer.Ctlcontrols.play();
        }

        private void DisplayUserInfo()
        {
            // Retrieve user details from the database using AccountDB
            User userDetails = accountDB.GetUserDetails(CurrentUser.UserId);

        }

        private void InitializeTextBoxPlaceholders()
        {
            InitializeTextBoxPlaceholder(txtUserFName, PlaceholderFName);
            InitializeTextBoxPlaceholder(txtUserLName, PlaceholderLName);
            InitializeTextBoxPlaceholder(txtUserEmail, PlaceholderEmail);
            InitializeTextBoxPlaceholder(txtUserAddress, PlaceholderAddress);
            InitializeTextBoxPlaceholder(txtUserPhone, PlaceholderPhone);
        }

        private void InitializeTextBoxPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    User userDetails = accountDB.GetUserDetails(CurrentUser.UserId);

                    txtUserLName.Text = userDetails.UserLName;
                    txtUserFName.Text = userDetails.UserFName;
                    txtUserEmail.Text = userDetails.UserEmail;
                    txtUserAddress.Text = userDetails.UserAddress;
                    txtUserPhone.Text = userDetails.UserPhone;
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void SetTextBoxText(TextBox textBox, string text, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
            }
            else
            {
                textBox.Text = text;
                textBox.ForeColor = Color.Black;
            }
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            // Update user information in the database
            string userFName = txtUserFName.Text == PlaceholderFName ? "" : txtUserFName.Text;
            string userLName = txtUserLName.Text == PlaceholderLName ? "" : txtUserLName.Text;
            string userEmail = txtUserEmail.Text == PlaceholderEmail ? "" : txtUserEmail.Text;
            string userAddress = txtUserAddress.Text == PlaceholderAddress ? "" : txtUserAddress.Text;
            string userPhone = txtUserPhone.Text == PlaceholderPhone ? "" : txtUserPhone.Text;

            User updatedUser = new User
            {
                UserId = CurrentUser.UserId, // Make sure to include the UserId for the update
                UserFName = userFName,
                UserLName = userLName,
                UserEmail = userEmail,
                UserAddress = userAddress,
                UserPhone = userPhone
            };

            bool success = accountDB.UpdateUserDetails(updatedUser);

            if (success)
            {

                PlayAudio(@"C:\Users\Vince Clyde\Downloads\final naaaa\Hireko\SFX\ServiceCreated.mp3");
                profileForm.DisplayUserInfo();
            }
            else
            {
                MessageBox.Show("Failed to update profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}