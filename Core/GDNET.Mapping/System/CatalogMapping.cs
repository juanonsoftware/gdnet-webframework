using System;
using GDNET.Base.DomainAbstraction;
using GDNET.Base.Utils;
using GDNET.Domain.Entities.System;
using GDNET.Mapping.Base;
using GDNET.Mapping.Common;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.System
{
    public class CatalogMapping : AbstractJoinedSubclassMapping<Catalog, Guid>, IEntityMapping
    {
        public CatalogMapping()
            : base()
        {
            var defaultDataLine = default(DataLine);

            base.Property(e => e.Code);
            base.Property(e => e.Name);
            base.Property(e => e.Description);
            base.Property(e => e.IsCustomizable);

            base.List(e => e.Lines, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(km => km.Column(MappingAssistant.GetForeignKeyColumn<Catalog>()));
                cm.Index(idx =>
                {
                    idx.Base(1);
                    idx.Column(ExpressionAssistant.GetPropertyName(() => defaultDataLine.Position));
                });
            }, m =>
            {
                m.OneToMany();
            });
        }
    }
}
