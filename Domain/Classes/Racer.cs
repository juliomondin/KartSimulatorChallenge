using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Classes
{
    public class Racer
    {
        /// <summary>
        /// Racer constructor.
        /// </summary>
        /// <param name="racerId"></param>
        /// <param name="name"></param>
        public Racer(int racerId, string name)
        {
            if (racerId <= 0) throw new ArgumentOutOfRangeException(nameof(racerId));
            RacerId = racerId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Racer constructor.
        /// </summary>
        public Racer()
        {
        }

        /// <summary>
        /// Racer code.
        /// </summary>
        public int RacerId { get; set; }

        /// <summary>
        /// Racer name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Racer final position.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Final lap number.
        /// </summary>
        public int FinalRoundNumber { get; set; }

        /// <summary>
        /// Completed race time.
        /// </summary>
        public TimeSpan FinalRaceTime { get; set; }

        /// <summary>
        /// Final average speed.
        /// </summary>
        public decimal FinalAverageSpeed { get; set; }

        /// <summary>
        /// Race completed time after the first.
        /// </summary>
        public TimeSpan ArrivedAfterWinner { get; set; }

        /// <summary>
        /// Laps.
        /// </summary>
        public IEnumerable<Lap> Laps { get; set; }

        /// <summary>
        /// Returns the racer's best lap.
        /// </summary>
        /// <param name="race"></param>
        /// <returns></returns>
        public Lap GetBestLap(Race race)
        {
            Laps = race.Laps.Where(x => x.Racer.RacerId == RacerId);
            return Laps.FirstOrDefault(x => x.LapTime == Laps.Min(y => y.LapTime));
        }
    }
}