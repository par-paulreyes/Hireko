using System;
using System.Data.SqlClient;
using Hireko.Database;

namespace Hireko.Forms
{
    public class LoginFormController
    {
        private string connectionString = DatabaseInitializer.GetConnectionString();

        public string? EnteredUsername { get; set; }
        public string? EnteredPassword { get; set; }

        public bool AuthenticateUser()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", EnteredUsername);
                command.Parameters.AddWithValue("@Password", EnteredPassword);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (SqlException ex)
                {
                    // Handle database errors
                    Console.WriteLine("Database error: " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
