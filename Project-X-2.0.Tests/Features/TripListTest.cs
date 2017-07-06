using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_X_2._0.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project_X_2._0.Tests.Features
{
    //aim of this feature is to test and implement that the trip presented on the front is one with latest date
    //and that past trips are displayed in ascending order of dates(new date is greatest)
    //and it doesn't contain the latest one
    [TestClass]
    public class TripListTest
    {
        [TestMethod]
        public void GetLatestTripTest()
        {
            var data = GetTripsList((1, 2017, 01, 03), (2, 2017, 03, 15));      //Arrange
            var tripsListManager = new TripsListManager(data);
            Trip latestTrip = tripsListManager.getLatest();     //Act  
            Assert.AreEqual(2, latestTrip.TripID);  //Assert
        }

        private List<Trip> GetTripsList(params (int, int, int, int)[] tripInfo)
        {
            var tripsList = new List<Trip>();
            tripsList = tripInfo.Select(ti => new Trip { TripID = ti.Item1,
                                                         Date = new DateTime(ti.Item2, ti.Item3, ti.Item4)
                                                       }).ToList();
            return tripsList;
        }
    }
}
