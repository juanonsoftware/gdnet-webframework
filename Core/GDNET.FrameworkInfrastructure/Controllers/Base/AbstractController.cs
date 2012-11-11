using System.Web.Mvc;
using System.Web.Routing;
using Castle.Core.Logging;

namespace GDNET.WebInfrastructure.Controllers.Base
{
    public abstract class AbstractController : Controller
    {
        private ILogger logger = NullLogger.Instance;

        public ILogger Logger
        {
            get { return this.logger; }
            set { this.logger = value; }
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
    }
}