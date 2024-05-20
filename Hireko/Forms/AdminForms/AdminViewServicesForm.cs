using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Hireko.Database;
using Hireko.Model;

namespace Hireko.Forms
{
    internal partial class AdminViewServicesForm : Form
    {
        private readonly ServiceDB serviceDB = new ServiceDB();
        private readonly AdminDB adminDB = new AdminDB();

        public AdminViewServicesForm()
        {
            InitializeComponent();
            LoadServices();
            this.AutoScroll = true;
        }

        private void LoadServices()
        {
            panel1.Controls.Clear();

            var services = serviceDB.GetAllServices();
            int panelWidth = 420;
            int panelHeight = 160;
            int columns = 2; // Two panels per row
            int spacing = 10; // Spacing between panels
            int yOffset = 20;
            int xOffset = 20;

            for (int i = 0; i < services.Count; i++)
            {
                Panel servicePanel = CreateServicePanel(services[i], xOffset, yOffset, panelWidth, panelHeight);
                panel1.Controls.Add(servicePanel);

                // Update xOffset and yOffset for the next panel
                if ((i + 1) % columns == 0)
                {
                    // Move to the next row
                    xOffset = 20;
                    yOffset += panelHeight + spacing;
                }
                else
                {
                    // Move to the next column in the same row
                    xOffset += panelWidth + spacing;
                }
            }

            // Adjust the panel height to fit all service panels
            panel1.Height = (services.Count / columns + (services.Count % columns > 0 ? 1 : 0)) * (panelHeight + spacing) + 20;
        }

        private Panel CreateServicePanel(Service service, int xOffset, int yOffset, int panelWidth, int panelHeight)
        {
            Panel servicePanel = new Panel
            {
                BackColor = Color.White,
                Size = new Size(panelWidth, panelHeight),
                Location = new Point(xOffset, yOffset)
            };

            CreateServiceLabels(service, servicePanel);
            CreateApproveButton(service, servicePanel);
            CreateDeleteButton(service, servicePanel, panelWidth, panelHeight); // Pass panelWidth and panelHeight to adjust button position

            return servicePanel;
        }

        private void CreateServiceLabels(Service service, Panel parentPanel)
        {
            string[] labelsText = {
                $"Service ID: {service.ServiceId}",
                $"User ID: {service.UserId}",
                $"Freelancer Name: {service.FreelancerName}",
                $"Service Name: {service.ServiceName}",
                $"Description: {service.ServiceDescription}"
            };

            for (int i = 0; i < labelsText.Length; i++)
            {
                Label label = new Label
                {
                    Text = labelsText[i],
                    AutoSize = true,
                    Font = new Font("Bahnschrift", 10),
                    Location = new Point(10, 10 + i * 20)
                };
                parentPanel.Controls.Add(label);
            }
        }

        private void CreateApproveButton(Service service, Panel parentPanel)
        {
            Button button = new Button
            {
                Font = new Font("Bahnschrift", 10),
                Location = new Point(205, 120), // Adjusted button position based on panel height
                Tag = service.ServiceId
            };
            button.AutoSize = true;
            if (service.ServiceStatus == "Approved")
            {
                button.Text = "Approved";
                button.Enabled = false;
            }
            else
            {
                button.Text = "Approve";
                button.Click += BtnApprove_Click;
            }

            parentPanel.Controls.Add(button);
        }

        private void CreateDeleteButton(Service service, Panel parentPanel, int panelWidth, int panelHeight)
        {
            Button button = new Button
            {
                Font = new Font("Bahnschrift", 10),
                Text = "Delete",
                Tag = service.ServiceId,
                Location = new Point(320, 120) // Adjusted button position based on panel width and height
            };
            button.AutoSize = true;
            button.Click += BtnDelete_Click;

            parentPanel.Controls.Add(button);
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            int serviceId = Convert.ToInt32((sender as Button).Tag);
            ConfirmAndPerformAction("Approve", () => adminDB.ApproveService(serviceId));
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int serviceId = Convert.ToInt32((sender as Button).Tag);
            ConfirmAndPerformAction("Delete", () => adminDB.DeleteService(serviceId));
        }

        private void ConfirmAndPerformAction(string actionName, Action action)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to {actionName} this service?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                action.Invoke();
                LoadServices();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim(); // Get the search term from the text box
            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Perform the search using the AccountDB
                var services = serviceDB.GetAllServices();

                services = services.Where(service =>
                    (service.ServiceId.ToString().Contains(searchTerm) ||
                    service.ServiceName.ToLower().Contains(searchTerm.ToLower()))).ToList();

                // Clear existing panels and reload the filtered users
                panel1.Controls.Clear();
                int panelWidth = 420;
                int panelHeight = 160;
                int columns = 2; // Two panels per row
                int spacing = 10; // Spacing between panels
                int yOffset = 20;
                int xOffset = 20;

                for (int i = 0; i < services.Count; i++)
                {
                    Panel servicePanel = CreateServicePanel(services[i], xOffset, yOffset, panelWidth, panelHeight);
                    panel1.Controls.Add(servicePanel);

                    // Update xOffset and yOffset for the next panel
                    if ((i + 1) % columns == 0)
                    {
                        // Move to the next row
                        xOffset = 20;
                        yOffset += panelHeight + spacing;
                    }
                    else
                    {
                        // Move to the next column in the same row
                        xOffset += panelWidth + spacing;
                    }
                }

                // Adjust the panel height to fit all service panels
                panel1.Height = (services.Count / columns + (services.Count % columns > 0 ? 1 : 0)) * (panelHeight + spacing) + 20;
            }
            else
            {
                // If the search term is empty, reload all users
                panel1.Controls.Clear();
                LoadServices();
            }
        }
    }
}
