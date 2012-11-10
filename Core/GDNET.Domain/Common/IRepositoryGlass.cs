namespace GDNET.Domain.Common
{
    public interface IRepositoryGlass<TEntity>
    {
        void ValidateOnCreation(TEntity entity);
        void ValidateOnModification(TEntity entity);
    }
}
