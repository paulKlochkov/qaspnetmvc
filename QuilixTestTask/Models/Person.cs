using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quilix.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Quilix.Web.Models
{
    public class Person : IPerson
    {
        public int PersonId { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Second name")]
        public string SecondName { get; set; }

        [Display(Name = "Last  name")]
        public string LastName { get; set; }
    }
}