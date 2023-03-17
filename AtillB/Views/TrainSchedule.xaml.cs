using AtillB.Services;
using AtillB.ViewModels;

namespace AtillB.Views;

public partial class TrainSchedule : ContentPage
{
	TrainScheduleViewModel vm;
	public TrainSchedule()
	{
		InitializeComponent();
		vm = new TrainScheduleViewModel(locationService: new LocationService(), trainAPIService: new TrainAPIService());
		BindingContext = vm;
	}
}