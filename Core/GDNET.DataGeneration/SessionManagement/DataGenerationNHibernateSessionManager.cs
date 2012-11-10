using GDNET.NHibernate.SessionManagement;

namespace GDNET.DataGeneration.SessionManagement
{
    public class DataGenerationNHibernateSessionManager : ApplicationNHibernateSessionManager
    {
        #region Singleton

        private class Nested
        {
            public static readonly DataGenerationNHibernateSessionManager instance = new DataGenerationNHibernateSessionManager();
        }

        public new static DataGenerationNHibernateSessionManager Instance
        {
            get { return Nested.instance; }
        }

        #endregion

        protected DataGenerationNHibernateSessionManager()
            : base(string.Empty, string.Empty)
        {
        }
    }
}
