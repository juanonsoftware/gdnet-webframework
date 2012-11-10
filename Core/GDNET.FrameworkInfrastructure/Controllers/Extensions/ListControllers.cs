using System.Web.Mvc;

namespace GDNET.WebInfrastructure.Controllers.Extensions
{
    public sealed class ListControllers
    {
        public static string Home
        {
            get
            {
                string fullName = typeof(HomeController).Name;
                return fullName.Substring(0, fullName.Length - typeof(Controller).Name.Length);
            }
        }

        public static string Account
        {
            get
            {
                string fullName = typeof(AccountController).Name;
                return fullName.Substring(0, fullName.Length - typeof(Controller).Name.Length);
            }
        }

        public static string ContentAdmin
        {
            get
            {
                string fullName = typeof(ContentAdminController).Name;
                return fullName.Substring(0, fullName.Length - typeof(Controller).Name.Length);
            }
        }

        public static string My
        {
            get
            {
                string fullName = typeof(MyController).Name;
                return fullName.Substring(0, fullName.Length - typeof(Controller).Name.Length);
            }
        }

        public static string Search
        {
            get
            {
                string fullName = typeof(SearchController).Name;
                return fullName.Substring(0, fullName.Length - typeof(Controller).Name.Length);
            }
        }
    }
}
