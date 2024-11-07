using Newtonsoft.Json.Linq;
using PokedexMAUI.Models;

namespace PokedexMAUI.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PokemonSpecies>> GetPokemonSpeciesByGenerationAsync(int generationId)
        {
            var url = $"https://pokeapi.co/api/v2/generation/{generationId}/";
            var response = await _httpClient.GetStringAsync(url).ConfigureAwait(false);
            var json = JObject.Parse(response);

            var pokemonSpecies = json["pokemon_species"]?
                .Select(p => new PokemonSpecies
                {
                    Name = (string?)p["name"] ?? "Unknown",
                    Url = (string?)p["url"] ?? string.Empty
                })
                .OrderBy(p => p.Id)
                .ToList();

            return pokemonSpecies ?? new List<PokemonSpecies>();
        }

        public async Task<List<PokemonSpecies>> GetAllPokemonSpeciesAsync(int limit)
        {
            var url = $"https://pokeapi.co/api/v2/pokemon?limit={limit}";
            var response = await _httpClient.GetStringAsync(url).ConfigureAwait(false);
            var json = JObject.Parse(response);

            var pokemonSpecies = json["results"]?
                .Select(p => new PokemonSpecies
                {
                    Name = (string?)p["name"] ?? "Unknown",
                    Url = (string?)p["url"] ?? string.Empty
                })
                .OrderBy(p => p.Id)
                .ToList();

            return pokemonSpecies ?? new List<PokemonSpecies>();
        }
    }
}
