using Newtonsoft.Json.Linq;
using PokedexMAUI.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PokedexMAUI;

public partial class PokemonByGeneration : ContentPage
{
    public ObservableCollection<PokemonSpecies> PokemonCollection { get; set; } = new ObservableCollection<PokemonSpecies>();

    public PokemonByGeneration()
	{
		InitializeComponent();
        BindingContext = this;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        IsBusy = true;

        try
        {
            var pokemonSpecies = await GetPokemonByGenerationAsync(1);
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

    public async Task<List<PokemonSpecies>> GetPokemonByGenerationAsync(int generationId)
    {
        using (var httpClient = new HttpClient())
        {
            var url = $"https://pokeapi.co/api/v2/generation/{generationId}/";
            var response = await httpClient.GetStringAsync(url);
            var json = JObject.Parse(response);

            var pokemonSpecies = json["pokemon_species"]?
                .Select(p => new PokemonSpecies
                {
                    Name = (string?)p["name"] ?? "Unkown",
                    Url = (string?)p["url"] ?? string.Empty
                })
                .OrderBy(p => p.Id) // Optional: order by ID
                .ToList();

            return pokemonSpecies ?? new List<PokemonSpecies>();
        }
    }
}