using GDNET.Framework.Services.General;

namespace GDNET.Framework.Services
{
    /// <summary>
    /// This class has no method, it's used for marking only
    /// </summary>
    public abstract class FrameworkServices
    {
        protected static FrameworkServices _instance = null;

        public FrameworkServices()
        {
        }

        protected void Initialize(FrameworkServices instance)
        {
            _instance = instance;
        }

        public static ITranslationService Translation
        {
            get
            {
                return _instance.GetTranslationService();
            }
        }

        protected abstract ITranslationService GetTranslationService();
    }
}
