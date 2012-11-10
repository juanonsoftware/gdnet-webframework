using GDNET.Domain.Entities.System;

namespace GDNET.Domain.Base.SessionManagement
{
    public abstract class DomainSessionContext : ISessionContext
    {
        public static ISessionContext Instance
        {
            get;
            private set;
        }

        protected void Initialize(ISessionContext context)
        {
            Instance = context;
        }

        public abstract User CurrentUser { get; }
    }
}
