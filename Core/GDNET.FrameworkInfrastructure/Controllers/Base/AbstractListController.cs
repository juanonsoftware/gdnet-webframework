using System.Web.Mvc;
using GDNET.WebInfrastructure.Controllers.Extensions;

namespace GDNET.WebInfrastructure.Controllers.Base
{
    public abstract class AbstractListController : AbstractController
    {
        public ActionResult Index()
        {
            return base.RedirectToAction(ControllerAssistant.GetActionName(() => this.List()));
        }

        public abstract ActionResult List();
    }
}