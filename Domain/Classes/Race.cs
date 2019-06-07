using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Classes
{
    public class Race
    {
        public List<Lap> Laps { get; private set; }

        public Race(List<Lap> laps)
        {
            Laps = laps;
        }

        //challenge
        public Lap GetBestLap()
        {
            return Laps.FirstOrDefault(x => x.RoundTime == Laps.Min(y => y.RoundTime));
        }

        public List<Lap> GetBestLapFromEachDriver()
        {
            var result = new List<Lap>();
            var query = Laps.DistinctBy(x => x.Driver.DriverId);
            foreach (var driver in query)
            {
                var driverLaps = Laps.Where(x => x.Driver.DriverId == driver.Driver.DriverId);
                var fasterLap = driverLaps.Where(x => x.RoundTime == driverLaps.Min(y => y.RoundTime));
                result.Add(fasterLap.FirstOrDefault());
            }

            return result;
        }


    }
}
