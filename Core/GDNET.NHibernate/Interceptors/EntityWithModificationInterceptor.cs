using System;
using System.Linq;
using GDNET.Base;
using GDNET.Base.DomainAbstraction;
using GDNET.Domain.Base.SessionManagement;
using NHibernate;
using NHibernate.Type;

namespace GDNET.NHibernate.Interceptors
{
    public class EntityWithModificationInterceptor : EmptyInterceptor
    {
        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            return this.UpdateEntity(entity, ref state, ref propertyNames);
        }

        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
        {
            return this.UpdateEntity(entity, ref currentState, ref propertyNames);
        }

        private bool UpdateEntity(object entity, ref object[] state, ref string[] propertyNames)
        {
            this.UpdateEntityWithCreation(entity, ref state, ref propertyNames);
            this.UpdateEntityWithModification(entity, ref state, ref propertyNames);

            return true;
        }

        protected virtual void UpdateEntityWithCreation(object entity, ref object[] state, ref string[] propertyNames)
        {
            if (entity is IEntityWithCreation)
            {
                var propertyIndex = propertyNames.ToList().IndexOf(EntityWithModificationMeta.CreatedBy);
                if (string.IsNullOrEmpty((string)state[propertyIndex]))
                {
                    state[propertyIndex] = this.GetEmailCurrentUser();

                    propertyIndex = propertyNames.ToList().IndexOf(EntityWithModificationMeta.CreatedAt);
                    state[propertyIndex] = DateTime.Now;
                }
            }
        }

        protected virtual void UpdateEntityWithModification(object entity, ref object[] state, ref string[] propertyNames)
        {
            if (entity is IEntityWithModification)
            {
                var entityWithModification = (IEntityWithModification)entity;

                if (string.IsNullOrEmpty(entityWithModification.CreatedBy))
                {
                    var propertyIndex = propertyNames.ToList().IndexOf(EntityWithModificationMeta.CreatedAt);
                    state[propertyIndex] = DateTime.Now;

                    propertyIndex = propertyNames.ToList().IndexOf(EntityWithModificationMeta.CreatedBy);
                    state[propertyIndex] = this.GetEmailCurrentUser();
                }
                else
                {
                    var propertyIndex = propertyNames.ToList().IndexOf(EntityWithModificationMeta.LastModifiedAt);
                    state[propertyIndex] = DateTime.Now;

                    propertyIndex = propertyNames.ToList().IndexOf(EntityWithModificationMeta.LastModifiedBy);
                    state[propertyIndex] = this.GetEmailCurrentUser();
                }
            }
        }

        protected virtual string GetEmailCurrentUser()
        {
            if (DomainSessionContext.Instance.CurrentUser == null)
            {
                return string.Empty;
            }
            else
            {
                return DomainSessionContext.Instance.CurrentUser.Email;
            }
        }
    }
}
