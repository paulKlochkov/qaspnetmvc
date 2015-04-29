using Qulix.Data.Common;
using System;
namespace Qulix.Data.Repository
{
    public interface IPersonRepository : IEntityRepository<int, IPerson>
    {
        IPerson FindById(int id);
        void DeleteById(int id);
        int Count();
    }
}
