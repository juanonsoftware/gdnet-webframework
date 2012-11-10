using GDNET.Domain.Entities.System.Management;

namespace GreatApp.Domain.Entities
{
    public partial class ContentPart : EntityHistoryComplex
    {
        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Details
        {
            get;
            set;
        }

        public virtual int? Position
        {
            get;
            protected set;
        }

        public virtual ContentItem ContentItem
        {
            get;
            set;
        }
    }
}
