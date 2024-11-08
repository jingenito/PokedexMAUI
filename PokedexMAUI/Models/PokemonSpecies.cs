namespace PokedexMAUI.Models
{
    public class PokemonSpecies
    {
        public string Name { get; set; } = "";
        public string Url { get; set; } = "";

        private int? _id;
        public int Id
        {
            get
            {
                if (!_id.HasValue)
                {
                    _id = int.Parse(Url.TrimEnd('/').Split('/').Last());
                }
                return _id.Value;
            }
        }

        public string Title => GetTitle(Name, Id);

        public string OfficialArtworkUrl => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/{Id}.png";
    
        public static string GetTitle(string Name, int Id)
        {
            return $"{Name} #{Id.ToString("D4")}";
        }
    }
}
