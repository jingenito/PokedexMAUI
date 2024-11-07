namespace PokedexMAUI.Models
{
    public class PokemonSpecies
    {
        public string Name { get; set; } = "";
        public string Url { get; set; } = "";

        public int Id => int.Parse(Url.TrimEnd('/').Split('/').Last());

        public string OfficialArtworkUrl => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/{Id}.png";
    }
}
