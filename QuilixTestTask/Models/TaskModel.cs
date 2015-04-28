using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Qulix.Data.Common;

namespace Qulix.Web.Models
{
    public class TaskModel : ITask
    {

        [ScaffoldColumn(false)]
        public int TaskId { get; set; }
        public string Name { get; set; }

        public int EstimatedHours { get; set; }

        [Display(Name = "Start date")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Status")]
        public TaskStatus Status { get; set; }

        private IPerson _executor;

        public TaskModel()
        {

        }
        public TaskModel(Task task)
        {
            TaskId = task.TaskId;
            Name = task.Name;
            EstimatedHours = task.EstimatedHours;
            StartDate = task.StartDate;
            EndDate = task.EndDate;
            Status = task.Status;
            Executor = task.Executor;
        }
        public IPerson Executor
        {
            get
            {
                return _executor;
            }
            set
            {
                _executor = value;
            }
        }

        [Display(Name = "Executor")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", _executor.FirstName, _executor.SecondName, _executor.LastName);
            }
        }
    }
}