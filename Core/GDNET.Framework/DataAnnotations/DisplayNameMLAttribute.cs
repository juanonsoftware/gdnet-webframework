using System.ComponentModel;
using GDNET.Framework.Services;

namespace GDNET.Framework.DataAnnotations
{
    public class DisplayNameMLAttribute : DisplayNameAttribute
    {
        private string keyword;

        public DisplayNameMLAttribute(string keyword)
        {
            this.keyword = keyword;
        }

        public override string DisplayName
        {
            get
            {
                return FrameworkServices.Translation.GetByKeyword(keyword);
            }
        }
    }
}
