using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Entities.System.Management;

namespace GDNET.Domain.Content
{
    public partial class ContentItem : EntityHistoryComplex
    {
        private IList<ContentPart> parts = new List<ContentPart>();

        #region Properties

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual string Keywords
        {
            get;
            set;
        }

        public virtual DataLine Language
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<ContentPart> Parts
        {
            get { return new ReadOnlyCollection<ContentPart>(this.parts); }
        }

        #endregion

        #region Methods

        public virtual ContentPart GetPart(Guid partId)
        {
            return this.parts.FirstOrDefault(x => x.Id == partId);
        }

        public virtual ContentItem AddPart(ContentPart part)
        {
            if (!this.parts.Contains(part))
            {
                part.ContentItem = this;
                this.parts.Add(part);
            }

            return this;
        }

        public virtual ContentItem RemovePart(ContentPart part)
        {
            if (this.parts.Contains(part))
            {
                this.parts.Remove(part);
            }

            return this;
        }

        public virtual ContentItem RemovePartById(Guid partId)
        {
            var contentPart = this.GetPart(partId);
            return this.RemovePart(contentPart);
        }

        public virtual ContentItem MoveUpPartById(Guid partId)
        {
            this.MovePartById(partId, true);
            return this;
        }

        public virtual ContentItem MoveDownPartById(Guid partId)
        {
            this.MovePartById(partId, false);
            return this;
        }

        private bool MovePartById(Guid partId, bool isUp)
        {
            if (this.parts.Count > 1)
            {
                var contentPart = this.GetPart(partId);
                if (contentPart != null)
                {
                    var index = this.parts.IndexOf(contentPart);
                    if (isUp && index > 0)
                    {
                        this.parts.Remove(contentPart);
                        this.parts.Insert(index - 1, contentPart);
                        return true;
                    }
                    else if (index < this.parts.Count - 1)
                    {
                        this.parts.Remove(contentPart);
                        this.parts.Insert(index + 1, contentPart);
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion
    }
}
