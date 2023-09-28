using CarManager.Services;
using CarManager.Model;
using CarManager.ViewModel;

namespace CarManager.View;

[QueryProperty("Car", "Car")]
public partial class DetailsPage : ContentPage
{
	public DetailsPage(CarDetailsViewModel vm)
	{
        InitializeComponent();
		BindingContext = vm;
	}
    public string CarId { get; set; }
    Car car;
    public Car Car
    {
        get => BindingContext as Car;
        set => BindingContext = value;
    }
    [RelayCommand]
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        #region checkbuttons
        if (DateTime.Now > Car.monthlyOilChecked-TimeSpan.FromDays(7))
        {
            this.monthlyOilCheckedBtn.IsEnabled = true;            
        }
        if (DateTime.Now > Car.monthlyTiresChecked - TimeSpan.FromDays(7))
        {
            this.monthlyTiresCheckedBtn.IsEnabled = true;
        }
        if (DateTime.Now > Car.monthlyLightsChecked - TimeSpan.FromDays(7))
        {
            this.monthlyLightsCheckedBtn.IsEnabled = true;
        }
        if (DateTime.Now > Car.monthlyWasherFluidChecked - TimeSpan.FromDays(7))
        {
            this.monthlyWasherFluidCheckedBtn.IsEnabled = true;
        }
        //
        if (DateTime.Now > Car.quarterlyBrakeFluidChecked - TimeSpan.FromDays(7))
        {
            this.quarterlyBrakeFluidCheckedBtn.IsEnabled = true;
        }
        if (DateTime.Now > Car.quarterlyHosesBeltsChecked - TimeSpan.FromDays(7))
        {
            this.quarterlyHosesBeltsCheckedBtn.IsEnabled = true;
        }
        if (DateTime.Now > Car.quarterlySteeringFluidChecked - TimeSpan.FromDays(7))
        {
            this.quarterlySteeringFluidCheckedBtn.IsEnabled = true;
        }
        if (DateTime.Now > Car.quarterlyTransFluidChecked - TimeSpan.FromDays(7))
        {
            this.quarterlyTransFluidCheckedBtn.IsEnabled = true;
        }
        //
        if (DateTime.Now > Car.sixMoAirFiltersChecked - TimeSpan.FromDays(7))
        {
            this.sixMoAirFiltersCheckedBtn.IsEnabled = true;
        }
        if (DateTime.Now > Car.sixMoBatteryChecked - TimeSpan.FromDays(7))
        {
            this.sixMoBatteryCheckedBtn.IsEnabled = true;
        }
        if (DateTime.Now > Car.sixMoOilChanged - TimeSpan.FromDays(7))
        {
            this.sixMoOilChangedBtn.IsEnabled = true;
        }
        if (DateTime.Now > Car.sixMoTiresRotated - TimeSpan.FromDays(7))
        {
            this.sixMoTiresRotatedBtn.IsEnabled = true;
        }
        //
        if (DateTime.Now > Car.yearlyAlignmentDone - TimeSpan.FromDays(7))
        {
            this.yearlyAlignmentDoneBtn.IsEnabled = true;
        }
        if (DateTime.Now > Car.yearlyBrakesChecked - TimeSpan.FromDays(7))
        {
            this.yearlyBrakesCheckedBtn.IsEnabled = true;
        }
        #endregion
    }
    //buttons IsEnabled = false is the default
    //if datetime.now > 7 days before task time value
    //  set button IsEnabled to true
    //on click button
    //  set IsEnabled to false
    async void ResetDate(object sender, EventArgs e)
    {
        var button = (Button)sender;        
        var classId = Convert.ToInt32(button.ClassId);
        #region resetbuttons
        switch (classId)
        {
            //one month
            case 1:                
                CarItemDatabase.ResetOilCheckById(Car.Id);
                monthlyOilCheckedText.Text = DateTime.Now.AddMonths(1).Date.ToString("M/d/yyyy");
                break;
            case 2:
                CarItemDatabase.ResetTireCheckById(Car.Id);
                monthlyTiresCheckedText.Text = DateTime.Now.AddMonths(1).Date.ToString("M/d/yyyy");
                break;
            case 3:
                CarItemDatabase.ResetLightsCheckById(Car.Id);
                monthlyLightsCheckedText.Text = DateTime.Now.AddMonths(1).Date.ToString("M/d/yyyy");
                break;
            case 4:
                CarItemDatabase.ResetWashFluidById(Car.Id);
                monthlyWasherFluidCheckedText.Text = DateTime.Now.AddMonths(1).Date.ToString("M/d/yyyy");
                break;
            //3 months
            case 5:
                CarItemDatabase.ResetBrakeFluidCheckById(Car.Id);
                quarterlyBrakeFluidCheckedText.Text = DateTime.Now.AddMonths(3).Date.ToString("M/d/yyyy");
                break;
            case 6:
                CarItemDatabase.ResetTransCheckById(Car.Id);
                quarterlyTransFluidCheckedText.Text = DateTime.Now.AddMonths(3).Date.ToString("M/d/yyyy");
                break;
            case 7:
                CarItemDatabase.ResetSteeringCheckById(Car.Id);
                quarterlySteeringFluidCheckedText.Text = DateTime.Now.AddMonths(3).Date.ToString("M/d/yyyy");
                break;
            case 8:
                CarItemDatabase.ResetHosesBeltsById(Car.Id);
                quarterlyHosesBeltsCheckedText.Text = DateTime.Now.AddMonths(3).Date.ToString("M/d/yyyy");
                break;
            //6 months
            case 9:
                CarItemDatabase.ResetOilChangedById(Car.Id);
                sixMoOilChangedText.Text = DateTime.Now.AddMonths(6).Date.ToString("M/d/yyyy");
                break;
            case 10:
                CarItemDatabase.ResetTiresRotatedById(Car.Id);
                monthlyOilCheckedText.Text = DateTime.Now.AddMonths(6).Date.ToString("M/d/yyyy");
                break;
            case 11:
                CarItemDatabase.ResetBatteryCheckedById(Car.Id);
                sixMoBatteryCheckedText.Text = DateTime.Now.AddMonths(6).Date.ToString("M/d/yyyy");
                break;
            case 12:
                CarItemDatabase.ResetAirFiltersCheckedById(Car.Id);
                sixMoAirFiltersCheckedText.Text = DateTime.Now.AddMonths(6).Date.ToString("M/d/yyyy");
                break;
            //yearly
            case 13:
                CarItemDatabase.ResetAlignmentById(Car.Id);
                yearlyAlignmentDoneText.Text = DateTime.Now.AddYears(1).Date.ToString("M/d/yyyy");
                break;
            case 14:
                CarItemDatabase.ResetBrakesCheckedById(Car.Id);
                yearlyBrakesCheckedText.Text = DateTime.Now.AddYears(1).Date.ToString("M/d/yyyy");
                break;
        }
        #endregion
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        var result = Shell.Current.DisplayAlert("Delete Vehicle", "Are you sure?", "No", "Yes");

        if( await result != true)
        {
            await CarItemDatabase.DeleteItemAsync(Car);
            await Shell.Current.GoToAsync("..");
        }
    }
    async void GoToMaintenancePage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(MaintenancePage), true, new Dictionary<string, object>
        {
            { "Car" , car}
        });
    }
}