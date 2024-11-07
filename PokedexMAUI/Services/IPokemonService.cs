using PokedexMAUI.Models;

namespace PokedexMAUI.Services
{
    public interface IPokemonService
    {
        Task<List<PokemonSpecies>> GetPokemonSpeciesByGenerationAsync(int generationId);
    }
}
