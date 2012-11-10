using GDNET.Business.Services.Impl.Security;
using GDNET.Domain.Services;
using GDNET.Domain.Services.Security;

namespace GDNET.Business
{
    public class BusinessServices : DomainServices
    {
        public BusinessServices()
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
