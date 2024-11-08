using Newtonsoft.Json.Linq;
using PokedexMAUI.Enums;
using PokedexMAUI.Extensions;
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
                    Name = ((string?)p["name"] ?? "Unknown").ToPokemonName().Replace("-", " ").ToTitleCase(),
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
                    Name = ((string?)p["name"] ?? "Unknown").ToPokemonName().Replace("-", " ").ToTitleCase(),
                    Url = (string?)p["url"] ?? string.Empty
                })
                .OrderBy(p => p.Id)
                .ToList();

            return pokemonSpecies ?? new List<PokemonSpecies>();
        }

        public async Task<Pokemon> GetPokemonAsync(int id)
        {
            var url = $"https://pokeapi.co/api/v2/pokemon/{id}";
            var response = await _httpClient.GetStringAsync(url).ConfigureAwait(false);
            var json = JObject.Parse(response);

            var pokemon = new Pokemon
            {
                Id = json["id"]?.Value<int>() ?? 0,
                Name = ((string?)json["name"] ?? "Unkown").ToPokemonName().Replace("-", " ").ToTitleCase(),
                HeightHm = json["height"]?.Value<int>() ?? 0,
                WeightHg = json["weight"]?.Value<int>() ?? 0,
                BaseAbilities = ParseAbilities(json["abilities"] as JArray ?? new JArray()),
                BaseStats = ParsePokemonStats(json["stats"] as JArray ?? new JArray()),
                Types = ParsePokemonTypes(json["types"] as JArray ?? new JArray())
            };

            return pokemon;
        }

        private List<PokemonAbility> ParseAbilities(JArray abilitiesArray)
        {
            var abilities = new List<PokemonAbility>();

            if (abilitiesArray != null)
            {
                foreach (var ability in abilitiesArray)
                {
                    abilities.Add(new PokemonAbility
                    {
                        Name = ((string?)ability["ability"]?["name"] ?? "Unknown").Replace("-", " ").ToTitleCase(),
                    });
                }
            }

            return abilities;
        }

        private List<PokemonType> ParsePokemonTypes(JArray typesArray)
        {
            var types = new List<PokemonType>();

            if (typesArray != null)
            {
                foreach (var type in typesArray)
                {
                    PokemonTypeColors color;
                    if (!Enum.TryParse((string?)type["type"]?["name"] ?? "error", true, out color))
                    {
                        color = PokemonTypeColors.Error;
                    }
                    types.Add(new PokemonType { PokemonTypeColor = color });
                }
            }

            return types;
        }

        private List<PokemonStat> ParsePokemonStats(JArray statsArray)
        {
            var stats = new List<PokemonStat>();

            if (statsArray != null)
            {
                foreach (var stat in statsArray)
                {
                    PokemonStatTypes type;
                    if (!Enum.TryParse(((string?)stat["stat"]?["name"] ?? "error").Replace("-", ""), true, out type))
                    {
                        type = PokemonStatTypes.Error;
                    }
                    stats.Add(new PokemonStat
                    {
                        Type = type,
                        Value = stat["base_stat"]?.Value<int>() ?? 0
                    });
                }
            }

            return stats;
        }
    }
}
