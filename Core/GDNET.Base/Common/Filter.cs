namespace GDNET.Base.Common
{
    public sealed class Filter
    {
        public string By { get; private set; }
        public object Value { get; private set; }

        public Filter(string by, object value)
        {
            By = by;
            Value = value;
        }
    }
}
