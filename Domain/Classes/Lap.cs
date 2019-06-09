using System;

namespace Domain.Classes
{
    public class Lap
    {
        public Lap(string hour, string racerId, string racer, string roundCount, string roundTime,
            string averageSpeed)
        {
            if (hour == null) throw new ArgumentNullException(nameof(hour));
            if (racerId == null) throw new ArgumentNullException(nameof(racerId));
            if (racer == null) throw new ArgumentNullException(nameof(racer));
            if (roundCount == null) throw new ArgumentNullException(nameof(roundCount));
            if (roundTime == null) throw new ArgumentNullException(nameof(roundTime));
            if (averageSpeed == null) throw new ArgumentNullException(nameof(averageSpeed));

            Hour = Convert.ToDateTime(hour);
            LapCount = int.Parse(roundCount);
            LapTime = TimeSpan.ParseExact(roundTime, "m\\:ss\\.fff", null);
            AverageSpeed = decimal.Parse(averageSpeed.Replace(",", "."));
            Racer = new Racer(int.Parse(racerId), racer);
        }

        public DateTime Hour { get; private set; }

        public Racer Racer { get; set; }
        public int LapCount { get; private set; }
        public TimeSpan LapTime { get; private set; }
        public decimal AverageSpeed { get; private set; }
    }
}