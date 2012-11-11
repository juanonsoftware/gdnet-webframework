using System.Collections.Generic;
using GDNET.Domain.Services;
using GreatApp.Domain.Entities;
using GreatApp.Infrastructure.Models;

namespace GreatApp.Infrastructure.Services
{
    public interface IContentModelsService : IBusinessService
    {
        ContentItem CreateContentItem(ContentItemModel itemModel);
        ContentPart CreateContentPart(ContentPartModel partModel);
        IList<ContentPartModel> GetAllContentParts(ContentItem contentItem);
        ContentItemModel GetContentItemModel(ContentItem contentItem);
        ContentItemModel GetContentItemModel(ContentItem contentItem, bool filterActiveOnly);
        ContentItemModel GetContentItemModel(string id);
        ContentItemModel GetContentItemModel(string id, bool filterActiveOnly);
        ContentItemModel GetContentItemModel(string id, bool filterActiveOnly, bool promotingOnView);
        ContentItemPartsModel GetContentItemParts(ContentItem contentItem);
        ContentPart GetContentPart(string contentPartId, string contentItemId);
        ContentPartModel GetContentPartModel(ContentPart contentPart);
        ContentPartModel GetContentPartModel(string contentPartId, string contentItemId);
        void UpdateContentItem(ContentItem contentItem, ContentItemModel contentModel);
        void UpdateContentPart(ContentPart contentPart, ContentPartModel partModel);
    }
}
