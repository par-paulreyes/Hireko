using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Hireko.Database;

namespace Hireko.Forms
{
    partial class LoginForm : Form
    {
        private string enteredUsername = "";
        private string enteredPassword = "";

        private string connectionString = DatabaseInitializer.GetConnectionString();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            enteredUsername = txtUsername.Text;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            enteredPassword = txtPassword.Text;
        }

        private void bntLogin_Click(object sender, EventArgs e)
        {
            if (AuthenticateUser(enteredUsername, enteredPassword))
            {
                MessageBox.Show("Login successful!");
                // Add code to navigate to the next form or perform further actions upon successful login
                // Redirect to BuyServiceForm
                CreateServiceForm buyServiceForm = new CreateServiceForm();
                buyServiceForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
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

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
    }
}
