using System;
using System.Web.Mvc;
using GDNET.AOP.ExceptionHandling;
using GDNET.Framework.Extensions;
using GDNET.Framework.Services;
using GDNET.WebInfrastructure.Common;
using GDNET.WebInfrastructure.Controllers.Base;
using GDNET.WebInfrastructure.Controllers.Extensions;
using GDNET.WebInfrastructure.Models.PageModels;
using GDNET.WebInfrastructure.Models.System;
using GDNET.WebInfrastructure.Services;
using GreatApp.Domain.Entities;
using GreatApp.Domain.Repositories;
using GreatApp.Infrastructure.Models;
using GreatApp.Infrastructure.Services;

namespace GDNET.WebInfrastructure.Controllers
{
    [CaptureException]
    public class HomeController : AbstractController
    {
        private readonly IContentItemRepository contentItemRepository;
        private readonly IContentModelsService contentModelsService;

        public HomeController(IContentItemRepository contentItemRepository, IContentModelsService contentModelsService)
            : base()
        {
            this.contentItemRepository = contentItemRepository;
            this.contentModelsService = contentModelsService;
        }

        public ActionResult Index()
        {
            var listContentItems = this.contentItemRepository.GetTopWithActive(GlobalSettings.DefaultPageSize);
            var listItems = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(listContentItems, true);

            var focusItems = this.contentItemRepository.GetTopWithActiveByViews(GlobalSettings.FocusItemSize);
            var focusModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(focusItems, true);

            HomeIndexModel model = new HomeIndexModel()
            {
                NewItems = listItems,
                FocusItems = focusModels,
            };
            model.PageMeta.Description = "";
            model.PageMeta.Author = FrameworkServices.Translation.GetByKeyword("GUI.Common.SiteAuthor");
            model.PageMeta.Keywords = FrameworkServices.Translation.GetByKeyword("GUI.Page.Home.Keywords");

            return base.View(model);
        }

        public ActionResult Details(string id)
        {
            ContentItemModel contentModel = this.contentModelsService.GetContentItemModel(id, true, true);
            if (contentModel == null)
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Index()));
            }

            var focusItems = this.contentItemRepository.GetTopWithActiveByViews(GlobalSettings.FocusItemSize, new Guid(id));
            var focusModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(focusItems, true);

            var authorModel = InfrastructureServices.AccountModels.GetUserModelByEmail<UserDetailsModel>(contentModel.CreatedBy);
            authorModel.DisplayMode = UserDetailsMode.Default;

            HomeDetailModel model = new HomeDetailModel()
            {
                ItemModel = contentModel,
                FocusItems = focusModels,
                AuthorModel = authorModel
            };
            model.PageMeta.Keywords = contentModel.Keywords;
            model.PageMeta.Description = contentModel.Description;
            model.PageMeta.Author = authorModel.DisplayName;

            return base.View(model);
        }

        public ActionResult About()
        {
            return base.View();
        }
    }
}
