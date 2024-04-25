using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Buyer_Page___Hireko
{
    public partial class Form1 : Form
    {
        private List<Service> servicesList;
        private DataGridView dataGridView;
        private TextBox searchTextBox;

        public Form1()
        {
            InitializeComponent();
            InitializeServices();
            InitializeUI(); // Call the InitializeUI method here to set up the UI
        }

        private void InitializeServices()
        {
            // Initialize your list of services
            servicesList = new List<Service>()
    {
        new Service("Recycling Bottles", "Recycling", 10), // Fixed category name
        new Service("Grass Cutting", "Farming", 20),
        new Service("Service 3", "Recycling", 30), // Fixed category name
        // Add more services as needed
    };
        }

        private void InitializeUI()
        {
            // Initialize searchTextBox
            TextBox searchTextBox = new TextBox();
            searchTextBox.Location = new System.Drawing.Point(10, 10);
            searchTextBox.Size = new System.Drawing.Size(200, 20);
            searchTextBox.TextChanged += SearchTextBox_TextChanged;
            this.Controls.Add(searchTextBox);

            ComboBox filterComboBox = new ComboBox();
            filterComboBox.Location = new System.Drawing.Point(250, 10);
            filterComboBox.Size = new System.Drawing.Size(150, 20);
            filterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            // Populate the filterComboBox with unique categories from servicesList
            filterComboBox.Items.Add("All"); // Add "All" option first
            foreach (Service service in servicesList)
            {
                if (!filterComboBox.Items.Contains(service.Category))
                {
                    filterComboBox.Items.Add(service.Category);
                }
            }
            filterComboBox.SelectedIndex = 0; // Select "All" by default
            filterComboBox.SelectedIndexChanged += FilterComboBox_SelectedIndexChanged;
            this.Controls.Add(filterComboBox);

            // Filter Label
            Label filterLabel = new Label();
            filterLabel.Text = "Filter:";
            filterLabel.Location = new System.Drawing.Point(210, 15);
            this.Controls.Add(filterLabel);

            int x = 10; // Initial x-coordinate for service blocks
            int y = 50; // Initial y-coordinate for service blocks
            int blockWidth = 100; // Width of each service block
            int blockHeight = 200; // Height of each service block
            int spacing = 10; // Spacing between service blocks

            foreach (Service service in servicesList)
            {
                Panel serviceBlock = new Panel();
                serviceBlock.Size = new System.Drawing.Size(blockWidth, blockHeight);
                serviceBlock.BorderStyle = BorderStyle.FixedSingle;
                serviceBlock.Location = new Point(x, y);

                // Display service information in the block
                Label nameLabel = new Label();
                nameLabel.Name = "serviceNameLabel"; // Assign a unique name
                nameLabel.Text = "Name: " + service.Name;
                nameLabel.Location = new System.Drawing.Point(10, 10);
                serviceBlock.Controls.Add(nameLabel);

                Label categoryLabel = new Label();
                categoryLabel.Name = "categoryLabel"; // Assign a unique name
                categoryLabel.Text = "Category: " + service.Category;
                categoryLabel.Location = new System.Drawing.Point(10, 30);
                serviceBlock.Controls.Add(categoryLabel);

                Label priceLabel = new Label();
                priceLabel.Text = "Price: $" + service.Price;
                priceLabel.Location = new System.Drawing.Point(10, 50);
                serviceBlock.Controls.Add(priceLabel);

                // Add Buy button to the service block
                Button buyButton = new Button();
                buyButton.Text = "Buy";
                buyButton.Tag = service; // Attach the service to the button for reference later
                buyButton.Location = new System.Drawing.Point(10, 70);
                buyButton.Click += BuyButton_Click;
                serviceBlock.Controls.Add(buyButton);

                this.Controls.Add(serviceBlock);

                // Adjust coordinates for the next service block
                x += blockWidth + spacing;
                if (x + blockWidth > this.ClientSize.Width) // Move to the next row if the next block exceeds the form width
                {
                    x = 10;
                    y += blockHeight + spacing;
                }
            }
        }






        private void BuyButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is Service service)
            {
                // Show service details form
                ServiceDetailsForm serviceDetailsForm = new ServiceDetailsForm(service);
                serviceDetailsForm.ShowDialog(); // Show the form as a dialog
            }
            else
            {
                MessageBox.Show("Please select a service to buy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            string searchText = searchTextBox.Text.ToLower();

            foreach (Control control in this.Controls)
            {
                if (control is Panel serviceBlock)
                {
                    // Find the labels inside the service block by name
                    Label nameLabel = serviceBlock.Controls["serviceNameLabel"] as Label;
                    Label categoryLabel = serviceBlock.Controls["categoryLabel"] as Label;

                    if (nameLabel != null && categoryLabel != null)
                    {
                        string serviceName = nameLabel.Text.ToLower();
                        string category = categoryLabel.Text.ToLower();

                        // Check if either the name or category contains the search text
                        bool nameMatch = serviceName.Contains(searchText);
                        bool categoryMatch = category.Contains(searchText);

                        // Show or hide the panel based on the search results
                        serviceBlock.Visible = nameMatch || categoryMatch;
                    }
                }
            }
        }



        private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox filterComboBox = sender as ComboBox;
            string selectedCategory = filterComboBox.SelectedItem.ToString();

            foreach (Control control in this.Controls)
            {
                if (control is Panel serviceBlock)
                {
                    Label categoryLabel = serviceBlock.Controls["categoryLabel"] as Label;

                    if (categoryLabel != null)
                    {
                        string category = categoryLabel.Text.ToLower();

                        // Check if the service category matches the selected category or if "All" is selected
                        bool categoryMatch = selectedCategory.Equals("All", StringComparison.OrdinalIgnoreCase) || category.Equals(selectedCategory, StringComparison.OrdinalIgnoreCase);

                        // Show or hide the panel based on the filter results
                        serviceBlock.Visible = categoryMatch;
                    }
                }
            }
        }




    }
}
