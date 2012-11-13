using System;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Windsor.Installer;
using GDNET.CastleConfiguration;
using GDNET.CastleIntergration.Utils;
using GDNET.Data.Base;
using GDNET.DataGeneration.Services;
using GDNET.DataGeneration.SessionManagement;
using GDNET.Domain.Repositories;

namespace GDNET.DataGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterDependencies();

            var repositories = new CoreRepositories();

            var user = DomainRepositories.User.FindByEmail("admin@webframework.com");
            var sessionContext = new DataSessionContext(user);

            // Users
            SystemService.GenerateUsers();

            // Contents
            ContentService.GenerateContentItems();

            DataGenerationNHibernateSessionManager.Instance.CommitTransaction();

            Console.WriteLine();
            Console.Write("Finished...");
        }

        private static void RegisterDependencies()
        {
            IocAssistant.Container = new WindsorContainer(new XmlInterpreter());
            IocAssistant.Container.Install(FromAssembly.InThisApplication());
        }
    }
}
