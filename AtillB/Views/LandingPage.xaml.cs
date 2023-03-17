namespace AtillB.Views;

public partial class LandingPage : ContentPage
{
	public LandingPage()
	{
		InitializeComponent();
	}
    private async void OnTrainScheduleClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.TrainSchedule());
    }
    private async void OnCreateTripClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.CreateTrip());
    }
    private async void OnBookATripClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.BookATrip());
    }
}