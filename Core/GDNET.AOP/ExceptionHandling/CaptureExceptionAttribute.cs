using System;
using System.Reflection;
using log4net;
using PostSharp.Aspects;

namespace GDNET.AOP.ExceptionHandling
{
    [Serializable]
    public class CaptureExceptionAttribute : OnExceptionAspect
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CaptureExceptionAttribute));

        [NonSerialized]
        private readonly Type exceptionType;

        public CaptureExceptionAttribute()
        {
        }

        public CaptureExceptionAttribute(Type exceptionType)
        {
            this.exceptionType = exceptionType;
        }

        public override Type GetExceptionType(MethodBase targetMethod)
        {
            return this.exceptionType;
        }

        public override void OnException(MethodExecutionArgs args)
        {
            logger.Error(args.Instance.ToString(), args.Exception);
            args.FlowBehavior = FlowBehavior.ThrowException;
        }
    }
}
