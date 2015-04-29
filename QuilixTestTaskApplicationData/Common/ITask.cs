using System;

namespace Qulix.Data.Common
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
        int ExecutorId { get; set; }
    }
}
