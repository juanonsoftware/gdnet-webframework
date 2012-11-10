using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using GreatApp.Domain;

namespace GDNET.WebInfrastructure.WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class AppServiceImpl : WebService
    {
        [WebMethod(true)]
        public string Hello()
        {
            string message = "Platform: " + HttpContext.Current.Request.Browser.Platform;
            message += ", Browser: " + HttpContext.Current.Request.Browser.Browser;
            message += ", Now: " + DateTime.Now.ToString();

            return message;
        }

        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<DataItemDTO> GetJsonResults(string @params, string query)
        {
            List<DataItemDTO> results = new List<DataItemDTO>();

            AppServiceRequestInfo requestInfo = AppServiceAssistant.Parse(@params, query);
            switch (requestInfo.Operator)
            {
                case AppServiceOperator.SearchContent:
                    var listContentItems = AppDomainRepositories.ContentItem.SearchTopWithActive(requestInfo.MaxRows, requestInfo.Query);
                    foreach (var contentItem in listContentItems)
                    {
                        var dto = new DataItemDTO()
                        {
                            Id = contentItem.Id.ToString(),
                            Label = contentItem.Name
                        };
                        results.Add(dto);
                    }
                    break;
            }

            return results;
        }
    }
}
