using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DrivingHistoryTracker.Tests
{
    [TestClass]
    public class TripTests
    {
        Trip testTrip;

        //[TestInitialize]
        //public void Initialize()
        //{
        //    testTrip = new Trip("Test", "12:00", "17:00", "300");
        //}


        [TestMethod]
        public void Trip_Constructor_Populates_Properties_Properly()
        {
            testTrip = new Trip("Test", "12:00", "17:00", "300");

            Assert.AreEqual("Test", testTrip.DriverName);
            Assert.AreEqual( new TimeSpan(12,0,0), testTrip.StartTime);
            Assert.AreEqual(new TimeSpan(17, 0, 0), testTrip.StopTime);
            Assert.AreEqual(300, testTrip.MilesDriven);
            Assert.AreEqual(300, testTrip.DurationInMinutes);
            Assert.AreEqual(60, testTrip.AvgTripSpeed);

            testTrip = new Trip("Test2", "00:00", "00:00", "0");

            Assert.AreEqual("Test2", testTrip.DriverName);
            Assert.AreEqual(new TimeSpan(0, 0, 0), testTrip.StartTime);
            Assert.AreEqual(new TimeSpan(0, 0, 0), testTrip.StopTime);
            Assert.AreEqual(0, testTrip.MilesDriven);
            Assert.AreEqual(0, testTrip.DurationInMinutes);
            Assert.AreEqual(0, testTrip.AvgTripSpeed);

            testTrip = new Trip("Test3", "00:00", "23:00", "1380");

            Assert.AreEqual("Test3", testTrip.DriverName);
            Assert.AreEqual(new TimeSpan(0, 0, 0), testTrip.StartTime);
            Assert.AreEqual(new TimeSpan(23, 00, 0), testTrip.StopTime);
            Assert.AreEqual(1380, testTrip.MilesDriven);
            Assert.AreEqual(1380, testTrip.DurationInMinutes);
            Assert.AreEqual(60, testTrip.AvgTripSpeed);
        }
    }
}
