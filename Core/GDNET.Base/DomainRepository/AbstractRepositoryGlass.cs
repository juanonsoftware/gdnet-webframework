using GDNET.Base.DomainAbstraction;

namespace GDNET.Base.DomainRepository
{
    public class AbstractRepositoryGlass<TEntity, TId> : IRepositoryGlass<TEntity> where TEntity : IEntityT<TId>
    {
        public virtual void ValidateOnCreation(TEntity entity) { }

        public virtual void ValidateOnModification(TEntity entity) { }
    }
}
