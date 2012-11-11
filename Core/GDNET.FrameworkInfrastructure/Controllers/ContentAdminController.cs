using System;
using System.Web.Mvc;
using GDNET.AOP.ExceptionHandling;
using GDNET.Domain.Base.SessionManagement;
using GDNET.Framework.Base;
using GDNET.Framework.DataAnnotations;
using GDNET.Framework.Extensions;
using GDNET.WebInfrastructure.Controllers.Base;
using GDNET.WebInfrastructure.Controllers.Extensions;
using GreatApp.Domain.Entities;
using GreatApp.Domain.Repositories;
using GreatApp.Domain.Services;
using GreatApp.Infrastructure.Models;
using GreatApp.Infrastructure.Services;

namespace GDNET.WebInfrastructure.Controllers
{
    [RootAuthorize]
    [CaptureException]
    public class ContentAdminController : AbstractListController
    {
        private readonly IContentItemRepository contentItemRepository;
        private readonly IContentModelsService contentModelsService;
        private readonly IContentBonusService contentBonusService;

        public ContentAdminController(IContentItemRepository contentItemRepository, IContentModelsService contentModelsService, IContentBonusService contentBonusService)
            : base()
        {
            this.contentItemRepository = contentItemRepository;
            this.contentModelsService = contentModelsService;
            this.contentBonusService = contentBonusService;
        }

        public override ActionResult List()
        {
            var listItems = this.contentItemRepository.GetAll();
            var listeModels = FrameworkExtensions.ConvertAll<ContentItemModel, ContentItem>(listItems);

            return base.View(listeModels);
        }

        public ActionResult Details(string id)
        {
            ContentItemModel contentModel = this.contentModelsService.GetContentItemModel(id);
            if (contentModel == null)
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.List()));
            }

            return base.View(contentModel);
        }

        #region Part methods

        public ActionResult MoveUpPart(string id, string cid)
        {
            var contentItem = contentItemRepository.GetById(new Guid(cid));
            if (contentItem != null)
            {
                contentItem.MoveUpPartById(new Guid(id));
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(cid)), new { id = cid });
            }
            else
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.List()));
            }
        }

        public ActionResult MoveDownPart(string id, string cid)
        {
            var contentItem = this.contentItemRepository.GetById(new Guid(cid));
            if (contentItem != null)
            {
                contentItem.MoveDownPartById(new Guid(id));
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(cid)), new { id = cid });
            }
            else
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.List()));
            }
        }

        public ActionResult DeletePart(string id, string cid)
        {
            var contentItem = this.contentItemRepository.GetById(new Guid(cid));
            if (contentItem != null)
            {
                contentItem.RemovePartById(new Guid(id));
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(cid)), new { id = cid });
            }
            else
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.List()));
            }
        }

        public ActionResult EditPart(string id, string cid)
        {
            ContentPartModel partModel = this.contentModelsService.GetContentPartModel(id, cid);
            if (partModel == null)
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(cid)), new { id = cid });
            }
            else
            {
                partModel.Mode = ViewModelMode.Modification;
            }

            return base.View("CreateOrUpdatePart", partModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPart(string id, string cid, ContentPartModel partModel, FormCollection collection)
        {
            if (base.ModelState.IsValid)
            {
                var contentPart = this.contentModelsService.GetContentPart(id, cid);
                if (contentPart != null)
                {
                    this.contentModelsService.UpdateContentPart(contentPart, partModel);
                    this.contentBonusService.CalculateTotalPoints(DomainSessionContext.Instance.CurrentUser);

                    return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(cid)), new { id = cid });
                }
            }

            return base.View("CreateOrUpdatePart", partModel);
        }

        public ActionResult CreatePart(string id)
        {
            ContentPartModel partModel = new ContentPartModel()
            {
                IsActive = true,
                Mode = ViewModelMode.Creation
            };

            return base.View("CreateOrUpdatePart", partModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatePart(string id, ContentPartModel partModel, FormCollection collection)
        {
            if (base.ModelState.IsValid)
            {
                var contentItem = this.contentItemRepository.GetById(new Guid(id));
                if (contentItem != null)
                {
                    var partItem = this.contentModelsService.CreateContentPart(partModel);
                    contentItem.AddPart(partItem);

                    this.contentBonusService.CalculateTotalPoints(DomainSessionContext.Instance.CurrentUser);
                    return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(id)), ControllerAssistant.BuildRouteValues(id));
                }
            }

            return base.View("CreateOrUpdatePart", partModel);
        }

        #endregion

        #region Create methods

        public ActionResult Create()
        {
            ContentItemModel itemModel = new ContentItemModel()
            {
                IsActive = true,
                Mode = ViewModelMode.Creation
            };

            return base.View("CreateOrUpdate", itemModel);
        }

        [HttpPost]
        public ActionResult Create(ContentItemModel itemModel, FormCollection collection)
        {
            if (base.ModelState.IsValid)
            {
                var contentItem = this.contentModelsService.CreateContentItem(itemModel);
                bool result = this.contentItemRepository.Save(contentItem);
                if (result)
                {
                    this.contentBonusService.CalculateTotalPoints(DomainSessionContext.Instance.CurrentUser);

                    string id = contentItem.Id.ToString();
                    return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.CreatePart(id)), ControllerAssistant.BuildRouteValues(id));
                }
            }

            return base.View("CreateOrUpdate", itemModel);
        }

        #endregion

        #region Edit methods

        public ActionResult Edit(string id)
        {
            ContentItemModel contentModel = this.contentModelsService.GetContentItemModel(id);
            if (contentModel == null)
            {
                return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.List()));
            }

            return base.View("CreateOrUpdate", contentModel);
        }

        [HttpPost]
        public ActionResult Edit(string id, ContentItemModel contentModel, FormCollection collection)
        {
            if (base.ModelState.IsValid)
            {
                var contentItem = this.contentItemRepository.GetById(new Guid(id));
                if (contentItem != null)
                {
                    this.contentModelsService.UpdateContentItem(contentItem, contentModel);
                    this.contentBonusService.CalculateTotalPoints(DomainSessionContext.Instance.CurrentUser);

                    return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.Details(id)), new { id = id });
                }
            }

            return base.View("CreateOrUpdate", contentModel);
        }

        #endregion

        #region Delete methods

        public ActionResult Delete(string id)
        {
            this.contentItemRepository.Delete(new Guid(id));
            return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.List()));
        }

        #endregion
    }
}
