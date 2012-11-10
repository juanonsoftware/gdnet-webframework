using System.Web.Mvc;
using System.Web.Routing;

namespace GDNET.WebInfrastructure.Controllers.Base
{
    public abstract class AbstractController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
    }
}