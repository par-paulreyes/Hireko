using MySql.Data.MySqlClient;
using System;

namespace Hireko.Database
{
    internal class ServiceDB : BaseDB
    {
        internal ServiceDB() : base() { }

        internal int CreateService(string service, string category, string occupation, string description, string experience, string education, decimal price)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO ServiceTbl (UserId, Service, Category, Occupation, ServiceDescription, ExperienceLevel, EducationalBackground, Price) " +
                               "VALUES (@UserId, @Service, @Category, @Occupation, @Description, @Experience, @Education, @Price); SELECT LAST_INSERT_ID();";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", User.CurrentUser);
                    command.Parameters.AddWithValue("@Service", service);
                    command.Parameters.AddWithValue("@Category", category);
                    command.Parameters.AddWithValue("@Occupation", occupation);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Experience", experience);
                    command.Parameters.AddWithValue("@Education", education);
                    command.Parameters.AddWithValue("@Price", price);

                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }
    }
}
