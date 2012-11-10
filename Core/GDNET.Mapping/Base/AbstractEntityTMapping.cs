using GDNET.Base;
using GDNET.Base.DomainAbstraction;
using GDNET.Mapping.Common;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace GDNET.Mapping.Base
{
    public abstract class AbstractEntityTMapping<TObject, TId> : ClassMapping<TObject>
        where TObject : AbstractEntityT<TId>
    {
        public AbstractEntityTMapping(IGeneratorDef generator)
        {
            base.Lazy(true);
            base.DynamicUpdate(true);
            base.DynamicInsert(true);

            base.Table(MappingAssistant.GetStrongTableByType(typeof(TObject)));

            base.Id<TId>(e => e.Id, m =>
            {
                m.Generator(generator);
                m.Column(EntityWithModificationMeta.Id);
                m.Access(Accessor.Field);
            });
        }
    }
}
