using AtillB.Models;
using AtillB.Utils;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtillB.Services
{
    public class DatabaseService
    {
        private static readonly DatabaseService _instance = new DatabaseService();
        private IMongoDatabase database;
        private IMongoCollection<User> userCollection;
        private IMongoCollection<Trip> tripCollection;
        private IMongoCollection<UserTrip> userTripCollection;
        private DatabaseService()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://eminaduro:Sarajevo1234@cluster0.toob9es.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            database = client.GetDatabase("ATillB");
            GetCollections();
        }
        private void GetCollections()
        {
            userCollection = database.GetCollection<User> ("User");
            tripCollection = database.GetCollection<Trip> ("Trip");
            userTripCollection = database.GetCollection<UserTrip> ("User_Trip");
        }
        public static DatabaseService Shared()
        {
            return _instance;
        }
        public async Task SignUp(User user)
        {
            await userCollection.InsertOneAsync(user);
            Console.WriteLine("User Saved!");
        }
        public async Task<User> Login(string username, string password)
        {
            var user = userCollection.AsQueryable().Where(m => m.Username == username&& m.Password ==password).FirstOrDefault();
            Console.WriteLine("User Logged in");
            return user;
        }
        public async Task<User> VerifyUser(int id)
        {
            var user = userCollection.AsQueryable().Where(m => m.Id == id).SingleOrDefault();
            user.IsAuthorized = true;
            await userCollection.ReplaceOneAsync(m => m.Id == id, user);
            Console.WriteLine("User Authorized");
            return user;
        }
        public async Task<List<Trip>> GetFutureTrips()
        {
            var trips = tripCollection.AsQueryable().Where(x => x.FreeSeats > 0).ToList();
            var userBookedTrips = await FindUserTripIds();
            Console.WriteLine("Trips founded:");
            List<Trip> tripss = trips.FindAll(x => !userBookedTrips.Contains(x.Id) && DateParser.StringToDate(x.Date) > DateTime.Now);
            return tripss;
        }

        public async Task CreateTrip(Trip trip)
        {
            await tripCollection.InsertOneAsync(trip);
            Console.WriteLine("Trip Saved!");
        }
        public async Task BookATrip(Trip trip)
        {
            var userTrip = new UserTrip();
            userTrip.Id = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            userTrip.TripId = trip.Id;
            userTrip.UserId = SessionData.User.Id;
            await userTripCollection.InsertOneAsync(userTrip);

            trip.FreeSeats -= 1;
            await tripCollection.FindOneAndReplaceAsync(x => x.Id == trip.Id, trip);
        }
        public async Task<List<int>> FindUserTripIds() 
        {
            var userTrips = userTripCollection.AsQueryable().Where(predicate: x => x.UserId == SessionData.User.Id);
            List<int> tripIDs = new List<int>();
            if (userTrips == null || userTrips.Count() == 0)
            {
                return tripIDs;
            }
            foreach (UserTrip userTrip in userTrips)
                {
                tripIDs.Add(userTrip.TripId);
            }
            return tripIDs;
        }
        public async Task<List<Trip>> FindUserTrips()
        {
            var tripIDs = await FindUserTripIds();
            var userTrips = tripCollection.AsQueryable().Where(predicate: x => tripIDs.Contains(x.Id)).ToList();

            return userTrips;
        }
    }
}
