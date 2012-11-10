using GDNET.Domain.Base.Exceptions;
using GDNET.Domain.Services;

namespace GDNET.Domain.Entities.System
{
    public partial class User
    {
        public static UserFactory Factory
        {
            get { return new UserFactory(); }
        }

        public class UserFactory
        {
            public User Create(string email, string password)
            {
                return this.Create(email, password, false);
            }

            public User Create(string email, string password, bool isActive)
            {
                ExceptionsManager.BusinessException.ThrowIfIsNullOrWhiteSpace(email);
                ExceptionsManager.BusinessException.ThrowIfTooShort(password, 4);

                var newUser = new User()
                {
                    Email = email,
                    Password = DomainServices.Encryption.Encrypt(password),
                    IsActive = isActive
                };

                return newUser;
            }
        }
    }
}
