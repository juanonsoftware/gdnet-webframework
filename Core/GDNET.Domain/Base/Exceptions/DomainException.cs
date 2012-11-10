using System;

namespace GDNET.Domain.Base.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException()
            : base()
        {
        }

        public DomainException(string message)
            : base(message)
        {
        }
    }
}
