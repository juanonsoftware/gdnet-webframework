namespace GDNET.Domain.Base.Exceptions
{
    public sealed class BusinessException : DomainException
    {
        public BusinessException()
            : base()
        {
        }

        public BusinessException(string message)
            : base(message)
        {
        }
    }
}
