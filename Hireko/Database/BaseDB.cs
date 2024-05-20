using System;
using System.Collections.Generic;
using System.Data;
using DotNetEnv;
using MySql.Data.MySqlClient;

namespace Hireko.Database
{
    internal abstract class BaseDB
    {
        protected readonly string _connectionString;

        protected BaseDB()
        {
            Env.Load();
            _connectionString = ConstructConnectionString();
        }

        private string ConstructConnectionString()
        {
            string server = Environment.GetEnvironmentVariable("DB_SERVER");
            string port = Environment.GetEnvironmentVariable("DB_PORT");
            string database = Environment.GetEnvironmentVariable("DB_DATABASE");
            string username = Environment.GetEnvironmentVariable("DB_USERNAME");
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            return $"Server={server};Port={port};Database={database};Uid={username};Pwd={password};";
        }

        protected void OpenConnection(MySqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        protected object ExecuteScalarQuery(string query, Dictionary<string, object> parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                OpenConnection(connection);

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }
                    object result = command.ExecuteScalar();
                    return result;
                }
            }
        }

        protected int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                OpenConnection(connection);

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        protected MySqlDataReader ExecuteReader(string query, Dictionary<string, object> parameters)
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            OpenConnection(connection);

            MySqlCommand command = new MySqlCommand(query, connection);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }
            return command.ExecuteReader();
        }
    }
}