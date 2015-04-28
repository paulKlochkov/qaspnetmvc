using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qulix.Data.Common
{
    public interface IPerson
    {
        int PersonId { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
        string LastName { get; set; }
    }
}
