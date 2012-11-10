using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GDNET.Framework.Extensions;

namespace GDNET.WebInfrastructure.Common.Handlers
{
    public class MultilingualMvcRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var language = requestContext.RouteData.Values[FrameworkConstants.LanguageRouteKey].ToString();
            var ci = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = ci;

            return base.GetHttpHandler(requestContext);
        }
    }
}
