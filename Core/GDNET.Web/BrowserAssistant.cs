using System.Text;
using System.Web;

namespace GDNET.Web
{
    public static class BrowserAssistant
    {
        public static string GetCommonInfos(this HttpBrowserCapabilities browser)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Browser: {0}; ", browser.Browser);
            sb.AppendFormat("Type: {0}; ", browser.Type);
            sb.AppendFormat("Version: {0}; ", browser.Version);
            sb.AppendFormat("Platform: {0}; ", browser.Platform);
            sb.AppendFormat("IsMobileDevice: {0}; ", browser.IsMobileDevice);

            return sb.ToString();
        }
    }
}
