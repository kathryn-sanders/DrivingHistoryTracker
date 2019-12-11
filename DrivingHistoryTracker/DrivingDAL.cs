using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DrivingHistoryTracker
{
    public class DrivingDAL
    {
        public Dictionary<string, Driver> DriverDB { get; set; } = new Dictionary<string, Driver>();

        public Dictionary<string, Driver> SortedDriverDB
        {
            get
            {
                return SortDictionary(DriverDB);
            }
        }

        public DrivingDAL(List<string> rawFileData)
        {
            foreach (string line in rawFileData)
            {
                string[] lineData = line.Split(' ');

                string command = lineData[0];
                string driverName = lineData[1];

                if (command.ToLower() == "driver")
                {
                    Driver newDriver = new Driver(driverName);
                    DriverDB[driverName] = newDriver;
                }

                if (command.ToLower() == "trip")
                {
                    string startTime = lineData[2];
                    string endTime = lineData[3];
                    string milesDriven = lineData[4];

                    Trip newTrip = new Trip(driverName, startTime, endTime, milesDriven);
                    if (newTrip.AvgTripSpeed > 5 || newTrip.AvgTripSpeed < 100)
                    {
                        DriverDB[driverName].AddTrip(newTrip);
                    }
                }
            }
        }

        public Dictionary<string, Driver> SortDictionary(Dictionary<string, Driver> originalDictionary)
        {
            List<KeyValuePair<string, Driver>> SortedKVPs = originalDictionary.OrderByDescending(unsortedKVP => unsortedKVP.Value.TotalMilesDriven).ToList();

            Dictionary<string, Driver> SortedDriverDB = SortedKVPs.ToDictionary(SortedKVPs => SortedKVPs.Key, SortedKVPs => SortedKVPs.Value);

            return SortedDriverDB;
        }

    }
}
