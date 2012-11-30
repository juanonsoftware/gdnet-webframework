using System.Collections.Generic;
using GDNET.Base.Common;
using GDNET.Base.DomainAbstraction;

namespace GDNET.Base.DomainRepository
{
    public interface IRepositoryBase<TEntity, TId> where TEntity : IEntityT<TId>
    {
        IRepositoryGlass<TEntity> RepositoryGlass
        {
            get;
            set;
        }

        /// <summary>
        /// Try to load an entity, it's not query to data store if we don't access file other than its id.
        /// </summary>
        TEntity LoadById(TId id);

        /// <summary>
        /// Gets entity from data store by its id.
        /// </summary>
        TEntity GetById(TId id);

        /// <summary>
        /// Gets entity from data store by a property.
        /// </summary>
        TEntity GetByProperty(Filter filter);

        /// <summary>
        /// Gets all entities (of TEntity type) from data store.
        /// </summary>
        IList<TEntity> GetAll();

        /// <summary>
        /// Gets all entities (of TEntity type) from data store. We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <param name="limit">Limit number of items to be fetched</param>
        Page<TEntity> GetAll(PageInfo limit);

        IList<TEntity> GetTopByProperty(int limit, string orderByProperty);
        IList<TEntity> GetTopByProperty(int limit, string orderByProperty, params Filter[] filters);

        IList<TEntity> FindByProperties(params Filter[] filters);
        Page<TEntity> FindByProperties(PageInfo info, params Filter[] filters);

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        Page<TEntity> FindByProperty(Filter filter);

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        Page<TEntity> FindByProperty(Filter filter, PageInfo page);

        /// <summary>
        /// Retrieves a collection of entities based on the name and values of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="values">The value of the property.</param>
        IList<TEntity> FindByProperty(string property, object[] values);

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        IList<TEntity> FindByProperty(Filter filter, Order order);

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        IList<TEntity> FindByProperty(Filter filter, Order order, PageInfo paging);

        /// <summary>
        /// Save an entity to data store.
        /// </summary>
        bool Save(TEntity entity);

        /// <summary>
        /// Save many entities to data store.
        /// </summary>
        bool Save(IList<TEntity> entities);

        /// <summary>
        /// Update an entity to data store.
        /// </summary>
        bool Update(TEntity entity);
        /// <summary>
        /// Update many entities to data store.
        /// </summary>
        bool Update(IList<TEntity> entities);

        /// <summary>
        /// Delete entity from data store by its id.
        /// </summary>
        bool Delete(TId id);

        /// <summary>
        /// Delete entity from data store.
        /// </summary>
        bool Delete(TEntity entity);
    }
}
