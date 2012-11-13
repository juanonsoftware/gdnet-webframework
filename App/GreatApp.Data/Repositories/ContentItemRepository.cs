using System;
using System.Collections.Generic;
using GDNET.Base;
using GDNET.Base.Utils;
using GDNET.Data.Base;
using GreatApp.Domain.Entities;
using GreatApp.Domain.Repositories;
using NHibernate;
using NHibernate.Criterion;

namespace GreatApp.Data.Repositories
{
    public class ContentItemRepository : AbstractRepository<ContentItem, Guid>, IContentItemRepository
    {
        private static readonly ContentItem DefaultContentItem = default(ContentItem);

        public ContentItemRepository(ISession session)
            : base(session)
        {
        }

        public IList<ContentItem> GetAllByAuthor(string createdByEmail)
        {
            return base.FindByProperty(EntityWithModificationMeta.CreatedBy, createdByEmail);
        }

        public IList<ContentItem> GetTopWithActive(int limit)
        {
            var propertyIsActive = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.IsActive);
            return base.GetTopByProperty(limit, EntityWithModificationMeta.CreatedAt, new List<string> { propertyIsActive }, new List<object> { true });
        }

        public IList<ContentItem> GetTopWithActiveByViews(int limit)
        {
            var propertyViews = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.Views);
            var propertyIsActive = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.IsActive);

            return base.GetAll(limit, Expression.Eq(propertyIsActive, true), new Order(propertyViews, false));
        }

        public IList<ContentItem> GetTopWithActiveByViews(int limit, Guid itemIdExclude)
        {
            var propertyViews = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.Views);
            var propertyIsActive = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.IsActive);

            var criterions = new List<ICriterion>()
            { 
                Expression.Eq(propertyIsActive, true),
                Expression.Not(Expression.Eq(EntityWithModificationMeta.Id, itemIdExclude)),
            };
            var orders = new List<Order>() 
            {
                new Order(propertyViews, false)
            };

            return base.GetAll(limit, criterions, orders);
        }

        public IList<ContentItem> GetTopWithActiveByAuthor(int limit, string authorEmail)
        {
            var propertyIsActive = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.IsActive);

            var criterions = new List<ICriterion>()
            { 
                Expression.Eq(propertyIsActive, true),
                Expression.Eq(EntityWithModificationMeta.CreatedBy, authorEmail),
            };
            var orders = new List<Order>() 
            {
                new Order(EntityWithModificationMeta.CreatedBy, false),
                //TODO: Need to order by CreatedAt of LastLog
                //new Order(EntityWithModificationMeta.LastModifiedAt, false)
            };

            return base.GetAll(limit, criterions, orders);
        }

        public IList<ContentItem> SearchTopWithActive(int limit, string query)
        {
            string propertyName = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.Name);
            string propertyDescription = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.Description);

            var criterionName = Expression.Like(propertyName, query, MatchMode.Anywhere);
            var criterionDescription = Expression.Like(propertyDescription, query, MatchMode.Anywhere);
            var criterions = new List<ICriterion>()
            {
                criterionName,
                criterionDescription
            };

            var orders = new List<Order>() 
            {
                new Order(EntityWithModificationMeta.CreatedBy, false),
                //TODO: Need to order by CreatedAt of LastLog
                //new Order(EntityWithModificationMeta.LastModifiedAt, false)
            };

            return base.GetAll(limit, criterions, false, orders);
        }
    }
}
