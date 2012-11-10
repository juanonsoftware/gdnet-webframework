using System;
using System.Globalization;
using GDNET.Base;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories.System;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagement;

namespace GDNET.Data.Repositories.System
{
    public class TranslationRepository : AbstractRepository<Translation, Guid>, ITranslationRepository
    {
        private const Translation DefaultTranslation = default(Translation);

        public TranslationRepository(INHibernateRepositoryStrategy strategy)
            : base(strategy)
        {
        }

        public Translation GetByKeyword(string keyword, CultureInfo culture)
        {
            string propertyKeyword = ExpressionAssistant.GetPropertyName(() => DefaultTranslation.Keyword);
            string propertyLanguage = ExpressionAssistant.GetPropertyName(() => DefaultTranslation.Language);

            string languageCode = culture.Name.Split('-')[0];
            var results = this.FindByProperties(new string[] { propertyLanguage, propertyKeyword }, new string[] { languageCode, keyword });

            return (results.Count == 1) ? results[0] : null;
        }

        public string GetValueByKeyword(string keyword, CultureInfo culture)
        {
            var translation = this.GetByKeyword(keyword, culture);
            return (translation == null) ? string.Empty : translation.Value;
        }
    }
}
