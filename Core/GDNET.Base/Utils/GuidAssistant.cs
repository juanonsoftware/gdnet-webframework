using System;

namespace GDNET.Base.Utils
{
    public static class GuidAssistant
    {
        public static string NewId()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }

        public static string NewId(string prefix)
        {
            return string.Concat(prefix, GuidAssistant.NewId());
        }
    }
}
