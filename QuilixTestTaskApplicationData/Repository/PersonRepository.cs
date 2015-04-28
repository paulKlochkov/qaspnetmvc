using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qulix.Data.Common;
namespace Qulix.Data.Repository
{
    /// <summary>
    /// Repository
    /// </summary>
    public class PersonRepository : Qulix.Data.Repository.IPersonRepository
    {
        private static List<IPerson> _persons = new List<IPerson>();
        static PersonRepository()
        {

            for (int i = 0; i < 100; i++)
            {
                Person person = new Person
                {
                    FirstName = string.Format("first name = {0}", i + 1),
                    SecondName = string.Format("first name = {0}", i + 1),
                    LastName = string.Format("first name = {0}", i + 1),
                    PersonId = i + 1
                };
                _persons.Add(person);
            }

        }
        public IPerson Create(IPerson entity)
        {
            _persons.Add(entity);
            return entity;
        }
        public void Delete(IPerson entity)
        {
            _persons.Remove(entity);
        }
        public IPerson Update(IPerson entity) { return entity; }

        public ICollection<IPerson> GetAllEnities()
        {
            return _persons;
        }


        public IPerson FindById(int id)
        {
            return _persons.FirstOrDefault(x => x.PersonId == id);
        }
    }
}
