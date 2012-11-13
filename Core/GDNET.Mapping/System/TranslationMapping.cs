using System;
using GDNET.Base.DomainAbstraction;
using GDNET.Domain.Entities.System;
using GDNET.Mapping.Base;

namespace GDNET.Mapping.System
{
    public class TranslationMapping : AbstractJoinedSubclassMapping<Translation, Guid>, IEntityMapping
    {
        public TranslationMapping()
            : base()
        {
            base.Property(e => e.Keyword);
            base.Property(e => e.Language);
            base.Property(e => e.Value);
        }
    }
}
