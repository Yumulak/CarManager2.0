using CarManager.Services;
using CarManager.Model;
using CarManager.ViewModel;

namespace CarManager.View;

[QueryProperty("Car", "Car")]
public partial class DetailsPage : ContentPage
{
	Car car;
	public Car Car
	{
		get => BindingContext as Car;
		set => BindingContext = value;
	}
	CarItemDatabase database;
	public DetailsPage(CarsViewModel vm, CarItemDatabase db)
	{
        InitializeComponent();
		BindingContext = vm;
		database = db;
	}
    async void OnDeleteClicked(object sender, EventArgs e)
    {
        await database.DeleteItemAsync(Car);
        await Shell.Current.GoToAsync("..");
    }
    async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}