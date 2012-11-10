using System.Collections.Generic;
using GDNET.Framework.Models;
using GDNET.WebInfrastructure.Models.System;
using GreatApp.Infrastructure.Models;

namespace GDNET.WebInfrastructure.Models.PageModels
{
    public sealed class AccountWatchModel : AbstractPageModel
    {
        public UserDetailsModel UserDetails
        {
            get;
            set;
        }

        public IList<ContentItemModel> FocusItems
        {
            get;
            set;
        }

        public AccountWatchModel()
            : base()
        {
            this.UserDetails = new UserDetailsModel();
            this.FocusItems = new List<ContentItemModel>();
        }
    }
}
