using GreatApp.Domain.Repositories;

namespace GreatApp.Domain
{
    public abstract class AppDomainRepositories
    {
        private static AppDomainRepositories _instance;

        protected void Initialize(AppDomainRepositories instance)
        {
            _instance = instance;
        }

        public static IContentItemRepository ContentItem
        {
            get { return _instance.GetContentItemRepository(); }
        }

        protected abstract IContentItemRepository GetContentItemRepository();
    }
}
