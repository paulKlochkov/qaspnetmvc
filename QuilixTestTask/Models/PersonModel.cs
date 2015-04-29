using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qulix.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Qulix.Web.Models
{
    public class PersonModel : IPerson
    {

        public PersonModel()
        { }
        public PersonModel(IPerson person)
        {
            this.PersonId = person.PersonId;
            this.FirstName = person.FirstName;
            this.SecondName = person.SecondName;
            this.LastName = person.LastName;
        }

        [Display(Name = "Id")]
        public int PersonId { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Second name")]
        public string SecondName { get; set; }

        [Display(Name = "Last  name")]
        public string LastName { get; set; }
    }
}