using System;
using System.Collections.Generic;
using System.Linq;
using GDNET.Domain.Repositories;
using GreatApp.Infrastructure.Models;
using GreatApp.Domain;
using GreatApp.Domain.Entities;

namespace GreatApp.Infrastructure.Services
{
    public class ContentModelsService
    {
        #region ContentItem

        public ContentItemModel GetContentItemModel(string id)
        {
            return this.GetContentItemModel(id, false);
        }

        public ContentItemModel GetContentItemModel(string id, bool filterActiveOnly)
        {
            return this.GetContentItemModel(id, filterActiveOnly, false);
        }

        public ContentItemModel GetContentItemModel(string id, bool filterActiveOnly, bool promotingOnView)
        {
            Guid guid = Guid.Empty;
            ContentItemModel model = null;

            if (Guid.TryParse(id, out guid))
            {
                ContentItem ci = AppDomainRepositories.ContentItem.GetById(guid);
                if (ci != null)
                {
                    if ((filterActiveOnly == false) || ci.IsActive)
                    {
                        model = this.GetContentItemModel(ci, filterActiveOnly);

                        if (promotingOnView)
                        {
                            ci.Views += 1;
                            ci.Parts.ToList().ForEach(part =>
                            {
                                if ((filterActiveOnly == false) || part.IsActive)
                                {
                                    part.Views += 1;
                                }
                            });
                        }
                    }
                }
            }

            return model;
        }

        public ContentItemModel GetContentItemModel(ContentItem contentItem)
        {
            return this.GetContentItemModel(contentItem, false);
        }

        public ContentItemModel GetContentItemModel(ContentItem contentItem, bool filterActiveOnly)
        {
            var model = new ContentItemModel();
            model.Initialize(contentItem, filterActiveOnly);

            return model;
        }

        public ContentItem CreateContentItem(ContentItemModel itemModel)
        {
            var catalog = DomainRepositories.Catalog.FindByCode("c.languages");

            var ci = new ContentItem()
            {
                Description = itemModel.Description,
                Keywords = itemModel.Keywords,
                IsActive = itemModel.IsActive,
                Name = itemModel.Name,
                Language = catalog.GetLineByCode(itemModel.Language),
            };
            ci.AddLogCreation();

            return ci;
        }

        public ContentPart CreateContentPart(ContentPartModel partModel)
        {
            var cp = new ContentPart()
            {
                Name = partModel.Name,
                Details = partModel.Details,
                IsActive = partModel.IsActive,
            };
            cp.AddLogCreation();

            return cp;
        }

        #endregion

        #region ContentPart

        public ContentPart GetContentPart(string contentPartId, string contentItemId)
        {
            ContentPart cp = null;
            Guid guid = new Guid(contentItemId);

            ContentItem ci = AppDomainRepositories.ContentItem.GetById(guid);
            if (ci != null)
            {
                cp = ci.GetPart(new Guid(contentPartId));
            }

            return cp;
        }

        public void UpdateContentPart(ContentPart contentPart, ContentPartModel partModel)
        {
            contentPart.Name = partModel.Name;
            contentPart.Details = partModel.Details;
            contentPart.IsActive = partModel.IsActive;

            contentPart.AddLog("Update Content part", string.Empty);
            contentPart.ContentItem.AddLog("Update Content part", string.Empty);
        }

        public ContentPartModel GetContentPartModel(string contentPartId, string contentItemId)
        {
            ContentPartModel model = null;
            ContentPart cp = this.GetContentPart(contentPartId, contentItemId);

            if (cp != null)
            {
                model = this.GetContentPartModel(cp);
            }

            return model;
        }

        public ContentPartModel GetContentPartModel(ContentPart contentPart)
        {
            var model = new ContentPartModel();
            model.Initialize(contentPart);

            return model;
        }

        public IList<ContentPartModel> GetAllContentParts(ContentItem contentItem)
        {
            List<ContentPartModel> contentParts = new List<ContentPartModel>();
            foreach (var contentPart in contentItem.Parts)
            {
                var partModel = this.GetContentPartModel(contentPart);
                contentParts.Add(partModel);
            }

            return contentParts;
        }

        public ContentItemPartsModel GetContentItemParts(ContentItem contentItem)
        {
            ContentItemPartsModel model = new ContentItemPartsModel(contentItem);
            model.AddContentParts(this.GetAllContentParts(contentItem));

            return model;
        }

        public void UpdateContentItem(ContentItem contentItem, ContentItemModel contentModel)
        {
            contentItem.Name = contentModel.Name;
            contentItem.Description = contentModel.Description;
            contentItem.Keywords = contentModel.Keywords;
            contentItem.IsActive = contentModel.IsActive;

            contentItem.AddLog("Update content", string.Empty);
        }

        #endregion
    }
}
