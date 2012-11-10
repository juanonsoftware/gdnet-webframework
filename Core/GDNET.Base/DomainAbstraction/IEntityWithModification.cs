using System;

namespace GDNET.Base.DomainAbstraction
{
    public interface IEntityWithModification : IEntityWithCreation
    {
        DateTime? LastModifiedAt { get; }
        string LastModifiedBy { get; }
    }
}
