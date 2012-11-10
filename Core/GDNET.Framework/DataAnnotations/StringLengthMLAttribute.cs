using System.ComponentModel.DataAnnotations;
using GDNET.Framework.Services;

namespace GDNET.Framework.DataAnnotations
{
    /// <summary>
    /// TODO: JS validation is not working
    /// </summary>
    public class StringLengthMLAttribute : StringLengthAttribute
    {
        public string ErrorKeyword
        {
            get;
            set;
        }

        public StringLengthMLAttribute(int maximumLength)
            : base(maximumLength)
        {
        }

        public StringLengthMLAttribute(int maximumLength, int minimumLength)
            : base(maximumLength)
        {
            base.MinimumLength = minimumLength;
        }

        public override string FormatErrorMessage(string name)
        {
            if (!string.IsNullOrEmpty(this.ErrorKeyword))
            {
                var format = FrameworkServices.Translation.GetByKeyword(this.ErrorKeyword);
                return string.Format(format, name, base.MinimumLength, base.MaximumLength);
            }
            else
            {
                return base.FormatErrorMessage(name);
            }
        }
    }
}
