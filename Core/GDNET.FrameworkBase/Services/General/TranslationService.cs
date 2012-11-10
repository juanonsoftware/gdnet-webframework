using System.Threading;
using GDNET.Domain.Repositories;

namespace GDNET.Framework.Services.General
{
    public sealed class TranslationService
    {
        public string GetByKeyword(string keyword)
        {
            string value = DomainRepositories.Translation.GetValueByKeyword(keyword, Thread.CurrentThread.CurrentUICulture);
            return string.IsNullOrEmpty(value) ? string.Format("! {0} !", keyword) : value;
        }
    }
}
