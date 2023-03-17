using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtillB.Services
{
    public interface ITrainAPIService
    {
        public Task<Models.TrainStation> GetNearbyStation(Location location);
        public Task<Models.TrainStation> GetStationBy(string name);
        public Task<Models.Departures> GetDeparturesFor(string locationId);
    }
}
