using Hireko.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Hireko.Database
{
    internal class AdminDB: BaseDB
    {
        internal AdminDB() : base() { }
        internal void ApproveService(int serviceId)
        {
            string query = "UPDATE ServiceTbl SET ServiceStatus = 'Approved' WHERE ServiceId = @ServiceId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@ServiceId", serviceId } };
            ExecuteNonQuery(query, parameters);
        }
        internal void DeleteService(int serviceId)
        {
            string query = "DELETE FROM ServiceTbl WHERE ServiceId = @ServiceId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@ServiceId", serviceId } };
            ExecuteNonQuery(query, parameters);
        }
        internal void UpdateOrderStatus(int orderId, string newStatus)
        {
            string query = "UPDATE OrderTbl SET OrderStatus = @NewStatus WHERE OrderId = @OrderId";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@OrderId", orderId },
                { "@NewStatus", newStatus }
            };
            ExecuteNonQuery(query, parameters);
        }
        internal void DeleteOrder(int orderId)
        {
            string query = "DELETE FROM OrderTbl WHERE OrderId = @OrderId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@OrderId", orderId } };
            ExecuteNonQuery(query, parameters);
        }
        internal void DeleteUser(int userId)
        {
            string query = "DELETE FROM UserTbl WHERE UserId = @UserId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@UserId", userId } };
            ExecuteNonQuery(query, parameters);
        }
        internal AdminDashboardTotals GetAdminDashboardTotals()
        {
            AdminDashboardTotals totals = new AdminDashboardTotals();

            string totalIncomeQuery = "SELECT SUM(ServiceFee) FROM OrderTbl WHERE OrderStatus = 'Paid'";
            string totalUsersQuery = "SELECT COUNT(*) FROM UserTbl";
            string totalServicesQuery = "SELECT COUNT(*) FROM ServiceTbl";
            string totalApprovedServicesQuery = "SELECT COUNT(*) FROM ServiceTbl WHERE ServiceStatus = 'Approved'";
            string totalPendingServicesQuery = "SELECT COUNT(*) FROM ServiceTbl WHERE ServiceStatus = 'Pending'";
            string totalOrdersQuery = "SELECT COUNT(*) FROM OrderTbl";

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(totalIncomeQuery, connection);
                object totalIncomeResult = command.ExecuteScalar();
                totals.TotalIncome = totalIncomeResult != DBNull.Value ? Convert.ToDecimal(totalIncomeResult) : 0;

                command.CommandText = totalUsersQuery;
                totals.TotalUsers = Convert.ToInt32(command.ExecuteScalar());

                command.CommandText = totalServicesQuery;
                totals.TotalServices = Convert.ToInt32(command.ExecuteScalar());

                command.CommandText = totalApprovedServicesQuery;
                totals.TotalApprovedServices = Convert.ToInt32(command.ExecuteScalar());

                command.CommandText = totalPendingServicesQuery;
                totals.TotalPendingServices = Convert.ToInt32(command.ExecuteScalar());

                command.CommandText = totalOrdersQuery;
                totals.TotalOrders = Convert.ToInt32(command.ExecuteScalar());
            }

            return totals;
        }
    }
}
