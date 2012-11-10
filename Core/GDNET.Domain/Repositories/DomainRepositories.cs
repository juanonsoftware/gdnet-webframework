using GDNET.Base.DomainRepository;
using GDNET.Domain.Repositories.Content;
using GDNET.Domain.Repositories.System;

namespace GDNET.Domain.Repositories
{
    public abstract class DomainRepositories
    {
        private static DomainRepositories _instance;

        protected void Initialize(DomainRepositories instance)
        {
            _instance = instance;
        }

        public static IUserRepository User
        {
            get { return _instance.GetUserRepository(); }
        }

        public static IContentItemRepository ContentItem
        {
            get { return _instance.GetContentItemRepository(); }
        }

        public static IRepositoryStrategy RepositoryStrategy
        {
            get { return _instance.GetRepositoryStrategy(); }
        }

        public static ITranslationRepository Translation
        {
            get { return _instance.GetTranslationRepository(); }
        }

        public static ICatalogRepository Catalog
        {
            get { return _instance.GetCatalogRepository(); }
        }

        protected abstract IUserRepository GetUserRepository();
        protected abstract IContentItemRepository GetContentItemRepository();
        protected abstract ITranslationRepository GetTranslationRepository();
        protected abstract ICatalogRepository GetCatalogRepository();

        protected abstract IRepositoryStrategy GetRepositoryStrategy();
    }
}
