using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Quilix.Data.Common;

namespace Quilix.Web.Models
{
    public class TaskModel : ITask
    {

        public int TaskId { get; set; }
        public string Name { get; set; }

        public int EstimatedHours { get; set; }

        [Display(Name = "Started")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Started")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Status")]
        public TaskStatus Status { get; set; }

        private IPerson _executor;
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