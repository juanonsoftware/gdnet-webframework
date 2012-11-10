using GDNET.Business.Services.Impl.Security;
using GDNET.Domain.Services;
using GDNET.Domain.Services.Security;

namespace GDNET.Business.Services
{
    public class ServicesManager : DomainServices
    {
        public ServicesManager()
            : base()
        {
            base.Initialize(this);
        }

        protected override IEncryptionService GetEncryptionService()
        {
            return new EncryptionService(EncryptionOption.AES);
        }
    }
}
