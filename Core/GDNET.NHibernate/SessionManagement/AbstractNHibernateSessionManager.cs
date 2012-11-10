using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace GDNET.NHibernate.SessionManagement
{
    public abstract class AbstractNHibernateSessionManager : INHibernateSessionManager
    {
        protected static ISessionFactory _sessionFactory = null;

        /// <summary>
        /// Must be defined in sub-classes
        /// </summary>
        public static AbstractNHibernateSessionManager Instance
        {
            get { throw new NotImplementedException("Must be implemented in concrete implementation."); }
        }

        public Configuration Configuration
        {
            get;
            protected set;
        }

        public virtual ISession GetSession()
        {
            if (CurrentSessionContext.HasBind(_sessionFactory))
            {
                return _sessionFactory.GetCurrentSession();
            }
            else
            {
                var nhSession = _sessionFactory.OpenSession();
                CurrentSessionContext.Bind(nhSession);

                return nhSession;
            }
        }

        public virtual ITransaction BeginTransaction()
        {
            this.RollbackTransaction();
            return this.GetSession().BeginTransaction();
        }

        public virtual void CommitTransaction()
        {
            var transaction = this.GetSession().Transaction;
            if (transaction != null && transaction.IsActive && !transaction.WasCommitted)
            {
                transaction.Commit();
            }
        }

        public virtual void RollbackTransaction()
        {
            var transaction = this.GetSession().Transaction;
            if (transaction != null && transaction.IsActive && !transaction.WasRolledBack)
            {
                transaction.Rollback();
            }
        }

        public void CloseSession()
        {
            if (CurrentSessionContext.HasBind(_sessionFactory))
            {
                ISession session = CurrentSessionContext.Unbind(_sessionFactory);

                if (session.Transaction != null)
                {
                    if (session.Transaction.IsActive && !session.Transaction.WasCommitted && !session.Transaction.WasRolledBack)
                    {
                        session.Transaction.Rollback();
                    }

                    session.Transaction.Dispose();
                }

                if (session.IsOpen)
                {
                    session.Close();
                }

                session.Dispose();
            }
        }
    }
}
