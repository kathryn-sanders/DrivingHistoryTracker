using System;
using System.Collections.Generic;
using System.Text;

namespace DrivingHistoryTracker
{
    public class Trip
    {
        public string Driver { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan StopTime { get; set; }
        public double MilesDriven { get; set; }
        public double DurationInMinutes
        {
            get
            {
                TimeSpan interval = StopTime - StartTime;
                return interval.TotalMinutes;
            }
            set { }
        }

        public double AvgTripSpeed
        {
            get
            {
                return (DurationInMinutes / MilesDriven) / 60;
            }
            set { }
        }

        public Trip(string driverName, string startTime, string stopTime, string milesDriven)
        {
            Driver = driverName;
            StartTime = TimeSpan.Parse(startTime);
            StopTime = TimeSpan.Parse(stopTime);
            MilesDriven = double.Parse(milesDriven);
        }
    }
}
