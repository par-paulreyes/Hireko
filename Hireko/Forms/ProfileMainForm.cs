using Hireko.Database;
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
    public partial class ProfileMainForm : Form
    {
        private string connectionString = DatabaseInitializer.GetConnectionString();

        private EditProfileForm editProfileForm;
        private ProfileForm profileMainForm;
        private ShowBuyerOrderForm showBuyerOrderForm;
        private ShowSellerOrderForm showSellerOrderForm;
        private ShowSellerServiceForm showSellerServiceForm;

        public ProfileMainForm()
        {
            InitializeComponent();

            // Initialize instances of the forms
            editProfileForm = new EditProfileForm();
            profileMainForm = new ProfileForm();
            showBuyerOrderForm = new ShowBuyerOrderForm();
            showSellerOrderForm = new ShowSellerOrderForm();
            showSellerServiceForm = new ShowSellerServiceForm();

            // Set the forms' TopLevel property to false
            editProfileForm.TopLevel = false;
            profileMainForm.TopLevel = false;
            showBuyerOrderForm.TopLevel = false;
            showSellerOrderForm.TopLevel = false;
            showSellerServiceForm.TopLevel = false;

            // Set the forms' Parent to the panel
            panel1.Controls.Add(editProfileForm);
            panel1.Controls.Add(profileMainForm);
            panel1.Controls.Add(showBuyerOrderForm);
            panel1.Controls.Add(showSellerOrderForm);
            panel1.Controls.Add(showSellerServiceForm);
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            // Show EditProfileForm in the panel
            editProfileForm.BringToFront();
            editProfileForm.Show();
        }

        private void btnBuyerOrder_Click(object sender, EventArgs e)
        {
            // Show ShowBuyerOrderForm sa panel
            showBuyerOrderForm.BringToFront();
            showBuyerOrderForm.Show();
        }

        private void btnSellerOrder_Click(object sender, EventArgs e)
        {
            // Show ShowSellerOrderForm sa panel
            showSellerOrderForm.BringToFront();
            showSellerOrderForm.Show();
        }

        private void btnSellerService_Click(object sender, EventArgs e)
        {
            // show ShowSellerServiceFOrm sa panel
            showSellerServiceForm.BringToFront();
            showSellerServiceForm.Show();
        }
    }
}
