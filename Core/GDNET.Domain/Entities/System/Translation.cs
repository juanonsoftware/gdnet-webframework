using GDNET.Domain.Entities.System.Management;

namespace GDNET.Domain.Entities.System
{
    public partial class Translation : EntityHistoryComplex
    {
        #region Properties

        public virtual string Keyword
        {
            get;
            protected set;
        }

        public virtual string Language
        {
            get;
            protected set;
        }

        public virtual string Value
        {
            get;
            set;
        }

        #endregion

        internal protected Translation() { }
    }
}
