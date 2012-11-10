using GDNET.Base;
using GDNET.Base.DomainAbstraction;
using GDNET.Mapping.Common;
using NHibernate.Mapping.ByCode.Conformist;

namespace GDNET.Mapping.Base
{
    public abstract class AbstractJoinedSubclassMapping<TObject, TId> : JoinedSubclassMapping<TObject>
        where TObject : AbstractEntityT<TId>
    {
        public AbstractJoinedSubclassMapping()
        {
            base.DynamicUpdate(true);
            base.DynamicInsert(true);

            base.Table(MappingAssistant.GetStrongTableByType(typeof(TObject)));
            base.Key(km => km.Column(EntityWithModificationMeta.Id));
        }
    }
}
