using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Hireko.Database;
using Hireko.Model;

namespace Hireko.Forms
{
    internal partial class ViewSellerServicesForm : Form
    {
        public ViewSellerServicesForm()
        {
            InitializeComponent();
            LoadServices();
            this.AutoScroll = true;
        }

        private void LoadServices()
        {
            // Retrieve services from the database
            ServiceDB serviceDB = new ServiceDB();
            int currentUserId = CurrentUser.UserId;
            var services = serviceDB.GetSellerServices(currentUserId);

            // Clear existing controls from the form
            Controls.Clear();

            // Check if the user has services
            bool userHasServices = services.Count > 0;

            // Create panels for each service and add labels and buttons to them
            int yOffset = 20;
            foreach (var service in services)
            {
                // Create a panel for each service
                Panel servicePanel = new Panel();
                servicePanel.BackColor = Color.White;
                servicePanel.BorderStyle = BorderStyle.FixedSingle;
                servicePanel.Size = new System.Drawing.Size(510, 250);
                servicePanel.Location = new System.Drawing.Point(10, yOffset);

                // Create labels for each property of ServiceInfo and add them to the panel
                Label lblServiceId = CreateLabel($"Service ID: {service.ServiceId}", 10, 10);
                Label lblService = CreateLabel($"Service Name: {service.ServiceName}", 10, 40);
                Label lblCategory = CreateLabel($"Category: {service.Category}", 10, 70);
                Label lblOccupation = CreateLabel($"Occupation: {service.Occupation}", 10, 100);
                Label lblDescription = CreateLabel($"Description: {service.ServiceDescription}", 10, 130);
                Label lblExperienceLevel = CreateLabel($"Experience Level: {service.ExperienceLevel}", 10, 160);
                Label lblEducationalBackground = CreateLabel($"Educational Background: {service.EducationalBackground}", 10, 190);
                Label lblPrice = CreateLabel($"Price: {service.Price}", 10, 220);
                Label lblServiceStatus = CreateLabel($"Service Status: {service.ServiceStatus}", 10, 250);
                Button btnRemoveService = CreateRemoveButton(service.ServiceId, 400, 10, userHasServices); // Pass 'userHasServices' bool
                servicePanel.Controls.Add(lblServiceId);
                servicePanel.Controls.Add(lblService);
                servicePanel.Controls.Add(lblCategory);
                servicePanel.Controls.Add(lblOccupation);
                servicePanel.Controls.Add(lblDescription);
                servicePanel.Controls.Add(lblExperienceLevel);
                servicePanel.Controls.Add(lblEducationalBackground);
                servicePanel.Controls.Add(lblPrice);
                servicePanel.Controls.Add(lblServiceStatus);
                servicePanel.Controls.Add(btnRemoveService);

                // Add the panel to the form
                Controls.Add(servicePanel);

                yOffset += 270; // Increase vertical spacing between panels
            }
        }

        private Label CreateLabel(string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font("Bahnschrift", 10);
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(x, y);
            return label;
        }

        private Button CreateRemoveButton(int serviceId, int x, int y, bool userHasServices)
        {
            Button button = new Button();
            button.Text = "Remove";
            button.Font = new Font("Bahnschrift", 9);
            button.BackColor = Color.White;
            button.Size = new Size(90, 30);
            button.Location = new System.Drawing.Point(x, y);

            // Disable the remove button if the user has no services
            if (!userHasServices)
            {
                button.Enabled = false;
            }
            else
            {
                button.Click += (sender, e) => RemoveService(serviceId);
            }

            return button;
        }

        private void RemoveService(int serviceId)
        {
            // Prompt user for confirmation
            DialogResult result = MessageBox.Show("Are you sure you want to remove this service?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Remove the service from the database
                ServiceDB serviceDB = new ServiceDB();
                serviceDB.RemoveService(serviceId);

                // Reload the form
                LoadServices();
            }
        }
    }
}
