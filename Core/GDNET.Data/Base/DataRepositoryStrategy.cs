using GDNET.NHibernate.SessionManagement;

namespace GDNET.Data.Base
{
    public class DataRepositoryStrategy : AbstractNHibernateRepositoryStrategy
    {
        public DataRepositoryStrategy(INHibernateSessionManager sessionManager)
            : base(sessionManager)
        {
        }
    }
}
