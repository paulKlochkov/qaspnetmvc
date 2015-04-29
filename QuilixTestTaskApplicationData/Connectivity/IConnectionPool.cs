namespace Qulix.Data.Connectivity
{



    /// <summary>
    /// Pool of database connections
    /// </summary>
    public interface IConnectionPool
    {
        /// <summary>
        /// Factory of SqlConnections
        /// </summary>
        ISqlConnectionFactory ConnectionFactory { set; }
        /// <summary>
        /// Get wrapped connection from pool
        /// </summary>
        /// <returns>Connection wrapper</returns>
        IConnectionWrapper GetConnection();
        /// <summary>
        /// Return connection to pool
        /// </summary>
        /// <param name="connectionWrapper">Connection wrapper</param>
        void DisposeConnection(IConnectionWrapper connectionWrapper);
    }


}
