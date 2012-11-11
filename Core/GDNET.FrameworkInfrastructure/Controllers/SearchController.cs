using System;
using System.Web.Mvc;
using GDNET.AOP.ExceptionHandling;
using GDNET.Domain.Repositories;
using GDNET.Framework.Extensions;
using GDNET.Framework.Services;
using GDNET.WebInfrastructure.Controllers.Base;
using GDNET.WebInfrastructure.Models.PageModels;
using GDNET.WebInfrastructure.Models.System;
using GDNET.WebInfrastructure.Services;
using GreatApp.Domain.Entities;
using GreatApp.Domain.Repositories;
using GreatApp.Infrastructure.Models;

namespace GDNET.WebInfrastructure.Controllers
{
    [CaptureException]
    public class SearchController : AbstractController
    {
        private const int DefaultPageSize = 10;
        private const int FocusItemSize = 10;
        private const string SearchBy = "by";
        private const string SearchValue = "value";
        private const string SearchAuthor = "author";

        private readonly IContentItemRepository contentItemRepository = null;

        public SearchController(IContentItemRepository contentItemRepository)
            : base()
        {
            this.contentItemRepository = contentItemRepository;
        }

        public ActionResult Index()
        {
            string searchBy = base.Request.Params[SearchBy];

            switch (searchBy)
            {
                case SearchAuthor:
                    return this.SearchByAuthor();
                default:
                    return base.RedirectToAction("Index", "Home");
            }
        }

        private ActionResult SearchByAuthor()
        {
            string authorId = base.Request.Params[SearchValue];
            Guid guid = Guid.Empty;
            SearchByAuthorModel model = new SearchByAuthorModel(SearchMode.Author);

            if (Guid.TryParse(authorId, out guid))
            {
                var author = DomainRepositories.User.GetById(guid);
                var authorModel = InfrastructureServices.AccountModels.GetUserModel<UserDetailsModel>(author);
                authorModel.DisplayMode = UserDetailsMode.Search;

                var topItems = this.contentItemRepository.GetTopWithActiveByAuthor(DefaultPageSize, author.Email);
                var topModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(topItems, true);

                var focusItems = this.contentItemRepository.GetTopWithActiveByViews(FocusItemSize);
                var focusModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(focusItems, true);

                model.NewItems = topModels;
                model.FocusItems = focusModels;
                model.AuthorModel = authorModel;
                model.PageMeta.Description = string.Format(FrameworkServices.Translation.GetByKeyword("GUI.Search.ByAuthor.Description"), authorModel.DisplayName);
                model.PageMeta.Author = authorModel.DisplayName;
            }

            return base.View("SearchByAuthor", model);
        }
    }
}
