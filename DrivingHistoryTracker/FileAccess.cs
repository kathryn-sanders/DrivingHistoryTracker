using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace DrivingHistoryTracker
{
    public class FileAccess
    {
        public static List<string> ReadFile(string filePath)
        {
            List<string> rawFileData = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        rawFileData.Add(line);
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error Reading the File");
            }

            return rawFileData;
        }

        public static void WriteToRecord(Dictionary<string, Driver> DriverOverview)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                Console.WriteLine($"Report can be found at {currentDirectory}/Report.txt");
                using (StreamWriter recordWriter = new StreamWriter($"{currentDirectory}/Report.txt", false))
                {
                    foreach (KeyValuePair<string, Driver> kvp in DriverOverview)
                    {
                        recordWriter.WriteLine($"{ kvp.Value.DriverName}: {Math.Round(kvp.Value.TotalMilesDriven)} miles @ {Math.Round(kvp.Value.AverageSpeed)} mph");
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error Writing to File");
            }
        }

        public static void WriteToRecord(Dictionary<string, Driver> DriverOverview, string outputPath)
        {
            try
            {
                using (StreamWriter recordWriter = new StreamWriter(outputPath, false))
                {
                    foreach (KeyValuePair<string, Driver> kvp in DriverOverview)
                    {
                        recordWriter.WriteLine($"{ kvp.Value.DriverName}: {Math.Round(kvp.Value.TotalMilesDriven)} miles @ {Math.Round(kvp.Value.AverageSpeed)} mph");
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error Writing to File");
            }
        }
    }
}
