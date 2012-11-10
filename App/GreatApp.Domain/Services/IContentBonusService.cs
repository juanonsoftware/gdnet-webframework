using GDNET.Domain.Entities.System;

namespace GreatApp.Domain.Services
{
    public interface IContentBonusService
    {
        void CalculateTotalPoints(User user);
    }
}
