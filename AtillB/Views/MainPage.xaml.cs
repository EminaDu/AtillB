namespace AtillB;

public partial class MainPage : ContentPage
{
    ViewModels.MainPageViewModel vm = new ViewModels.MainPageViewModel();
    public MainPage()
	{
		InitializeComponent();
        BindingContext = vm;
	}
	private async void OnLoginClicked(object sender, EventArgs e)
	{
        var isSuccessfull = await vm.SignIn();
        if (isSuccessfull == true)
        {
            await Navigation.PushAsync(new Views.LandingPage());
        }
	}

    private async void OnSignupClicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Views.SignupPage()); 
    }

    //private async void OnSearchTrainClicked(object sender, EventArgs e)
    //{
    //       await Navigation.PushAsync(new Views.TrainSchedule());
    //   }
}

