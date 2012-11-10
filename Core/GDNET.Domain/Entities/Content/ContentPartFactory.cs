using GDNET.Domain.Base.Exceptions;

namespace GDNET.Domain.Content
{
    public partial class ContentPart
    {
        public static ContentPartFactory Factory
        {
            get { return new ContentPartFactory(); }
        }

        public class ContentPartFactory
        {
            public ContentPart Create(string name, string details)
            {
                return this.Create(name, details, false);
            }

            public ContentPart Create(string name, string details, bool isActive)
            {
                ExceptionsManager.BusinessException.ThrowIfIsNullOrWhiteSpace(name);
                ExceptionsManager.BusinessException.ThrowIfIsNullOrWhiteSpace(details);

                var contentPart = new ContentPart
                {
                    Name = name,
                    Details = details,
                    IsActive = isActive
                };

                return contentPart;
            }
        }
    }
}
