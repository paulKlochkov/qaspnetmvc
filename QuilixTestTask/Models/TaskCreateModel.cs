using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qulix.Data.Common;

namespace Qulix.Web.Models
{
    public class TaskCreateModel : TaskModel
    {
        public TaskCreateModel()
            : base()
        {
            Executors = StaticDS.Persons;
        }
        public int ExecutorId { get; set; }
        public IEnumerable<IPerson> Executors { get; set; }
    }
}