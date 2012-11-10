using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GDNET.Domain.Entities.System.Management;

namespace GDNET.Domain.Entities.System
{
    public partial class Catalog : EntityHistoryComplex
    {
        private IList<DataLine> lines = new List<DataLine>();

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

        public virtual bool IsCustomizable
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<DataLine> Lines
        {
            get { return new ReadOnlyCollection<DataLine>(this.lines); }
        }

        #endregion

        #region Methods

        public virtual Catalog AddDataLine(DataLine aLine)
        {
            if (!this.lines.Contains(aLine))
            {
                this.lines.Add(aLine);
            }

            return this;
        }

        public virtual Catalog AddDataLines(IList<DataLine> listOfLines)
        {
            foreach (var aLine in listOfLines)
            {
                this.AddDataLine(aLine);
            }

            return this;
        }

        public virtual Catalog AddDataLines(params DataLine[] listOfLines)
        {
            return this.AddDataLines(listOfLines.ToList());
        }

        public virtual Catalog RemoveDataLine(DataLine aLine)
        {
            if (this.lines.Contains(aLine))
            {
                this.lines.Remove(aLine);
            }

            return this;
        }

        public virtual DataLine GetLineByCode(string code)
        {
            return this.Lines.FirstOrDefault(x => x.Code == code);
        }

        #endregion

        internal protected Catalog() { }
    }
}
