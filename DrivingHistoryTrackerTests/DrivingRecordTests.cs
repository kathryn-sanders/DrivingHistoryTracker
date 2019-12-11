﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrivingHistoryTracker.Tests
{
    [TestClass]
    public class DrivingRecordTests
    {
        Driver testDriverObj1;
        Driver testDriverObj2;
        Driver testDriverObj3;
        DrivingRecord testRecord1;

        [TestInitialize]
        public void Initialize()
        {
            string testString1 = "Driver testDriver1";
            string testString2 = "driver testDriver2";
            string testString3 = "driver testDriver3";
            string testString4 = "Trip testDriver1 0:00 23:00 2300";
            string testString5 = "trip testDriver2 0:00 0:00 0";
            string testString6 = "trip testDriver3 12:00 20:00 480";

            testDriverObj1 = new Driver("testDriver1");
            testDriverObj2 = new Driver("testDriver2");
            testDriverObj3 = new Driver("testDriver3");

            List<string> testInput = new List<string>();
            testInput.Add(testString1);
            testInput.Add(testString2);
            testInput.Add(testString3);
            testInput.Add(testString4);
            testInput.Add(testString5);
            testInput.Add(testString6);

            testRecord1 = new DrivingRecord(testInput);
        }

        [TestMethod]
        public void DrivingRecord_Constructor_Adds_New_Data_To_DriverOverview()
        {

            Assert.AreEqual(2, testRecord1.DriverOverview.Count);
            CollectionAssert.Contains(testRecord1.DriverOverview.Keys, "testDriver1");
            CollectionAssert.Contains(testRecord1.DriverOverview.Keys, "testDriver2");
            Assert.AreEqual(testRecord1.DriverOverview["testDriver1"].DriverName, testDriverObj1.DriverName);
            Assert.AreEqual(testRecord1.DriverOverview["testDriver2"].DriverName, testDriverObj2.DriverName);
        }

        [TestMethod]
        public void SortDictionary_Orders_By_TotalMilesDriven()
        {
            Dictionary<string, Driver> sortResult = new Dictionary<string, Driver>();
            sortResult.Add("testDriver1", testDriverObj1);
            sortResult.Add("testDriver3", testDriverObj3);
            sortResult.Add("testDriver2", testDriverObj2);

            Assert.AreEqual(sortResult.Count, testRecord1.SortDictionary(testRecord1.DriverOverview).Count);
            CollectionAssert.AreEqual(sortResult.Keys, testRecord1.SortDictionary(testRecord1.DriverOverview).Keys);



        }
    }
}