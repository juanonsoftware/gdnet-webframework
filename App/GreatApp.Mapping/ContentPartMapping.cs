using System;
using GDNET.Base.DomainAbstraction;
using GDNET.Mapping.Base;
using GDNET.Mapping.Common;
using GreatApp.Domain.Entities;
using NHibernate.Mapping.ByCode;

namespace GreatApp.Mapping
{
    public class ContentPartMapping : AbstractJoinedSubclassMapping<ContentPart, Guid>, IEntityMapping
    {
        public ContentPartMapping()
            : base()
        {
            var defaultContentPart = default(ContentPart);

            base.Property(e => e.Name, m => m.NotNullable(true));
            base.Property(e => e.Details, m => m.NotNullable(true));

            base.ManyToOne(x => x.ContentItem, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Access(Accessor.Property);
                m.Column(MappingAssistant.GetForeignKeyColumn(() => defaultContentPart.ContentItem));
            });
        }
    }
}
