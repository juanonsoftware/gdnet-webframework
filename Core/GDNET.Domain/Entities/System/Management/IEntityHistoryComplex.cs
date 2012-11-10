using System;
using GDNET.Base.DomainAbstraction;

namespace GDNET.Domain.Entities.System.Management
{
    public interface IEntityHistoryComplex : IEntityWithCreation
    {
        EntityLog LastLog { get; }

        bool IsActive { get; set; }
        Int64 Views { get; set; }

        void AddLogCreation();
        void AddLog(string message, string contentText);
    }
}
