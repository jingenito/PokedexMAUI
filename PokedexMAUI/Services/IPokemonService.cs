﻿using PokedexMAUI.Models;

namespace PokedexMAUI.Services
{
    public interface IPokemonService
    {
        Task<List<PokemonSpecies>> GetPokemonSpeciesByGenerationAsync(int generationId);
        Task<List<PokemonSpecies>> GetAllPokemonSpeciesAsync(int limit);
        Task<Pokemon> GetPokemonAsync(int id);
    }
}
