using System;
using System.Linq;
using GDNET.Base.Common;
using GDNET.Base.DomainRepository;
using GDNET.Base.Utils;
using GDNET.Domain.Base.Exceptions;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories;

namespace GDNET.Data.Repositories.System
{
    public class UserRepositoryGlass : AbstractRepositoryGlass<User, Guid>
    {
        public override void ValidateOnCreation(User entity)
        {
            var propertyEmail = ExpressionAssistant.GetPropertyName(() => entity.Email);
            var usersByEmail = DomainRepositories.User.FindByProperty(new Filter(propertyEmail, entity.Email));
            if (usersByEmail.HasItems())
            {
                ExceptionsManager.BusinessException.Throw("This email address is in used.");
            }
        }

        public override void ValidateOnModification(User entity)
        {
            var propertyEmail = ExpressionAssistant.GetPropertyName(() => entity.Email);
            var usersByEmail = DomainRepositories.User.FindByProperty(new Filter(propertyEmail, entity.Email));

            if (usersByEmail.Items.Count(u => u.Id != entity.Id) > 0)
            {
                ExceptionsManager.BusinessException.Throw("This email address is in used by other user.");
            }
        }
    }
}
