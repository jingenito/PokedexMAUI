using PokedexMAUI.Models;
using PokedexMAUI.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PokedexMAUI;

public partial class PokemonByGeneration : ContentPage
{
    private readonly IPokemonService _pokemonService;

    public ObservableCollection<Generation> GenerationCollection { get; set; }

    public PokemonByGeneration(IPokemonService pokemonService)
    {
        InitializeComponent();

        _pokemonService = pokemonService;

        //initialize the GenerationCollection
        GenerationCollection = new ObservableCollection<Generation>
        {
            new Generation { Id=1, Name="Kanto", MinSpeciesId=1, MaxSpeciesId=151, PokemonCollection=new ObservableCollection<PokemonSpecies>()},
            new Generation { Id=2, Name="Johto", MinSpeciesId=152, MaxSpeciesId=251, PokemonCollection=new ObservableCollection<PokemonSpecies>()},
            new Generation { Id=3, Name="Hoenn", MinSpeciesId=252, MaxSpeciesId=386, PokemonCollection=new ObservableCollection<PokemonSpecies>()},
            new Generation { Id=4, Name="Sinnoh", MinSpeciesId=387, MaxSpeciesId=493, PokemonCollection=new ObservableCollection<PokemonSpecies>()},
            new Generation { Id=5, Name="Unova", MinSpeciesId=494, MaxSpeciesId=649, PokemonCollection=new ObservableCollection<PokemonSpecies>()},
            new Generation { Id=6, Name="Kalos", MinSpeciesId=650, MaxSpeciesId=721, PokemonCollection=new ObservableCollection<PokemonSpecies>()},
            new Generation { Id=7, Name="Alola", MinSpeciesId=722, MaxSpeciesId=809, PokemonCollection=new ObservableCollection<PokemonSpecies>()},
            new Generation { Id=8, Name="Galar", MinSpeciesId=810, MaxSpeciesId=898, PokemonCollection=new ObservableCollection<PokemonSpecies>()}
        };

        //set the binding context for the UI controls
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        IsBusy = true;

        try
        {
            var pokemonSpecies = await _pokemonService.GetAllPokemonSpeciesAsync(1000);

            // Ensure each generation's collection is clear before starting
            foreach (var generation in GenerationCollection)
            {
                generation.PokemonCollection.Clear();
            }

            //update the Pokemon collection
            var currentGenerationIndex = 0;
            var currentGeneration = GenerationCollection[currentGenerationIndex];
            foreach (var pokemon in pokemonSpecies)
            {
                currentGeneration.PokemonCollection.Add(pokemon);

                //check to see if this pokemon is the last in the generation
                if (pokemon.Id == currentGeneration.MaxSpeciesId)
                {
                    //increment the currentGeneration
                    currentGenerationIndex++;
                    if (currentGenerationIndex >= GenerationCollection.Count) break;
                    currentGeneration = GenerationCollection[currentGenerationIndex];
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }

    public class Generation
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int MinSpeciesId { get; set; } = 0;
        public int MaxSpeciesId { get; set; } = 0;
        public ObservableCollection<PokemonSpecies> PokemonCollection { get; set; } = new ObservableCollection<PokemonSpecies>();
    }
}