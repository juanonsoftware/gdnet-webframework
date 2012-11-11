using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GDNET.Framework.Services;
using GreatApp.Business;
using GreatApp.Infrastructure.Services;

namespace GDNET.WebInfrastructure.Installers
{
    public class BusinessServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register all services within namespace of class AppInfrastructureServices
            container.Register(Classes.FromAssemblyContaining<AppInfrastructureServices>()
                                      .Where(Component.IsInSameNamespaceAs<AppInfrastructureServices>(true))
                                      .WithService.AllInterfaces()
                                      .LifestyleTransient());

            // Register all services within namespace of class AppBusinessServices
            container.Register(Classes.FromAssemblyContaining<AppBusinessServices>()
                                      .Where(Component.IsInSameNamespaceAs<AppBusinessServices>(true))
                                      .WithService.AllInterfaces()
                                      .LifestyleTransient());

            // Register all services in current assembly
            container.Register(Classes.FromAssemblyContaining<FrameworkServices>()
                                      .Where(Component.IsInSameNamespaceAs<FrameworkServices>(true))
                                      .WithService.AllInterfaces()
                                      .LifestyleTransient());
        }
    }
}
