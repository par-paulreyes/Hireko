using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hireko.Forms
{
    public partial class MainForm : Form
    {
        private BuyServiceForm buyServiceForm;
        private CreateServiceForm createServiceForm;
        private ProfileMainForm profileForm;
        public MainForm(string username)
        {
            InitializeComponent();
            // Initialize instances of the forms
            buyServiceForm = new BuyServiceForm();
            createServiceForm = new CreateServiceForm();
            profileForm = new ProfileMainForm(username);

            // Set the forms' TopLevel property to false
            buyServiceForm.TopLevel = false;
            createServiceForm.TopLevel = false;
            profileForm.TopLevel = false;

            // Set the forms' Parent to the panel
            panel.Controls.Add(buyServiceForm);
            panel.Controls.Add(createServiceForm);
            panel.Controls.Add(profileForm);

        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bntHome_Click(object sender, EventArgs e)
        {
            // Show BuyServiceForm in the panel
            buyServiceForm.BringToFront();
            buyServiceForm.Show();
        }

        private void bntCreateService_Click(object sender, EventArgs e)
        {
            // Show CreateServiceForm in the panel
            createServiceForm.BringToFront();
            createServiceForm.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            // Show ProfileForm in the panel
            profileForm.BringToFront();
            profileForm.Show();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}