using Google.Protobuf.WellKnownTypes;
using Hireko.Database;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hireko.Forms
{
    public partial class CreateServiceForm : Form
    {
        private ServiceDB serviceDB;
        public CreateServiceForm()
        {
            InitializeComponent();
            LoadComboBoxes();
            serviceDB = new ServiceDB();
        }

        private void btnCreateService_Click(object sender, EventArgs e)
        {
            string service = txtService.Text;
            string category = cmbCategory.Text;
            string occupation = cmbOccupation.Text;
            string description = txtDescription.Text;
            string experience = cmbExperience.Text;
            string education = cmbEducation.Text;
            decimal price;

            if (!ValidateComboBoxItem(cmbCategory, category) ||
                !ValidateComboBoxItem(cmbOccupation, occupation) ||
                !ValidateComboBoxItem(cmbExperience, experience) ||
                !ValidateComboBoxItem(cmbEducation, education))
            {
                MessageBox.Show("Please select a valid option from the dropdown list.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Invalid price format. Please enter a valid price.");
                return;
            }

            int ServiceId = serviceDB.CreateService(service, category, occupation, description, experience, education, price);

            if (ServiceId != -1)
            {
                MessageBox.Show("Service created successfully");
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to create service. Please try again.");
            }
        }

        private void LoadComboBoxes()
        {
            // Populate combo boxes with example data
            cmbCategory.Items.AddRange(new string[] { "Category 1", "Category 2", "Category 3" });
            cmbExperience.Items.AddRange(new string[] { "Entry Level", "Intermediate", "Advanced" });
            cmbEducation.Items.AddRange(new string[] { "High School", "Bachelor's Degree", "Master's Degree", "PhD" });
        }

        private void ClearForm()
        {
            cmbCategory.SelectedIndex = -1;
            cmbOccupation.SelectedIndex = -1;
            txtDescription.Clear();
            cmbExperience.SelectedIndex = -1;
            cmbEducation.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private bool ValidateComboBoxItem(ComboBox comboBox, string value)
        {
            return comboBox.Items.Contains(value);
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Here you can dynamically update cboOccupation based on the selected category
            string selectedCategory = cmbCategory.Text;

            // Example logic: Populate cboOccupation based on selectedCategory
            if (selectedCategory == "Category 1")
            {
                cmbOccupation.Items.Clear();
                cmbOccupation.Items.AddRange(new string[] { "Occupation A", "Occupation B", "Occupation C" });
            }
            else if (selectedCategory == "Category 2")
            {
                cmbOccupation.Items.Clear();
                cmbOccupation.Items.AddRange(new string[] { "Occupation X", "Occupation Y", "Occupation Z" });
            }
            else if (selectedCategory == "Category 3")
            {
                cmbOccupation.Items.Clear();
                cmbOccupation.Items.AddRange(new string[] { "Occupation I", "Occupation J", "Occupation K" });
            }
            // Add more conditions as needed for other categories
        }
    }
}
