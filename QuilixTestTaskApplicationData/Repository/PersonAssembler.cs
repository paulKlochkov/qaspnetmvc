using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qulix.Data.Common;

namespace Qulix.Data.Repository
{
    class PersonAssembler : IEntityAssembler<IPerson>
    {
        public IPerson Assemble(System.Data.SqlClient.SqlDataReader reader)
        {
            return new Person
            {
                PersonId = Convert.ToInt32(reader["PersonId"]),
                FirstName = Convert.ToString(reader["FirstName"]),
                SecondName = Convert.ToString(reader["SecondName"]),
                LastName = Convert.ToString(reader["LastName"])
            };
        }
    }
}
