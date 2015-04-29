using System;
using System.Data.SqlClient;

namespace Qulix.Data.Connectivity
{
    public interface ISqlConnectionFactory
    {
        System.Data.SqlClient.SqlConnection CreateNew();
    }
}
