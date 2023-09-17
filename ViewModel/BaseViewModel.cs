using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.View;

namespace CarManager.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {

        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Title))]
        bool isBusy;

        [ObservableProperty]
        string title;
        
        public bool isNotBusy => !IsBusy;


    }
}
