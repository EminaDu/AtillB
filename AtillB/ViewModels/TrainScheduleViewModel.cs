using AtillB.Models;
using AtillB.Services;
using AtillB.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtillB.ViewModels
{
    public partial class TrainScheduleViewModel: ObservableObject
    {
        [ObservableProperty]
        public string stationName;

        [ObservableProperty]
        ObservableCollection<Departure> departures;

    ILocationService locationService;
        ITrainAPIService trainAPIService;
        Location currentLocation;
        public Models.TrainStation StationLocation;
        public TrainScheduleViewModel(ITrainAPIService trainAPIService, ILocationService locationService)
        { 
            this.locationService = locationService;
            this.trainAPIService = trainAPIService;
            Departures = new ObservableCollection<Departure>();
            GetCurentLocation();
        }

        void GetCurentLocation()
        {
            var task = Task.Run(() => locationService.GetCurrentLocation());
            task.Wait();
            currentLocation = task.Result;
            GetNearbyStation();
        }

        void GetNearbyStation()
        {
            var task = Task.Run(() => trainAPIService.GetNearbyStation(location: currentLocation));
            task.Wait();
            StationLocation = task.Result;
            StationName = StationLocation.stopLocationOrCoordLocation.First().StopLocation.name;
            GetDepartures();
            //GetStationByName();
        }
        void GetStationByName()
        {
            var task = Task.Run(() => trainAPIService.GetStationBy(name: "Nyköping"));
            task.Wait();
            StationLocation = task.Result;
            GetDepartures();
        }
        void GetDepartures()
        {
            var task = Task.Run(() => trainAPIService.GetDeparturesFor(locationId: StationLocation.stopLocationOrCoordLocation.First().StopLocation.extId));
            task.Wait();
            Console.WriteLine(task.Result);
            Departure[] departure = task.Result.Departure;
            if (departure.Count() > 0)
                {
                Departures = new ObservableCollection<Departure>(departure);
            }
        }
    }
}
