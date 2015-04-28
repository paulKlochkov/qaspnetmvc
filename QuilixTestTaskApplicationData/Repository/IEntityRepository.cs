using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qulix.Data.Repository
{
    interface IEntityRepository<TEntity>
    {
        TEntity Create(TEntity entity);
        void Delete(TEntity entity);
        TEntity Update(TEntity entity);
        ICollection<TEntity> GetAllEnities();
    }
}
