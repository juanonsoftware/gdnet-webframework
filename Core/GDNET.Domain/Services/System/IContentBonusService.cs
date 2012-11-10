using GDNET.Domain.Entities.System;

namespace GDNET.Domain.Services.System
{
    public interface IContentBonusService
    {
        void CalculateTotalPoints(User user);
    }
}
