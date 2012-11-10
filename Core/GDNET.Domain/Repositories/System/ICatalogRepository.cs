using System;
using GDNET.Base.DomainRepository;
using GDNET.Domain.Entities.System;

namespace GDNET.Domain.Repositories.System
{
    public interface ICatalogRepository : IRepositoryBase<Catalog, Guid>
    {
        Catalog FindByCode(string code);
    }
}
