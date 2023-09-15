

namespace CarManager.View;

public partial class AddCarsPage : ContentPage
{
	public AddCarsPage(AddCarsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		

	}

    [RelayCommand]
    async Task NavigatedTo(NavigatedToEventArgs args)
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