using AtillB.Services.LoginService;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AtillB.Services;
using AtillB.Utils;

namespace AtillB.ViewModels
{
    public partial class CreateTripPageViewModelcs : ObservableObject
    {

        [ObservableProperty]
        public string from;
        [ObservableProperty]
        public string to;
        [ObservableProperty]
        public DateTime date;
        [ObservableProperty]
        public DateTime time;
        [ObservableProperty]
        public int freeSeats;
       

        public async Task<bool> CreateTrip()
        {
            Models.Trip trip = new();
            trip.Id = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            trip.From = From;
            trip.To = To;
            trip.Date = DateParser.DateTimeToString(Date, Time);
            trip.FreeSeats = FreeSeats;             
            var task = Task.Run(() => DatabaseService.Shared().CreateTrip(trip));
            task.Wait();
            return task != null;
        }
    }
}
