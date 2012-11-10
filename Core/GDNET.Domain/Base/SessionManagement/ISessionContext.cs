using GDNET.Domain.Entities.System;

namespace GDNET.Domain.Base.SessionManagement
{
    public interface ISessionContext
    {
        User CurrentUser { get; }
    }
}
