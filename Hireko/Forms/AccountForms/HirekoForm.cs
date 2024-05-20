


using System;
using System.Windows.Forms;

namespace Hireko.Forms
{
    internal partial class HirekoForm : Form
    {
        private LoginForm loginForm;

        public HirekoForm()
        {
            InitializeComponent();
            loginForm = new LoginForm(this);
            ShowForm(loginForm);
        }


        public void ShowForm(Form form)
        {
            panel.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel.Controls.Add(form);
            form.Show();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        
    }
}
