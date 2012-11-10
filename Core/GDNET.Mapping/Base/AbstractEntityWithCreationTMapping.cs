using GDNET.Base;
using GDNET.Base.DomainAbstraction;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.Base
{
    public abstract class AbstractEntityWithCreationTMapping<TObject, TId> : AbstractEntityTMapping<TObject, TId>
        where TObject : AbstractEntityWithCreationT<TId>
    {
        public AbstractEntityWithCreationTMapping(IGeneratorDef generator)
            : base(generator)
        {
            base.Property(e => e.CreatedAt, m =>
            {
                m.Column(EntityWithModificationMeta.CreatedAt);
                m.Access(Accessor.Field);
                m.NotNullable(true);
            });
            base.Property(e => e.CreatedBy, m =>
            {
                m.Column(EntityWithModificationMeta.CreatedBy);
                m.Access(Accessor.Field);
                m.NotNullable(true);
            });
        }
    }
}
