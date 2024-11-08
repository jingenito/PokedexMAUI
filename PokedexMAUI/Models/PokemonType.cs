using PokedexMAUI.Enums;
using PokedexMAUI.Extensions;
using System.Drawing;

namespace PokedexMAUI.Models
{
    public class PokemonType
    {
        public PokemonTypeColors PokemonTypeColor { get; set; }
        public string Name => PokemonTypeColor.ToString();
        public string Color => PokemonTypeColor.Description();
        public string ForeColor
        {
            get
            {
                // Parse the background color from hex
                System.Drawing.Color bgColor = ColorTranslator.FromHtml(Color);

                // Calculate luminance
                double luminance = (0.299 * bgColor.R + 0.587 * bgColor.G + 0.114 * bgColor.B) / 255;

                // Determine the proper foreground color based on the luminance
                return luminance > 0.5 ? "black" : "white";
            }
        }
    }
}
