using Domain.Classes;
using System.Collections.Generic;

namespace KartSimulator.Application
{
    /// <summary>
    /// Generates the messages that are going to be shown in the console.
    /// </summary>
    public class Application : IApplication
    {
        /// <summary>
        /// Initial message.
        /// </summary>
        /// <returns></returns>
        public string GetInitialMenu()
        {
            return "To find the race final result, press 1 \nTo find who made the faster lap, press 2 \n" +
                   "To find the best lap from each racer, press 3 \nTo find each racer average speed, press 4\n" +
                   "To find when each racer arrived after the first, press 5\n";
        }

        /// <summary>
        /// Generates option 1 message.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="leavers"></param>
        /// <returns></returns>
        public string GetFinalResult(List<Position> result, List<Position> leavers)
        {
            var raceResult = "";
            result.ForEach(x => raceResult +=
                $"\n Position: {x.ArrivingPosition} / {x.Racer.RacerId} - {x.Racer.Name}   / Finished Laps: {x.NumberOfCompletedLaps}   /    Finished Time: {x.FinalTime}))");
            raceResult += "\n============================================================================\n";
            raceResult += "The following racers didn't completed the race: \n";
            leavers.ForEach(x => raceResult +=
                $"\n{x.Racer.RacerId} - {x.Racer.Name}   / Finished Laps: {x.NumberOfCompletedLaps}   /    Finished Time: {x.FinalTime}))"); ;

            return raceResult;
        }

        /// <summary>
        /// Generates option 2 message.
        /// </summary>
        /// <param name="lap"></param>
        /// <returns></returns>
        public string GetBestLap(Lap lap)
        {
            return
            $"The best lap was made by {lap.Racer.Name} with the time of {lap.LapTime}";
        }

        /// <summary>
        /// Generates option 3 message.
        /// </summary>
        /// <param name="laps"></param>
        /// <returns></returns>
        public string GetBestLapFromEachRacer(List<Lap> laps)
        {
            var result = "";
            laps.ForEach(x => result += $"{x.Racer.Name} best time was {x.LapTime}\n");
            return result;
        }

        /// <summary>
        /// Generates option 4 message.
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public string GetAverageSpeedFromEachRacer(List<Position> positions)
        {
            var result = "";
            positions.ForEach(x => result +=
                $"{x.Racer.RacerId} - {x.Racer.Name}    Average Speed: {x.AverageSpeed} \n");
            return result;
        }

        /// <summary>
        /// Generates option 5 message.
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public string GetCompletedTimeAfterFirst(List<Position> positions)
        {
            var result = "";

            positions.ForEach(x => result += $"{x.Racer.Name} -  {x.CompletedAfterFirst} \n");

            return result;
        }
    }
}