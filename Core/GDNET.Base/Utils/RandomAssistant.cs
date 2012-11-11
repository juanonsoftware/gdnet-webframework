using System;
using System.Text;

namespace GDNET.Base.Utils
{
    public sealed class RandomAssistant
    {
        public static string GenerateASentence(Random aRandom)
        {
            int length = aRandom.Next(100, 200);
            return RandomAssistant.GenerateASentence(aRandom, length);
        }

        public static string GenerateASentence(Random aRandom, int length)
        {
            StringBuilder sb = new StringBuilder();

            for (int index = 0; index < length; index++)
            {
                int wordLength = aRandom.Next(2, 20);
                if (index % wordLength == 0 && index > 0)
                {
                    sb.Append(" ");
                }

                int randomValue = aRandom.Next(Convert.ToInt32(char.Parse("a")), Convert.ToInt32(char.Parse("z")));
                string aChar = char.ConvertFromUtf32(randomValue);
                if (index == 0)
                {
                    aChar = aChar.ToUpper();
                }

                sb.Append(aChar);
            }

            return sb.ToString();
        }

        public static string GenerateAParagraph(Random aRandom)
        {
            string result = string.Empty;

            for (int counter = 0; counter < 3; counter++)
            {
                result += GenerateASentence(aRandom);
                result += ". ";
            }

            return result.Trim();
        }

        public static string GenerateEmailAddress(Random aRandom)
        {
            StringBuilder sb = new StringBuilder();

            int length1 = aRandom.Next(3, 20);
            int length2 = aRandom.Next(3, 10);

            for (int index = 0; index < length1; index++)
            {
                int randomValue = aRandom.Next(Convert.ToInt32(char.Parse("a")), Convert.ToInt32(char.Parse("z")));
                sb.Append(char.ConvertFromUtf32(randomValue));
            }
            sb.Append("@");

            for (int index = 0; index < length2; index++)
            {
                int randomValue = aRandom.Next(Convert.ToInt32(char.Parse("a")), Convert.ToInt32(char.Parse("z")));
                sb.Append(char.ConvertFromUtf32(randomValue));
            }

            sb.Append(".com");

            return sb.ToString();
        }
    }
}
