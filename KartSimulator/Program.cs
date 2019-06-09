using Domain.Classes;
using KartSimulator.Application;
using KartSimulator.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KartSimulator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region DI

            var collection = new ServiceCollection();
            collection.AddSingleton<IFileReader, FileReader>();
            collection.AddSingleton<IResultGenerator<Lap>, ResultGenerator>();
            collection.AddSingleton<IRepository<Lap>, Repository<Lap>>();
            collection.AddSingleton<IApplication, Application.Application>();

            var serviceProvider = collection.BuildServiceProvider();

            #endregion DI

            var service = serviceProvider.GetService<IRepository<Lap>>();
            var application = serviceProvider.GetService<IApplication>();

            var race = new Race(service.GetAll());
            var result = new RaceResult(race);

            Console.WriteLine(application.GetInitialMenu());

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    result.GetResult();
                    var raceResult = application.GetFinalResult(result.Result, result.Leavers);
                    Console.WriteLine(raceResult);
                    break;

                case "2":
                    var bestLap = race.GetBestLap();
                    Console.WriteLine(application.GetBestLap(bestLap));
                    break;

                case "3":
                    var bestLaps = race.GetBestLapFromEachRacer();
                    Console.WriteLine(application.GetBestLapFromEachRacer(bestLaps));
                    break;

                case "4":
                    var averageSpeed = result.GetAverageSpeed();
                    Console.WriteLine(application.GetAverageSpeedFromEachRacer(averageSpeed));
                    break;

                case "5":
                default:
                    var completedAfterFirst = result.GetCompletedTimeAfterFirst();
                    Console.WriteLine(application.GetCompletedTimeAfterFirst(completedAfterFirst));
                    break;
            }

            Console.ReadKey();
        }
    }
}