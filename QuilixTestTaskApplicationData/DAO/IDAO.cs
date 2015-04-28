using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quilix.Data.DAO
{
    interface IDAO<TEntity>
    {
        TEntity Create(TEntity entity);
        void Delete(TEntity entity);
        TEntity Update(TEntity entity);
    }
}
