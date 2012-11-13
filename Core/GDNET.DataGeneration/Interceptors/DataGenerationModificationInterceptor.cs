using GDNET.CastleIntergration.Interceptors;

namespace GDNET.DataGeneration.Interceptors
{
    public class DataGenerationModificationInterceptor : EntityWithModificationInterceptor
    {
        protected override string GetEmailCurrentUser()
        {
            return "data@webframework";
        }
    }
}
