namespace PokedexMAUI.Models
{
    public class Pokemon
    {
        public int Id { get; set; } = 0;
        public string PokedexNumber => $"#{Id.ToString("D4")}";
        public string Name { get; set; } = string.Empty;
        public string Title => $"{Name} {PokedexNumber}";

        public int HeightHm { get; set; } = 0;
        public double HeightM => HeightHm * 0.1;
        public int WeightHg { get; set; } = 0;
        public double WeightKg => WeightHg * 0.1;

        public List<PokemonAbility> BaseAbilities { get; set; } = new List<PokemonAbility>();
        public List<PokemonStat> BaseStats { get; set; } = new List<PokemonStat>();
        public List<PokemonType> Types { get; set; } = new List<PokemonType>();

        public string OfficialArtworkUrl { get; set; } = string.Empty;
    }
}
