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
            builder.Services.AddSingleton<DBConstants>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddSingleton<AddCarsPage>();
            builder.Services.AddSingleton<AddCarsViewModel>();

            builder.Services.AddTransient<CarsViewPage>();
            builder.Services.AddTransient<CarsViewModel>();

            builder.Services.AddTransient<DetailsPage>();
            builder.Services.AddTransient<CarDetailsViewModel>();

            builder.Services.AddTransient<MaintenancePage>();
            builder.Services.AddTransient<MaintenanceViewModel>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}