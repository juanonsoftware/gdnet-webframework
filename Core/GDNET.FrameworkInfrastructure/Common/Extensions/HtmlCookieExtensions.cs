using System.Web.Mvc;
using GDNET.WebInfrastructure.Services;

namespace GDNET.WebInfrastructure.Common.Extensions
{
    public static class HtmlCookieExtensions
    {
        public static string GetUserCustomizedLanguageName(this HtmlHelper htmlHelper)
        {
            var userInfo = InfrastructureServices.DataStored.GetUserCustomizedInfo();
            return userInfo.LanguageName;
        }
    }
}
