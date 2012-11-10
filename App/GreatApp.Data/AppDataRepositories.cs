using GDNET.NHibernate.SessionManagement;
using GreatApp.Data.Repositories;
using GreatApp.Domain;
using GreatApp.Domain.Repositories;

namespace GreatApp.Data
{
    public sealed class AppDataRepositories : AppDomainRepositories
    {
        private INHibernateRepositoryStrategy repositoryStrategy = null;

        public AppDataRepositories(INHibernateRepositoryStrategy strategy)
        {
            this.repositoryStrategy = strategy;
            base.Initialize(this);
        }

        protected override IContentItemRepository GetContentItemRepository()
        {
            return new ContentItemRepository(this.repositoryStrategy);
        }
    }
}
