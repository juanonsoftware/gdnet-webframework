using GDNET.Domain.Base.Exceptions;

namespace GreatApp.Domain.Entities
{
    public partial class ContentItem
    {
        public static ContentItemFactory Factory
        {
            get { return new ContentItemFactory(); }
        }

        public class ContentItemFactory
        {
            public ContentItem Create(string name)
            {
                return this.Create(name, false);
            }

            public ContentItem Create(string name, bool isActive)
            {
                ExceptionsManager.BusinessException.ThrowIfIsNullOrWhiteSpace(name);

                var contentItem = new ContentItem
                {
                    Name = name,
                    IsActive = isActive
                };

                return contentItem;
            }
        }
    }
}
