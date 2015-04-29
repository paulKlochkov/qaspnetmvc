using System;
using System.Collections.Generic;
using System.Linq;

namespace Qulix.Data.Connectivity
{
    public class ConnectionPool : IConnectionPool
    {
        private static ConnectionPool _instance;
        public static ConnectionPool Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConnectionPool();
                }
                return _instance;
            }
        }

        private Int32 _created = 0;

        private Stack<ConnectionWrapper> _connectionFreeWrappers = new Stack<ConnectionWrapper>();
        private List<ConnectionWrapper> _busyWrappers = new List<ConnectionWrapper>();

        ISqlConnectionFactory _connectionFactory;

        private void InitNewConnectionFactory(string connectionString)
        {
            _connectionFactory = new DataDirectorySqlConnectionFactory(connectionString);
        }

        public ConnectionPool(string connectionString)
        {
            Limit = 5;
            this.InitNewConnectionFactory(connectionString);
        }

        public void SetConnectionString(string connectionString)
        {
            this.InitNewConnectionFactory(connectionString);
        }

        public ConnectionPool()
            : this("")
        {

        }

        public Int32 Limit { get; set; }

        public ISqlConnectionFactory ConnectionFactory
        {
            set { _connectionFactory = value; }
        }

        public IConnectionWrapper GetConnection()
        {
            if (_connectionFactory == null)
            {
                throw new ConnectionPoolWrongUseException();
            }
            if (_connectionFreeWrappers.Count > 0)
            {
                var connection = _connectionFreeWrappers.Pop();
                _busyWrappers.Add(connection);
                return connection;
            }

            if (_connectionFreeWrappers.Count == 0 && _busyWrappers.Count >= Limit)
            {
                throw new OperationCanceledException();
            }

            if (_created == Limit)
            {
                throw new OperationCanceledException();
            }

            _created++;
            var newConnection = new ConnectionWrapper(_connectionFactory.CreateNew(), this, _created);
            _busyWrappers.Add(newConnection);
            return newConnection;
        }

        public void DisposeConnection(IConnectionWrapper connectionWrapper)
        {
            var connection = _busyWrappers.FirstOrDefault(x => x.Id == connectionWrapper.Id);
            if (connection == null)
            {
                throw new ArgumentException("connectionWrapper");
            }
            _busyWrappers.Remove(connection);
            _connectionFreeWrappers.Push(connection);
        }
    }
}
