using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quilix.Data.Common
{
    public interface ITask
    {
        int TaskId { get; set; }
        string Name { get; set; }
        int EstimatedHours { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        TaskStatus Status { get; set; }
        IPerson Executor { get; set; }
    }
}
