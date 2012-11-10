using System;
using GDNET.Utils;

namespace GDNET.WebInfrastructure.WebServices
{
    public static class AppServiceAssistant
    {
        private const string SEPARATOR = "&";

        public static AppServiceRequestInfo Parse(string parameters, string query)
        {
            AppServiceRequestInfo result = new AppServiceRequestInfo();

            if (!string.IsNullOrEmpty(parameters))
            {
                int index1 = 0, index2 = 0;

                // MaxRows
                int maxRows = 10;
                if (parameters.Contains(AppServiceConstant.MaxRows))
                {
                    index1 = parameters.IndexOf(AppServiceConstant.MaxRows) + AppServiceConstant.MaxRows.Length + 1;
                    index2 = parameters.IndexOf(SEPARATOR, index1);
                    maxRows = Convert.ToInt32(parameters.Substring(index1, index2 - index1));
                }

                // Operator
                AppServiceOperator @operator = AppServiceOperator.Unknown;
                if (parameters.Contains(AppServiceConstant.Operator))
                {
                    index1 = parameters.IndexOf(AppServiceConstant.Operator) + AppServiceConstant.Operator.Length + 1;
                    index2 = parameters.IndexOf(SEPARATOR, index1);
                    if (index2 < 0)
                    {
                        index2 = parameters.Length;
                    }

                    @operator = EnumAssistant.Parse<AppServiceOperator>(parameters.Substring(index1, index2 - index1));
                }

                result = new AppServiceRequestInfo(maxRows, query, @operator);
            }

            return result;
        }
    }
}
