using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Qulix.Data.Connectivity
{
    public class DatabaseSchemaGenerator : IDataBaseSchemaGenerator
    {
        private const string DefaultSqlConnectionString = "Server=localhost;Integrated security=SSPI;";
        private const string DefaultSqlScriptPath = "CreateDatabase.sql";

        private string _connectionString = string.Empty;
        private string _scriptPath = string.Empty;

        public DatabaseSchemaGenerator(string connection = "", string scriptPath = "")
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                _connectionString = DefaultSqlConnectionString;
            }
            else
            {
                _connectionString = connection;
            }
            if (string.IsNullOrWhiteSpace(scriptPath))
            {
                _scriptPath = DefaultSqlScriptPath;
            }
            else
            {
                _scriptPath = scriptPath;
            }
        }

        public void GenerateSchema()
        {
            using (SqlConnection databaseConnection = new SqlConnection(_connectionString))
            {
                databaseConnection.Open();
                string script = GetScript();
                SqlCommand createCommand = databaseConnection.CreateCommand();
                createCommand.CommandText = script;
                createCommand.ExecuteNonQuery();
            }
        }

        private String GetScript()
        {
            string script = string.Empty;
            using (StreamReader file = File.OpenText(_scriptPath))
            {
                script = file.ReadToEnd();
            }
            return script;
        }
    }
}
