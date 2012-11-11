using System;

namespace GDNET.Base.Utils
{
    public static class EnumAssistant
    {
        public static T Parse<T>(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }

            string defaultValue = Enum.GetNames(typeof(T))[0];
            return EnumAssistant.Parse<T>(defaultValue);
        }
    }
}
