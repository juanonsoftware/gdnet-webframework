using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace GDNET.WebInfrastructure.Controllers.Extensions
{
    public static class ControllerAssistant
    {
        public static string GetControllerName(Type controllerType)
        {
            var myType = controllerType;

            while (myType.BaseType != null)
            {
                if (myType.BaseType.FullName == typeof(Controller).FullName)
                {
                    if (controllerType.Name.EndsWith(typeof(Controller).Name))
                    {
                        return controllerType.Name.Substring(0, controllerType.Name.Length - typeof(Controller).Name.Length);
                    }
                    else
                    {
                        return controllerType.Name;
                    }
                }

                myType = myType.BaseType;
            }

            return string.Empty;
        }

        public static string GetActionName(Expression<Action> expression)
        {
            if (expression != null && expression.Body != null)
            {
                MethodCallExpression m = expression.Body as MethodCallExpression;
                if (m != null)
                {
                    return m.Method.Name;
                }
            }

            return null;
        }

        public static object BuildRouteValues(string idValue)
        {
            return new { id = idValue };
        }
    }
}
