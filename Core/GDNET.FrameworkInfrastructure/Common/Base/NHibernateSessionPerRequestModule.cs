using System;
using System.Web;
using GDNET.Business;
using GDNET.CastleConfiguration;
using GDNET.Data.Base;
using GDNET.Domain.Repositories;
using GDNET.WebInfrastructure.Impl;

namespace GDNET.WebInfrastructure.Common.Base
{
    public class NHibernateSessionPerRequestModule : IHttpModule
    {
        private HttpApplication context;

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
            context.AuthenticateRequest += context_AuthenticateRequest;

            this.context = context;
        }

        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            string currentUserEmail = "guest@webframework.com";
            if ((this.context.User != null) && this.context.User.Identity.IsAuthenticated)
            {
                currentUserEmail = this.context.User.Identity.Name;
            }

            new CoreRepositories();
            new WebFrameworkServices();
            new BusinessServices();
            var currentUser = DomainRepositories.User.FindByEmail(currentUserEmail);
            var sessionContext = new DataSessionContext(currentUser);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            WebNHibernateSessionManager.Instance.BeginTransaction();
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            WebNHibernateSessionManager.Instance.CommitTransaction();
            WebNHibernateSessionManager.Instance.CloseSession();
        }
    }
}
