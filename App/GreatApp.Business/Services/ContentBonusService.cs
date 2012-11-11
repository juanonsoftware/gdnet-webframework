using GDNET.Domain.Entities.System;
using GreatApp.Domain.Entities;
using GreatApp.Domain.Repositories;
using GreatApp.Domain.Services;

namespace GreatApp.Business.Services
{
    public class ContentBonusService : IContentBonusService
    {
        private const double GroupI = 120;
        private const double GroupII = 60;
        private const double GroupIII = 30;
        private const double GroupIV = 15;
        private const double GroupV = 5;

        private readonly IContentItemRepository contentItemRepository;

        public ContentBonusService(IContentItemRepository contentItemRepository)
        {
            this.contentItemRepository = contentItemRepository;
        }

        public void CalculateTotalPoints(User user)
        {
            if (user.TotalPoints > 0)
            {
                return;
            }

            var listContentItems = this.contentItemRepository.GetAllByAuthor(user.Email);
            foreach (ContentItem item in listContentItems)
            {
                user.AddNewPoints(GroupV);
            }
        }
    }
}
