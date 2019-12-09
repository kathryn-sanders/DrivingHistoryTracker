using System;
using System.Collections.Generic;

namespace DrivingHistoryTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string inputFilePath = args[0];


            List<string> rawFileData = FileAccess.ReadFile(inputFilePath);
            DrivingRecord record = new DrivingRecord(rawFileData);

            if (args.Length > 1)
            {
                FileAccess.WriteToRecord(record.SortedDriverOverview, args[1]);
            }
            else
            {
                FileAccess.WriteToRecord(record.SortedDriverOverview);
            }
            Console.ReadLine();
        }
    }
}
