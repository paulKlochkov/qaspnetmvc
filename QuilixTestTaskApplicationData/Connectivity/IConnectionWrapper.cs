using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qulix.Data.Connectivity
{
    public interface IConnectionWrapper : IDisposable
    {
        Int32 Id { get; }
        System.Data.SqlClient.SqlConnection Instance { get; }
    }
}
