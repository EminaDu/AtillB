namespace AtillB.Views;

public partial class SignupPage : ContentPage
{
    ViewModels.SignupPageViewModel vm = new();
    public SignupPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnSignupClicked(object sender, EventArgs e)
    {
        var isSuccessfull = await vm.TrySignUp();
        if (isSuccessfull)
        {
            await Navigation.PopAsync();
        }
    }
}