using System;
using System.IO;

namespace CarConnectionSQL
{
    public class Program
    {
        static readonly string wInitPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"\"+ "thecarconnectionpicturedataset";

        static void Main(string[] args)
        {
            Console.WriteLine("The path folder will be: " + wInitPath);
            Console.WriteLine("Press 'Enter' to begin process of transformation.");

            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                TransformInsert();
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine(elapsedMs);
            }
        }


        async static void TransformInsert()
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(wInitPath);
                CarsDatabaseEntities carsDatabaseEntities = new CarsDatabaseEntities();

                int wTotalFiles = default;

                var txtFiles = Directory.EnumerateFiles(wInitPath);

                foreach (string file in txtFiles)
                {
                    wTotalFiles++;
                    string[] wData = file.Split('_');
                    string[] make = wData[0].Split('\\');
                    Car car = new Car
                    {
                        make = Convert.ToString(make[6]),
                        model = Convert.ToString(wData[1]),
                        year = Convert.ToString(wData[2]),
                        msrp = Convert.ToString(wData[3]),
                        frontwheelsize = Convert.ToString(wData[4]),
                        horsepower = Convert.ToString(wData[5]),
                        displacement = Convert.ToString(wData[6]),
                        enginetype = Convert.ToString(wData[7]),
                        width = Convert.ToString(wData[8]),
                        height = Convert.ToString(wData[9]),
                        length = Convert.ToString(wData[10]),
                        gasmileage = Convert.ToString(wData[11]),
                        drivetrain = Convert.ToString(wData[12]),
                        passengercapacity = Convert.ToString(wData[13]),
                        passengerdoors = Convert.ToString(wData[14]),
                        bodystyle = Convert.ToString(wData[15])
                    };
                    carsDatabaseEntities.Cars.Add(car);
                    Console.WriteLine($"Car entity #{wTotalFiles} successfully created");
                }

                Console.WriteLine("Images found :" + Convert.ToString(wTotalFiles));

                await carsDatabaseEntities.SaveChangesAsync();
                Console.WriteLine("Data inserted! Check SQL Server.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("There is no folder thecarconnectionpicturedataset in the specified path. Check and try again.");
            }
        }
    }
}
