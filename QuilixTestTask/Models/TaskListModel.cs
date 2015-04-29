using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qulix.Data.Common;

namespace Qulix.Web.Models
{
    /// <summary>
    /// Represents list of tasks model
    /// </summary>
    public class TaskListModel : List<Qulix.Web.Models.TaskModel>
    {
        /// <summary>
        /// Number of persons allowed to be assigned to tasks 
        /// </summary>
        public int PersonCount { get; set; }

        public TaskListModel(ICollection<ITask> tasks)
            : base()
        {
            this.AddRange(tasks.Select(task => new TaskModel(task)).ToList());
        }

        private TaskModel _template = new TaskModel();

        /// <summary>
        /// Field is used as template for columns
        /// </summary>
        public TaskModel Template
        {
            get
            {
                return _template;
            }
        }
    }
}