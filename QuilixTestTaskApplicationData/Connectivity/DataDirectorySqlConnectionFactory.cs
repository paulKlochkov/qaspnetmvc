using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
namespace Qulix.Data.Connectivity
{
    public class DataDirectorySqlConnectionFactory : ISqlConnectionFactory
    {
        private static readonly String DefaultConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private String _connectionString = string.Empty;

        public DataDirectorySqlConnectionFactory(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                _connectionString = DefaultConnectionString;
            }
            _connectionString = connectionString;
        }
        public System.Data.SqlClient.SqlConnection CreateNew()
        {
            var connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
