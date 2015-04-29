using System;
using Qulix.Data.Common;

namespace Qulix.Data.Repository
{
    /// <summary>
    /// Assembles task from datareader
    /// </summary>
    class TaskAssembler : IEntityAssembler<ITask>
    {
        public ITask Assemble(System.Data.SqlClient.SqlDataReader reader)
        {
            Task task = new Task
            {
                TaskId = Convert.ToInt32(reader["TaskId"]),
                StartDate = Convert.ToDateTime(reader["StartDate"]),
                EndDate = Convert.ToDateTime(reader["EndDate"]),
                Status = (TaskStatus)Convert.ToInt32(reader["Status"]),
                Name = Convert.ToString(reader["Name"]),
                EstimatedHours = Convert.ToInt32(reader["EstimatedHours"]),
                ExecutorId = Convert.ToInt32(reader["Executor"])
            };

            return task;
        }
    }
}
