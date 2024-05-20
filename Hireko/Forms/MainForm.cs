using System;
using System.Windows.Forms;
using Hireko.Model;

namespace Hireko.Forms
{
    internal partial class MainForm : BaseForm
    {
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private BuyServiceForm mainBuyerForm;
        private CreateServiceForm createServiceForm;
        private MainProfileForm mainProfileForm;
        private ServiceDetailsForm serviceDetailsForm;

        public MainForm(HirekoForm form) : base(form)
        {
            mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            mediaPlayer.CreateControl();
            mediaPlayer.Visible = false; // Hide the control from the UI
            mediaPlayer.settings.autoStart = false; // Do not start automatically
            InitializeComponent();
            mainBuyerForm = new BuyServiceForm(this);
            bntProfile.AutoSize = true;
            bntProfile.Text = "Profile";
            // Show the default form
            ShowForm(mainBuyerForm);
        }

        private void ShowForm(Form form)
        {
            // Clear the panel before showing a new form
            panel.Controls.Clear();

            // Set the form properties
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Add the form to the panel and show it
            panel.Controls.Add(form);
            form.Show();
        }

        public void ShowBuyServiceForm()
        {
            mainBuyerForm = new BuyServiceForm(this);
            ShowForm(mainBuyerForm);
        }
        public void ShowServiceDetails()
        {
            serviceDetailsForm = new ServiceDetailsForm(this);
            ShowForm(serviceDetailsForm);
        }
        private void bntHome_Click(object sender, EventArgs e)
        {
            PlayAudio("Log In.mp3");
            mainBuyerForm = new BuyServiceForm(this);
            ShowForm(mainBuyerForm);
        }

        private void bntCreateService_Click(object sender, EventArgs e)
        {
            PlayAudio("Log In.mp3");
            createServiceForm = new CreateServiceForm();
            ShowForm(createServiceForm);
        }

        private void bntProfile_Click(object sender, EventArgs e)
        {
            PlayAudio("Log In.mp3");
            mainProfileForm = new MainProfileForm();
            ShowForm(mainProfileForm);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                PlayAudio("Log In.mp3");
                base.ShowForm(new LoginForm(hirekoForm));
            }
        }
    }
}
