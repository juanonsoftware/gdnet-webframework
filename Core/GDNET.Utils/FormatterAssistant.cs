using System;
using System.Threading;

namespace GDNET.Utils
{
    public static class FormatterAssistant
    {
        /// <summary>
        /// Format an integer number by current UI culture
        /// </summary>
        public static string Format(int? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToString(Thread.CurrentThread.CurrentUICulture);
            }
            return string.Empty;
        }

        /// <summary>
        /// Format a double number by current UI culture
        /// </summary>
        public static string Format(double? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToString(Thread.CurrentThread.CurrentUICulture);
            }
            return string.Empty;
        }

        /// <summary>
        /// Format a date by current UI culture
        /// </summary>
        public static string Format(DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToString(Thread.CurrentThread.CurrentUICulture);
            }
            return string.Empty;
        }

        /// <summary>
        /// Format a date to style "2009-01-28T20:24:17"
        /// </summary>
        public static string FormatPretty(DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToString("yyyy-MM-ddThh:mm:ss");
            }
            return string.Empty;
        }
    }
}
