using System;
using System.Web;
using GDNET.CastleIntergration.Utils;
using NHibernate;

namespace GDNET.CastleIntergration.Modules
{
    /// <summary>
    /// NHibernate Session & Transaction management module following the TransactionPerRequest pattern.
    /// </summary>
    public class NHibernateSessionPerRequestModule : IHttpModule
    {
        private HttpApplication context = null;
        private ISession nhSession = null;
        private ITransaction nhTransaction = null;

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            this.context = context;

            this.context.BeginRequest += context_BeginRequest;
            this.context.EndRequest += context_EndRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            this.nhSession = IocAssistant.Resolve<ISession>();
            this.nhTransaction = this.nhSession.BeginTransaction();
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            if (this.nhTransaction.IsActive && !this.nhTransaction.WasCommitted)
            {
                this.nhTransaction.Commit();
            }
            if (this.nhSession.IsOpen)
            {
                this.nhSession.Close();
            }

            this.nhTransaction.Dispose();
            this.nhSession.Dispose();
        }
    }
}
