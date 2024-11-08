using System.ComponentModel;

namespace PokedexMAUI.Enums
{
    public enum PokemonStatTypes
    {
        [Description("HP")]
        HP,
        [Description("Attack")]
        Attack,
        [Description("Defense")]
        Defense,
        [Description("Special Attack")]
        SpecialAttack,
        [Description("Special Defense")]
        SpecialDefense,
        [Description("Speed")]
        Speed,
        [Description("Error")]
        Error
    }
}
