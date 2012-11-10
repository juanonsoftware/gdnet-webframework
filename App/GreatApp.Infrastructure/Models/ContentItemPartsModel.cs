using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GreatApp.Domain.Entities;

namespace GreatApp.Infrastructure.Models
{
    public class ContentItemPartsModel
    {
        private List<ContentPartModel> contentParts = new List<ContentPartModel>();

        public ContentItemPartsModel(ContentItem contentItem)
        {
            this.Id = contentItem.Id;
        }

        public Guid Id
        {
            get;
            protected set;
        }

        public int PartsCount
        {
            get { return this.contentParts.Count; }
        }

        public ReadOnlyCollection<ContentPartModel> ContentParts
        {
            get { return new ReadOnlyCollection<ContentPartModel>(this.contentParts); }
        }

        public ContentItemPartsModel AddContentParts(IEnumerable<ContentPartModel> parts)
        {
            this.contentParts.AddRange(parts);
            return this;
        }
    }
}
