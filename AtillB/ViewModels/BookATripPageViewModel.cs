using AtillB.Models;
using AtillB.Services;
using AtillB.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AtillB.ViewModels
{
    public partial class BookATripPageViewModel: ObservableObject
    {
        [ObservableProperty]
        public string fromName;

        [ObservableProperty]
        public string toName;

        [ObservableProperty]
        public string date;

        [ObservableProperty]
        public string time;

        [ObservableProperty]
        public DateTime curentDate;

        [ObservableProperty]
        public Trip selectedTrip;

        [ObservableProperty]
        ObservableCollection<Trip> trips;

        //public IRelayCommand FilterTrips { get; }

        List<Trip> allTrips;
        public BookATripPageViewModel()
        {
            allTrips = new List<Trip>();
            Trips = new ObservableCollection<Trip>();
            Date = DateParser.JustDateToString(DateTime.Now);
            Time = DateParser.JustTimeToString(DateTime.Now);
            CurentDate = DateTime.Now;
        }

        [RelayCommand]
        public async void BookATrip(Trip trip)
        {
            await Task.Run(() => DatabaseService.Shared().BookATrip(trip));
        }

        public async void GetTrips()
        {
            allTrips = await Task.Run(() => DatabaseService.Shared().GetFutureTrips());
            FilterTrips();
        }

        [RelayCommand]
        public void FilterTrips()
        {
            Trips = new ObservableCollection<Trip>(allTrips);
        }

        partial void OnFromNameChanged(string value)
        {
            FilterTrips();
        }

        partial void OnToNameChanged(string value)
        {
            FilterTrips();
        }

        partial void OnDateChanged(string value)
        {
            FilterTrips();
        }

        partial void OnTimeChanged(string value)
        {
            FilterTrips();
        }
    }
}
