using System.Web.Mvc;
using GDNET.Framework.Services;

namespace GDNET.Framework.DataAnnotations
{
    public class CompareMLAttribute : CompareAttribute
    {
        private string errorKeyword;

        public CompareMLAttribute(string otherProperty, string errorKeyword)
            : base(otherProperty)
        {
            this.errorKeyword = errorKeyword;
        }

        public override string FormatErrorMessage(string name)
        {
            string format = FrameworkServices.Translation.GetByKeyword(this.errorKeyword);
            return string.Format(format, name);
        }
    }
}
