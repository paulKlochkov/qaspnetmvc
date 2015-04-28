using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qulix.Data.Repository
{
    public abstract class Repository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        public TEntity Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> GetAllEnities()
        {
            throw new NotImplementedException();
        }
    }
}
