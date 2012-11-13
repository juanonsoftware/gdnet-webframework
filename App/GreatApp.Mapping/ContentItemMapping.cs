using System;
using GDNET.Base.DomainAbstraction;
using GDNET.Base.Utils;
using GDNET.Mapping.Base;
using GDNET.Mapping.Common;
using GreatApp.Domain.Entities;
using NHibernate.Mapping.ByCode;

namespace GreatApp.Mapping
{
    public class ContentItemMapping : AbstractJoinedSubclassMapping<ContentItem, Guid>, IEntityMapping
    {
        public ContentItemMapping()
            : base()
        {
            var defaultContentPart = default(ContentPart);
            var defaultContentItem = default(ContentItem);

            base.Property(e => e.Name, m => m.NotNullable(true));
            base.Property(e => e.Description);
            base.Property(e => e.Keywords);

            base.ManyToOne(e => e.Language, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Access(Accessor.Property);
                m.Cascade(Cascade.None);
                m.Column(MappingAssistant.GetForeignKeyColumn(() => defaultContentItem.Language));
            });

            base.List(e => e.Parts, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(km => km.Column(MappingAssistant.GetForeignKeyColumn(() => defaultContentPart.ContentItem)));
                cm.Index(idx =>
                {
                    idx.Base(1);
                    idx.Column(ExpressionAssistant.GetPropertyName(() => defaultContentPart.Position));
                });
            }, m =>
            {
                m.OneToMany(mapping => mapping.NotFound(NotFoundMode.Exception));
            });
        }
    }
}
