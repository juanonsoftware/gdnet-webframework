using System;
using GDNET.Base.DomainAbstraction;
using GDNET.Domain.Base.Exceptions;

namespace GDNET.Domain.Entities.System.Management
{
    public class EntityLog : AbstractEntityT<Guid>, IEntityWithCreation
    {
        protected EntityHistoryComplex entityHistory;

        public virtual DateTime CreatedAt
        {
            get;
            set;
        }

        public virtual string CreatedBy
        {
            get;
            set;
        }

        public virtual string LogMessage
        {
            get;
            set;
        }

        public virtual string LogContentText
        {
            get;
            set;
        }

        public virtual EntityHistoryComplex EntityHistory
        {
            get { return entityHistory; }
            set
            {
                if (entityHistory != null)
                {
                    ExceptionsManager.BusinessException.Throw("Could not modify entity history");
                }
                entityHistory = value;
            }
        }
    }
}
