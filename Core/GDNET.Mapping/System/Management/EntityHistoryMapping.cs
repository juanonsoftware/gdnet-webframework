using System;
using GDNET.Domain.Entities.System.Management;
using GDNET.Mapping.Base;
using GDNET.NHibernate.Mapping;
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
