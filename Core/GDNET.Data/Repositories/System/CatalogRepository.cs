using System;
using GDNET.Base;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories.ReferenceData;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagement;

namespace GDNET.Data.Repositories.System
{
    public class CatalogRepository : AbstractRepository<Catalog, Guid>, ICatalogRepository
    {
        public CatalogRepository(INHibernateRepositoryStrategy strategy)
            : base(strategy)
        {
        }

        public Catalog FindByCode(string code)
        {
            var defaultCatalog = default(Catalog);
            string codeProperty = ExpressionAssistant.GetPropertyName(() => defaultCatalog.Code);

            var listOfCatalogs = base.FindByProperty(codeProperty, code);
            return (listOfCatalogs.Count > 0 ? listOfCatalogs[0] : null);
        }
    }
}
