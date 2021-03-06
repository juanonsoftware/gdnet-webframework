﻿using System;
using GDNET.Base.DomainAbstraction;
using GDNET.Domain.Entities.System;
using GDNET.Mapping.Base;

namespace GDNET.Mapping.System
{
    public class DataLineMapping : AbstractJoinedSubclassMapping<DataLine, Guid>, IEntityMapping
    {
        public DataLineMapping()
            : base()
        {
            base.Property(e => e.Code);
            base.Property(e => e.Name);
            base.Property(e => e.Description);
            base.Property(e => e.Position);
        }
    }
}
