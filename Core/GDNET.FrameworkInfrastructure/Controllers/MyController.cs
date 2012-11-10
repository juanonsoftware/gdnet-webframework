using System.Web.Mvc;
using GDNET.AOP.ExceptionHandling;
using GDNET.WebInfrastructure.Controllers.Base;
using GDNET.WebInfrastructure.Controllers.Extensions;
using GDNET.WebInfrastructure.Models.PageModels;
using GDNET.WebInfrastructure.Models.System;
using GDNET.WebInfrastructure.Services;

namespace GDNET.WebInfrastructure.Controllers
{
    [CaptureException]
    public class MyController : AbstractController
    {
        public ActionResult ChangeLanguage()
        {
            MyChangeLanguageModel model = new MyChangeLanguageModel();
            model.UserCustomizedInformation = InfrastructureServices.DataStored.GetUserCustomizedInfo();
            model.PageMeta.Keywords = "";
            model.PageMeta.Description = "";
            model.PageMeta.Author = "";

            return base.View(model);
        }

        [HttpPost]
        public ActionResult ChangeLanguage(MyChangeLanguageModel model)
        {
            if (base.ModelState.IsValid)
            {
                UserCustomizedInformationModel customizedModel = new UserCustomizedInformationModel(model.UserCustomizedInformation.Language, model.UserCustomizedInformation.LanguageUI);
                InfrastructureServices.DataStored.SetUserCustomizedInfo(customizedModel);

                return base.RedirectToAction("Index", ListControllers.Home, new { language = model.UserCustomizedInformation.LanguageUI });
            }

            return base.View(model);
        }
    }
}
