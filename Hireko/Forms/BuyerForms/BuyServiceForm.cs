using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Hireko.Database;
using Hireko.Model;

namespace Hireko.Forms
{
    internal partial class BuyServiceForm : Form
    {
        private readonly AccountDB accountDB = new AccountDB();
        private readonly ServiceDB serviceDB = new ServiceDB();
        private readonly AdminDB adminDB = new AdminDB();
        private MainForm mainForm;

        public BuyServiceForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
            LoadServices();
            this.AutoScroll = true;

            // Populate the ComboBox with categories
            PopulateCategoriesComboBox();

            // Set pretext for the search textbox
            SetPretext(txtSearch, "Search for services here!");
            txtSearch.GotFocus += TxtSearch_GotFocus;
            txtSearch.LostFocus += TxtSearch_LostFocus;
        }

        private void SetPretext(TextBox textBox, string pretext)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.ForeColor = SystemColors.GrayText;
                textBox.Text = pretext;
            }
        }

        private void ClearPretext(TextBox textBox, string pretext)
        {
            if (textBox.Text == pretext && textBox.ForeColor == SystemColors.GrayText)
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.ControlText;
            }
        }

        private void TxtSearch_GotFocus(object sender, EventArgs e)
        {
            ClearPretext(txtSearch, "Search for services here!");
        }

        private void TxtSearch_LostFocus(object sender, EventArgs e)
        {
            SetPretext(txtSearch, "Search for services here!");
        }

        private void PopulateCategoriesComboBox()
        {
            List<string> categories = new List<string> { "All Category", "Consultation", "Landscaping and Housework", "Waste Management" };
            comboBox1.Items.AddRange(categories.ToArray());
            comboBox1.SelectedIndex = 0;
        }

        public void LoadServices()
        {
            panel1.Controls.Clear();

            var services = serviceDB.GetAllServices();

            services = services.Where(service =>
                    service.UserId != CurrentUser.UserId &&
                    service.ServiceStatus == "Approved").ToList();

            DisplayFilteredServices(services);
        }

        private void DisplayFilteredServices(List<Service> services)
        {
            panel1.Controls.Clear();

            if (services.Count == 0)
            {
                Label noServiceLabel = new Label
                {
                    Text = "No services match the criteria.",
                    Font = new Font("Bahnschrift", 9),
                    AutoSize = true,
                    Location = new Point(20, 20)
                };
                panel1.Controls.Add(noServiceLabel);
                panel1.Height = 100;
                return;
            }

            for (int i = 0; i < services.Count; i++)
            {
                CreateServicePanel(services[i], i);
            }

            int columns = (services.Count + 1) / 2; // Calculate number of columns needed
            panel1.Width = columns * 400 + 20; // Adjust panel width (400 = 380 panel width + 20 margin)
        }

        private void CreateServicePanel(Service service, int index)
        {
            Panel servicePanel = new Panel
            {
                BackColor = Color.FromArgb(243, 202, 82),
                Size = new Size(380, 130) // Fixed size of the panel
            };

            // Calculate the position based on index
            int panelsPerColumn = 2; // Number of panels per column
            int xOffset = 20; // X offset for the first column
            int yOffset = 20; // Y offset for the first row

            int xPos = (index / panelsPerColumn) * (servicePanel.Width + 20) + xOffset;
            int yPos = (index % panelsPerColumn) * (servicePanel.Height + 20) + yOffset;

            servicePanel.Location = new Point(xPos, yPos);

            // Create and add labels and button to the panel
            CreateServiceLabels(service, servicePanel);
            CreateHireButton(service, servicePanel);

            panel1.Controls.Add(servicePanel);
        }

        private void CreateServiceLabels(Service service, Panel parentPanel)
        {
            string[] labelsText = {
                $"Service: {service.ServiceName}",
                $"Name: {service.FreelancerName}",
                $"Price: {service.Price}",
                $"{service.ServiceDescription}"
            };

            Font[] labelFonts = {
                new Font("Bahnschrift", 10, FontStyle.Bold), // Font for Service Name
                new Font("Bahnschrift", 9),                   // Font for Name
                new Font("Bahnschrift", 9),                   // Font for Price
                new Font("Bahnschrift", 9)                    // Font for Description
            };

            for (int i = 0; i < labelsText.Length; i++)
            {
                Label label = new Label
                {
                    Text = labelsText[i],
                    Font = labelFonts[i],  // Set font
                    AutoSize = true,
                    Location = new Point(10, 10 + i * 20)
                };
                parentPanel.Controls.Add(label);
            }
        }

        private void CreateHireButton(Service service, Panel parentPanel)
        {
            Button button = new Button
            {
                Text = "Hire",
                Tag = service.ServiceId,
                Size = new Size(70, 30), // Set size of the button
                Location = new Point(parentPanel.Width - 80, parentPanel.Height - 40), // Align to lower right
                Font = new Font("Bahnschrift", 9),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            button.Click += BtnHire_Click;
            button.FlatAppearance.BorderSize = 0;
            parentPanel.Controls.Add(button);
        }

        private void BtnHire_Click(object sender, EventArgs e)
        {
            int serviceId = Convert.ToInt32((sender as Button).Tag);
            CurrentService.ServiceId = serviceId;
            ConfirmAndPerformAction("Buy", () => mainForm.ShowServiceDetails());
        }

        private void ConfirmAndPerformAction(string actionName, Action action)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to {actionName} this service?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                action.Invoke();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim(); // Get the search term from the text box
            string selectedCategory = comboBox1.Text; // Get the selected category from comboBox1

            var services = serviceDB.GetAllServices();

            if (!string.IsNullOrEmpty(searchTerm) && searchTerm != "Search for services here!")
            {
                services = services.Where(service =>
                    service.UserId != CurrentUser.UserId &&
                    service.ServiceStatus == "Approved" &&
                    (service.ServiceName.ToLower().Contains(searchTerm.ToLower()) ||
                    service.FreelancerName.ToLower().Contains(searchTerm.ToLower()))).ToList();
            }
            else
            {
                services = services.Where(service =>
                    service.UserId != CurrentUser.UserId &&
                    service.ServiceStatus == "Approved").ToList();
            }

            if (selectedCategory != "All Category")
            {
                services = services.Where(service => service.Category == selectedCategory).ToList();
            }

            DisplayFilteredServices(services);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = ""; // Clear the search term text box
            comboBox1.SelectedIndex = 0; // Reset the category selection to "All Category"
            LoadServices();
        }

        private void BuyServiceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
