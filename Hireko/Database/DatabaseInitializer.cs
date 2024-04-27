using System;
using System.Data.SqlClient;


namespace Hireko.Database
{
    public class DatabaseInitializer
    {
        public static string GetDatabaseFile()
        {
            string solutionDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));

            string databaseFile = Path.Combine(solutionDirectory, @"DataBase\HirekoDatabase.mdf");
            return databaseFile;
        }

        public static string GetConnectionString()
        {
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{GetDatabaseFile()}"";Integrated Security=True";
            return connectionString;
        }


        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";

        public void InitializeDatabase()
        {
            string databaseName = "HirekoDatabase";

            string createDatabaseQuery = $"CREATE DATABASE {databaseName} ON PRIMARY (NAME={databaseName}, FILENAME='{GetDatabaseFile()}')";
            string createUsersTableQuery = @"
            CREATE TABLE Users (
                UserId INT PRIMARY KEY IDENTITY,
                Username NVARCHAR(50) NOT NULL,
                Password NVARCHAR(50) NOT NULL,
                FirstName NVARCHAR(100) NOT NULL,
                LastName NVARCHAR(100) NOT NULL,
                Email NVARCHAR(100) NOT NULL,
                Address NVARCHAR(255),
                Phone NVARCHAR(20),
                UserType NVARCHAR(50) NOT NULL DEFAULT 'buyer'
            )";
            string createBuyersTableQuery = @"
            CREATE TABLE Buyers (
                BuyerId INT PRIMARY KEY,
                FullName NVARCHAR(100) NOT NULL,
                [Address] NVARCHAR(255) NOT NULL,
                Phone NVARCHAR(20),
                UserId INT FOREIGN KEY REFERENCES Users(UserId)
            )";

            string createFreelancersTableQuery = @"
            CREATE TABLE Freelancers (
                FreelancerId INT PRIMARY KEY,
                FullName NVARCHAR(100) NOT NULL,
                [Address] NVARCHAR(255) NOT NULL,
                Phone NVARCHAR(20),
                UserId INT FOREIGN KEY REFERENCES Users(UserId)
            )";

            string createServicesTableQuery = @"
            CREATE TABLE Services (
                ServiceId INT PRIMARY KEY IDENTITY,
                Category NVARCHAR(50) NOT NULL,
                Occupation NVARCHAR(100) NOT NULL,
                Description NVARCHAR(255) NOT NULL,
                ExperienceLevel NVARCHAR(50) NOT NULL,
                EducationalBackground NVARCHAR(50) NOT NULL,
                Price DECIMAL(10,2) NOT NULL,
                Rating DECIMAL(3,2),
                UserId INT FOREIGN KEY REFERENCES Users(UserId)
            )";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(createDatabaseQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Database created successfully.");
                    }

                    connection.ChangeDatabase(databaseName);

                    using (SqlCommand command = new SqlCommand(createUsersTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Users table created successfully.");
                    }

                    using (SqlCommand command = new SqlCommand(createBuyersTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Buyers table created successfully.");
                    }

                    using (SqlCommand command = new SqlCommand(createFreelancersTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Freelancers table created successfully.");
                    }

                    using (SqlCommand command = new SqlCommand(createServicesTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Services table created successfully.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
