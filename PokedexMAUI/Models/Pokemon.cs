namespace PokedexMAUI.Models
{
    public class Pokemon
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;

        public string Title => PokemonSpecies.GetTitle(Name, Id);

        public int HeightHm { get; set; } = 0;
        public string Height => (HeightHm * 0.1).ToString("0.###") + " m";
        public int WeightHg { get; set; } = 0;
        public string Weight => (WeightHg * 0.1).ToString("0.###") + " kg";

        public List<PokemonAbility> BaseAbilities { get; set; } = new List<PokemonAbility>();
        public List<PokemonStat> BaseStats { get; set; } = new List<PokemonStat>();
        public List<PokemonType> Types { get; set; } = new List<PokemonType>();

        public string OfficialArtworkUrl { get; set; } = string.Empty;
    }
}
