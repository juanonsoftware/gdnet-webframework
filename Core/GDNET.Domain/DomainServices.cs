using GDNET.Domain.Services.Security;

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

        protected abstract IEncryptionService GetEncryptionService();
    }
}
