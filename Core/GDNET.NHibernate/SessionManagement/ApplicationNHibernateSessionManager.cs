using System.IO;
using System.Reflection;
using GDNET.NHibernate.Helpers;
using GDNET.NHibernate.Interceptors;
using NHibernate.Cfg;
using NHibernate.Context;

namespace GDNET.NHibernate.SessionManagement
{
    public class ApplicationNHibernateSessionManager : AbstractNHibernateSessionManager
    {
        protected string hibernateConfiguration;
        protected string mappingAssemblies;

        private const string DefaultHibernateConfigurationFile = "App_Data/hibernate.cfg.xml";
        private const string DefaultMappingAssembliesFile = "App_Data/MappingAssemblies.txt";

        #region Singleton

        private class Nested
        {
            public static readonly ApplicationNHibernateSessionManager instance = new ApplicationNHibernateSessionManager();
        }

        public new static ApplicationNHibernateSessionManager Instance
        {
            get { return Nested.instance; }
        }

        #endregion

        private ApplicationNHibernateSessionManager()
            : this(string.Empty, string.Empty)
        {
        }

        protected ApplicationNHibernateSessionManager(string hibernateConfigurationFile, string mappingAssembliesFile)
        {
            if (string.IsNullOrEmpty(hibernateConfigurationFile))
            {
                hibernateConfigurationFile = DefaultHibernateConfigurationFile;
            }
            if (string.IsNullOrEmpty(mappingAssembliesFile))
            {
                mappingAssembliesFile = DefaultMappingAssembliesFile;
            }

            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            hibernateConfiguration = Path.Combine(directory, hibernateConfigurationFile);
            mappingAssemblies = Path.Combine(directory, mappingAssembliesFile);

            this.BuildSessionFactory();
        }

        protected virtual void BuildSessionFactory()
        {
            base.Configuration = ConfigurationAssistant.BuildConfiguration(this.mappingAssemblies, this.hibernateConfiguration, this.ApplicationDirectory, new EntityWithModificationInterceptor());
            _sessionFactory = base.Configuration.CurrentSessionContext<CallSessionContext>().BuildSessionFactory();
        }

        protected virtual string ApplicationDirectory
        {
            get { return Directory.GetCurrentDirectory(); }
        }
    }
}
