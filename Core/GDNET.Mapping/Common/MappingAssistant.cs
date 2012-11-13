using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GDNET.Base;
using GDNET.Base.Utils;

namespace GDNET.Mapping.Common
{
    public static class MappingAssistant
    {
        public static string GetForeignKeyColumn<T>(Expression<Func<T>> property)
        {
            string propertyName = ExpressionAssistant.GetPropertyName(property);
            return (propertyName + EntityWithModificationMeta.Id);
        }

        public static string GetForeignKeyColumn<T>()
        {
            return (typeof(T).Name + EntityWithModificationMeta.Id);
        }

        public static string GetStrongTableByType(Type type)
        {
            List<string> sqlObjectNames = new List<string>
            {
                "user",
            };

            if (sqlObjectNames.Contains(type.Name.ToLower()))
            {
                return string.Format("[{0}]", type.Name);
            }

            return type.Name;
        }
    }
}
