using Microsoft.Extensions.Logging;
using PokedexMAUI.Services;

namespace PokedexMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialSymbolsSharp.ttf", "MaterialIconsSharp");
                    fonts.AddFont("MaterialSymbolsRounded.ttf", "MaterialIconsRounded");
                    fonts.AddFont("MaterialSymbolsOutlined.ttf", "MaterialIconsOutlined");
                });

            // Register the PokemonService with dependency injection
            builder.Services.AddSingleton<IPokemonService, PokemonService>();
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddTransient<PokemonByGeneration>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
