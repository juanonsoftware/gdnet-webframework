using GDNET.Domain.Base.Exceptions;

namespace GDNET.Domain.Base.Validators
{
    public sealed class DomainValidator
    {
        public static void NullException(object objet)
        {
            if (objet != null) return;
            throw new DomainException(string.Empty);
        }

        public static void NullOrEmptyException(string objet)
        {
            if (!string.IsNullOrEmpty(objet)) return;
            throw new DomainException(string.Empty);
        }
    }
}
