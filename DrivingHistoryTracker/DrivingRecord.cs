using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DrivingHistoryTracker
{
    public class DrivingRecord
    {
        public Dictionary<string, Driver> DriverOverview { get; set; } = new Dictionary<string, Driver>();

        public Dictionary<string, Driver> SortedDriverOverview
        {
            get
            {
                return SortDictionary(DriverOverview);
            }
        }

        public DrivingRecord(List<string> rawFileData)
        {
            foreach (string line in rawFileData)
            {
                string[] lineData = line.Split(' ');

                string command = lineData[0];
                string driverName = lineData[1];

                if (command.ToLower() == "driver")
                {
                    Driver newDriver = new Driver(driverName);
                    DriverOverview[driverName] = newDriver;
                }

                if (command.ToLower() == "trip")
                {
                    string startTime = lineData[2];
                    string endTime = lineData[3];
                    string milesDriven = lineData[4];

                    Trip newTrip = new Trip(driverName, startTime, endTime, milesDriven);
                    if (newTrip.AvgTripSpeed < 5 || newTrip.AvgTripSpeed > 100)
                    {
                        DriverOverview[driverName].AddTrip(newTrip);
                    }
                }
            }
        }

        public Dictionary<string, Driver> SortDictionary(Dictionary<string, Driver> originalDictionary)
        {
            List<KeyValuePair<string, Driver>> SortedKVPs = originalDictionary.OrderByDescending(unsortedKVP => unsortedKVP.Value.TotalMilesDriven).ToList();

            Dictionary<string, Driver> SortedDriverOverview = SortedKVPs.ToDictionary(SortedKVPs => SortedKVPs.Key, SortedKVPs => SortedKVPs.Value);

            return SortedDriverOverview;
        }

    }
}
