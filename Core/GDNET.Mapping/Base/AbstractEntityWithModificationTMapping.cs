using GDNET.Base;
using GDNET.Base.DomainAbstraction;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.Base
{
    public abstract class AbstractEntityWithModificationTMapping<TObject, TId> : AbstractEntityWithCreationTMapping<TObject, TId>
        where TObject : AbstractEntityWithModificationT<TId>
    {
        public AbstractEntityWithModificationTMapping(IGeneratorDef generator)
            : base(generator)
        {
            base.Property(e => e.LastModifiedAt, m =>
            {
                m.Column(EntityWithModificationMeta.LastModifiedAt);
                m.Access(Accessor.Field);
            });
            base.Property(e => e.LastModifiedBy, m =>
            {
                m.Column(EntityWithModificationMeta.LastModifiedBy);
                m.Access(Accessor.Field);
            });
        }
    }
}
