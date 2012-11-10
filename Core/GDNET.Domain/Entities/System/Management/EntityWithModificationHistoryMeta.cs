using System;
using GDNET.Base;

namespace GDNET.Domain.Entities.System.Management
{
    public static class EntityWithModificationHistoryMeta
    {
        private class DefaultEntityWithModificationHistory : AbstractEntityWithModificationHistoryT<int>
        {
            public static readonly DefaultEntityWithModificationHistory Instance = new DefaultEntityWithModificationHistory();

            public override void AddLog(string message, string contentText)
            {
                throw new NotImplementedException();
            }
        }

        public static string FirstLog
        {
            get
            {
                return ExpressionAssistant.GetPropertyName(() => DefaultEntityWithModificationHistory.Instance.FirstLog);
            }
        }

        public static string LastLog
        {
            get
            {
                return ExpressionAssistant.GetPropertyName(() => DefaultEntityWithModificationHistory.Instance.LastLog);
            }
        }

        public static string IsActive
        {
            get
            {
                return ExpressionAssistant.GetPropertyName(() => DefaultEntityWithModificationHistory.Instance.IsActive);
            }
        }

        public static string Views
        {
            get
            {
                return ExpressionAssistant.GetPropertyName(() => DefaultEntityWithModificationHistory.Instance.Views);
            }
        }
    }
}
