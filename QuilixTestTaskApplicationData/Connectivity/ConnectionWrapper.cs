using System;

namespace Qulix.Data.Connectivity
{
    /// <summary>
    /// Pool Wrapper for SqlConnection
    /// </summary>
    sealed class ConnectionWrapper : IConnectionWrapper
    {
        private IConnectionPool _connectionPool;

        private System.Data.SqlClient.SqlConnection _connection;
        /// <summary>
        /// SqlConnection instance
        /// </summary>
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



        public ConnectionWrapper(System.Data.SqlClient.SqlConnection _connection, IConnectionPool pool, Int32 id)
        {
            _connectionPool = pool;
            Id = id;
            Instance = _connection;
        }

        /// <summary>
        /// Return connection to Pool
        /// </summary>
        public void Dispose()
        {
            _connectionPool.DisposeConnection(this);
        }

        /// <summary>
        /// Connection wrapper unique id in pool
        /// </summary>
        public int Id
        {
            get;
            private set;
        }
    }

}
