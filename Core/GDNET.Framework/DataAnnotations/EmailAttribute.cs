using System.ComponentModel.DataAnnotations;
using GDNET.Framework.Services;

namespace GDNET.Framework.DataAnnotations
{
    public sealed class EmailAttribute : RegularExpressionAttribute
    {
        private static readonly string EmailPattern = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)$";

        private string errorKeyword;

        public EmailAttribute(string errorKeyword)
            : base(EmailPattern)
        {
            this.errorKeyword = errorKeyword;
        }

        public override string FormatErrorMessage(string name)
        {
            var format = FrameworkServices.Translation.GetByKeyword(this.errorKeyword);
            return string.Format(format, name);
        }
    }
}
