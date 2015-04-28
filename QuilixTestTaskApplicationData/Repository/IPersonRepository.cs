using System;
namespace Qulix.Data.Repository
{
    public interface IPersonRepository : IEntityRepository<Qulix.Data.Common.IPerson>
    {
        Qulix.Data.Common.IPerson Create(Qulix.Data.Common.IPerson entity);
        void Delete(Qulix.Data.Common.IPerson entity);
        System.Collections.Generic.ICollection<Qulix.Data.Common.IPerson> GetAllEnities();
        Qulix.Data.Common.IPerson Update(Qulix.Data.Common.IPerson entity);
        Qulix.Data.Common.IPerson FindById(int id);
    }
}
