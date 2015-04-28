using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qulix.Data.Common;

namespace Qulix.Web.Models
{
    public class StaticDS
    {
        private static List<Person> _persons = new List<Person>();
        private static List<Task> _tasks = new List<Task>();

        static StaticDS()
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
            for (int i = 0; i < 100; i++)
            {
                Task task = new Task
                {
                    TaskId = i + 1,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Name = string.Format("Task {0}", 1 + i),
                    Status = Data.Common.TaskStatus.InProcess,
                    Executor = _persons.FirstOrDefault(x => x.PersonId == i + 1),
                    EstimatedHours = 8
                };
                _tasks.Add(task);
            }
        }
        public static List<Person> Persons
        {
            get
            {
                return _persons;
            }
        }

        public static List<Task> Tasks
        {
            get
            {
                return _tasks;
            }
        }
    }
}