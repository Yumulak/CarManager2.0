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
                .UseMauiCommunityToolkit()
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

            builder.Services.AddSingleton<CarsViewPage>();
            builder.Services.AddSingleton<CarsViewModel>();

            builder.Services.AddSingleton<DetailsPage>();
            builder.Services.AddSingleton<CarDetailsViewModel>();

            builder.Services.AddSingleton<MaintenancePage>();
            builder.Services.AddSingleton<MaintenanceViewModel>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}