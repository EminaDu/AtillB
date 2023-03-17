using AtillB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AtillB.Services
{
    internal class TrainAPIService : ITrainAPIService
    {
        private const string APIKey = "052058ec-de3f-4ac6-91e5-1381069c1368";
        private const string defaultParams = "format=json&accessId=" + APIKey;
        private HttpClient client = new HttpClient();

        public TrainAPIService()
        {
            client.BaseAddress = new Uri("https://api.resrobot.se/v2.1/");
        }

        public async Task<Departures> GetDeparturesFor(string locationId)
        {
            Departures departures = null;
            string parameters = "id=" + locationId;
            HttpResponseMessage response = await client.GetAsync("departureBoard" + "?" + parameters + "&" + defaultParams);
            if(response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                departures = JsonSerializer.Deserialize<Departures>(responseString);
            }
            return departures;
        }

        public async Task<Models.TrainStation> GetNearbyStation(Location location)
        {
            Models.TrainStation nearbyStation = null;
            string parameters = "originCoordLat=" + location.Latitude.ToString() + "&originCoordLong=" + location.Longitude.ToString();
            HttpResponseMessage response = await client.GetAsync("location.nearbystops?" + parameters + "&" + defaultParams);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                nearbyStation = JsonSerializer.Deserialize<Models.TrainStation>(responseString);
            }

            return nearbyStation;
        }

        public async Task<TrainStation> GetStationBy(string name)
        {
            Models.TrainStation nearbyStation = null;
            string parameters = "input=" + name;
            HttpResponseMessage response = await client.GetAsync("location.name" + "?" + parameters + "&" + defaultParams);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                nearbyStation = JsonSerializer.Deserialize<Models.TrainStation>(responseString);
            }

            return nearbyStation;
        }

    }
}

