using GDNET.Mapping.System.Management;
using GDNET.NHibernate.Mapping;
using GDNET.NHibernate.SessionManagement;
using GDNET.Utils;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using Console = System.Console;

namespace GDNET.DataTests.Base
{
    public class UnitTestSessionManager : ApplicationNHibernateSessionManager
    {
        #region Singleton

        protected UnitTestSessionManager()
            : base(string.Empty, string.Empty)
        {
        }

        private class Nested
        {
            public static readonly UnitTestSessionManager instance = new UnitTestSessionManager();
        }

        public new static UnitTestSessionManager Instance
        {
            get { return Nested.instance; }
        }

        #endregion

        protected override void BuildConfiguration(params IInterceptor[] interceptors)
        {
            var listeMappingTypes = ReflectionAssistant.GetTypesImplementedInterfaceOnAssembly(typeof(IEntityMapping), typeof(EntityHistoryMapping).Assembly);
            var mapper = new ModelMapper();
            mapper.AddMappings(listeMappingTypes);

            Console.WriteLine("HbmMappings");
            Console.WriteLine(mapper.CompileMappingForAllExplicitlyAddedEntities().AsString());

            base.Configuration = new Configuration()
                     .SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
                     .SetProperty(Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
                     .SetProperty(Environment.ShowSql, "true")
                     .SetProperty(Environment.ConnectionString, "Data Source=test.db;new=True;UT8Encoding=True;");

            base.Configuration.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), string.Empty);
            foreach (var interceptor in interceptors)
            {
                base.Configuration.SetInterceptor(interceptor);
            }
        }
    }
}
