using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qulix.Data.Common
{
    public class Task : ITask
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public int EstimatedHours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TaskStatus Status { get; set; }
        public IPerson Executor { get; set; }
    }
}
