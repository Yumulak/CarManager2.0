using CarManager.Services;

namespace CarManager.View;

[QueryProperty(nameof(CarId), nameof(CarId))]
public partial class MaintenancePage : ContentPage
{
    public Car car
    {
        get => BindingContext as Car;
        set => BindingContext = value;
    }
    public string CarId { get; set; }
	public MaintenancePage(MaintenanceViewModel vm)
	{
		InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        int.TryParse(CarId, out var result);
        BindingContext = await CarItemDatabase.GetCarAsync(result);

    }
}