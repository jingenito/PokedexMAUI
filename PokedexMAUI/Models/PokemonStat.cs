using PokedexMAUI.Enums;
using PokedexMAUI.Extensions;

namespace PokedexMAUI.Models
{
    public class PokemonStat
    {
        public PokemonStatTypes Type { get; set; } = PokemonStatTypes.Error;
        public int Value { get; set; } = 0;
        public string Name => Type.Description();
        public double Percentage
        {
            get
            {
                switch(Type)
                {
                    case PokemonStatTypes.HP:
                        return Value / 255.0;
                    case PokemonStatTypes.Attack:
                        return Value / 190.0;
                    case PokemonStatTypes.Defense:
                        return Value / 230.0;
                    case PokemonStatTypes.SpecialAttack:
                        return Value / 194.0;
                    case PokemonStatTypes.SpecialDefense:
                        return Value / 230.0;
                    case PokemonStatTypes.Speed:
                        return Value / 200.0;
                    default: return 0.0;
                }
            }
        }
    }
}
