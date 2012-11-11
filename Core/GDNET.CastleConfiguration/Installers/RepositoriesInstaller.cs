using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GDNET.Data;
using GreatApp.Data;

namespace GDNET.CastleConfiguration.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// TODO: Should be changed for dynamically register repositories
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<DataRepositories>()
                                      .Where(Component.IsInSameNamespaceAs<DataRepositories>(true))
                                      .WithService.AllInterfaces()
                                      .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<AppDataRepositories>()
                                      .Where(Component.IsInSameNamespaceAs<AppDataRepositories>(true))
                                      .WithService.AllInterfaces()
                                      .LifestyleTransient());
        }
    }
}
