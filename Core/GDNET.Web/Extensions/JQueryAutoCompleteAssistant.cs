using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using GDNET.Base.Utils;

namespace GDNET.Web.Extensions
{
    public static class JQueryAutoCompleteAssistant
    {
        public static MvcHtmlString AutoComplete(this HtmlHelper htmlHelper, string targetUrl, string parameters)
        {
            return htmlHelper.AutoComplete(targetUrl, parameters, false, null, string.Empty);
        }

        public static MvcHtmlString AutoComplete(this HtmlHelper htmlHelper, string targetUrl, string parameters, bool withLog)
        {
            return htmlHelper.AutoComplete(targetUrl, parameters, withLog, null, string.Empty);
        }

        public static MvcHtmlString AutoComplete(this HtmlHelper htmlHelper, string targetUrl, string parameters, bool withLog, object htmlAttributes)
        {
            return htmlHelper.AutoComplete(targetUrl, parameters, withLog, null, string.Empty);
        }

        public static MvcHtmlString AutoComplete(this HtmlHelper htmlHelper, string targetUrl, string parameters, bool withLog, object htmlAttributes, string onSelectBody)
        {
            string newId = GuidAssistant.NewId();
            string containerId = string.Format("autoc_{0}", newId);
            string logContainerId = string.Format("log_", newId);

            string textBox = htmlHelper.TextBox(containerId, null, htmlAttributes).ToString();

            string ajax = ReflectionAssistant.ReadFileContent(Assembly.GetExecutingAssembly(), "GDNET.Web.Extensions.ScriptTemplates.autoComplete.js");
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Cache), JQueryConstants.DefaultCache.ToString().ToLower());
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Timeout), JQueryConstants.DefaultTimeout.ToString());
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.MinLength), JQueryConstants.DefaultMinLength.ToString());
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Type), JQueryConstants.DefaultMethod.ToString());
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.ContentType), JQueryConstants.ContentTypeJson);
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Url), targetUrl);
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Id), containerId);
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Log), logContainerId);
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Select), onSelectBody);

            string data = "JSON.stringify({ params: '" + parameters + "', query: request.term })";
            ajax = ajax.Replace(JQueryAssistant.GetPattern(JQueryConstants.Data), data);

            string documentReady = ReflectionAssistant.ReadFileContent(Assembly.GetExecutingAssembly(), "GDNET.Web.Extensions.ScriptTemplates.ready.js");
            documentReady = documentReady.Replace(JQueryAssistant.GetPattern(JQueryConstants.Body), ajax);

            string autoComplete = string.Empty;
            if (withLog)
            {
                string logContainer = string.Format("<div id=\"{0}\"></div>", logContainerId);
                autoComplete = string.Concat(logContainer, textBox, documentReady);
            }
            else
            {
                autoComplete = string.Concat(textBox, documentReady);
            }

            return MvcHtmlString.Create(autoComplete);
        }
    }
}
