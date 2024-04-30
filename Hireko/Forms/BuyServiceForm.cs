using Hireko.Database;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hireko.Forms
{
    public partial class BuyServiceForm : Form
    {
        private string connectionString = DatabaseInitializer.GetConnectionString();

        public BuyServiceForm()
        {
            InitializeComponent();
        }

        private void BuyServiceForm_Load(object sender, EventArgs e)
        {
            // Call a method to load service details into the container
            LoadServiceDetails();
        }

        private void LoadServiceDetails()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Category, Occupation, Description, Price FROM Services";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            // Create a panel to display each service
                            Panel servicePanel = new Panel();
                            servicePanel.BorderStyle = BorderStyle.FixedSingle;
                            servicePanel.Padding = new Padding(10);
                            servicePanel.Margin = new Padding(5);
                            servicePanel.Width = flowLayoutPanelServices.Width - 25; // Adjust width as needed

                            // Construct the display text for each service
                            string serviceInfo = $"Category: {reader["Category"]} \nOccupation: {reader["Occupation"]} \nPrice: {reader["Price"]}";

                            // Create a label to show the service info
                            Label labelServiceInfo = new Label();
                            labelServiceInfo.Text = serviceInfo;
                            labelServiceInfo.AutoSize = true;

                            // Add the label to the panel
                            servicePanel.Controls.Add(labelServiceInfo);

                            // Add the panel to the flowLayoutPanelServices
                            flowLayoutPanelServices.Controls.Add(servicePanel);
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error accessing database: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
