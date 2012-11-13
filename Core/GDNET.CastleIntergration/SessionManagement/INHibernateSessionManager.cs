using NHibernate;

namespace GDNET.CastleIntergration.SessionManagement
{
    public interface INHibernateSessionManager
    {
        ISession GetSession();

        ITransaction BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        void CloseSession();
    }
}
