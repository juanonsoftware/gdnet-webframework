using System;
using GDNET.Base.DomainRepository;
using GDNET.Domain.Entities.System;

namespace GDNET.Domain.Repositories.ReferenceData
{
    public interface ICatalogRepository : IRepositoryBase<Catalog, Guid>
    {
        Catalog FindByCode(string code);
    }
}
