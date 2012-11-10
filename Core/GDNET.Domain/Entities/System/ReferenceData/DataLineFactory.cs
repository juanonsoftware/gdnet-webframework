namespace GDNET.Domain.Entities.System
{
    public partial class DataLine
    {
        public static DataLineFactory Factory
        {
            get { return new DataLineFactory(); }
        }

        public class DataLineFactory
        {
            public DataLine Create(string code, string name)
            {
                return new DataLine()
                {
                    Code = code,
                    Name = name
                };
            }
        }
    }
}
