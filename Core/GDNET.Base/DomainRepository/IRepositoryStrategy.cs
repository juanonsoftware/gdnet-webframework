namespace GDNET.Base.DomainRepository
{
    public interface IRepositoryStrategy
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

        void Flush();
        void Clear();
        void FlushAndClear();
    }
}
