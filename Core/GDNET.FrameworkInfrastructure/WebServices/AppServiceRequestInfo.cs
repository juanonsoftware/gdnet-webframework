namespace GDNET.WebInfrastructure.WebServices
{
    public sealed class AppServiceRequestInfo
    {
        public int MaxRows
        {
            get;
            private set;
        }

        public string Query
        {
            get;
            private set;
        }

        public AppServiceOperator Operator
        {
            get;
            private set;
        }

        public AppServiceRequestInfo()
        {
            this.Operator = AppServiceOperator.Unknown;
        }

        public AppServiceRequestInfo(int maxRows, string query, AppServiceOperator @operator)
        {
            this.MaxRows = maxRows;
            this.Query = query;
            this.Operator = @operator;
        }
    }
}
