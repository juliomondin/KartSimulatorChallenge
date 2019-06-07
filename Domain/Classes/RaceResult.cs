using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Classes
{
    public class RaceResult
    {
        public Race Race { get; private set; }
        public RaceResult(Race race)
        {
            Race = race ?? throw new ArgumentNullException(nameof(race));
        }

        public List<Position> GetResult()
        {
            return new List<Position>();
        }

    }

    public class Position
    {
        public int ArrivingPosition { get; set; }

        public Driver Driver { get; set; }

        public int NumberOfFinishedLaps { get; set; }

        public TimeSpan FinalTime { get; set; }
    }
}
