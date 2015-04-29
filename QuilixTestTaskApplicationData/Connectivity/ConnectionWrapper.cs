using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qulix.Data.Connectivity
{
    sealed class ConnectionWrapper : IConnectionWrapper
    {
        private System.Data.SqlClient.SqlConnection _connection;
        public System.Data.SqlClient.SqlConnection Instance
        {
            get
            {
                return _connection;
            }
            private set
            {
                _connection = value;
            }
        }
        private IConnectionPool _connectionPool;

        public ConnectionWrapper(System.Data.SqlClient.SqlConnection _connection, IConnectionPool pool, Int32 id)
        {
            _connectionPool = pool;
            Id = id;
            Instance = _connection;
        }


        public void Dispose()
        {
            _connectionPool.DisposeConnection(this);
        }

        public int Id
        {
            get;
            private set;
        }
    }

}
