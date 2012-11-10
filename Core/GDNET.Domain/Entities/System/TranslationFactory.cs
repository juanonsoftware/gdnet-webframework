namespace GDNET.Domain.Entities.System
{
    public partial class Translation
    {
        public static TranslationFactory Factory
        {
            get { return new TranslationFactory(); }
        }

        public class TranslationFactory
        {
            public Translation Create(string keyword, string culture, string value)
            {
                return new Translation()
                {
                    Keyword = keyword,
                    Language = culture,
                    Value = value,
                };
            }
        }
    }
}
