using System.Web;
using GDNET.Framework.Extensions;
using GDNET.WebInfrastructure.Models.System;

namespace GDNET.WebInfrastructure.Services.Storage
{
    public sealed class DataStoredService
    {
        public UserCustomizedInformationModel GetUserCustomizedInfo()
        {
            if (HttpContext.Current.Request.Cookies[FrameworkConstants.UserInfoKey] == null)
            {
                UserCustomizedInformationModel userCustomized = new UserCustomizedInformationModel(string.Empty, string.Empty);
                this.SetUserCustomizedInfo(userCustomized);
            }

            var userInfo = HttpContext.Current.Request.Cookies[FrameworkConstants.UserInfoKey];
            UserCustomizedInformationModel info = new UserCustomizedInformationModel(userInfo.Value);

            return info;
        }

        public void SetUserCustomizedInfo(UserCustomizedInformationModel model)
        {
            HttpContext.Current.Request.Cookies.Remove(FrameworkConstants.UserInfoKey);

            HttpCookie cookie = new HttpCookie(FrameworkConstants.UserInfoKey, model.Serialize());
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
