
using Hireko.Database;
using Hireko.Model;
using System;
using System.Windows.Forms;

namespace Hireko.Forms
{
    internal partial class MainProfileForm : Form
    {
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private ViewBuyerOrdersForm viewBuyerOrdersForm;
        private ViewSellerOrdersForm viewSellerOrdersForm;
        private ViewSellerServicesForm viewSellerServicesForm;
        private ProfileForm profileForm;
        private EditProfileForm editProfileForm;
        private AccountDB accountDB;

        public MainProfileForm()
        {
            mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            mediaPlayer.CreateControl();
            mediaPlayer.Visible = false; // Hide the control from the UI
            mediaPlayer.settings.autoStart = false; // Do not start automatically
            InitializeComponent();
            profileForm = new ProfileForm();
            editProfileForm = new EditProfileForm(profileForm);
            SetUserButton();
            // Show the default form
            ShowForm(profileForm);
        }
        private void SetUserButton()
        {
            accountDB = new AccountDB();
            User userDetails = accountDB.GetUserDetails(CurrentUser.UserId);
            // Set visibility based on user type
            if (userDetails.UserType == "Seller")
            {
                label1.Visible = true; // Show "Seller Tools" label
                btnViewSellerOrders.Visible = true; // Show "Your Orders" button for seller
                btnViewSellerServices.Visible = true; // Show "Your Services" button for seller
            }
            else
            {
                label1.Visible = false; // Hide "Seller Tools" label for buyer
                btnViewSellerOrders.Visible = false; // Hide "Your Orders" button for buyer
                btnViewSellerServices.Visible = false; // Hide "Your Services" button for buyer
            }
        }
        private void PlayAudio(string filePath)
        {
            mediaPlayer.URL = filePath; // Set the file path
            mediaPlayer.Ctlcontrols.play(); // Start playback
        }

        private void ShowForm(Form form)
        {
            // Clear the panel before showing a new form
            panel2.Controls.Clear();

            // Set the form properties
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Add the form to the panel and show it
            panel2.Controls.Add(form);
            form.Show();
        }
        private void btnViewUserProfile_Click(object sender, EventArgs e)
        {
            PlayAudio(@"C:\Users\Vince Clyde\Downloads\final naaaa\Hireko\SFX\Log In.mp3");
            ShowForm(profileForm);
        }

        private void btnViewBuyerOrders_Click(object sender, EventArgs e)
        {
            PlayAudio(@"C:\Users\Vince Clyde\Downloads\final naaaa\Hireko\SFX\Log In.mp3");
            viewBuyerOrdersForm = new ViewBuyerOrdersForm();
            ShowForm(viewBuyerOrdersForm);

        }

        private void btnViewSellerOrders_Click(object sender, EventArgs e)
        {
            PlayAudio(@"C:\Users\Vince Clyde\Downloads\final naaaa\Hireko\SFX\Log In.mp3");
            viewSellerOrdersForm = new ViewSellerOrdersForm();
            ShowForm(viewSellerOrdersForm);
        }

        private void btnViewSellerServices_Click(object sender, EventArgs e)
        {
            PlayAudio(@"C:\Users\Vince Clyde\Downloads\final naaaa\Hireko\SFX\Log In.mp3");
            viewSellerServicesForm = new ViewSellerServicesForm();
            ShowForm(viewSellerServicesForm);
        }

        private void MainProfileForm_Load(object sender, EventArgs e)
        {
            PlayAudio(@"C:\Users\Vince Clyde\Downloads\final naaaa\Hireko\SFX\Log In.mp3");
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            PlayAudio(@"C:\Users\Vince Clyde\Downloads\final naaaa\Hireko\SFX\Log In.mp3");
            ShowForm(editProfileForm);
        }
    }
}
