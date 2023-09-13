using Microsoft.Extensions.Logging;
using CarManager.View;
using CarManager.Services;

namespace CarManager
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
                });
            builder.Services.AddSingleton<CarService>();
            builder.Services.AddSingleton<CarsViewModel>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}