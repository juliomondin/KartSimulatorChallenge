using System;
using System.Collections.Generic;
using System.Text;
using Domain.Classes;

namespace KartSimulator.Application
{
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
