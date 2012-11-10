using System.Collections.Generic;
using System.Web.Mvc;
using GDNET.Framework.Extensions;
using GDNET.Web.Extensions;
using GDNET.WebInfrastructure.WebServices;

namespace GDNET.WebInfrastructure.Common.Extensions
{
    public static class FrameworkJQueryAssistant
    {
        public static MvcHtmlString AutoCompleteSearchContent(this HtmlHelper htmlHelper)
        {
            return htmlHelper.AutoCompleteSearchContent(null);
        }

        public static MvcHtmlString AutoCompleteSearchContent(this HtmlHelper htmlHelper, object htmlAttributes)
        {
            List<string> listParams = new List<string>();
            listParams.Add(string.Format("{0}={1}", AppServiceConstant.Operator, AppServiceOperator.SearchContent));

            string targetUrl = "/AppServices.asmx/GetJsonResults";
            string parameters = string.Join("&", listParams.ToArray());
            string onSelectBody = string.Format("window.location.href = '/{0}/Home/Details/' + ui.item.id; return false;", FrameworkExtensions.GetLanguageRoute());

            return htmlHelper.AutoComplete(targetUrl, parameters, false, htmlAttributes, onSelectBody);
        }
    }
}
