using PokedexMAUI.Enums;
using PokedexMAUI.Extensions;

namespace PokedexMAUI.Models
{
    public class PokemonType
    {
        PokemonTypeColors PokemonTypeColor { get; set; }
        string Name => PokemonTypeColor.ToString();
        string Color => PokemonTypeColor.Description();
    }
}
