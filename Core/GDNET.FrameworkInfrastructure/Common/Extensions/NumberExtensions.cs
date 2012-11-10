using System.Web.Mvc;
using GDNET.Framework.Services;
using GDNET.Utils;

namespace GDNET.WebInfrastructure.Common.Extensions
{
    public static class NumberExtensions
    {
        public static string Format(this HtmlHelper htmlHelper, int? value)
        {
            return FormatterAssistant.Format(value);
        }

        public static string Format(this HtmlHelper htmlHelper, int? value, string keywordOnZero)
        {
            if (!value.HasValue || value.Value == 0)
            {
                return FrameworkServices.Translation.GetByKeyword(keywordOnZero);
            }

            return FormatterAssistant.Format(value);
        }

        public static string Format(this HtmlHelper htmlHelper, double? value)
        {
            return FormatterAssistant.Format(value);
        }

        public static string Format(this HtmlHelper htmlHelper, double? value, string keywordOnZero)
        {
            if (!value.HasValue || value.Value == 0)
            {
                return FrameworkServices.Translation.GetByKeyword(keywordOnZero);
            }

            return FormatterAssistant.Format(value);
        }
    }
}
