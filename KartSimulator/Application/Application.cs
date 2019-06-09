using Domain.Classes;
using System.Collections.Generic;

namespace KartSimulator.Application
{
    public class Application : IApplication
    {
        public string GetInitialMenu()
        {
            return "To find the race final result, press 1 \nTo find who made the faster lap, press 2 \n" +
                   "To find the best lap from each driver, press 3 \nTo find each driver average speed, press 4\n" +
                   "To find when each driver arrived after the first, press 5\n";
        }

        public string GetFinalResult(List<Position> result, List<Position> leavers)
        {
            var raceResult = "";
            result.ForEach(x => raceResult +=
                $"\n Position: {x.ArrivingPosition} / {x.Driver.DriverId} - {x.Driver.Name}   / Finished Laps: {x.NumberOfCompletedLaps}   /    Finished Time: {x.FinalTime}))");
            raceResult += "\n============================================================================\n";
            raceResult += "The following racers didn't completed the race: \n";
            leavers.ForEach(x => raceResult +=
                $"\n{x.Driver.DriverId} - {x.Driver.Name}   / Finished Laps: {x.NumberOfCompletedLaps}   /    Finished Time: {x.FinalTime}))"); ;

            return raceResult;
        }

        public string GetBestLap(Lap lap)
        {
            return
            $"The best lap was made by {lap.Driver.Name} with the time of {lap.LapTime}";
        }

        public string GetBestLapFromEachRacer(List<Lap> laps)
        {
            var result = "";
            laps.ForEach(x => result += $"{x.Driver.Name} best time was {x.LapTime}\n");
            return result;
        }

        public string GetAverageSpeedFromEachRacer(List<Position> positions)
        {
            var result = "";
            positions.ForEach(x => result +=
                $"{x.Driver.DriverId} - {x.Driver.Name}    Average Speed: {x.AverageSpeed} \n");
            return result;
        }

        public string GetCompletedTimeAfterFirst(List<Position> positions)
        {
            var result = "";

            positions.ForEach(x => result += $"{x.Driver.Name} -  {x.CompletedAfterFirst} \n");

            return result;
        }
    }
}