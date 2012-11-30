using System.IO;
using System.Web.Hosting;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using GDNET.CastleIntergration.Interceptors;
using GDNET.CastleIntergration.Utils;
using NHibernate;

namespace GDNET.CastleIntergration.Facilities
{
    public class NHibernateFacility : AbstractFacility
    {
        private static string _mappingAssemblies = HostingEnvironment.MapPath("~/App_Data/MappingAssemblies.txt");
        private static string _hibernateConfiguration = HostingEnvironment.MapPath("~/App_Data/hibernate.cfg.xml");
        private static string _applicationDirectory = Path.Combine(HostingEnvironment.MapPath("~/"), "bin");

        public NHibernateFacility()
        {
        }

        public NHibernateFacility(string mappingAssemblies, string hibernateConfiguration, string applicationDirectory)
        {
            _mappingAssemblies = mappingAssemblies;
            _hibernateConfiguration = hibernateConfiguration;
            _applicationDirectory = applicationDirectory;
        }

        protected override void Init()
        {
            var modificationInterceptor = new EntityWithModificationInterceptor();
            var nhConfig = ConfigurationAssistant.BuildConfiguration(_mappingAssemblies, _hibernateConfiguration, _applicationDirectory, modificationInterceptor);

            Kernel.Register(
                Component.For<ISessionFactory>()
                    .UsingFactoryMethod(nhConfig.BuildSessionFactory),
                Component.For<ISession>()
                    .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
                    .LifestylePerWebRequest()
                );
        }
    }
}
