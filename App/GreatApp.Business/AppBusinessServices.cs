using GreatApp.Business.Services;
using GreatApp.Domain;
using GreatApp.Domain.Services;

namespace GreatApp.Business
{
    public sealed class AppBusinessServices : AppDomainServices
    {
        public AppBusinessServices()
            : base()
        {
            base.Initialize(this);
        }

        protected override IContentBonusService GetContentBonusService()
        {
            return new ContentBonusService();
        }
    }
}
