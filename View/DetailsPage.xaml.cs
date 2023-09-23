using CarManager.Services;
using CarManager.Model;
using CarManager.ViewModel;

namespace CarManager.View;

[QueryProperty("Car", "Car")]
public partial class DetailsPage : ContentPage
{
	public DetailsPage(CarDetailsViewModel vm)
	{
        InitializeComponent();
		BindingContext = vm;
	}
    public string CarId { get; set; }
    Car car;
    public Car Car
    {
        get => BindingContext as Car;
        set => BindingContext = value;
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        await CarItemDatabase.DeleteItemAsync(Car);
        await Shell.Current.GoToAsync("..");
    }
    async void GoToMaintenancePage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(MaintenancePage), true, new Dictionary<string, object>
        {
            { "Car" , car}
        });
    }

}