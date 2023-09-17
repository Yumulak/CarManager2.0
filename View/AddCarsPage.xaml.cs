

namespace CarManager.View;

public partial class AddCarsPage : ContentPage
{
	public AddCarsPage(AddCarsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		

	}
}