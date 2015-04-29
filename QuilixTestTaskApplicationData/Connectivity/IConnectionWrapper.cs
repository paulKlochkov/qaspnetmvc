using System;

namespace Qulix.Data.Connectivity
{
    public interface IConnectionWrapper : IDisposable
    {
        Int32 Id { get; }
        System.Data.SqlClient.SqlConnection Instance { get; }
    }
}
