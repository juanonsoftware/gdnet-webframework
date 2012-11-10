using GDNET.Domain.Base.Exceptions.Managers;

namespace GDNET.Domain.Base.Exceptions
{
    public sealed class ExceptionsManager
    {
        public static BusinessExceptionManager BusinessException
        {
            get { return new BusinessExceptionManager(); }
        }
    }
}
