using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Base.DomainAbstraction;

namespace GDNET.Domain.Entities.System.Management
{
    public class EntityHistoryComplex : AbstractEntityWithCreationT<Guid>, IEntityHistoryComplex
    {
        protected IList<EntityLog> logs = new List<EntityLog>();

        public virtual EntityLog LastLog
        {
            get;
            protected internal set;
        }

        public virtual bool IsActive
        {
            get;
            set;
        }

        public virtual Int64 Views
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<EntityLog> Logs
        {
            get { return new ReadOnlyCollection<EntityLog>(this.logs); }
        }

        #region Methods

        public virtual void AddLogCreation()
        {
            this.AddLog("Creation", string.Empty);
        }

        public virtual void AddLog(string message, string contentText)
        {
            EntityLog logEntry = new EntityLog()
            {
                LogMessage = message,
                LogContentText = contentText,
            };
            logEntry.EntityHistory = this;

            this.logs.Add(logEntry);
            this.LastLog = logEntry;
        }

        #endregion
    }
}
