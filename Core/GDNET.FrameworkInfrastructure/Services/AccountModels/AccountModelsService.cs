using System;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Entities.System.ReferenceData;
using GDNET.Domain.Repositories;
using GDNET.Framework.Base;
using GDNET.WebInfrastructure.Models.PageModels;

namespace GDNET.WebInfrastructure.Services.AccountModels
{
    public class AccountModelsService
    {
        public T GetUserModelByEmail<T>(string email) where T : AbstractViewModel<User>
        {
            User user = DomainRepositories.User.FindByEmail(email);
            return (user == null) ? null : this.GetUserModel<T>(user);
        }

        public T GetUserModelById<T>(string id) where T : AbstractViewModel<User>
        {
            Guid guid = Guid.Empty;

            if (Guid.TryParse(id, out guid))
            {
                User user = DomainRepositories.User.GetById(guid);
                if (user != null)
                {
                    return this.GetUserModel<T>(user);
                }
            }

            return null;
        }

        public AccountUpdateDetailsModel GetUpdateDetailsModelByEmail(string email)
        {
            User user = DomainRepositories.User.FindByEmail(email);
            return (user == null) ? null : this.GetUserModel<AccountUpdateDetailsModel>(user);
        }

        public AccountUpdateDetailsModel GetUpdateDetailsModel(User user)
        {
            return this.GetUserModel<AccountUpdateDetailsModel>(user);
        }

        public T GetUserModel<T>(User user) where T : AbstractViewModel<User>
        {
            T model = Activator.CreateInstance<T>();
            model.Initialize(user, false);

            return (T)model;
        }

        public bool UpdateUserFromModel(string email, AccountUpdateDetailsModel model)
        {
            bool result = false;
            var catalog = DomainRepositories.Catalog.FindByCode(SystemCatalogs.Languages);
            User user = DomainRepositories.User.FindByEmail(email);

            if (user != null)
            {
                user.DisplayName = model.DisplayName;
                user.Introduction = model.Introduction;
                user.IsActive = model.IsActive;
                user.Language = catalog.GetLineByCode(model.Language);
                user.AddLog("UpdateDetails", string.Empty);

                result = true;
            }

            return result;
        }
    }
}
