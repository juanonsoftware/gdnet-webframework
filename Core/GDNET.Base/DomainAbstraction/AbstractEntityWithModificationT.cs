using System;

namespace GDNET.Base.DomainAbstraction
{
    public abstract class AbstractEntityWithModificationT<TId> : AbstractEntityWithCreationT<TId>, IEntityWithModification
    {
        private DateTime? lastModifiedAt = null;
        private string lastModifiedBy = string.Empty;

        public virtual DateTime? LastModifiedAt
        {
            get { return lastModifiedAt; }
        }

        public virtual string LastModifiedBy
        {
            get { return lastModifiedBy; }
        }
    }
}
