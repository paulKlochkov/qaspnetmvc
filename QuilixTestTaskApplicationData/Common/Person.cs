using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qulix.Data.Common
{
    public class Person : IPerson
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", FirstName, SecondName, LastName);
            }
        }
    }
}
