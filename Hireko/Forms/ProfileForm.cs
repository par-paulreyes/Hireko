using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Hireko.Database;
using Hireko.Models;
using Microsoft.VisualBasic.ApplicationServices;

namespace Hireko.Forms
{
    public partial class ProfileForm : Form
    {
        private string connectionString = DatabaseInitializer.GetConnectionString();

        private string currentUsername = "";

        public ProfileForm(string username)
        {
            InitializeComponent();
            currentUsername = username;
        }

        private void ProfileMainForm_Load(object sender, EventArgs e)
        {
            // Call a method to load and display user information based on currentUser
            LoadUserInfo(currentUsername);
        }

        private void LoadUserInfo(string username)
        {
            // Implement code here to fetch user information from the database using the username
            // You can use the connectionString to establish a connection and execute a query
            // Populate the form controls (text boxes, labels, etc.) with the fetched user information
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Example: Display username in a label
                        lblUsername.Text = reader["Username"].ToString();
                        lblFirstName.Text = reader["FirstName"].ToString();
                        lblLastName.Text = reader["LastName"].ToString();
                        lblEmail.Text = reader["Email"].ToString();
                       // lblAddress.Text = reader["Address"].ToString();
                      //  lblPhone.Text = reader["Phone"].ToString();
                      //  lblRating.Text = reader["Rating"].ToString();
                       // lblUserType.Text = reader["UserType"].ToString();
                    }
                    reader.Close();
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
    }

}
