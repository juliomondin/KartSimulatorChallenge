using System;

namespace Domain.Classes
{
    public class Position
    {
        public int ArrivingPosition { get; set; }

        public Driver Driver { get; set; }

        public int NumberOfCompletedLaps { get; set; }

        public TimeSpan FinalTime { get; set; }

        public decimal AverageSpeed { get; set; }

        public TimeSpan CompletedAfterFirst { get; set; }
    }
}