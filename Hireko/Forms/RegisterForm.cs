using Hireko.Database;
using System.Data.SqlClient;
using Hireko.Models;

namespace Hireko.Forms
{
    public partial class RegisterForm : Form
    {
        private User user = new User();

        private string connectionString = DatabaseInitializer.GetConnectionString();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            user.Username = txtUsername.Text;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            user.Password = txtPassword.Text;
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            user.ConfirmPassword = txtConfirmPassword.Text;
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            user.FirstName = txtFirstName.Text;
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            user.LastName = txtLastName.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            user.Email = txtEmail.Text;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            user.Phone = txtPhone.Text;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            user.Address = txtAddress.Text;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (user.Password != user.ConfirmPassword)
                {
                    MessageBox.Show("Passwords do not match. Please re-enter your password.");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@Username", user.Username);

                    try
                    {
                        connection.Open();
                        int existingUserCount = (int)checkCommand.ExecuteScalar();
                        if (existingUserCount > 0)
                        {
                            MessageBox.Show("Username already exists. Please choose a different username.");
                            return;
                        }

                        string insertQuery = "INSERT INTO Users (Username, Password, FirstName, LastName, Email, [Address], Phone) VALUES (@Username, @Password, @FirstName, @LastName, @Email, @Address, @Phone)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@Username", user.Username);
                        insertCommand.Parameters.AddWithValue("@Password", user.Password);
                        insertCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                        insertCommand.Parameters.AddWithValue("@LastName", user.LastName);
                        insertCommand.Parameters.AddWithValue("@Email", user.Email);
                        insertCommand.Parameters.AddWithValue("@Address", user.Address);
                        insertCommand.Parameters.AddWithValue("@Phone", user.Phone);

                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registration successful! You can now login with your credentials.");
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
            if (string.IsNullOrWhiteSpace(user.Username) ||
                string.IsNullOrWhiteSpace(user.Password) ||
                string.IsNullOrWhiteSpace(user.ConfirmPassword) ||
                string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(user.Phone) ||
                string.IsNullOrWhiteSpace(user.Address))
            {
                MessageBox.Show("Please fill in all the required fields.");
                return false;
            }

            return true;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
