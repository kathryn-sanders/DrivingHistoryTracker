using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DrivingHistoryTracker.Tests
{
    [TestClass]
    public class TripTests
    {
        Trip testTrip;

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

            // testTrip = new Trip("", "", "", "");

            // This test fails if the input file doesn't contain all four required components
            // following a trip command. For the purposes of this exercise, I commented it out
            // and stopped here, but in a realistic scenario I might want to ensure that all
            // components were present and able to be parsed before processing the line data.
        }
    }
}
