using System.Reflection;
using System.Web.Mvc;
using GDNET.Base.Utils;

namespace GDNET.Web.Extensions
{
    public static class JQueryAjaxAssistant
    {
        public static MvcHtmlString Ajax(this HtmlHelper htmlHelper, string targetUrl)
        {
            string containerId = GuidAssistant.NewId("ajax_");
            string container = string.Format("<div id=\"{0}\"></div>", containerId);

            string ajax = ReflectionAssistant.ReadFileContent(Assembly.GetExecutingAssembly(), "GDNET.Web.Extensions.ScriptTemplates.ajaxWSString.js");
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Cache), JQueryConstants.DefaultCache.ToString().ToLower());
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Timeout), JQueryConstants.DefaultTimeout.ToString());
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Type), JQueryConstants.DefaultMethod.ToString());
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Url), targetUrl);
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Data), "{}");
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Id), containerId);

            string documentReady = ReflectionAssistant.ReadFileContent(Assembly.GetExecutingAssembly(), "GDNET.Web.Extensions.ScriptTemplates.ready.js");
            documentReady = documentReady.Replace(JQueryAssistant.GetPattern(JQueryConstants.Body), ajax);

            return MvcHtmlString.Create(string.Concat(container, documentReady));
        }
    }
}
