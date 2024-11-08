using System.Xml.Linq;

namespace PokedexMAUI.Extensions
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            var words = str.Replace("-", " ").Split(" ");
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }

            return string.Join(" ", words);
        }

        public static string ToPokemonName(this string str)
        {
            if (str.EndsWith("-f"))
                return str.Replace("-f", " Female");
            else if (str.EndsWith("-m"))
                return str.Replace("-m", " Male");
            return str;
        }
    }
}
