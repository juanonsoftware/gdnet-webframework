using System.Collections.Generic;
using GDNET.Framework.Models;
using GDNET.WebInfrastructure.Models.System;
using GreatApp.Infrastructure.Models;

namespace GDNET.WebInfrastructure.Models.PageModels
{
    public class HomeDetailModel : AbstractPageModel
    {
        public ContentItemModel ItemModel
        {
            get;
            set;
        }

        public IList<ContentItemModel> FocusItems
        {
            get;
            set;
        }

        public UserDetailsModel AuthorModel
        {
            get;
            set;
        }

        public HomeDetailModel()
            : base()
        {
            this.ItemModel = new ContentItemModel();
            this.FocusItems = new List<ContentItemModel>();
            this.AuthorModel = new UserDetailsModel();
        }
    }
}
