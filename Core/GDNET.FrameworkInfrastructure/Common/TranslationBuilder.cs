using System.CodeDom;
using System.Web.Compilation;
using System.Web.UI;
using GDNET.Framework.Services;

namespace GDNET.WebInfrastructure.Common
{
    public class TranslationBuilder : ExpressionBuilder
    {
        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            CodeTypeReferenceExpression thisType = new CodeTypeReferenceExpression(base.GetType());
            CodePrimitiveExpression expression = new CodePrimitiveExpression(entry.Expression.Trim().ToString());

            return new CodeMethodInvokeExpression(thisType, "GetTranslation", expression);
        }

        public static string GetTranslation(string expression)
        {
            return FrameworkServices.Translation.GetByKeyword(expression);
        }

        public override bool SupportsEvaluate
        {
            get
            {
                return true;
            }
        }
    }
}
