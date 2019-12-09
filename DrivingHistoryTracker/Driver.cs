using System;
using System.Collections.Generic;
using System.Text;

namespace DrivingHistoryTracker
{
    public class Driver
    {
        public string DriverName { get; set; }
        public double TotalMilesDriven
        {
            get
            {
                double totalTripMiles = 0;
                foreach (Trip trip in TripHistory)
                {
                    totalTripMiles = totalTripMiles + trip.MilesDriven;
                }
                return totalTripMiles;
            }
            set { }
        }
        public double TotalTimeDrivenInMinutes
        {
            get
            {
                double totalTripMinutes = 0;
                foreach (Trip trip in TripHistory)
                {
                    totalTripMinutes = totalTripMinutes + trip.DurationInMinutes;
                }
                return totalTripMinutes;
            }
            set { }
        }
        public double AverageSpeed
        {
            get
            {
                if (TripHistory.Count > 0)
                {
                    return (TotalMilesDriven / TotalTimeDrivenInMinutes) / 60;
                }
                else
                {
                    return 0;
                }
            }
            set {}
        }
        public List<Trip> TripHistory { get; set; }

        public Driver(string driverName)
        {
            DriverName = driverName;
            TripHistory = new List<Trip>();
        }

        public void AddTrip(Trip trip)
        {
            TripHistory.Add(trip);
        }
    }
}
