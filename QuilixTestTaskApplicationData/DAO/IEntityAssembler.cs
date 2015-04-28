using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Quilix.Data.DAO
{
    public interface IEntityAssembler<T>
    {
        T Assemble(System.Data.SqlClient.SqlDataReader reader);
    }
}