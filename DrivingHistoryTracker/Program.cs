using System;
using System.Collections.Generic;

namespace DrivingHistoryTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = args[0];


            List<string> rawFileData = FileAccess.ReadFile(inputFilePath);
            DrivingDAL drivingDao = new DrivingDAL(rawFileData);

            if (args.Length > 1)
            {
                FileAccess.WriteToRecord(drivingDao.SortedDriverDB, args[1]);
            }
            else
            {
                FileAccess.WriteToRecord(drivingDao.SortedDriverDB);
            }
            Console.ReadLine();
        }
    }
}
