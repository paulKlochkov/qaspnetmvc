using System;
using Qulix.Data.Common;
using System.Collections.Generic;

namespace Qulix.Data.Repository
{
    public interface ITaskRepository : IEntityRepository<int, ITask>
    {
        ITask FindById(int id);
        void DeleteById(int key);
    }
}
