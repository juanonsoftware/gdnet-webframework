using System;
using GDNET.Base.Common;
using GDNET.Base.Utils;
using GDNET.Data.Base;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories.ReferenceData;
using NHibernate;

namespace GDNET.Data.Repositories.System
{
    public class CatalogRepository : AbstractRepository<Catalog, Guid>, ICatalogRepository
    {
        private static readonly Catalog DefaultCatalog = default(Catalog);

        public CatalogRepository(ISession session)
            : base(session)
        {
        }

        public Catalog FindByCode(string code)
        {
            var codeProperty = ExpressionAssistant.GetPropertyName(() => DefaultCatalog.Code);
            var catalogs = base.FindByProperty(new Filter(codeProperty, code));
            return (catalogs.Items.Length > 0 ? catalogs.Items[0] : null);
        }
    }
}
