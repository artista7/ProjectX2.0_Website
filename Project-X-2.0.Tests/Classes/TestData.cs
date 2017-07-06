using Project_X_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X_2._0.Tests
{
    class TestData
    {
        public static IQueryable<Trip> Trips
        {
            get
            {
                var trips = new List<Trip>();
                for(int i = 0; i < 10; i++)
                {
                    var trip = new Trip();
                    trip.TripID = i;
                    trips.Add(trip);
                }
                return trips.AsQueryable();
            }
        }
    }
}
