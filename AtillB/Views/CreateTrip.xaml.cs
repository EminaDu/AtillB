namespace AtillB.Views;

public partial class CreateTrip : ContentPage
{
	ViewModels.CreateTripPageViewModelcs vm = new ();
	public CreateTrip()
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private async void OnCreateTripClickedAsync(object sender, EventArgs e)
    {
		var successfull = await vm.CreateTrip();
		if (successfull) {
            await Navigation.PopAsync();
        }
    }
}