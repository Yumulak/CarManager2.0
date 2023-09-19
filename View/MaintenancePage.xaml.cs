using CarManager.Services;

namespace CarManager.View;

[QueryProperty("Car", "Car")]
public partial class MaintenancePage : ContentPage
{
    public Car car
    {
        get => BindingContext as Car;
        set => BindingContext = value;
    }
	public MaintenancePage(MaintenanceViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}