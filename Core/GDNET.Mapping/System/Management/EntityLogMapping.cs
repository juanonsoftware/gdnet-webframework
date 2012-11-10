using System;
using GDNET.Base;
using GDNET.Domain.Entities.System.Management;
using GDNET.Mapping.Base;
using GDNET.Mapping.Common;
using GDNET.NHibernate.Mapping;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.System.Management
{
    public class EntityLogMapping : AbstractEntityTMapping<EntityLog, Guid>, IEntityMapping
    {
        private EntityLog defaultEntity = default(EntityLog);

        public EntityLogMapping()
            : base(Generators.Guid)
        {
            base.Property(e => e.CreatedAt, m =>
            {
                m.Column(EntityWithModificationMeta.CreatedAt);
                m.Access(Accessor.Property);
                m.NotNullable(true);
            });
            base.Property(e => e.CreatedBy, m =>
            {
                m.Column(EntityWithModificationMeta.CreatedBy);
                m.Access(Accessor.Property);
                m.NotNullable(true);
            });
            base.Property(e => e.LogContentText, m =>
            {
                m.Column(ExpressionAssistant.GetPropertyName(() => defaultEntity.LogContentText));
                m.Access(Accessor.Property);
            });
            base.Property(e => e.LogMessage, m =>
            {
                m.Column(ExpressionAssistant.GetPropertyName(() => defaultEntity.LogMessage));
                m.Access(Accessor.Property);
                m.NotNullable(true);
            });
            base.ManyToOne(x => x.EntityHistory, m =>
            {
                m.Cascade(Cascade.All);
                m.Access(Accessor.Field);
                m.Column(MappingAssistant.GetForeignKeyColumn(() => defaultEntity.EntityHistory));
            });
        }
    }
}
