using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Qulix.Data.Repository
{
    interface IEntityAssembler<TEntity>
    {
        TEntity Assemble(System.Data.SqlClient.SqlDataReader reader);
    }
}