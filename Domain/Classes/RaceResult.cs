using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Classes
{
    public class RaceResult
    {
        public Race Race { get; private set; }

        public List<Position> Result { get; private set; }
        public List<Position> Leavers { get; private set; }

        public RaceResult(Race race)
        {
            Race = race ?? throw new ArgumentNullException(nameof(race));
        }

        public void GetResult()
        {
            //get the list of racers first.
            Result = new List<Position>();
            Leavers = new List<Position>();

            var position = 1;
            var racers = GetListOfDrivers();
            //now I'll create a position to each driver
            racers.ForEach(x => Result.Add(new Position { Driver = x }));
            // now I'll fill the rest of position's information with data from raw race
            foreach (var lap in Race.Laps)
            {
                Result.First(x => x.Driver.DriverId == lap.Driver.DriverId).NumberOfCompletedLaps++;
                Result.First(x => x.Driver.DriverId == lap.Driver.DriverId).FinalTime += lap.LapTime;
            }
            Result = Result.OrderBy(x => x.FinalTime).ToList();
            //now I'll remove the racers that did not complete the race
            foreach (var x in Result)
            {
                if (x.NumberOfCompletedLaps >= 4)
                {
                    x.ArrivingPosition = position;
                    position++;
                }
                else
                {
                    Leavers.Add(x);
                }
            }
            Leavers.ForEach(x => Result.RemoveAll(y => y.NumberOfCompletedLaps < 4));
            Result = Result.OrderBy(x => x.ArrivingPosition).ToList();
        }

        public List<Position> GetAverageSpeed()
        {
            var result = new List<Position>();
            var racers = GetListOfDrivers();

            racers.ForEach(x => result.Add(new Position { Driver = x }));

            foreach (var lap in Race.Laps)
            {
                result.First(x => x.Driver.DriverId == lap.Driver.DriverId).NumberOfCompletedLaps++;
                result.First(x => x.Driver.DriverId == lap.Driver.DriverId).AverageSpeed += lap.AverageSpeed;
            }
            result.ForEach(x => x.AverageSpeed /= x.NumberOfCompletedLaps);
            return result;
        }

        public List<Position> GetCompletedTimeAfterFirst()
        {
            GetResult();
            var firstCompletedTime = Result[0].FinalTime;
            Result.ForEach(x => x.CompletedAfterFirst = x.FinalTime - firstCompletedTime);
            return Result;
        }

        private List<Driver> GetListOfDrivers()
        {
            var racers = new List<Driver>();
            var query = Race.Laps.DistinctBy(x => x.Driver.DriverId).ToList();
            query.ForEach(x => racers.Add(x.Driver));
            return racers;
        }
    }
}