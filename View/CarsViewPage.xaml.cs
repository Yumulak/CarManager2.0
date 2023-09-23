using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Services;
using CarManager.View;

namespace CarManager.View;

public partial class CarsViewPage : ContentPage
{
    public ObservableCollection<Car> Cars { get; set; } = new();

    public CarsViewPage(CarsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        BindingContext = this;
	}

    [RelayCommand]
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var cars = await CarItemDatabase.GetAllCarsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {

            Cars.Clear();
            foreach (var car in cars)
            {
                Cars.Add(car);
            }
        });
    }
    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Car car)
        {
            return;
        }

        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            ["Car"] = car
        });
    }

}