using GDNET.Framework.Models;
using GDNET.WebInfrastructure.Models.System;

namespace GDNET.WebInfrastructure.Models.PageModels
{
    public class MyChangeLanguageModel : AbstractPageModel
    {
        public UserCustomizedInformationModel UserCustomizedInformation
        {
            get;
            set;
        }

        public MyChangeLanguageModel()
            : base()
        {
        }
    }
}
