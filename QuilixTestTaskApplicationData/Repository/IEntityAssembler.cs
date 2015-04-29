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
        /// <summary>
        /// Assembles entity from SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        TEntity Assemble(System.Data.SqlClient.SqlDataReader reader);
    }
}