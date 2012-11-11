using System;
using System.Collections.Generic;
using System.Linq;
using GDNET.Base.DomainAbstraction;
using GDNET.Base.DomainRepository;
using GDNET.Domain.Base.Validators;
using GDNET.NHibernate.SessionManagement;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using Expressions = System.Linq.Expressions;

namespace GDNET.NHibernate.Repositories
{
    public abstract class AbstractRepository<TEntity, TId> : IRepositoryBase<TEntity, TId> where TEntity : IEntityT<TId>
    {
        protected ISession Session
        {
            get;
            set;
        }

        #region Ctors

        public AbstractRepository(ISession session)
        {
            this.Session = session;
        }

        public AbstractRepository(INHibernateRepositoryStrategy strategy)
        {
            this.Session = strategy.Session;
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

        protected IList<TEntity> GetAll(int limit, ICriterion criterion, Order order)
        {
            return this.GetAll(limit, new List<ICriterion> { criterion }, new List<Order> { order });
        }

        protected IList<TEntity> GetAll(int limit, IList<ICriterion> criterions, IList<Order> orders)
        {
            return this.GetAll(limit, criterions, true, orders);
        }

        protected IList<TEntity> GetAll(int limit, IList<ICriterion> criterions, bool andConditions, IList<Order> orders)
        {
            var criteria = this.Session.CreateCriteria(typeof(TEntity)).SetCacheable(true);
            criteria.SetMaxResults(limit);

            if (criterions != null)
            {
                if (andConditions)
                {
                    criterions.ForEach(x => { criteria.Add(x); });
                }
                else if (criterions.Count > 0)
                {
                    var criterionFinal = criterions[0];
                    for (int count = 1; count < criterions.Count; count++)
                    {
                        criterionFinal = Expression.Or(criterionFinal, criterions[count]);
                    }

                    criteria.Add(criterionFinal);
                }
            }

            if (orders != null)
            {
                orders.ForEach(y => { criteria.AddOrder(y); });
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
            TEntity result = this.Session.Get<TEntity>(id);
            return result;
        }

        public TEntity GetByProperty(string propertyName, object value)
        {
            var entities = this.FindByProperty(propertyName, value, 0, 1);
            return (entities.Count == 1) ? entities[0] : default(TEntity);
        }

        #endregion

        #region GetAll Methods

        public virtual IList<TEntity> GetAll()
        {
            return this.GetAll(0, 0);
        }

        /// <summary>
        /// Gets all entities (of TEntity type) from data store. We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        public virtual IList<TEntity> GetAll(int page, int pageSize)
        {
            var query = this.Session.Query<TEntity>().Cacheable();
            if (!(page == 0 && pageSize == 0))
            {
                query = query.Skip(page * pageSize).Take(pageSize);
            }
            return query.ToList();
        }

        public virtual IList<TEntity> GetAll(int page, int pageSize, out int totalRows)
        {
            var query = this.Session.Query<TEntity>().Cacheable();
            totalRows = query.Count();

            if (!(page == 0 && pageSize == 0))
            {
                query = query.Skip(page * pageSize).Take(pageSize);
            }
            return query.ToList();
        }

        public virtual IList<TEntity> GetTopByProperty(int limit, string orderByProperty)
        {
            var criteria = this.Session.CreateCriteria(typeof(TEntity)).SetCacheable(true);
            criteria.AddOrder(new Order(orderByProperty, false));
            criteria.SetFirstResult(0).SetMaxResults(limit);

            return criteria.List<TEntity>();
        }

        public virtual IList<TEntity> GetTopByProperty(int limit, string orderByProperty, IList<string> filterProperties, IList<object> filterValues)
        {
            var criteria = this.Session.CreateCriteria(typeof(TEntity)).SetCacheable(true);

            for (int counter = 0; counter < filterProperties.Count; counter++)
            {
                criteria.Add(Expression.Eq(filterProperties[counter], filterValues[counter]));
            }

            criteria.AddOrder(new Order(orderByProperty, false));
            criteria.SetFirstResult(0).SetMaxResults(limit);

            return criteria.List<TEntity>();
        }

        #endregion

        #region FindByProperty Methods

        public virtual IList<TEntity> FindByProperties(string[] properties, object[] values)
        {
            var criteria = this.Session.CreateCriteria(typeof(TEntity)).SetCacheable(true);
            for (int counter = 0; counter < properties.Length; counter++)
            {
                criteria.Add(Expression.Eq(properties[counter], values[counter]));
            }

            return criteria.List<TEntity>();
        }

        public virtual IList<TEntity> FindByProperties(string[] properties, object[] values, int page, int pageSize)
        {
            var criteria = this.Session.CreateCriteria(typeof(TEntity)).SetCacheable(true);
            for (int counter = 0; counter < properties.Length; counter++)
            {
                criteria.Add(Expression.Eq(properties[counter], values[counter]));
            }

            if (!(page == 0 && pageSize == 0))
            {
                criteria = criteria.SetFirstResult(page * pageSize).SetFetchSize(pageSize);
            }

            return criteria.List<TEntity>();
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        public IList<TEntity> FindByProperty(string property, object value)
        {
            return this.FindByProperty(property, value, 0, 0);
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and values of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="values">The value of the property.</param>
        public virtual IList<TEntity> FindByProperty(string property, object[] values)
        {
            DomainValidator.Instance.NullOrEmptyException(property);

            var criteria = this.Session.CreateCriteria(typeof(TEntity)).Add(Expression.In(property, values)).SetCacheable(true);
            return criteria.List<TEntity>();
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        public virtual IList<TEntity> FindByProperty(string property, object value, int page, int pageSize)
        {
            DomainValidator.Instance.NullOrEmptyException(property);

            var criteria = this.Session.CreateCriteria(typeof(TEntity)).Add(Expression.Eq(property, value));
            if (!(page == 0 && pageSize == 0))
            {
                criteria = criteria.SetFirstResult(page * pageSize).SetMaxResults(pageSize);
            }

            return criteria.SetCacheable(true).List<TEntity>();
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        public IList<TEntity> FindByProperty(string property, object value, string orderByProperty)
        {
            return this.FindByProperty(property, value, orderByProperty, true, 0, 0);
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        public IList<TEntity> FindByProperty(string property, object value, string orderByProperty, bool isAsc)
        {
            return this.FindByProperty(property, value, orderByProperty, isAsc, 0, 0);
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        public IList<TEntity> FindByProperty(string property, object value, string orderByProperty, int page, int pageSize)
        {
            return this.FindByProperty(property, value, orderByProperty, true, 0, 0);
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        public virtual IList<TEntity> FindByProperty(string property, object value, string orderByProperty, bool isAsc, int page, int pageSize)
        {
            var orderBy = new Order(orderByProperty, isAsc);
            var criteria = this.Session.CreateCriteria(typeof(TEntity)).Add(Expression.Eq(property, value));
            criteria = criteria.AddOrder(orderBy);

            if ((page != 0) || (pageSize != 0))
            {
                criteria = criteria.SetFirstResult(page * pageSize).SetMaxResults(pageSize);
            }

            return criteria.SetCacheable(true).List<TEntity>();
        }

        #endregion

        #region Save/update

        public bool Save(TEntity entity)
        {
            DomainValidator.Instance.NullException(entity);

            if (this.RepositoryGlass != null)
            {
                this.RepositoryGlass.ValidateOnCreation(entity);
            }

            // Saving entity
            this.Session.SaveOrUpdate(entity);

            return true;
        }

        public bool Save(IList<TEntity> entities)
        {
            DomainValidator.Instance.NullException(entities);

            foreach (var e in entities)
            {
                if (!this.Save(e))
                {
                    return false;
                }
            }

            return true;
        }

        public bool Update(TEntity entity)
        {
            DomainValidator.Instance.NullException(entity);

            this.Session.SaveOrUpdate(entity);

            return true;
        }

        public bool Update(IList<TEntity> entities)
        {
            DomainValidator.Instance.NullException(entities);

            foreach (var e in entities)
            {
                if (!this.Update(e))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Delete methods

        public bool Delete(TId id)
        {
            TEntity entity = this.LoadById(id);
            return this.Delete(entity);
        }

        public bool Delete(TEntity entity)
        {
            DomainValidator.Instance.NullException(entity);
            this.Session.Delete(entity);

            return true;
        }

        #endregion

        #endregion

    }
}
