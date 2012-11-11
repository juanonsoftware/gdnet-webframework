using System.Threading;
using GDNET.Domain.Repositories.System;

namespace GDNET.Framework.Services.General
{
    public class TranslationService : ITranslationService
    {
        private readonly ITranslationRepository translationRepository = null;

        public TranslationService(ITranslationRepository translationRepository)
        {
            this.translationRepository = translationRepository;
        }

        public string GetByKeyword(string keyword)
        {
            string value = this.translationRepository.GetValueByKeyword(keyword, Thread.CurrentThread.CurrentUICulture);
            return string.IsNullOrEmpty(value) ? string.Format("! {0} !", keyword) : value;
        }
    }
}
