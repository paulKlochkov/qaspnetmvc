using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quilix.Web.Models;

namespace Quilix.Web.Models
{
    public class StaticDS
    {
        private static List<Person> _persons = new List<Person>();
        private static List<TaskModel> _tasks = new List<TaskModel>();

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
                TaskModel task = new TaskModel
                {
                    TaskId = i+1,
                    StartDate =DateTime.Now,
                    EndDate = DateTime.Now,
                    Name = string.Format("Task {0}", 1 + i),
                    Status = Data.Common.TaskStatus.InProcess,
                    Executor = _persons.FirstOrDefault(x => x.PersonId == i+1),
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

        public static List<TaskModel> Tasks
        {
            get
            {
                return _tasks;
            }
        }
    }
}