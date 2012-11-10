namespace GDNET.Framework.Models
{
    public sealed class PageMetaModel
    {
        public string Description
        {
            get;
            set;
        }

        public string Keywords
        {
            get;
            set;
        }

        public string Author
        {
            get;
            set;
        }

        public PageMetaModel() { }

        public PageMetaModel(string description, string keywords, string author)
        {
            this.Description = description;
            this.Keywords = keywords;
            this.Author = author;
        }
    }
}
