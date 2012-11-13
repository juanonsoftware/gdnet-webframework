using System;
using GDNET.Base.Utils;
using GDNET.Data.Base;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories.System;
using NHibernate;

namespace GDNET.Data.Repositories.System
{
    public class UserRepository : AbstractRepository<User, Guid>, IUserRepository
    {
        public UserRepository(ISession session)
            : base(session)
        {
        }

        public User FindByEmail(string email)
        {
            var defaultUser = default(User);
            string emailProperty = ExpressionAssistant.GetPropertyName(() => defaultUser.Email);

            var listOfUsers = base.FindByProperty(emailProperty, email);
            return (listOfUsers.Count > 0) ? listOfUsers[0] : null;
        }
    }
}
