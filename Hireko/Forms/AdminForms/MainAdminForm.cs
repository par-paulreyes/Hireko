using System;
using System.Windows.Forms;

namespace Hireko.Forms
{
    internal partial class MainAdminForm : BaseForm
    {
        private AdminViewServicesForm adminViewServicesForm;
        private AdminViewUsersForm adminViewUsersForm;
        private AdminViewOrderForm adminViewOrderForm;
        private AdminDashboardForm adminDashboardForm;

        public MainAdminForm(HirekoForm form) : base(form)
        {
            InitializeComponent();
            adminDashboardForm = new AdminDashboardForm();
            ShowForm(adminDashboardForm);

            btnServices.Click += ButtonServices_Click;
            btnUsers.Click += ButtonUsers_Click;
            btnOrders.Click += ButtonOrders_Click;
            btnDashboard.Click += ButtonDashboard_Click;
            btnLogout.Click += ButtonLogout_Click;
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

        private void ButtonServices_Click(object sender, EventArgs e)
        {
            PlayAudio("Log In.mp3");
            adminViewServicesForm = new AdminViewServicesForm();
            ShowForm(adminViewServicesForm);
        }

        private void ButtonUsers_Click(object sender, EventArgs e)
        {
            PlayAudio("Log In.mp3");
            adminViewUsersForm = new AdminViewUsersForm();
            ShowForm(adminViewUsersForm);
        }

        private void ButtonOrders_Click(object sender, EventArgs e)
        {
            PlayAudio("Log In.mp3");
            adminViewOrderForm = new AdminViewOrderForm();
            ShowForm(adminViewOrderForm);
        }

        private void ButtonDashboard_Click(object sender, EventArgs e)
        {
            PlayAudio("Log In.mp3");
            ShowForm(adminDashboardForm);
        }

        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                PlayAudio("Log Out.mp3");
                base.ShowForm(new LoginForm(hirekoForm));
            }
        }
    }
}
