using GDNET.Domain.Services;

namespace GDNET.Framework.Services.General
{
    public interface ITranslationService : IBusinessService
    {
        string GetByKeyword(string keyword);
    }
}
