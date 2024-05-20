using MySql.Data.MySqlClient;
using System;
using Hireko.Model;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Hireko.Database
{
    internal class AccountDB : BaseDB
    {
        internal AccountDB() : base()
        {
        }
        internal int Register(string username, string password, string firstName, string lastName, string email, string address, string phone)
        {
            string hashedPassword = HashPassword(password);
            if (UsernameExists(username))
            {
                return -1;
            }

            string query = "INSERT INTO UserTbl (Username, UserPass, UserFName, UserLName, UserEmail, UserAddress, UserPhone) " +
                           "VALUES (@Username, @Password, @FirstName, @LastName, @Email, @Address, @Phone); SELECT LAST_INSERT_ID();";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Username", username },
                { "@Password", hashedPassword },
                { "@FirstName", firstName },
                { "@LastName", lastName },
                { "@Email", email },
                { "@Address", address },
                { "@Phone", phone }
            };

            int userId = Convert.ToInt32(ExecuteScalarQuery(query, parameters));
            return userId;
        }

        internal bool UsernameExists(string username)
        {
            string query = "SELECT COUNT(*) FROM UserTbl WHERE Username = @Username";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@Username", username } };
            int count = Convert.ToInt32(ExecuteScalarQuery(query, parameters));
            return count > 0;
        }

        internal int Login(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            string query = "SELECT UserID FROM UserTbl WHERE Username = @Username AND UserPass = @Password";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Username", username },
                { "@Password", hashedPassword }
            };
            object result = ExecuteScalarQuery(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute hash from the password bytes
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert hashed bytes to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        internal bool IsAdmin(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            string query = "SELECT COUNT(*) FROM AdminTbl WHERE AdminUser = @Username AND AdminPass = @Password";
            Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@Username", username },
            { "@Password", hashedPassword }
        };
            int count = Convert.ToInt32(ExecuteScalarQuery(query, parameters));
            return count > 0;
        }

        internal List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            string query = "SELECT UserId, Username, UserFName, UserLName, UserEmail, UserAddress, UserPhone, UserType FROM UserTbl";

            using (MySqlDataReader reader = ExecuteReader(query, null))
            {
                while (reader.Read())
                {
                    User user = new User
                    {
                        UserId = reader.GetInt32("UserId"),
                        Username = reader.GetString("Username"),
                        UserFName = reader.GetString("UserFName"),
                        UserLName = reader.GetString("UserLName"),
                        UserEmail = reader.GetString("UserEmail"),
                        UserAddress = reader.GetString("UserAddress"),
                        UserPhone = reader.GetString("UserPhone"),
                        UserType = reader.GetString("UserType")
                    };
                    users.Add(user);
                }
            }
            return users;
        }
        internal User GetUserDetails(int userId)
        {
            User user = new User();

            string query = "SELECT * FROM UserTbl WHERE UserID = @UserId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@UserId", userId } };

            using (MySqlDataReader reader = ExecuteReader(query, parameters))
            {
                if (reader.Read())
                {
                    user.UserId = reader.GetInt32("UserID");
                    user.Username = reader.GetString("Username");
                    user.UserFName = reader.GetString("UserFName");
                    user.UserLName = reader.GetString("UserLName");
                    user.UserEmail = reader.GetString("UserEmail");
                    user.UserAddress = reader.GetString("UserAddress");
                    user.UserPhone = reader.GetString("UserPhone");
                    user.UserRating = reader.GetDecimal("UserRating");
                    user.UserType = reader.GetString("UserType");
                }
            }
            return user;
        }
        internal bool UpdateUserDetails(User updatedUser)
        {
            string query = "UPDATE UserTbl SET UserFName = @UserFName, UserLName = @UserLName, UserEmail = @UserEmail, UserAddress = @UserAddress, UserPhone = @UserPhone WHERE UserID = @UserID";
            Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@UserFName", updatedUser.UserFName },
            { "@UserLName", updatedUser.UserLName },
            { "@UserEmail", updatedUser.UserEmail },
            { "@UserAddress", updatedUser.UserAddress },
            { "@UserPhone", updatedUser.UserPhone },
            { "@UserID", CurrentUser.UserId }
        };

            int rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
    }
}