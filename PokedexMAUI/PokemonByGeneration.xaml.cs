using PokedexMAUI.Models;
using PokedexMAUI.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PokedexMAUI;

public partial class PokemonByGeneration : ContentPage
{
    private readonly IPokemonService _pokemonService;

    public ObservableCollection<PokemonSpecies> PokemonCollection { get; set; } = new ObservableCollection<PokemonSpecies>();

    public PokemonByGeneration(IPokemonService pokemonService)
	{
		InitializeComponent();
        _pokemonService = pokemonService;

        //set the binding context for the UI controls
        BindingContext = this;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        IsBusy = true;

        try
        {
            var pokemonSpecies = await _pokemonService.GetPokemonSpeciesByGenerationAsync(1);

            //update the Pokemon collection
            PokemonCollection.Clear();
            foreach (var pokemon in pokemonSpecies)
            {
                PokemonCollection.Add(pokemon);
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
}