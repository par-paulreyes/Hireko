using System;
using System.Windows.Forms;
using Hireko.Database;
using Hireko.Model;

namespace Hireko.Forms
{
    internal partial class AdminDashboardForm : Form
    {
        private AdminDB adminDB;

        public AdminDashboardForm()
        {
            InitializeComponent();
            adminDB = new AdminDB();
            UpdateDashboard();
        }

        private void UpdateDashboard()
        {
            AdminDashboardTotals totals = adminDB.GetAdminDashboardTotals();
            if (totals.TotalApprovedServices == 0)
            {
                textBox4.Enabled = false;
            }
            if (totals.TotalPendingServices == 0)
            {
                textBox5.Enabled = false;
            }

            textBox1.Text = $"Total Income: {totals.TotalIncome.ToString("C")}";
            textBox3.Text = $"{totals.TotalUsers} Users";
            textBox2.Text = $"{totals.TotalServices} Services";
            textBox4.Text = $"{totals.TotalApprovedServices} Approved Services";
            textBox5.Text = $"{totals.TotalPendingServices} Pending Services";
            textBox6.Text = $"{totals.TotalOrders} Total Orders";
        }
    }
}
