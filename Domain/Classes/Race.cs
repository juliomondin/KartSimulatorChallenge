using System.Collections.Generic;
using System.Linq;

namespace Domain.Classes
{
    public class Race
    {
        /// <summary>
        /// Race's laps.
        /// </summary>
        public List<Lap> Laps { get; private set; }

        /// <summary>
        /// Race's constructor.
        /// </summary>
        /// <param name="laps"></param>
        public Race(List<Lap> laps)
        {
            Laps = laps;
        }

        /// <summary>
        /// Returns tha race's best lap.
        /// </summary>
        /// <returns></returns>
        public Lap GetBestLap()
        {
            return Laps.FirstOrDefault(x => x.LapTime == Laps.Min(y => y.LapTime));
        }

        /// <summary>
        /// Returns the best lap from each racer.
        /// </summary>
        /// <returns></returns>
        public List<Lap> GetBestLapFromEachRacer()
        {
            var result = new List<Lap>();
            var query = Laps.DistinctBy(x => x.Racer.RacerId);
            foreach (var racer in query)
            {
                var racerLaps = Laps.Where(x => x.Racer.RacerId == racer.Racer.RacerId);
                var fasterLap = racerLaps.Where(x => x.LapTime == racerLaps.Min(y => y.LapTime));
                result.Add(fasterLap.FirstOrDefault());
            }

            return result;
        }
    }
}