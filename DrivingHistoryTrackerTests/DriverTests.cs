using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrivingHistoryTracker.Tests
{
    [TestClass]
    public class DriverTests
    {
        Driver testDriver1;
        Driver testDriver2;
        Trip testTrip1;

        [TestInitialize]
        public void Initialize()
        {
            testTrip1 = new Trip("Test1", "9:00", "15:00", "120");
            Trip testTrip2 = new Trip("Test1", "12:00", "20:00", "480");
            Trip testTrip3 = new Trip("Test1", "0:00", "23:00", "2300");
            Trip testTrip4 = new Trip("Test1", "0:00", "0:00", "0");

            testDriver1 = new Driver("Test1");
            testDriver1.AddTrip(testTrip1);
            testDriver1.AddTrip(testTrip2);
            testDriver1.AddTrip(testTrip3);
            testDriver1.AddTrip(testTrip4);

            testDriver2 = new Driver("Test2");
        }


        [TestMethod]
        public void Derived_Property_TotalMilesDriven_Calculates_Correctly()
        {
            Assert.AreEqual((120 + 480 + 2300 + 0), testDriver1.TotalMilesDriven);
            Assert.AreEqual(0, testDriver2.TotalMilesDriven);
        }

        [TestMethod]
        public void Derived_Property_TotalTimeDrivenInMinutes_Calculates_Correctly()
        {
            Assert.AreEqual((6 + 8 + 23) * 60, testDriver1.TotalTimeDrivenInMinutes);
            Assert.AreEqual(0, testDriver2.TotalTimeDrivenInMinutes);
        }

        [TestMethod]
        public void Derived_Property_AverageSpeed_Calculates_Correctly()
        {
            Assert.AreEqual((testDriver1.TotalMilesDriven/testDriver1.TotalTimeDrivenInMinutes)*60, testDriver1.AverageSpeed);
            Assert.AreEqual(0, testDriver2.AverageSpeed);
        }

        [TestMethod]
        public void Driver_Constructor_Populates_Properties_Properly()
        {
            Driver testDriver1 = new Driver("Test1");

            Assert.AreEqual("Test1", testDriver1.DriverName);
            Assert.AreEqual(0, testDriver1.TotalMilesDriven);
            Assert.AreEqual(0, testDriver1.TotalTimeDrivenInMinutes);
            Assert.AreEqual(0, testDriver1.AverageSpeed);
            Assert.AreEqual(0, testDriver1.TripHistory.Count);

            Driver testDriver2 = new Driver("");

            Assert.AreEqual("", testDriver2.DriverName);
            Assert.AreEqual(0, testDriver2.TotalMilesDriven);
            Assert.AreEqual(0, testDriver2.TotalTimeDrivenInMinutes);
            Assert.AreEqual(0, testDriver2.AverageSpeed);
            Assert.AreEqual(0, testDriver2.TripHistory.Count);
        }

        [TestMethod]
        public void AddTrip_Increases_TripHistory_Count()
        {
            Assert.AreEqual(0, testDriver2.TripHistory.Count);

            testDriver2.AddTrip(testTrip1);

            Assert.AreEqual(1, testDriver2.TripHistory.Count);

            CollectionAssert.Contains(testDriver2.TripHistory, testTrip1);
        }
    }
}
