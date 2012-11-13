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
        private static string MappingAssemblies = HostingEnvironment.MapPath("~/App_Data/MappingAssemblies.txt");
        private static string HibernateConfiguration = HostingEnvironment.MapPath("~/App_Data/hibernate.cfg.xml");
        private static string ApplicationDirectory = Path.Combine(HostingEnvironment.MapPath("~/"), "bin");

        public NHibernateFacility()
            : base()
        {
        }

        public NHibernateFacility(string mappingAssemblies, string hibernateConfiguration, string applicationDirectory)
            : base()
        {
            MappingAssemblies = mappingAssemblies;
            HibernateConfiguration = hibernateConfiguration;
            ApplicationDirectory = applicationDirectory;
        }

        protected override void Init()
        {
            var modificationInterceptor = new EntityWithModificationInterceptor();
            var nhConfig = ConfigurationAssistant.BuildConfiguration(MappingAssemblies, HibernateConfiguration, ApplicationDirectory, modificationInterceptor);

            base.Kernel.Register(
                Component.For<ISessionFactory>()
                    .UsingFactoryMethod(() => nhConfig.BuildSessionFactory()),
                Component.For<ISession>()
                    .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
                    .LifestylePerWebRequest()
                );
        }
    }
}
