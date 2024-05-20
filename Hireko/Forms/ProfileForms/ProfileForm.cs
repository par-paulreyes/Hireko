using System;
using System.Drawing;
using System.Windows.Forms;
using Hireko.Database;
using Hireko.Model;

namespace Hireko.Forms
{
    internal partial class ProfileForm : Form
    {
        private AccountDB accountDB;

        public ProfileForm()
        {
            InitializeComponent();
            accountDB = new AccountDB();
            DisplayUserInfo();
        }

        public void DisplayUserInfo()
        {
            // Retrieve user details from the database using AccountDB
            User userDetails = accountDB.GetUserDetails(CurrentUser.UserId);

            // Display user information in labels
            lblUserIdValue.Text = $"{userDetails.UserId}";
            lblUserFullNameValue.Text = $"{userDetails.UserFName}  {userDetails.UserLName}";
            lblUserEmailValue.Text = $"{userDetails.UserEmail}";
            lblUserAddressValue.Text = $"{userDetails.UserAddress}";
            lblUserPhoneValue.Text = $"{userDetails.UserPhone}";

            textBox1.Text = $"{userDetails.Username}";
        }

    }
}

       
