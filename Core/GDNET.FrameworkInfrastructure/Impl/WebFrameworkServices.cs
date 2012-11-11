using GDNET.CastleIntergration;
using GDNET.Framework.Services;
using GDNET.Framework.Services.General;

namespace GDNET.WebInfrastructure.Impl
{
    public class WebFrameworkServices : FrameworkServices
    {
        public WebFrameworkServices()
            : base()
        {
            this.Initialize(this);
        }

        protected override ITranslationService GetTranslationService()
        {
            return IocAssistant.Resolve<ITranslationService>();
        }
    }
}
