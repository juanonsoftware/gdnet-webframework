using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using GDNET.Domain.Entities.System.ReferenceData;
using GDNET.Domain.Repositories;

namespace GDNET.WebInfrastructure.Common.Base
{
    public class LanguageRouteConstraint : IRouteConstraint
    {
        private static List<string> _languagesCode = new List<string>();

        private static void TryIntializeLanguages()
        {
            if (_languagesCode.Count == 0)
            {
                var languageCatalog = DomainRepositories.Catalog.FindByCode(SystemCatalogs.Languages);
                _languagesCode.AddRange(languageCatalog.Lines.Select(x => x.Code));
            }
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            LanguageRouteConstraint.TryIntializeLanguages();

            string aValue = values[parameterName].ToString();
            return _languagesCode.Contains(aValue);
        }
    }
}
