using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qulix.Data.Common;
using Qulix.Data.Repository;
using System.ComponentModel.DataAnnotations;
namespace Qulix.Web.Models
{
    public class TaskCreateEditModel : ITask
    {
        //private static List<>
        private ICollection<IPerson> _executors;

        /// <summary>
        /// Init default values
        /// </summary>
        private void Init()
        {
            //Get all available executors for DB
            _executors = new PersonRepository().GetAllEnities();
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
        }

        [Display(Name = "Id")]
        public int TaskId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Estimated")]
        public int EstimatedHours { get; set; }

        [Required]
        [Display(Name = "Start date")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End date")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Status")]
        public TaskStatus Status { get; set; }


        public TaskCreateEditModel()
        {
            this.Init();
        }

        public TaskCreateEditModel(ITask task)
        {
            this.Init();
            TaskId = task.TaskId;
            Name = task.Name;
            EstimatedHours = task.EstimatedHours;
            StartDate = task.StartDate;
            EndDate = task.EndDate;
            Status = task.Status;
            Executor = task.Executor;
            ExecutorId = task.ExecutorId;
        }

        /// <summary>
        /// Current executor
        /// </summary>
        private int _executorId;
        [Required]
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
        /// <summary>
        /// Create executors drop-downList
        /// </summary>
        public IEnumerable<SelectListItem> Executors
        {
            get
            {
                return new SelectList(_executors, "PersonId", "FullName");
            }
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


        public IPerson _executor { get; set; }
    }
}