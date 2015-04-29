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
        [Display(Name = "Id")]
        public int TaskId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Estimated")]
        public int EstimatedHours { get; set; }

        [Required]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Status")]
        public TaskStatus Status { get; set; }

        private IPerson _executor;

        public TaskModel()
        {

        }

        public TaskModel(ITask task)
        {
            TaskId = task.TaskId;
            Name = task.Name;
            EstimatedHours = task.EstimatedHours;
            StartDate = task.StartDate;
            EndDate = task.EndDate;
            Status = task.Status;
            Executor = task.Executor;
            ExecutorId = task.ExecutorId;
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



        public int ExecutorId { get; set; }
    }
}