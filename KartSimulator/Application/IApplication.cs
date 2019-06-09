using Domain.Classes;
using System.Collections.Generic;

namespace KartSimulator.Application
{
    /// <summary>
    /// Generates the messages that are going to be shown in the console.
    /// </summary>
    public interface IApplication
    {
        string GetInitialMenu();

        string GetFinalResult(List<Position> result, List<Position> leavers);

        string GetBestLap(Lap lap);

        string GetBestLapFromEachRacer(List<Lap> laps);

        string GetAverageSpeedFromEachRacer(List<Position> positions);

        string GetCompletedTimeAfterFirst(List<Position> positions);
    }
}