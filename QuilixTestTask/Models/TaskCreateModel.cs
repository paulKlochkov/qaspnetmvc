using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qulix.Data.Common;
using Qulix.Data.Repository;

namespace Qulix.Web.Models
{
    public class TaskCreateModel : TaskModel
    {
        private ICollection<IPerson> _executors;
        public TaskCreateModel()
            : base()
        {
            _executors = new PersonRepository().GetAllEnities();
        }

        public TaskCreateModel(ITask task)
            : base(task)
        {
            _executors = new PersonRepository().GetAllEnities();
        }

        private int _executorId;
        private ITask task;
        public int ExecutorId
        {
            get
            {
                return _executorId;
            }
            set
            {
                _executorId = value;
                Executor = _executors.FirstOrDefault(x => x.PersonId == _executorId);
            }
        }
        public IEnumerable<SelectListItem> Executors
        {
            get
            {
                return new SelectList(_executors, "PersonId", "FirstName");
            }
        }
    }
}