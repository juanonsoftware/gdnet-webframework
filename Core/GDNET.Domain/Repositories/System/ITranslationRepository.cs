using System;
using System.Globalization;
using GDNET.Base.DomainRepository;
using GDNET.Domain.Entities.System;

namespace GDNET.Domain.Repositories.System
{
    public interface ITranslationRepository : IRepositoryBase<Translation, Guid>
    {
        Translation GetByKeyword(string keyword, CultureInfo culture);
        string GetValueByKeyword(string keyword, CultureInfo culture);
    }
}
