using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Hireko.Database; // Assuming DatabaseInitializer is in this namespace

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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Services (FreelancerName, Service, Category, Occupation, Description, ExperienceLevel, EducationalBackground, Price) 
                                 VALUES (@FreelancerName, @Service, @Category, @Occupation, @Description, @ExperienceLevel, @EducationalBackground, @Price)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FreelancerName", freelancerName);
                command.Parameters.AddWithValue("@Service", service);
                command.Parameters.AddWithValue("@Category", category);
                command.Parameters.AddWithValue("@Occupation", occupation);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@ExperienceLevel", experienceLevel);
                command.Parameters.AddWithValue("@EducationalBackground", educationalBackground);
                command.Parameters.AddWithValue("@Price", price);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Service created successfully!");
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create service. Please try again.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
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
