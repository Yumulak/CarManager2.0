using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.View;

namespace CarManager.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {

        }
        [RelayCommand]
        private async Task ViewCars()
        {
            await Shell.Current.GoToAsync(nameof(CarsViewPage));
        }
        [RelayCommand]
        private async Task AddCars()
        {
            await Shell.Current.GoToAsync(nameof(AddCarsPage));
        }
    }
}
