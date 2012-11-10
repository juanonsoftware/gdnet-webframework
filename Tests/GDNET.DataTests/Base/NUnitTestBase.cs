using System;
using System.IO;
using GDNET.Business;
using GDNET.Data;
using GDNET.Data.Base;
using GDNET.Domain.Entities.System;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Console = System.Console;

namespace GDNET.DataTests.Base
{
    public class NUnitTestBase
    {
        private DateTime startDate;

        [SetUp]
        public void SetUp()
        {
            var servicesManager = new BusinessServices();
            var sessionStrategy = new DataRepositoryStrategy(UnitTestSessionManager.Instance);
            var repositories = new DataRepositories(sessionStrategy);

            UnitTestSessionManager.Instance.BeginTransaction();
            ISession currentSession = UnitTestSessionManager.Instance.GetSession();
            (new SchemaExport(UnitTestSessionManager.Instance.Configuration)).Execute(true, true, false, currentSession.Connection, Console.Out);

            User currentUser = User.Factory.Create("test@mail.com", "123456");
            var sessionContext = new DataSessionContext(currentUser);

            Console.WriteLine();
            Console.WriteLine("------------->>");
            this.startDate = DateTime.Now;
        }

        [TearDown]
        public void TearDown()
        {
            UnitTestSessionManager.Instance.CommitTransaction();
            Console.WriteLine();
            Console.WriteLine("<<-------------");
            Console.WriteLine(DateTime.Now - this.startDate);

            UnitTestSessionManager.Instance.CloseSession();
            File.Delete("test.db");
        }
    }
}
