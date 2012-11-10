using GDNET.Domain.Base.Exceptions;

namespace GDNET.Domain.Base.Validators
{
    public sealed class DomainValidator
    {
        #region Singleton

        private DomainValidator() { }

        private class Nested
        {
            public static readonly DomainValidator instance = new DomainValidator();
        }

        public static DomainValidator Instance
        {
            get { return Nested.instance; }
        }

        #endregion

        public void NullException(object objet)
        {
            if (objet == null)
            {
                string message = string.Empty;
                throw new DomainException(message);
            }
        }

        public void NullOrEmptyException(string objet)
        {
            if (string.IsNullOrEmpty(objet))
            {
                string message = string.Empty;
                throw new DomainException(message);
            }
        }
    }
}
