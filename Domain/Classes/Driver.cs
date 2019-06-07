using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Classes
{
    public class Driver
    {
        public Driver(int driverId, string name)
        {
            if (driverId <= 0) throw new ArgumentOutOfRangeException(nameof(driverId));
            DriverId = driverId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public Driver()
        {

        }
        public int DriverId { get; set; }
        public string Name { get; set; }

        public int Position { get; set; }
        public int FinalRoundNumber { get; set; }

        public TimeSpan FinalRaceTime { get; set; }

        //challenge
        public decimal FinalAverageSpeed { get; set; }

        public TimeSpan ArrivedAfterWinner { get; set; }

        // I think I'll need it
        public IEnumerable<Lap> Laps { get; set; }

        public Lap GetBestLap(Race race)
        {
            Laps = race.Laps.Where(x => x.Driver.DriverId == DriverId);
            return Laps.FirstOrDefault(x => x.RoundTime == Laps.Min(y => y.RoundTime));
        }
    }
}