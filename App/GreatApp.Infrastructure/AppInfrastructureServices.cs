using GreatApp.Infrastructure.Services;

namespace GreatApp.Infrastructure
{
    public sealed class AppInfrastructureServices
    {
        public static ContentModelsService ContentModels
        {
            get { return new ContentModelsService(); }
        }
    }
}
