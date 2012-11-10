namespace GDNET.Framework.Models
{
    public abstract class AbstractPageModel
    {
        public AbstractPageModel()
        {
            this.PageMeta = new PageMetaModel();
        }

        public PageMetaModel PageMeta
        {
            get;
            private set;
        }
    }
}
