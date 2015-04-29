using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qulix.Data.Connectivity
{




    public interface IConnectionPool
    {
        ISqlConnectionFactory ConnectionFactory { set; }
        IConnectionWrapper GetConnection();
        void DisposeConnection(IConnectionWrapper connectionWrapper);
    }


}
