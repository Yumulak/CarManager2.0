using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Services;

namespace CarManager.ViewModel
{
    public partial class AddCarsViewModel : BaseViewModel
    {
        public AddCarsViewModel() 
        {
        }

        [ObservableProperty]
        public ObservableCollection<Car> cars;

        [ObservableProperty]
        string make;
        [ObservableProperty]
        string model;
        [ObservableProperty]
        string year;
        [ObservableProperty]
        string purchaseYear;
        [ObservableProperty]
        string purchaseMonth;
        [ObservableProperty]
        string price;

        [RelayCommand]
        async Task AddCar()
        {
            if (string.IsNullOrWhiteSpace(Make) || string.IsNullOrWhiteSpace(Model) || string.IsNullOrWhiteSpace(Year) || string.IsNullOrWhiteSpace(PurchaseYear) || string.IsNullOrWhiteSpace(PurchaseMonth) || string.IsNullOrWhiteSpace(Price))
            {
                return;
            }
            Car car = new(Make, Model, Year, PurchaseYear, PurchaseMonth, Price);

            //add item
            Make = string.Empty;
            Model = string.Empty;
            Year = string.Empty;
            PurchaseYear = string.Empty;
            PurchaseMonth = string.Empty;
            Price = string.Empty;

            await Shell.Current.DisplayAlert("Car Added", $"{car.Make} {car.Model}", "OK");
            await CarItemDatabase.AddCarAsync(car);
            await Shell.Current.GoToAsync("..");
        }
    }
}
