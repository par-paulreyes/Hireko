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
        private string enteredFirstName = "";
        private string enteredLastName = "";
        private string enteredEmail = "";
        private string enteredPhone = "";
        private string enteredAddress = "";

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

        private void first_Name_TextChanged(object sender, EventArgs e)
        {
            enteredFirstName = first_Name.Text;
        }

        private void last_Name_TextChanged(object sender, EventArgs e)
        {
            enteredLastName = last_Name.Text;
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            enteredEmail = email.Text;
        }

        private void phone_TextChanged(object sender, EventArgs e)
        {
            enteredPhone = phone.Text;
        }

        private void address_TextChanged(object sender, EventArgs e)
        {
            enteredAddress = address.Text;
        }

        private void register_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (enteredPassword != enteredConfirmPassword)
                {
                    MessageBox.Show("Passwords do not match. Please re-enter your password.");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Users (Username, Password, FirstName, LastName, Email, [Address], Phone) VALUES (@Username, @Password, @FirstName, @LastName, @Email, @Address, @Phone)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", enteredUsername);
                    command.Parameters.AddWithValue("@Password", enteredPassword);
                    command.Parameters.AddWithValue("@FirstName", enteredFirstName);
                    command.Parameters.AddWithValue("@LastName", enteredLastName);
                    command.Parameters.AddWithValue("@Email", enteredEmail);
                    command.Parameters.AddWithValue("@Address", enteredAddress);
                    command.Parameters.AddWithValue("@Phone", enteredPhone);

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
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(enteredUsername) ||
                string.IsNullOrWhiteSpace(enteredPassword) ||
                string.IsNullOrWhiteSpace(enteredConfirmPassword) ||
                string.IsNullOrWhiteSpace(enteredFirstName) ||
                string.IsNullOrWhiteSpace(enteredLastName) ||
                string.IsNullOrWhiteSpace(enteredEmail) ||
                string.IsNullOrWhiteSpace(enteredPhone) ||
                string.IsNullOrWhiteSpace(enteredAddress))
            {
                MessageBox.Show("Please fill in all the required fields.");
                return false;
            }

            return true;
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
