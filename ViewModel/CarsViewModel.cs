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
        public ObservableCollection<Car> Cars { get; set; } = new();
        public CarsViewModel() 
        {

        }

        [RelayCommand]
        async Task NavigatedTo()
        {
            var items = await CarItemDatabase.GetAllCarsAsync();
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

        [RelayCommand]
        async Task Tap(Car car)
        {
            try
            {
                var navParameter = new Dictionary<string, object>
                {
                    {"Car", car}
                };
                await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", navParameter);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
    }
}
