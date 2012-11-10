namespace GDNET.Domain.Entities.System
{
    public partial class Catalog
    {
        public static CatalogFactory Factory
        {
            get { return new CatalogFactory(); }
        }

        public class CatalogFactory
        {
            public Catalog Create(string code, string name)
            {
                return new Catalog()
                {
                    Code = code,
                    Name = name
                };
            }
        }
    }
}
