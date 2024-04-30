using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Hireko.Models;
using Hireko.Database;

namespace Hireko.Forms
{
    public partial class CreateServiceForm : Form
    {
        private string connectionString = DatabaseInitializer.GetConnectionString();

        public CreateServiceForm()
        {
            InitializeComponent();
            LoadComboBoxes(); // Populate combo boxes with examples
        }

        private void bntCreateService_Click(object sender, EventArgs e)
        {
            // Read input values
            string freelancerName = txtFreelancerName.Text;
            string service = txtService.Text;
            string category = cboCategory.Text;
            string occupation = cboOccupation.Text;
            string description = txtDescription.Text;
            string experienceLevel = cboExperienceLevel.Text;
            string educationalBackground = cboEducationalBackground.Text;
            decimal price;

            // Validate inputs against combo box items
            if (!ValidateComboBoxItem(cboCategory, category) ||
                !ValidateComboBoxItem(cboOccupation, occupation) ||
                !ValidateComboBoxItem(cboExperienceLevel, experienceLevel) ||
                !ValidateComboBoxItem(cboEducationalBackground, educationalBackground))
            {
                MessageBox.Show("Please select a valid option from the dropdown list.");
                return;
            }

            // Validate price format
            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Invalid price format. Please enter a valid price.");
                return;
            }

            // Create a new Service instance
            Service newService = new Service
            {
                FreelancerName = freelancerName,
                ServiceName = service,
                Category = category,
                Occupation = occupation,
                Description = description,
                ExperienceLevel = experienceLevel,
                EducationalBackground = educationalBackground,
                Price = price
            };

            // Save the service to the database
            if (SaveServiceToDatabase(newService))
            {
                MessageBox.Show("Service created successfully!");
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to create service. Please try again.");
            }
        }

        private bool SaveServiceToDatabase(Service service)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Services (FreelancerName, Service, Category, Occupation, Description, ExperienceLevel, EducationalBackground, Price) 
                                 VALUES (@FreelancerName, @Service, @Category, @Occupation, @Description, @ExperienceLevel, @EducationalBackground, @Price)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FreelancerName", service.FreelancerName);
                command.Parameters.AddWithValue("@Service", service.ServiceName);
                command.Parameters.AddWithValue("@Category", service.Category);
                command.Parameters.AddWithValue("@Occupation", service.Occupation);
                command.Parameters.AddWithValue("@Description", service.Description);
                command.Parameters.AddWithValue("@ExperienceLevel", service.ExperienceLevel);
                command.Parameters.AddWithValue("@EducationalBackground", service.EducationalBackground);
                command.Parameters.AddWithValue("@Price", service.Price);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void LoadComboBoxes()
        {
            // Populate combo boxes with example data
            cboCategory.Items.AddRange(new string[] { "Category 1", "Category 2", "Category 3" });
            cboExperienceLevel.Items.AddRange(new string[] { "Entry Level", "Intermediate", "Advanced" });
            cboEducationalBackground.Items.AddRange(new string[] { "High School", "Bachelor's Degree", "Master's Degree", "PhD" });
        }

        private void ClearForm()
        {
            cboCategory.SelectedIndex = -1;
            cboOccupation.SelectedIndex = -1;
            txtDescription.Clear();
            cboExperienceLevel.SelectedIndex = -1;
            cboEducationalBackground.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private bool ValidateComboBoxItem(ComboBox comboBox, string value)
        {
            return comboBox.Items.Contains(value);
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Here you can dynamically update cboOccupation based on the selected category
            string selectedCategory = cboCategory.Text;

            // Example logic: Populate cboOccupation based on selectedCategory
            if (selectedCategory == "Category 1")
            {
                cboOccupation.Items.Clear();
                cboOccupation.Items.AddRange(new string[] { "Occupation A", "Occupation B", "Occupation C" });
            }
            else if (selectedCategory == "Category 2")
            {
                cboOccupation.Items.Clear();
                cboOccupation.Items.AddRange(new string[] { "Occupation X", "Occupation Y", "Occupation Z" });
            }
            else if (selectedCategory == "Category 3")
            {
                cboOccupation.Items.Clear();
                cboOccupation.Items.AddRange(new string[] { "Occupation I", "Occupation J", "Occupation K" });
            }
            // Add more conditions as needed for other categories
        }
    }
}
