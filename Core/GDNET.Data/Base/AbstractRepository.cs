using System;
using System.Collections.Generic;
using System.Linq;
using GDNET.Base.Common;
using GDNET.Base.DomainAbstraction;
using GDNET.Base.DomainRepository;
using GDNET.Domain.Base.Validators;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using Expressions = System.Linq.Expressions;
using NHOrder = NHibernate.Criterion.Order;
using Order = GDNET.Base.Common.Order;

namespace GDNET.Data.Base
{
    public abstract class AbstractRepository<TEntity, TId> : IRepositoryBase<TEntity, TId> where TEntity : IEntityT<TId>
    {
        protected ISession Session
        {
            get;
            private set;
        }

        #region Ctors

        public AbstractRepository(ISession session)
        {
            this.Session = session;
        }

        #endregion

        public IRepositoryGlass<TEntity> RepositoryGlass
        {
            get;
            set;
        }

        protected IQuery CreateQuery(string hqlQuery)
        {
            return this.Session.CreateQuery(hqlQuery);
        }

        protected IList<TEntity> GetAll(int limit, Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            var query = this.Session.Query<TEntity>().Cacheable();
            query = query.Where(predicate).Take(limit);

            return query.ToList();
        }

        protected IList<TEntity> GetAll(int limit, ICriterion criterion, NHOrder order)
        {
            return this.GetAll(limit, new List<ICriterion> { criterion }, new List<NHOrder> { order });
        }

        protected IList<TEntity> GetAll(int limit, IList<ICriterion> criterions, IList<NHOrder> orders)
        {
            return this.GetAll(limit, criterions, true, orders);
        }

        protected IList<TEntity> GetAll(int limit, IList<ICriterion> criterions, bool andConditions, IList<NHOrder> orders)
        {
            var criteria = CreateCriteria().SetCacheable(true);
            criteria.SetMaxResults(limit);

            if (criterions != null)
            {
                if (andConditions)
                {
                    criterions.ForEach(x => criteria.Add(x));
                }
                else if (criterions.Count > 0)
                {
                    var criterionFinal = criterions[0];
                    for (int count = 1; count < criterions.Count; count++)
                    {
                        criterionFinal = Restrictions.Or(criterionFinal, criterions[count]);
                    }

                    criteria.Add(criterionFinal);
                }
            }

            if (orders != null)
            {
                orders.ForEach(y => criteria.AddOrder(y));
            }

            return criteria.List<TEntity>();
        }

        #region IRepositoryBase<TEntity,TId> Members

        #region Get/load

        public TEntity LoadById(TId id)
        {
            return this.Session.Load<TEntity>(id);
        }

        public virtual TEntity GetById(TId id)
        {
            return this.Session.Get<TEntity>(id);
        }

        public TEntity GetByProperty(Filter filter)
        {
            var entities = this.FindByProperty(filter, new PageInfo(1, 0));
            return (entities.Items.Length == 1) ? entities.Items[0] : default(TEntity);
        }

        #endregion

        #region GetAll Methods

        public virtual IList<TEntity> GetAll()
        {
            return Session.Query<TEntity>().Cacheable().ToList();
        }

        /// <summary>
        /// Gets all entities (of TEntity type) from data store. We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <param name="limit">Limit number of items to be fetched</param>
        public virtual Page<TEntity> GetAll(PageInfo limit)
        {
            var entitiesCount = CreateCriteria().SetProjection(Projections.RowCount()).FutureValue<int>();
            var entities = CreateCriteria().SetFirstResult(limit.From).SetFetchSize(limit.Size).SetCacheable(true).Future<TEntity>();

            return new Page<TEntity>(entities, limit, entitiesCount.Value);
        }

        public virtual IList<TEntity> GetTopByProperty(int limit, string orderByProperty)
        {
            var criteria = CreateCriteria().AddOrder(new Order(orderByProperty, false).ToNhOrder());
            criteria.SetFirstResult(0).SetMaxResults(limit);

            return criteria.List<TEntity>();
        }

        public virtual IList<TEntity> GetTopByProperty(int limit, string orderByProperty, params Filter[] filters)
        {
            var criteria = CreateCriteria().AddOrder(new Order(orderByProperty, false).ToNhOrder())
                                           .SetFirstResult(0).SetMaxResults(limit);
            foreach (var filter in filters)
            {
                criteria.Add(Restrictions.Eq(filter.By, filter.Value));
            }

            return criteria.List<TEntity>();
        }

        #endregion

        #region FindByProperty Methods

        public virtual IList<TEntity> FindByProperties(params Filter[] filters)
        {
            var criteria = CreateCriteria().SetCacheable(true);
            foreach (var filter in filters)
            {
                criteria.Add(Restrictions.Eq(filter.By, filter.Value));
            }

            return criteria.List<TEntity>();
        }

        public virtual Page<TEntity> FindByProperties(PageInfo info, params Filter[] filters)
        {
            var criteriaEntities = CreateCriteria().SetFirstResult(info.From).SetFetchSize(info.Size);
            foreach (var filter in filters)
            {
                criteriaEntities.Add(Restrictions.Eq(filter.By, filter.Value));
            }

            var entities = criteriaEntities.Future<TEntity>();
            var entitiesCount = CreateCriteria().SetProjection(Projections.RowCount()).FutureValue<int>();

            return new Page<TEntity>(entities, info, entitiesCount.Value);
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        public Page<TEntity> FindByProperty(Filter filter)
        {
            return this.FindByProperty(filter, new PageInfo(int.MaxValue, 0));
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and values of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="values">The value of the property.</param>
        public virtual IList<TEntity> FindByProperty(string property, object[] values)
        {
            DomainValidator.NullOrEmptyException(property);

            var criteria = CreateCriteria().Add(Restrictions.In(property, values)).SetCacheable(true);
            return criteria.List<TEntity>();
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equ.al 0.
        /// </summary>
        public virtual Page<TEntity> FindByProperty(Filter filter, PageInfo page)
        {
            var criteria = CreateCriteria().Add(Restrictions.Eq(filter.By, filter.Value));
            var entities = criteria.SetFirstResult(page.From).SetMaxResults(page.Size).Future<TEntity>();
            var entitiesCount = CreateCriteria().SetProjection(Projections.RowCount()).FutureValue<int>();

            return new Page<TEntity>(entities, page, entitiesCount.Value);
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        public IList<TEntity> FindByProperty(Filter filter, Order order)
        {
            return this.FindByProperty(filter, order, new PageInfo(int.MaxValue, 0));
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        public IList<TEntity> FindByProperty(Filter filter, Order order, PageInfo paging)
        {
            var criteria = CreateCriteria().Add(Restrictions.Eq(filter.By, filter.Value));
            criteria.AddOrder(order.ToNhOrder());
            criteria.SetFirstResult(paging.From).SetFetchSize(paging.Size);

            return criteria.SetCacheable(true).List<TEntity>();
        }


        #endregion

        #region Save/update

        public bool Save(TEntity entity)
        {
            DomainValidator.NullException(entity);

            if (RepositoryGlass != null)
            {
                RepositoryGlass.ValidateOnCreation(entity);
            }
            Session.SaveOrUpdate(entity);

            return true;
        }

        public bool Save(IList<TEntity> entities)
        {
            DomainValidator.NullException(entities);
            return entities.All(Save);
        }

        public bool Update(TEntity entity)
        {
            DomainValidator.NullException(entity);
            Session.SaveOrUpdate(entity);
            return true;
        }

        public bool Update(IList<TEntity> entities)
        {
            DomainValidator.NullException(entities);
            return entities.All(Update);
        }

        #endregion

        #region Delete methods

        public bool Delete(TId id)
        {
            return Delete(LoadById(id));
        }

        public bool Delete(TEntity entity)
        {
            DomainValidator.NullException(entity);
            Session.Delete(entity);

            return true;
        }

        #endregion

        private ICriteria CreateCriteria()
        {
            return Session.CreateCriteria(typeof(TEntity));
        }

        #endregion

    }
}
