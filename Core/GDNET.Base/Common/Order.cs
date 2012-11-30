namespace GDNET.Base.Common
{
    public sealed class Order
    {
        public string By { get; private set; }
        public bool Ascending { get; private set; }

        public Order(string by, bool ascending)
        {
            By = by;
            Ascending = ascending;
        }
    }
}
