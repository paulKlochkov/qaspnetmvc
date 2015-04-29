using System.Collections.Generic;
using Qulix.Data.Common;
using Qulix.Data.Connectivity;
using System.Data.SqlClient;

namespace Qulix.Data.Repository
{
    /// <summary>
    /// Controls creation and manipulation of tasks in Database
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        private static readonly TaskAssembler _taskAssembler = new TaskAssembler();
        #region SQL COMMANDS
        private const string SelectAllQuery = @"select * from Tasks";
        private const string SelectByIdQuery = @"select Top 1 * from Tasks where TaskId = @taskId";
        private const string InsertQuery =
    @"INSERT INTO [dbo].[Tasks]
           ([Name]
           ,[EstimatedHours]
           ,[StartDate]
           ,[EndDate]
           ,[Status]
           ,[Executor])
     VALUES
           (@name
           ,@estimatedHours
           ,@startDate
           ,@endDate
           ,@status
           ,@executor)";
        private const string DeleteQuery = @"delete from Tasks where TaskId = @taskId";
        private const string UpdateQuery =
@"UPDATE [dbo].[Tasks]
   SET [Name] = @name
      ,[EstimatedHours] = @estimatedHours
      ,[StartDate] = @startDate
      ,[EndDate] = @endDate
      ,[Status] = @status
      ,[Executor] = @executor
 WHERE TaskId = @taskId";
        #endregion
        /// <summary>
        /// Create task in DataBase
        /// </summary>
        /// <param name="entity">Task</param>
        /// <returns>Created task</returns>
        public ITask Create(ITask entity)
        {
            //_tasks.Add(entity);
            using (var wrapper = ConnectionPool.Instance.GetConnection())
            {
                SqlConnection connection = wrapper.Instance;
                SqlCommand command = connection.CreateCommand();
                command.CommandText = InsertQuery;
                command.Parameters.Add("name", entity.Name);
                command.Parameters.Add("startDate", entity.StartDate);
                command.Parameters.Add("endDate", entity.EndDate);
                command.Parameters.Add("estimatedHours", entity.EstimatedHours);
                command.Parameters.Add("status", entity.Status);
                command.Parameters.Add("executor", entity.Executor.PersonId);

                command.ExecuteNonQuery();
            }
            return entity;
        }
        /// <summary>
        /// Delete task from database
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(ITask entity)
        {
            this.DeleteById(entity.TaskId);
        }
        /// <summary>
        /// Delete task from database
        /// </summary>
        /// <param name="key"></param>
        public void DeleteById(int key)
        {
            using (var wrapper = ConnectionPool.Instance.GetConnection())
            {
                SqlConnection connection = wrapper.Instance;
                SqlCommand command = connection.CreateCommand();
                command.CommandText = DeleteQuery;
                command.Parameters.Add("taskId", key);
                command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Update task in database
        /// </summary>
        /// <param name="from">New Task</param>
        /// <returns>Updated task</returns>
        public ITask Update(ITask from)
        {
            ITask entity = FindById(from.TaskId);
            entity.Name = from.Name;
            entity.StartDate = from.StartDate;
            entity.Status = from.Status;
            entity.EstimatedHours = from.EstimatedHours;
            entity.EndDate = from.EndDate;
            entity.Executor = from.Executor;
            return entity;
        }

        /// <summary>
        /// Update task in database
        /// </summary>
        /// <param name="key">TaskId</param>
        /// <param name="value">New Task</param>
        /// <returns>Updated task</returns>
        public ITask Update(int key, ITask value)
        {
            using (var wrapper = ConnectionPool.Instance.GetConnection())
            {
                SqlConnection connection = wrapper.Instance;
                SqlCommand command = connection.CreateCommand();
                command.CommandText = UpdateQuery;
                command.Parameters.Add("name", value.Name);
                command.Parameters.Add("startDate", value.StartDate);
                command.Parameters.Add("endDate", value.EndDate);
                command.Parameters.Add("estimatedHours", value.EstimatedHours);
                command.Parameters.Add("status", value.Status);
                command.Parameters.Add("executor", value.Executor.PersonId);
                command.Parameters.Add("taskId", key);
                command.ExecuteNonQuery();
            }
            return value;
        }
        /// <summary>
        /// Get list of tasks
        /// </summary>
        /// <returns>All Tasks</returns>
        public ICollection<ITask> GetAllEnities()
        {
            List<ITask> tasks = new List<ITask>();
            using (var wrapper = ConnectionPool.Instance.GetConnection())
            {
                SqlConnection connection = wrapper.Instance;
                SqlCommand command = connection.CreateCommand();
                command.CommandText = SelectAllQuery;
                IPersonRepository personRepository = new PersonRepository();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ITask task = _taskAssembler.Assemble(reader);

                        task.Executor = personRepository.FindById(task.ExecutorId);
                        tasks.Add(task);
                    }
                }
            }

            return tasks;
        }
        /// <summary>
        /// Find task by id
        /// </summary>
        /// <param name="id">TaskId</param>
        /// <returns>Task</returns>
        public ITask FindById(int id)
        {
            ITask task = null;
            using (var wrapper = ConnectionPool.Instance.GetConnection())
            {
                SqlConnection connection = wrapper.Instance;
                SqlCommand command = connection.CreateCommand();
                command.CommandText = SelectByIdQuery;
                command.Parameters.Add("taskId", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        task = _taskAssembler.Assemble(reader);
                        IPersonRepository personRepository = new PersonRepository();
                        task.Executor = personRepository.FindById(task.ExecutorId);
                    }
                }
            }

            return task;
        }



    }
}
