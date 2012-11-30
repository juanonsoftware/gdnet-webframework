using GDNET.Base.Common;
using NHOrder = NHibernate.Criterion.Order;

namespace GDNET.Data.Base
{
    public static class OrderExtensions
    {
        public static NHOrder ToNhOrder(this Order order)
        {
            return new NHOrder(order.By, order.Ascending);
        }
    }
}
