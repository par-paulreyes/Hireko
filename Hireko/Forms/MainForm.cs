using System;
using System.Windows.Forms;
using Hireko.Database;

namespace Hireko.Forms
{
    public partial class MainForm : Form
    {
        private MainBuyerForm mainBuyerForm;
        private CreateServiceForm createServiceForm;
        private MainProfileForm mainProfileForm;

        public MainForm()
        {
            InitializeComponent();
            mainBuyerForm = new MainBuyerForm();
            createServiceForm = new CreateServiceForm();
            mainProfileForm = new MainProfileForm();
            label1.Text = User.CurrentUser;
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
            ShowForm(createServiceForm);
            
        }

        private void bntProfile_Click(object sender, EventArgs e)
        {
            ShowForm(mainProfileForm);
        }
    }
}
