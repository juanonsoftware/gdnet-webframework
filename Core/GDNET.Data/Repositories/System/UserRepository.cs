using System;
using GDNET.Base.Common;
using GDNET.Base.Utils;
using GDNET.Data.Base;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories.System;
using NHibernate;

namespace GDNET.Data.Repositories.System
{
    public class UserRepository : AbstractRepository<User, Guid>, IUserRepository
    {
        private static readonly User DefaultUser = default(User);

        public UserRepository(ISession session)
            : base(session)
        {
        }

        public User FindByEmail(string email)
        {
            var emailProperty = ExpressionAssistant.GetPropertyName(() => DefaultUser.Email);
            var users = base.FindByProperty(new Filter(emailProperty, email));
            return (users.Items.Length > 0) ? users.Items[0] : null;
        }
    }
}
