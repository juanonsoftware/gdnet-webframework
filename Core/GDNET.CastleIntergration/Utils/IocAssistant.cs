using Castle.Windsor;

namespace GDNET.CastleIntergration.Utils
{
    public static class IocAssistant
    {
        public static IWindsorContainer Container
        {
            get;
            set;
        }

        public static T Resolve<T>()
        {
            return IocAssistant.Container.Resolve<T>();
        }
    }
}
