namespace GDNET.Base.Common
{
    public sealed class PageInfo
    {
        public int Size { get; private set; }
        public int Index { get; private set; }

        public int From
        {
            get { return (Size * Index); }
        }

        public PageInfo(int size, int index)
        {
            Size = size;
            Index = index;
        }
    }
}
