using GDNET.Base.DomainAbstraction;

namespace GDNET.Base
{
    public static class EntityWithModificationMeta
    {
        private class DefaultEntityWithModification : AbstractEntityWithModificationT<int>
        {
            private DefaultEntityWithModification() { }

            public static readonly DefaultEntityWithModification Instance = new DefaultEntityWithModification();
        }

        public static string Id
        {
            get
            {
                return ExpressionAssistant.GetPropertyName(() => DefaultEntityWithModification.Instance.Id);
            }
        }

        public static string CreatedAt
        {
            get
            {
                return ExpressionAssistant.GetPropertyName(() => DefaultEntityWithModification.Instance.CreatedAt);
            }
        }

        public static string LastModifiedAt
        {
            get
            {
                return ExpressionAssistant.GetPropertyName(() => DefaultEntityWithModification.Instance.LastModifiedAt);
            }
        }

        public static string CreatedBy
        {
            get
            {
                return ExpressionAssistant.GetPropertyName(() => DefaultEntityWithModification.Instance.CreatedBy);
            }
        }

        public static string LastModifiedBy
        {
            get
            {
                return ExpressionAssistant.GetPropertyName(() => DefaultEntityWithModification.Instance.LastModifiedBy);
            }
        }
    }
}
