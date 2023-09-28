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
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        

    }
    //buttons IsEnabled = false is the default
    //if datetime.now > task time value
    //  set button IsEnabled to true
    //on click button
    //  set IsEnabled to false
    private void SetButtonIsEnabled(DateTime taskDate)
    {
        if(taskDate >= (DateTime.Now - TimeSpan.FromDays(7)))
        {

        }
    }
    async void ResetDate(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var classId = Convert.ToInt32(button.ClassId);
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
    }
    
    async void OnDeleteClicked(object sender, EventArgs e)
    {
        await CarItemDatabase.DeleteItemAsync(Car);
        await Shell.Current.GoToAsync("..");
    }
    async void GoToMaintenancePage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(MaintenancePage), true, new Dictionary<string, object>
        {
            { "Car" , car}
        });
    }
}