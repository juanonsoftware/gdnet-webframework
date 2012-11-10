using System;
using System.Web.Mvc;
using System.Web.Security;
using GDNET.AOP.ExceptionHandling;
using GDNET.Framework.Extensions;
using GDNET.Framework.Services;
using GDNET.WebInfrastructure.Common;
using GDNET.WebInfrastructure.Controllers.Base;
using GDNET.WebInfrastructure.Controllers.Extensions;
using GDNET.WebInfrastructure.Models.PageModels;
using GDNET.WebInfrastructure.Models.System;
using GDNET.WebInfrastructure.Services;
using GreatApp.Domain;
using GreatApp.Domain.Entities;
using GreatApp.Infrastructure.Models;

namespace GDNET.WebInfrastructure.Controllers
{
    [CaptureException]
    public class AccountController : AbstractController
    {
        private ActionResult RedirectToHomeIndex()
        {
            var homeController = default(HomeController);
            var actionName = ControllerAssistant.GetActionName(() => homeController.Index());
            return base.RedirectToAction(actionName, ListControllers.Home);
        }

        public ActionResult Watch(string id)
        {
            AccountWatchModel pageModel = new AccountWatchModel();
            var userModel = InfrastructureServices.AccountModels.GetUserModelById<UserDetailsModel>(id);

            if (userModel != null)
            {
                userModel.DisplayMode = UserDetailsMode.AccountWatch;

                var topContents = AppDomainRepositories.ContentItem.GetTopWithActiveByAuthor(GlobalSettings.DefaultPageSize, userModel.Email);
                var topModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(topContents, true);

                pageModel.UserDetails = userModel;
                pageModel.FocusItems = topModels;
            }

            return base.View(pageModel);
        }

        #region LogOn

        public ActionResult LogOn()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult LogOn(AccountLogOnModel model, string returnUrl)
        {
            if (base.ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (base.Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") &&
                        !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return base.Redirect(returnUrl);
                    }
                    else
                    {
                        return this.RedirectToHomeIndex();
                    }
                }
                else
                {
                    string errorMessage = FrameworkServices.Translation.GetByKeyword("GUI.Account.LogOn.ValidateUserError");
                    base.ModelState.AddModelError("", errorMessage);
                }
            }

            // If we got this far, something failed, redisplay form
            return base.View(model);
        }

        #endregion

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        [Authorize]
        public ActionResult Details()
        {
            return base.View();
        }

        [Authorize]
        public ActionResult UpdateDetails()
        {
            var email = base.HttpContext.User.Identity.Name;
            AccountUpdateDetailsModel model = InfrastructureServices.AccountModels.GetUserModelByEmail<AccountUpdateDetailsModel>(email);

            return base.View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateDetails(AccountUpdateDetailsModel model)
        {
            if (base.ModelState.IsValid)
            {
                var email = base.HttpContext.User.Identity.Name;
                bool result = InfrastructureServices.AccountModels.UpdateUserFromModel(email, model);

                if (result)
                {
                    return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details()));
                }
            }

            return base.View(model);
        }

        #region Registration

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AccountRegisterModel model)
        {
            if (base.ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.Email, model.Password, model.Email, null, null, true, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return this.RedirectToHomeIndex();
                }
                else
                {
                    base.ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            return base.View(model);
        }

        #endregion

        #region ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(AccountChangePasswordModel model)
        {
            if (base.ModelState.IsValid)
            {
                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    var actionName = ControllerAssistant.GetActionName(() => this.ChangePasswordSuccess());
                    return RedirectToAction(actionName);
                }
                else
                {
                    base.ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        #endregion

        #region Status Codes

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        #endregion
    }
}
