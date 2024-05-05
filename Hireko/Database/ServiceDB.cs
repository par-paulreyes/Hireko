using MySql.Data.MySqlClient;
using System;

namespace Hireko.Database
{
    internal class ServiceDB : BaseDB// Hindi ko pa naayos
    {
        internal ServiceDB() : base() { }

        internal int CreateService(string username, string password, string firstName, string lastName, string email, string address, string phone)
        {
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
    }
}