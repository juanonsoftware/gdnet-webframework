using System;
using GDNET.Domain.Entities.System.Management;
using GDNET.Mapping.Base;
using GDNET.Mapping.Common;
using GDNET.NHibernate.Mapping;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.System.Management
{
    public class EntityHistoryComplexMapping : AbstractEntityWithCreationTMapping<EntityHistoryComplex, Guid>, IEntityMapping
    {
        public EntityHistoryComplexMapping()
            : base(Generators.Guid)
        {
            var defaultEntity = default(EntityHistoryComplex);
            var defaultEntityLog = default(EntityLog);

            base.Property(x => x.IsActive);
            base.Property(x => x.Views);

            base.ManyToOne(x => x.LastLog, m =>
            {
                m.Fetch(FetchKind.Join);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Lazy(LazyRelation.NoLazy);
                m.Column(MappingAssistant.GetForeignKeyColumn(() => defaultEntity.LastLog));
            });

            base.Bag(x => x.Logs, cm =>
            {
                cm.Inverse(true);
                cm.Access(Accessor.Field);
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(km => km.Column(MappingAssistant.GetForeignKeyColumn(() => defaultEntityLog.EntityHistory)));
            }, m =>
            {
                m.OneToMany();
            });
        }
    }
}
