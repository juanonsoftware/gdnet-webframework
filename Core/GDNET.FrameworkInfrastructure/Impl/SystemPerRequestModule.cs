using System;
using System.Web;
using GDNET.Business;
using GDNET.CastleConfiguration;
using GDNET.Data.Base;
using GDNET.Domain.Repositories;

namespace GDNET.WebInfrastructure.Impl
{
    public class SystemPerRequestModule : IHttpModule
    {
        private HttpApplication context = null;

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            this.context = context;

            this.context.BeginRequest += context_BeginRequest;
            this.context.EndRequest += context_EndRequest;
            this.context.AuthenticateRequest += context_AuthenticateRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            var repositories = new CoreRepositories();
            var frameworkServices = new WebFrameworkServices();
            var businessServices = new BusinessServices();
        }

        void context_EndRequest(object sender, EventArgs e)
        {
        }

        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            string currentUserEmail = "guest@webframework.com";
            if ((this.context.User != null) && this.context.User.Identity.IsAuthenticated)
            {
                currentUserEmail = this.context.User.Identity.Name;
            }

            var currentUser = DomainRepositories.User.FindByEmail(currentUserEmail);
            var sessionContext = new DataSessionContext(currentUser);
        }
    }
}
