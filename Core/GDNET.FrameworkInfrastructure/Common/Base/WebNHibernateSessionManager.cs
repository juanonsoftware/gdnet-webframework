using System.IO;
using System.Web.Hosting;
using GDNET.NHibernate.Helpers;
using GDNET.NHibernate.Interceptors;
using GDNET.NHibernate.SessionManagement;
using NHibernate.Cfg;
using NHibernate.Context;

namespace GDNET.WebInfrastructure.Common.Base
{
    public class WebNHibernateSessionManager : ApplicationNHibernateSessionManager
    {
        #region Singleton

        private class Nested
        {
            public static readonly WebNHibernateSessionManager instance = new WebNHibernateSessionManager();
        }

        public new static WebNHibernateSessionManager Instance
        {
            get { return Nested.instance; }
        }

        #endregion

        private static readonly string WebMappingAssemblies = HostingEnvironment.MapPath("~/App_Data/MappingAssemblies.txt");
        private static readonly string WebHibernateConfiguration = HostingEnvironment.MapPath("~/App_Data/hibernate.cfg.xml");

        protected WebNHibernateSessionManager()
            : base(WebHibernateConfiguration, WebMappingAssemblies)
        {
        }

        protected override void BuildSessionFactory()
        {
            base.Configuration = ConfigurationAssistant.BuildConfiguration(this.mappingAssemblies, this.hibernateConfiguration, this.ApplicationDirectory, new EntityWithModificationInterceptor());
            _sessionFactory = base.Configuration.CurrentSessionContext<WebSessionContext>().BuildSessionFactory();
        }

        protected override string ApplicationDirectory
        {
            get { return Path.Combine(HostingEnvironment.MapPath("~/"), "bin"); }
        }
    }
}
