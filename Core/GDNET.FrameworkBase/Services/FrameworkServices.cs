using GDNET.Framework.Services.General;

namespace GDNET.Framework.Services
{
    public sealed class FrameworkServices
    {
        public static TranslationService Translation
        {
            get { return new TranslationService(); }
        }
    }
}
