using PokedexMAUI.Models;

namespace PokedexMAUI;

public partial class SelectedPokemon : ContentPage
{
    public SelectedPokemon(Pokemon pokemon)
	{
		InitializeComponent();
		BindingContext = pokemon;
	}
}