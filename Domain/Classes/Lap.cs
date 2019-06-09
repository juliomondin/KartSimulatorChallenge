﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Domain.Classes
{
    public class Lap
    {
        public Lap(string hour, string driverId, string driver, string roundCount, string roundTime,
            string averageSpeed)
        {
            if (hour == null) throw new ArgumentNullException(nameof(hour));
            if (driverId == null) throw new ArgumentNullException(nameof(driverId));
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            if (roundCount == null) throw new ArgumentNullException(nameof(roundCount));
            if (roundTime == null) throw new ArgumentNullException(nameof(roundTime));
            if (averageSpeed == null) throw new ArgumentNullException(nameof(averageSpeed));


            Hour = Convert.ToDateTime(hour);
            LapCount = int.Parse(roundCount);
            LapTime = TimeSpan.ParseExact(roundTime, "m\\:ss\\.fff", null);
            AverageSpeed = decimal.Parse(averageSpeed.Replace(",", "."));
            Driver = new Driver(int.Parse(driverId), driver);
        }
        public DateTime Hour { get; private set; }

        public Driver Driver { get; set; }
        public int LapCount { get; private set; }
        public TimeSpan LapTime { get; private set; }
        public decimal AverageSpeed { get; private set; }
    }
}
