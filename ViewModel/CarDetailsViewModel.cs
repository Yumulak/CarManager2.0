using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.View;
using CarManager.Model;
using CarManager.Services;

namespace CarManager.ViewModel
{

    [QueryProperty("Item", "Item")]
    public partial class CarDetailsViewModel : BaseViewModel
    {

        public ObservableCollection<Car> Cars { get; } = new();

        public CarDetailsViewModel() 
        {
            
        }
    }
}
