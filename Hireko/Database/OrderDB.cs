using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Hireko.Model;

namespace Hireko.Database
{
    internal class OrderDB : BaseDB
    {
        internal OrderDB() : base() { }

        internal int CreateOrder()
        {
            string query = "INSERT INTO OrderTbl (SellerUserId, BuyerUserId, ServiceId, ServiceFee, Price) VALUES (@SellerId, @BuyerId, @ServiceId, @ServiceFee, @ServicePrice); SELECT LAST_INSERT_ID();";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@SellerId", CurrentService.SellerId },
                { "@BuyerId", CurrentUser.UserId },
                { "@ServiceId", CurrentService.ServiceId },
                { "@ServiceFee", CurrentService.ServiceFee },
                { "@ServicePrice", CurrentService.Price}

            };
            object result = ExecuteScalarQuery(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }




        internal List<Order> GetBuyerOrders(int userId)
        {
            List<Order> orders = new List<Order>();

            string query = "SELECT OrderId, SellerUserId, BuyerUserId, ServiceId, OrderStatus FROM OrderTbl WHERE BuyerUserId = @UserId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@UserId", userId } };

            using (MySqlDataReader reader = ExecuteReader(query, parameters))
            {
                while (reader.Read())
                {
                    Order order = new Order
                    {
                        OrderId = Convert.ToInt32(reader["OrderId"]),
                        SellerUserId = Convert.ToInt32(reader["SellerUserId"]),
                        BuyerUserId = Convert.ToInt32(reader["BuyerUserId"]),
                        OrderStatus = reader["OrderStatus"].ToString(),
                        ServiceId = Convert.ToInt32(reader["ServiceId"])
                    };
                    orders.Add(order);
                }
            }
            return orders;
        }

        internal List<Order> GetSellerOrders(int userId)
        {
            List<Order> orders = new List<Order>();

            string query = "SELECT OrderId, SellerUserId, BuyerUserId, ServiceId, OrderStatus FROM OrderTbl WHERE SellerUserId = @SellerId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@SellerId", userId } };

            using (MySqlDataReader reader = ExecuteReader(query, parameters))
            {
                while (reader.Read())
                {
                    Order order = new Order
                    {
                        OrderId = Convert.ToInt32(reader["OrderId"]),
                        SellerUserId = Convert.ToInt32(reader["SellerUserId"]),
                        BuyerUserId = Convert.ToInt32(reader["BuyerUserId"]),
                        OrderStatus = reader["OrderStatus"].ToString(),
                        ServiceId = Convert.ToInt32(reader["ServiceId"])
                    };
                    orders.Add(order);
                }
            }
            return orders;
        }

        internal List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            string query = "SELECT OrderId, SellerUserId, BuyerUserId, ServiceId, OrderStatus FROM OrderTbl";

            using (MySqlDataReader reader = ExecuteReader(query, null))
            {
                while (reader.Read())
                {
                    Order order = new Order
                    {
                        OrderId = Convert.ToInt32(reader["OrderId"]),
                        SellerUserId = Convert.ToInt32(reader["SellerUserId"]),
                        BuyerUserId = Convert.ToInt32(reader["BuyerUserId"]),
                        OrderStatus = reader["OrderStatus"].ToString(),
                        ServiceId = Convert.ToInt32(reader["ServiceId"])
                    };
                    orders.Add(order);
                }
            }
            return orders;
        }
        internal string GetOrderStatus(int orderId)
        {
            string query = "SELECT OrderStatus FROM OrderTbl WHERE OrderId = @OrderId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@OrderId", orderId } };

            object result = ExecuteScalarQuery(query, parameters);
            return result != null ? result.ToString() : null;
        }

        internal void UpdateOrderStatus(int orderId, string status)
        {
            string query = "UPDATE OrderTbl SET OrderStatus = @Status WHERE OrderId = @OrderId";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Status", status },
                { "@OrderId", orderId }
            };
            ExecuteNonQuery(query, parameters);
        }

        internal void RemoveOrder(int orderId)
        {
            string query = "DELETE FROM OrderTbl WHERE OrderId = @OrderId";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@OrderId", orderId } };
            ExecuteNonQuery(query, parameters);
        }
    }
}