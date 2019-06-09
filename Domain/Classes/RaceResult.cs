using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Classes
{
    public class RaceResult
    {
        /// <summary>
        /// Race the the result is being shown.
        /// </summary>
        public Race Race { get; private set; }

        /// <summary>
        /// Racers that completed the race.
        /// </summary>
        public List<Position> Result { get; private set; }

        /// <summary>
        /// Racers that didn't completed the race.
        /// </summary>
        public List<Position> Leavers { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="race"></param>
        public RaceResult(Race race)
        {
            Race = race ?? throw new ArgumentNullException(nameof(race));
        }

        /// <summary>
        /// Fills the result and leavers properties.
        /// </summary>
        public void GetResult()
        {
            //get the list of racers first.
            Result = new List<Position>();
            Leavers = new List<Position>();

            var position = 1;
            var racers = GetListOfRacers();
            //now I'll create a position to each racer
            racers.ForEach(x => Result.Add(new Position { Racer = x }));
            // now I'll fill the rest of position's information with data from raw race
            foreach (var lap in Race.Laps)
            {
                Result.First(x => x.Racer.RacerId == lap.Racer.RacerId).NumberOfCompletedLaps++;
                Result.First(x => x.Racer.RacerId == lap.Racer.RacerId).FinalTime += lap.LapTime;
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

        /// <summary>
        /// Returns a list with each racers average speed.
        /// </summary>
        /// <returns></returns>
        public List<Position> GetAverageSpeed()
        {
            var result = new List<Position>();
            var racers = GetListOfRacers();

            racers.ForEach(x => result.Add(new Position { Racer = x }));

            foreach (var lap in Race.Laps)
            {
                result.First(x => x.Racer.RacerId == lap.Racer.RacerId).NumberOfCompletedLaps++;
                result.First(x => x.Racer.RacerId == lap.Racer.RacerId).AverageSpeed += lap.AverageSpeed;
            }
            result.ForEach(x => x.AverageSpeed /= x.NumberOfCompletedLaps);
            return result;
        }

        /// <summary>
        /// Returns a list with each racers completed time after the first racer to complete the race.
        /// </summary>
        /// <returns></returns>
        public List<Position> GetCompletedTimeAfterFirst()
        {
            GetResult();
            var firstCompletedTime = Result[0].FinalTime;
            Result.ForEach(x => x.CompletedAfterFirst = x.FinalTime - firstCompletedTime);
            return Result;
        }

        private List<Racer> GetListOfRacers()
        {
            var racers = new List<Racer>();
            var query = Race.Laps.DistinctBy(x => x.Racer.RacerId).ToList();
            query.ForEach(x => racers.Add(x.Racer));
            return racers;
        }
    }
}