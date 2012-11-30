using System;
using System.Collections.Generic;
using GDNET.Base.Common;
using GDNET.Base.DomainRepository;
using GreatApp.Domain.Entities;

namespace GreatApp.Domain.Repositories
{
    public interface IContentItemRepository : IRepositoryBase<ContentItem, Guid>
    {
        Page<ContentItem> GetAllByAuthor(string createdByEmail);

        IList<ContentItem> GetTopWithActive(int limit);
        IList<ContentItem> GetTopWithActiveByViews(int limit);
        IList<ContentItem> GetTopWithActiveByViews(int limit, Guid itemIdExclude);
        IList<ContentItem> GetTopWithActiveByAuthor(int limit, string authorEmail);

        IList<ContentItem> SearchTopWithActive(int limit, string query);
    }
}
