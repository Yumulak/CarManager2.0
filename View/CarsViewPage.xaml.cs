namespace CarManager.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Services;
using CarManager.View;

public partial class CarsViewPage : ContentPage
{
    CarItemDatabase database;
    public ObservableCollection<Car> Cars { get; } = new();

    public CarsViewPage(CarsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    [RelayCommand]
    async Task ONNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await database.GetCarsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {

            Cars.Clear();
            foreach (var item in items)
            {
                Cars.Add(item);
            }
        });
    }
}