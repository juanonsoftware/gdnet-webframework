using System;

namespace GDNET.Base.DomainAbstraction
{
    public abstract class AbstractEntityWithCreationT<TId> : AbstractEntityT<TId>, IEntityWithCreation
    {
        private DateTime createdAt = DateTime.MinValue;
        private string createdBy = string.Empty;

        public virtual DateTime CreatedAt
        {
            get { return createdAt; }
        }

        public virtual string CreatedBy
        {
            get { return createdBy; }
        }
    }
}
