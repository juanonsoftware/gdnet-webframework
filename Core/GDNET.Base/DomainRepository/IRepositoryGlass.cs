namespace GDNET.Base.DomainRepository
{
    public interface IRepositoryGlass<TEntity>
    {
        void ValidateOnCreation(TEntity entity);
        void ValidateOnModification(TEntity entity);
    }
}
