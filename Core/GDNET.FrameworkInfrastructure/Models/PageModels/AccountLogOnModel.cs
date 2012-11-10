using System.ComponentModel.DataAnnotations;
using GDNET.Framework.DataAnnotations;
using GDNET.Framework.Models;

namespace GDNET.WebInfrastructure.Models.PageModels
{
    public sealed class AccountLogOnModel : AbstractPageModel
    {
        [Required]
        [Email("GUI.Common.InvalidFormat.Email")]
        [DisplayNameML("GUI.User.UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayNameML("GUI.User.Password")]
        public string Password { get; set; }

        [DisplayNameML("GUI.LogOnModel.RememberMe")]
        public bool RememberMe { get; set; }
    }
}
