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
            var result = new RaceResult(race);

            Console.WriteLine("To find the race final result, press 1");
            Console.WriteLine("To find who made the faster lap, press 2");
            Console.WriteLine("To find the best lap from each driver, press 3");
            Console.WriteLine("To find each driver average speed, press 4");
            Console.WriteLine("To find when each driver arrived after the first, press 5");


            var option = Console.ReadLine();

            switch (option)
            {
                case "1":

                    result.GetResult();
                    result.Result.ForEach(x => Console.WriteLine(
                        $"Position: {x.ArrivingPosition} / {x.Driver.DriverId} - {x.Driver.Name}   / Finished Laps: {x.NumberOfCompletedLaps}   /    Finished Time: {x.FinalTime}))"));

                    Console.WriteLine("============================================================================");
                    Console.WriteLine("The following racers didn't completed the race: ");
                    result.Leavers.ForEach(x => Console.WriteLine(
                        $"{x.Driver.DriverId} - {x.Driver.Name}   / Finished Laps: {x.NumberOfCompletedLaps}   /    Finished Time: {x.FinalTime}))")); ;
                    break;
                case "2":
                    var bestLap = race.GetBestLap();
                    Console.WriteLine(
                        $"The best lap was made by {bestLap.Driver.Name} with the time of {bestLap.LapTime}");
                    break;
                case "3":
                    var bestLaps = race.GetBestLapFromEachDriver();
                    bestLaps.ForEach(x => Console.WriteLine($"{x.Driver.Name} best time was {x.LapTime}"));
                    break;
                case "4":
                    var averageSpeed = result.GetAverageSpeed();
                    averageSpeed.ForEach(x => Console.WriteLine(
                        $"{x.Driver.DriverId} - {x.Driver.Name}    Average Speed: {x.AverageSpeed} "));
                    break;
                case "5":
                default:
                    Console.WriteLine("All the drivers that completed the race:");
                    var completedAfterFirst = result.GetCompletedTimeAfterFirst();
                    completedAfterFirst.ForEach(x => Console.WriteLine($"{x.Driver.Name} -  {x.CompletedAfterFirst}"));
                    break;
            }

            Console.ReadKey();

        }
    }
}
