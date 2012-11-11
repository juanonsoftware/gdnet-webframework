using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Windsor.Installer;
using GDNET.CastleIntergration;
using GDNET.CastleIntergration.Mvc;
using GDNET.Framework.Extensions;
using GDNET.WebInfrastructure.Common.Base;
using GDNET.WebInfrastructure.Common.Handlers;
using log4net.Config;

namespace GDNET.WebInfrastructure.Impl
{
    public class GDNETHttpApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            BootstrapContainer();

            // Configure Log4Net
            XmlConfigurator.Configure();
        }

        protected void Application_End()
        {
            IocAssistant.Container.Dispose();
        }

        private static void BootstrapContainer()
        {
            IocAssistant.Container = new WindsorContainer(new XmlInterpreter());
            IocAssistant.Container.Install(FromAssembly.InThisApplication());

            var controllerFactory = new WindsorControllerFactory(IocAssistant.Container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            foreach (Route aRoute in routes)
            {
                if (!(aRoute.RouteHandler is NormalMvcRouteHandler))
                {
                    aRoute.RouteHandler = new MultilingualMvcRouteHandler();
                    aRoute.Url = "{" + FrameworkConstants.LanguageRouteKey + "}/" + aRoute.Url;

                    if (aRoute.Defaults == null)
                    {
                        aRoute.Defaults = new RouteValueDictionary();
                    }
                    aRoute.Defaults.Add(FrameworkConstants.LanguageRouteKey, "vi");

                    if (aRoute.Constraints == null)
                    {
                        aRoute.Constraints = new RouteValueDictionary();
                    }
                    aRoute.Constraints.Add(FrameworkConstants.LanguageRouteKey, new LanguageRouteConstraint());
                }
            }
        }
    }
}
