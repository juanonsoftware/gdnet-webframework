using GDNET.WebInfrastructure.Services.AccountModels;
using GDNET.WebInfrastructure.Services.Storage;

namespace GDNET.WebInfrastructure.Services
{
    public sealed class InfrastructureServices
    {
        public static AccountModelsService AccountModels
        {
            get { return new AccountModelsService(); }
        }

        public static DataStoredService DataStored
        {
            get { return new DataStoredService(); }
        }
    }
}
