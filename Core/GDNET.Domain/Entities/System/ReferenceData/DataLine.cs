using GDNET.Domain.Entities.System.Management;

namespace GDNET.Domain.Entities.System
{
    public partial class DataLine : EntityHistoryComplex
    {
        #region Properties

        public virtual string Code
        {
            get;
            protected set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual int Position
        {
            get;
            protected set;
        }

        #endregion

        internal protected DataLine() { }
    }
}
