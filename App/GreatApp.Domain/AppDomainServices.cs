using GreatApp.Domain.Services;

namespace GreatApp.Domain
{
    public abstract class AppDomainServices
    {
        private static AppDomainServices _instance = null;

        public AppDomainServices()
        {
        }

        protected void Initialize(AppDomainServices instance)
        {
            _instance = instance;
        }

        public static IContentBonusService ContentBonus
        {
            get { return _instance.GetContentBonusService(); }
        }

        protected abstract IContentBonusService GetContentBonusService();
    }
}
