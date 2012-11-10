using System;
using System.Linq.Expressions;

namespace GDNET.Base
{
    public class ExpressionAssistant
    {
        public static string GetPropertyName<T>(Expression<Func<T>> property)
        {
            MemberExpression member = property.Body as MemberExpression;

            if (member == null)
            {
                UnaryExpression unary = property.Body as UnaryExpression;
                member = unary.Operand as MemberExpression;
            }

            return member.Member.Name;
        }
    }
}
