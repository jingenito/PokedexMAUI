namespace PokedexMAUI.Models
{
    public class Pokemon
    {
        double HeightHm { get; set; } = 0.0;
        double HeightM => HeightHm * 0.1;
        double WeightHg { get; set; } = 0.0;
        double WeightG => WeightHg * 0.1;

        List<Stat> Stats { get; set; } = new List<Stat>();
        List<PokemonType> Types { get; set; } = new List<PokemonType>();
    }
}
