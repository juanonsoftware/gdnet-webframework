using System;

namespace GDNET.Base.DomainAbstraction
{
    public interface IEntityWithCreation : IEntity
    {
        DateTime CreatedAt { get; }
        string CreatedBy { get; }
    }
}
