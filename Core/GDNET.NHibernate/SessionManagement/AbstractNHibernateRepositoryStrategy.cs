using NHibernate;

namespace GDNET.NHibernate.SessionManagement
{
    public abstract class AbstractNHibernateRepositoryStrategy : INHibernateRepositoryStrategy
    {
        protected INHibernateSessionManager sessionManager;
        protected ITransaction transaction;

        public AbstractNHibernateRepositoryStrategy(INHibernateSessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        public ISession Session
        {
            get { return this.sessionManager.GetSession(); }
        }

        public void BeginTransaction()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
                this.transaction.Dispose();
            }

            this.transaction = this.sessionManager.GetSession().BeginTransaction();
        }

        public void Commit()
        {
            if (this.transaction != null)
            {
                this.transaction.Commit();
                this.transaction.Dispose();
            }
        }

        public void Rollback()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
                this.transaction.Dispose();
            }
        }

        public void Flush()
        {
            this.sessionManager.GetSession().Flush();
        }

        public void Clear()
        {
            this.sessionManager.GetSession().Clear();
        }

        public void FlushAndClear()
        {
            this.Flush();
            this.Clear();
        }
    }
}
