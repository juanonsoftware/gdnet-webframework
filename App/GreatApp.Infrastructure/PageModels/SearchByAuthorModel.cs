using GDNET.WebInfrastructure.Models.System;

namespace GDNET.WebInfrastructure.Models.PageModels
{
    public class SearchByAuthorModel : HomeIndexModel
    {
        public SearchByAuthorModel(SearchMode mode)
            : base()
        {
            this.Mode = mode;
            this.AuthorModel = new UserDetailsModel();
        }

        public SearchMode Mode
        {
            get;
            set;
        }

        public UserDetailsModel AuthorModel
        {
            get;
            set;
        }
    }
}
