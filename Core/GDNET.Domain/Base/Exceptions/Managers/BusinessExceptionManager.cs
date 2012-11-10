namespace GDNET.Domain.Base.Exceptions.Managers
{
    public sealed class BusinessExceptionManager
    {
        public void Throw(string message)
        {
            throw new BusinessException(message);
        }

        public void ThrowIfIsNullOrWhiteSpace(string objet, string message)
        {
            if (string.IsNullOrWhiteSpace(objet))
            {
                throw new BusinessException(message);
            }
        }

        public void ThrowIfIsNullOrWhiteSpace(string objet)
        {
            this.ThrowIfIsNullOrWhiteSpace(objet, string.Empty);
        }

        public void ThrowIfTooShort(string objet, int minLength, string message)
        {
            if (string.IsNullOrWhiteSpace(objet) || (objet.Length < minLength))
            {
                throw new BusinessException(message);
            }
        }

        public void ThrowIfTooShort(string objet, int minLength)
        {
            this.ThrowIfTooShort(objet, minLength, string.Empty);
        }
    }
}
