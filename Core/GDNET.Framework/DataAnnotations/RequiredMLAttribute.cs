using System.ComponentModel.DataAnnotations;
using GDNET.Framework.Services;

namespace GDNET.Framework.DataAnnotations
{
    /// <summary>
    /// TODO: JS validation is not working
    /// </summary>
    public class RequiredMLAttribute : RequiredAttribute
    {
        public RequiredMLAttribute(string keyword)
            : base()
        {
            base.AllowEmptyStrings = false;
            base.ErrorMessage = FrameworkServices.Translation.GetByKeyword(keyword);
        }
    }
}
