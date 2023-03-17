namespace AtillB.Views;

public partial class BookATrip : ContentPage
{
	ViewModels.BookATripPageViewModel vm = new();
	public BookATrip()
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        vm.GetTrips();
    }
}