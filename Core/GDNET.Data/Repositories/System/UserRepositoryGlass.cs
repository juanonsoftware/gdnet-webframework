using System;
using GDNET.Base;
using GDNET.Base.DomainRepository;
using GDNET.Domain.Base.Exceptions;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories;

namespace GDNET.Data.Repositories.System
{
    public class UserRepositoryGlass : AbstractRepositoryGlass<User, Guid>
    {
        public override void ValidateOnCreation(User entity)
        {
            string propertyEmail = ExpressionAssistant.GetPropertyName(() => entity.Email);
            var listUsersByEmail = DomainRepositories.User.FindByProperty(propertyEmail, entity.Email);
            if (listUsersByEmail.Count > 0)
            {
                ExceptionsManager.BusinessException.Throw("");
            }
        }

        public override void ValidateOnModification(User entity)
        {
            string propertyEmail = ExpressionAssistant.GetPropertyName(() => entity.Email);
            var listUsersByEmail = DomainRepositories.User.FindByProperty(propertyEmail, entity.Email);

            foreach (var user in listUsersByEmail)
            {
                if (user.Id != entity.Id)
                {
                    ExceptionsManager.BusinessException.Throw("");
                }
            }
        }
    }
}
