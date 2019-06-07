using System;
using System.Security.Cryptography.X509Certificates;
using Domain.Classes;
using KartSimulator.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace KartSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DI
            var collection = new ServiceCollection();
            collection.AddSingleton<IFileReader, FileReader>();
            collection.AddSingleton<IResultGenerator<Lap>, ResultGenerator>();
            collection.AddSingleton<IRepository<Lap>, Repository<Lap>>();

            var serviceProvider = collection.BuildServiceProvider();
            #endregion

            var service = serviceProvider.GetService<IRepository<Lap>>();

            var race = new Race(service.GetAll());

            Console.WriteLine("To find the race final result, press 1");
            Console.WriteLine("To find who made the best race's lap, press 2");
            Console.WriteLine("To find the best lap from which driver, press 3");
            Console.WriteLine("To find each driver average speed, press 4");
            Console.WriteLine("To find when each pilot arrived after the winner, press 5");


            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    var result = new RaceResult(race);
                    result.GetResult().ForEach(x => Console.WriteLine(
                        $"Position: {x.FinalTime} / {x.Driver.DriverId} - {x.Driver.Name}   / Finished Laps: {x.NumberOfFinishedLaps}   /    Finished Time: {x.FinalTime}))"));
                    break;
                case "2":
                    var bestLap = race.GetBestLap();
                    Console.WriteLine(
                        $"The best lap was made by {bestLap.Driver.Name} with the time of {bestLap.RoundTime}");
                    break;
                case "3":
                    var bestLaps = race.GetBestLapFromEachDriver();
                    bestLaps.ForEach(x => Console.WriteLine($"{x.Driver.Name} best time was {x.RoundTime}"));
                    break;
                case "4":
                    break;
                case "5":
                default:
                    Console.WriteLine("Come on!");
                    break;
            }

            Console.ReadKey();

        }
    }
}
