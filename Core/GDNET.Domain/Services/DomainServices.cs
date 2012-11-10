using GDNET.Domain.Services.Security;
using GDNET.Domain.Services.System;

namespace GDNET.Domain.Services
{
    public abstract class DomainServices
    {
        public static DomainServices _instance = null;

        public DomainServices()
        {
        }

        protected void Initialize(DomainServices instance)
        {
            _instance = instance;
        }

        public static IEncryptionService Encryption
        {
            get { return _instance.GetEncryptionService(); }
        }

        public static IContentBonusService ContentBonus
        {
            get { return _instance.GetContentBonusService(); }
        }

        protected abstract IEncryptionService GetEncryptionService();
        protected abstract IContentBonusService GetContentBonusService();
    }
}
