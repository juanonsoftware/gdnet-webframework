using System;
using System.ComponentModel.DataAnnotations;
using GDNET.Base.DomainAbstraction;
using GDNET.Domain.Entities.System.Management;
using GDNET.Framework.DataAnnotations;

namespace GDNET.Framework.Base
{
    public abstract class AbstractViewModel<T> where T : IEntity
    {
        #region Properties

        public string Id
        {
            get;
            protected set;
        }

        [Required]
        [DisplayNameML("GUI.Entity.IsActive")]
        public bool IsActive
        {
            get;
            set;
        }

        [DisplayNameML("GUI.Entity.CreatedAt")]
        public DateTime CreatedAt
        {
            get;
            set;
        }

        [DisplayNameML("GUI.Entity.CreatedBy")]
        public string CreatedBy
        {
            get;
            set;
        }

        [DisplayNameML("GUI.Entity.LastModifiedAt")]
        public DateTime? LastModifiedAt
        {
            get;
            set;
        }

        [DisplayNameML("GUI.Entity.LastModifiedBy")]
        public string LastModifiedBy
        {
            get;
            set;
        }

        #region Mode

        public ViewModelMode Mode
        {
            get;
            set;
        }

        public bool IsCreation
        {
            get { return this.Mode == ViewModelMode.Creation; }
        }

        #endregion

        #endregion

        #region Methods

        public void Initialize(T entity)
        {
            this.Initialize(entity, false);
        }

        public abstract void Initialize(T entity, bool filterActiveOnly);

        protected void InitializeCommon(T entity)
        {
            if (entity is IEntityWithCreation)
            {
                this.CreatedAt = ((IEntityWithCreation)entity).CreatedAt;
                this.CreatedBy = ((IEntityWithCreation)entity).CreatedBy;
            }

            if (entity is IEntityWithModification)
            {
                this.LastModifiedAt = ((IEntityWithModification)entity).LastModifiedAt;
                this.LastModifiedBy = ((IEntityWithModification)entity).LastModifiedBy;
            }

            if (entity is IEntityHistoryComplex)
            {
                this.IsActive = ((IEntityHistoryComplex)entity).IsActive;

                var lastLog = ((IEntityHistoryComplex)entity).LastLog;
                if (lastLog != null)
                {
                    this.LastModifiedAt = lastLog.CreatedAt;
                    this.LastModifiedBy = lastLog.CreatedBy;
                }
            }
        }

        #endregion
    }
}
