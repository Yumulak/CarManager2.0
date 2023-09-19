using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.ViewModel
{
    [QueryProperty("Car", "Car")]
    public partial class MaintenanceViewModel : BaseViewModel
    {

        public MaintenanceViewModel() 
        {
               
        }
        [ObservableProperty]
        Car car;

        
    }
}
