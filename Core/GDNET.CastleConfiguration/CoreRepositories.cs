using GDNET.CastleIntergration.Utils;
using GDNET.Domain.Repositories;
using GDNET.Domain.Repositories.ReferenceData;
using GDNET.Domain.Repositories.System;
using GDNET.Domain.Services;

namespace GDNET.CastleConfiguration
{
    public sealed class CoreRepositories : DomainRepositories, IBusinessService
    {
        public CoreRepositories()
            : base()
        {
            this.Initialize(this);
        }

        protected override IUserRepository GetUserRepository()
        {
            return IocAssistant.Resolve<IUserRepository>();
        }

        protected override ITranslationRepository GetTranslationRepository()
        {
            return IocAssistant.Resolve<ITranslationRepository>();
        }

        protected override ICatalogRepository GetCatalogRepository()
        {
            return IocAssistant.Resolve<ICatalogRepository>();
        }
    }
}
