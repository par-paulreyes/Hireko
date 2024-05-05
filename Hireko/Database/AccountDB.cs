using MySql.Data.MySqlClient;
using System;
using Hireko.Forms;

namespace Hireko.Database
{
    internal class AccountDB : BaseDB
    {
        internal AccountDB() : base() 
        {
        }

        internal int Register(string username, string password, string firstName, string lastName, string email, string address, string phone)
        {
            if (UsernameExists(username))
            {
                return -1;
            }

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO UserTbl (Username, UserPass, UserFName, UserLName, UserEmail, UserAddress, UserPhone) VALUES (@Username, @Password, @FirstName, @LastName, @Email, @Address, @Phone); SELECT LAST_INSERT_ID();";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Phone", phone);

                    int userId = Convert.ToInt32(command.ExecuteScalar());
                    return userId;
                }
            }
        }

        internal bool UsernameExists(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM UserTbl WHERE Username = @Username";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        internal int Login(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT UserID FROM UserTbl WHERE Username = @Username AND UserPass = @Password";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }
    }
}
