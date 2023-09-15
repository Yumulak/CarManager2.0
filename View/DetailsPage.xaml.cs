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
	public DetailsPage(CarsViewModel vm, CarItemDatabase carDB)
	{
        InitializeComponent();
		BindingContext = vm;
		database = carDB;
	}

    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Car.Model))
        {
            await DisplayAlert("Name Required", "Please enter a name for the todo item.", "OK");
            return;
        }

        await database.SaveItemAsync(Car);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Car.Id == 0)
            return;
        await database.DeleteItemAsync(Car);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}