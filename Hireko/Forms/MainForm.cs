using System;
using System.Windows.Forms;
using Hireko.Database;

namespace Hireko.Forms
{
    public partial class MainForm : Form
    {
        private MainBuyerForm mainBuyerForm;
        private MainServiceForm mainServiceForm;
        private MainProfileForm mainProfileForm;
        private AccountDB accountDB;

        public MainForm()
        {
            InitializeComponent();
            mainBuyerForm = new MainBuyerForm();
            mainServiceForm = new MainServiceForm();
            mainProfileForm = new MainProfileForm();
            accountDB = new AccountDB();
            label1.Text = User.GetCurrentUser();
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

        private void bntHome_Click(object sender, EventArgs e)
        {
            ShowForm(mainBuyerForm);
        }

        private void bntCreateService_Click(object sender, EventArgs e)
        {
            ShowForm(mainServiceForm);
        }

        private void bntProfile_Click(object sender, EventArgs e)
        {
            ShowForm(mainProfileForm);
        }
    }
}
