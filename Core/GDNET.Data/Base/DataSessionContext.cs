using GDNET.Domain.Base.SessionManagement;
using GDNET.Domain.Entities.System;

namespace GDNET.Data.Base
{
    public sealed class DataSessionContext : DomainSessionContext
    {
        private User currentUser = null;

        public DataSessionContext(User currentUser)
            : base()
        {
            base.Initialize(this);
            this.currentUser = currentUser;
        }

        public override User CurrentUser
        {
            get { return this.currentUser; }
        }
    }
}
