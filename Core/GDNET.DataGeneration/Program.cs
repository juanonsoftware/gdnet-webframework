using System;
using GDNET.Business;
using GDNET.Data;
using GDNET.Data.Base;
using GDNET.DataGeneration.Helpers;
using GDNET.DataGeneration.SessionManagement;
using GDNET.Domain.Repositories;
using NHibernate;

namespace GDNET.DataGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            var sessionStrategy = new DataRepositoryStrategy(DataGenerationNHibernateSessionManager.Instance);
            var repositories = new DataRepositories(sessionStrategy);
            var servicesManager = new BusinessServices();

            var user = DomainRepositories.User.FindByEmail("admin@webframework.com");
            var sessionContext = new DataSessionContext(user);

            DataGenerationNHibernateSessionManager.Instance.BeginTransaction();
            ISession currentSession = DataGenerationNHibernateSessionManager.Instance.GetSession();

            // Users
            SystemAssistant.GenerateUsers();

            // Contents
            ContentAssistant.GenerateContentItems();

            DataGenerationNHibernateSessionManager.Instance.CommitTransaction();

            Console.WriteLine();
            Console.Write("Finished...");
        }
    }
}
