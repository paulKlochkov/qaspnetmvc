using System.Collections.Generic;
using Qulix.Data.Common;
using Qulix.Data.Connectivity;
using System.Data.SqlClient;

namespace Qulix.Data.Repository
{
    /// <summary>
    /// Repository
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        #region SQL COMMANDS
        private const string SelectAllQuery = @"select * from Persons";
        private const string SelectByIdQuery = @"select * from Persons where PersonId = @personId";
        private const string InsertQuery = @"insert into Persons (FirstName,SecondName,LastName) values(@firstName,@secondName,@lastName)";
        private const string DeleteQuery = @"delete from Persons where Persons.PersonId = @personId";
        private const string CountQuery = @"select count(PersonId) from Persons";
        private const string FindQuery = @"SELECT TOP 1 *
                                                    FROM Persons
                                                    where [PersonId] = @personId";
        private const string UpdateQuery = @"UPDATE [dbo].[Persons]
                                            SET [FirstName] = @firstName
                                            ,[SecondName] = @secondName
                                            ,[LastName] = @lastName
                                             WHERE [PersonId] = @personId";
        #endregion
        private static readonly PersonAssembler _personAssembler = new PersonAssembler();

        /// <summary>
        /// Create Person in Database
        /// </summary>
        /// <param name="entity">Person to create in Database</param>
        /// <returns></returns>
        public IPerson Create(IPerson entity)
        {
            using (var wrapper = ConnectionPool.Instance.GetConnection())
            {
                SqlConnection connection = wrapper.Instance;
                SqlCommand command = connection.CreateCommand();
                command.CommandText = InsertQuery;
                command.Parameters.Add("firstName", entity.FirstName);
                command.Parameters.Add("secondName", entity.SecondName);
                command.Parameters.Add("lastName", entity.LastName);
                command.ExecuteNonQuery();
            }
            //_persons.Add(entity);
            return entity;
        }

        /// <summary>
        /// Delete Person
        /// </summary>
        /// <param name="entity">Person to delete</param>
        public void Delete(IPerson entity)
        {
            this.DeleteById(entity.PersonId);
        }

        /// <summary>
        /// Delete Person with following PersonId
        /// </summary>
        /// <param name="id">PersonId</param>
        public void DeleteById(int id)
        {
            using (var wrapper = ConnectionPool.Instance.GetConnection())
            {
                SqlConnection connection = wrapper.Instance;
                SqlCommand command = connection.CreateCommand();
                command.CommandText = DeleteQuery;
                command.Parameters.Add("personId", id);
                command.ExecuteNonQuery();
            }

        }

        /// <summary>
        /// Update Person
        /// </summary>
        /// <param name="entity">Person</param>
        /// <returns></returns>
        public IPerson Update(IPerson entity)
        {
            return this.Update(entity.PersonId, entity);
        }

        /// <summary>
        /// Update Person
        /// </summary>
        /// <param name="key">PersonId</param>
        /// <param name="value">Person</param>
        /// <returns>Updated value</returns>
        public IPerson Update(int key, IPerson value)
        {
            //person.FirstName = value.FirstName;
            //person.LastName = value.LastName;
            //person.SecondName = value.SecondName;
            using (var wrapper = ConnectionPool.Instance.GetConnection())
            {
                SqlConnection connection = wrapper.Instance;
                SqlCommand command = connection.CreateCommand();
                command.CommandText = UpdateQuery;
                command.Parameters.Add("firstName", value.FirstName);
                command.Parameters.Add("secondName", value.SecondName);
                command.Parameters.Add("lastName", value.LastName);
                command.Parameters.Add("personId", key);
                command.ExecuteNonQuery();
            }
            return value;
        }

        /// <summary>
        /// Get all persons
        /// </summary>
        /// <returns></returns>
        public ICollection<IPerson> GetAllEnities()
        {
            List<IPerson> persons = new List<IPerson>();
            using (var wrapper = ConnectionPool.Instance.GetConnection())
            {
                SqlConnection connection = wrapper.Instance;
                SqlCommand command = connection.CreateCommand();
                command.CommandText = SelectAllQuery;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IPerson person = _personAssembler.Assemble(reader);
                        persons.Add(person);
                    }
                }
            }
            return persons;
        }

        /// <summary>
        /// Find Person by Id
        /// </summary>
        /// <param name="id">Id of person</param>
        /// <returns></returns>
        public IPerson FindById(int id)
        {
            IPerson person = null;
            using (var wrapper = ConnectionPool.Instance.GetConnection())
            {
                SqlConnection connection = wrapper.Instance;
                SqlCommand command = connection.CreateCommand();
                command.CommandText = SelectByIdQuery;
                command.Parameters.Add("personId", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        person = _personAssembler.Assemble(reader);
                    }
                }
            }
            return person;
        }



        public int Count()
        {
            int count = 0;
            using (var wrapper = ConnectionPool.Instance.GetConnection())
            {
                SqlConnection connection = wrapper.Instance;
                SqlCommand command = connection.CreateCommand();
                command.CommandText = CountQuery;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                }
            }
            return count;
        }
    }
}
