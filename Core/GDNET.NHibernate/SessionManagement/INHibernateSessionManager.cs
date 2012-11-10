using NHibernate;

namespace GDNET.NHibernate.SessionManagement
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
