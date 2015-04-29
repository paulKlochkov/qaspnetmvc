using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qulix.Data.Repository
{
    public interface IEntityRepository<TKey, TEntity>
    {
        TEntity Create(TEntity entity);
        void Delete(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Update(TKey key, TEntity value);
        ICollection<TEntity> GetAllEnities();
    }
}
