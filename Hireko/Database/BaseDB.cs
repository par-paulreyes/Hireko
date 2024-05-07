using System;
using DotNetEnv;

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
    }
}