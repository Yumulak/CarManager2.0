using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Services;
using CarManager.View;

namespace CarManager.ViewModel
{
    public partial class CarsViewModel : BaseViewModel
    {
        CarItemDatabase database;
        public ObservableCollection<Car> Cars { get; set; } = new();
        public CarsViewModel(CarService carService, CarItemDatabase carItemDatabase) 
        {
            Title = "Car Manager";
            database = carItemDatabase;
        }

        [RelayCommand]
        async Task NavigatedTo()
        {
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

        //sort cars in view page by price descending
        [RelayCommand]
        void SortByPrice()
        {
            Cars = new ObservableCollection<Car>(Cars.OrderByDescending(i => i.Price));
        }

        //sort cars in view page by year descending
        [RelayCommand]
        void SortByYear()
        {
            Cars = new ObservableCollection<Car>(Cars.OrderByDescending(i => i.ModelYear));
        }
    }
}
