using CarManager.View;
namespace CarManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainViewModel));
            Routing.RegisterRoute(nameof(CarsViewPage), typeof(CarsViewPage));
            Routing.RegisterRoute(nameof(AddCarsPage), typeof(AddCarsPage));
            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        }
    }
}