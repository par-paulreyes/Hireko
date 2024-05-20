using MySql.Data.MySqlClient;
using System;
using Hireko.Model;
using System.Collections.Generic;

namespace Hireko.Database
{
    internal class ServiceDB : BaseDB
    {
        internal ServiceDB() : base() { }

        internal int CreateService(string freelancer, string service, string category, string occupation, string description, string experience, string education, decimal price)
        {
            string query = "INSERT INTO ServiceTbl (UserId, FreelancerName, Service, Category, Occupation, ServiceDescription, ExperienceLevel, EducationalBackground, Price) VALUES (@UserId, @Freelancer, @Service, @Category, @Occupation, @Description, @Experience, @Education, @Price); SELECT LAST_INSERT_ID();";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@UserId", CurrentUser.UserId },
                { "@Freelancer", freelancer },
                { "@Service", service },
                { "@Category", category },
                { "@Occupation", occupation },
                { "@Description", description },
                { "@Experience", experience },
                { "@Education", education },
                { "@Price", price }
            };
            object result = ExecuteScalarQuery(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }
        internal int UpdateUserTypeToSeller()
        {
            string query = "UPDATE UserTbl SET UserType = 'Seller' WHERE UserId = @UserId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@UserId", CurrentUser.UserId } };
            object result = ExecuteScalarQuery(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        internal string GetServiceName(int serviceId)
        {
            string serviceName = null;

            string query = "SELECT Service FROM ServiceTbl WHERE ServiceId = @ServiceId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@ServiceId", serviceId } };

            object result = ExecuteScalarQuery(query, parameters);
            if (result != null)
            {
                serviceName = result.ToString();
            }
            return serviceName;
        }
        internal List<Service> GetAllServices()
        {
            List<Service> services = new List<Service>();

            string query = "SELECT * FROM ServiceTbl";

            using (MySqlDataReader reader = ExecuteReader(query, null))
            {
                while (reader.Read())
                {
                    Service service = new Service
                    {
                        ServiceId = reader.GetInt32("ServiceId"),
                        UserId = reader.GetInt32("UserId"),
                        FreelancerName = reader.GetString("FreelancerName"),
                        ServiceName = reader.GetString("Service"),
                        Category = reader.GetString("Category"),
                        Occupation = reader.GetString("Occupation"),
                        ServiceDescription = reader.GetString("ServiceDescription"),
                        ExperienceLevel = reader.GetString("ExperienceLevel"),
                        EducationalBackground = reader.GetString("EducationalBackground"),
                        Price = reader.GetDecimal("Price"),
                        ServiceStatus = reader.GetString("ServiceStatus")
                    };
                    services.Add(service);
                }
            }
            return services;
        }

        internal Service GetServiceDetails(object serviceId)
        {
            Service service = null;

            string query = "SELECT * FROM ServiceTbl WHERE ServiceId = @ServiceId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@ServiceId", serviceId } };

            using (MySqlDataReader reader = ExecuteReader(query, parameters))
            {
                if (reader.Read())
                {
                    service = new Service
                    {
                        ServiceId = reader.GetInt32("ServiceId"),
                        UserId = reader.GetInt32("UserId"),
                        FreelancerName = reader.GetString("FreelancerName"),
                        ServiceName = reader.GetString("Service"),
                        Category = reader.GetString("Category"),
                        Occupation = reader.GetString("Occupation"),
                        ServiceDescription = reader.GetString("ServiceDescription"),
                        ExperienceLevel = reader.GetString("ExperienceLevel"),
                        EducationalBackground = reader.GetString("EducationalBackground"),
                        Price = reader.GetDecimal("Price"),
                        ServiceStatus = reader.GetString("ServiceStatus")
                    };
                }
            }
            return service;
        }

        internal decimal GetServiceFee(int serviceId)
        {
            string query = "SELECT Price FROM ServiceTbl WHERE ServiceId = @ServiceId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@ServiceId", serviceId } };

            object result = ExecuteScalarQuery(query, parameters);

            if (result != null && decimal.TryParse(result.ToString(), out decimal servicePrice))
            {
                decimal serviceFee = servicePrice * 0.03m; // Use decimal literal with 'm' suffix
                return serviceFee;
            }
            else
            {
                return 0; // Return 0 if the fee is not found or cannot be parsed
            }
        }


        internal List<Service> GetSellerServices(int userId)
        {
            List<Service> services = new List<Service>();

            string query = "SELECT * FROM ServiceTbl WHERE UserId = @UserId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@UserId", userId } };

            using (MySqlDataReader reader = ExecuteReader(query, parameters))
            {
                while (reader.Read())
                {
                    Service service = new Service
                    {
                        ServiceId = reader.GetInt32("ServiceId"),
                        UserId = reader.GetInt32("UserId"),
                        FreelancerName = reader.GetString("FreelancerName"),
                        ServiceName = reader.GetString("Service"),
                        Category = reader.GetString("Category"),
                        Occupation = reader.GetString("Occupation"),
                        ServiceDescription = reader.GetString("ServiceDescription"),
                        ExperienceLevel = reader.GetString("ExperienceLevel"),
                        EducationalBackground = reader.GetString("EducationalBackground"),
                        Price = reader.GetDecimal("Price"),
                        ServiceStatus = reader.GetString("ServiceStatus")
                    };
                    services.Add(service);
                }
            }
            return services;
        }

        internal void RemoveService(int serviceId)
        {
            string query = "DELETE FROM ServiceTbl WHERE ServiceId = @ServiceId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@ServiceId", serviceId } };
            ExecuteNonQuery(query, parameters);
        }

        public bool UserHasServices(int userId)
        {
            string query = "SELECT COUNT(*) FROM ServiceTbl WHERE ServiceId = @UserId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@UserId", userId } };

            using (MySqlDataReader reader = ExecuteReader(query, parameters))
            {
                int serviceCount = 0;
                if (reader.Read())
                {
                    serviceCount = Convert.ToInt32(reader[0]);
                }
                return serviceCount > 0;
            }
        }

        internal List<Service> SearchServices(string searchText)
        {
            List<Service> services = new List<Service>();

            string query = "SELECT * FROM ServiceTbl WHERE ServiceStatus = 'Approved' AND UserId != @UserId AND FreelancerName LIKE @SearchText OR Service LIKE @SearchText";

            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@SearchText", "%" + searchText + "%" }, { "@UserId", CurrentUser.UserId } };

            using (MySqlDataReader reader = ExecuteReader(query, parameters))
            {
                while (reader.Read())
                {
                    Service service = new Service
                    {
                        ServiceId = reader.GetInt32("ServiceId"),
                        UserId = reader.GetInt32("UserId"),
                        FreelancerName = reader.GetString("FreelancerName"),
                        ServiceName = reader.GetString("Service"),
                        Category = reader.GetString("Category"),
                        Occupation = reader.GetString("Occupation"),
                        ServiceDescription = reader.GetString("ServiceDescription"),
                        ExperienceLevel = reader.GetString("ExperienceLevel"),
                        EducationalBackground = reader.GetString("EducationalBackground"),
                        Price = reader.GetDecimal("Price"),
                        ServiceStatus = reader.GetString("ServiceStatus")
                    };
                    services.Add(service);
                }
            }
            return services;
        }
    }
}