using System.Collections.Generic;
using System.Linq;

namespace GDNET.Base.Common
{
    public class Page<T>
    {
        public T[] Items { get; private set; }
        public PageInfo Info { get; private set; }
        public int? ItemsCount { get; private set; }

        #region Constructors

        public Page(T[] items, PageInfo info)
        {
            Items = items;
            Info = info;
        }

        public Page(T[] items, PageInfo info, int itemsCount)
            : this(items, info)
        {
            ItemsCount = itemsCount;
        }

        public Page(IEnumerable<T> items, PageInfo info)
            : this(items.ToArray(), info)
        {
        }

        public Page(IEnumerable<T> items, PageInfo info, int itemsCount)
            : this(items.ToArray(), info, itemsCount)
        {
        }

        public Page(Page<T> page)
        {
            Items = page.Items;
            Info = page.Info;
            ItemsCount = page.ItemsCount;
        }

        #endregion

        #region Methods

        public bool HasItems()
        {
            return (Items != null && Items.Length > 0) || (ItemsCount.GetValueOrDefault(0) > 0);
        }

        #endregion
    }
}
