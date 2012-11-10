using GDNET.Domain.Content;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories;
using GDNET.Domain.Services.System;

namespace GDNET.Business.Services.System
{
    public class ContentBonusService : IContentBonusService
    {
        private const double GroupI = 120;
        private const double GroupII = 60;
        private const double GroupIII = 30;
        private const double GroupIV = 15;
        private const double GroupV = 5;

        public void CalculateTotalPoints(User user)
        {
            if (user.TotalPoints > 0)
            {
                return;
            }

            var listContentItems = DomainRepositories.ContentItem.GetAllByAuthor(user.Email);
            foreach (ContentItem item in listContentItems)
            {
                user.AddNewPoints(GroupV);
            }
        }
    }
}
