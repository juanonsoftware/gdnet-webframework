using System;
using System.Globalization;
using GDNET.Base.Common;
using GDNET.Base.Utils;
using GDNET.Data.Base;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories.System;
using NHibernate;

namespace GDNET.Data.Repositories.System
{
    public class TranslationRepository : AbstractRepository<Translation, Guid>, ITranslationRepository
    {
        private const Translation DefaultTranslation = default(Translation);

        public TranslationRepository(ISession session)
            : base(session)
        {
        }

        public Translation GetByKeyword(string keyword, CultureInfo culture)
        {
            var propertyKeyword = ExpressionAssistant.GetPropertyName(() => DefaultTranslation.Keyword);
            var propertyLanguage = ExpressionAssistant.GetPropertyName(() => DefaultTranslation.Language);
            var languageCode = culture.Name.Split('-')[0];

            var results = this.FindByProperties(new Filter(propertyLanguage, languageCode), new Filter(propertyKeyword, keyword));
            return (results.Count == 1) ? results[0] : null;
        }

        public string GetValueByKeyword(string keyword, CultureInfo culture)
        {
            var translation = this.GetByKeyword(keyword, culture);
            return (translation == null) ? string.Empty : translation.Value;
        }
    }
}
