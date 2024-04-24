using Hireko.Database;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hireko.Forms
{
    public partial class RegisterForm : Form
    {
        private string enteredUsername = "";
        private string enteredPassword = "";
        private string enteredConfirmPassword = "";

        private string connectionString = DatabaseInitializer.GetConnectionString();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            enteredUsername = username.Text;
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            enteredPassword = password.Text;
        }

        private void confirm_password_TextChanged(object sender, EventArgs e)
        {
            enteredConfirmPassword = confirm_password.Text;
        }

        private void register_Click(object sender, EventArgs e)
        {
            if (enteredPassword != enteredConfirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please re-enter your password.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", enteredUsername);
                command.Parameters.AddWithValue("@Password", enteredPassword);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registration successful! You can now login with your credentials.");
                        // Navigate back to the login form
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Registration failed. Please try again.");
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
        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Navigate back to the login form
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
