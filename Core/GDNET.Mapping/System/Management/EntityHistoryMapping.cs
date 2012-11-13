using System;
using GDNET.Base.DomainAbstraction;
using GDNET.Domain.Entities.System.Management;
using GDNET.Mapping.Base;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.System.Management
{
    public class EntityHistoryMapping : AbstractEntityWithModificationTMapping<EntityHistory, Guid>, IEntityMapping
    {
        public EntityHistoryMapping()
            : base(Generators.Guid)
        {
        }
    }
}
