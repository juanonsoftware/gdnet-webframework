using GDNET.Base.DomainRepository;
using NHibernate;

namespace GDNET.NHibernate.SessionManagement
{
    public interface INHibernateRepositoryStrategy : IRepositoryStrategy
    {
        ISession Session { get; }
    }
}
