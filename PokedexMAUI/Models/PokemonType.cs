using PokedexMAUI.Enums;
using PokedexMAUI.Extensions;

namespace PokedexMAUI.Models
{
    public class PokemonType
    {
        public PokemonTypeColors PokemonTypeColor { get; set; }
        public string Name => PokemonTypeColor.ToString();
        public string Color => PokemonTypeColor.Description();
    }
}
