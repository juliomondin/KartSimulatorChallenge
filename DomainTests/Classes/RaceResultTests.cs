using System;
using System.Collections.Generic;
using System.Text;
using Domain.Classes;
using FluentAssertions;
using Xunit;

namespace DomainTests.Classes
{
    public class RaceResultTests
    {
        [Fact]
        public void Constructor_Throws_Exception_When_Invalid_Parameter()
        {
            Assert.Throws<ArgumentNullException>(() => new RaceResult(null));
        }

        [Fact]
        public void GetResult_Returns_Right_Result_No_Leavers()
        {
            var laps = new List<Lap>
            {
                new Lap("12:01:12", "1", "testPosition2", "1", "1:11.111", "1"),
                new Lap("12:01:12", "1", "testPosition2", "2", "1:11.111", "1"),
                new Lap("12:01:12", "1", "testPosition2", "3", "1:11.111", "1"),
                new Lap("12:01:12", "1", "testPosition2", "4", "1:11.111", "1"),
                new Lap("12:01:12", "2", "testPosition1", "1", "0:11.111", "1"),
                new Lap("12:01:12", "2", "testPosition1", "2", "0:11.111", "1"),
                new Lap("12:01:12", "2", "testPosition1", "3", "0:11.111", "1"),
                new Lap("12:01:12", "2", "testPosition1", "4", "0:11.111", "1")
            };
            var race = new Race(laps);
            var raceResult = new RaceResult(race);
            raceResult.GetResult();
            raceResult.Result[0].Should().NotBeNull();
            raceResult.Result[1].Should().NotBeNull();
            raceResult.Result[0].Driver.Name.Should().Be("testPosition1");
            raceResult.Result[0].Driver.DriverId.Should().Be(2);
            raceResult.Result[1].Driver.Name.Should().Be("testPosition2");
            raceResult.Result[1].Driver.DriverId.Should().Be(1);
            raceResult.Leavers.Should().BeEmpty();
        }

        [Fact]
        public void GetResult_Returns_Righ_Result_With_Leavers()
        {
            var laps = new List<Lap>
            {
                new Lap("12:01:12", "1", "testPosition2", "1", "1:11.111", "1"),
                new Lap("12:01:12", "1", "testPosition2", "2", "1:11.111", "1"),
                new Lap("12:01:12", "1", "testPosition2", "3", "1:11.111", "1"),
                new Lap("12:01:12", "1", "testPosition2", "4", "1:11.111", "1"),
                new Lap("12:01:12", "2", "testPosition1", "1", "0:11.111", "1"),
                new Lap("12:01:12", "2", "testPosition1", "2", "0:11.111", "1"),
                new Lap("12:01:12", "2", "testPosition1", "3", "0:11.111", "1"),
                new Lap("12:01:12", "2", "testPosition1", "4", "0:11.111", "1"),
                new Lap("12:01:12", "3", "testPosition3", "4", "0:11.111", "1")
            };
            var race = new Race(laps);
            var raceResult = new RaceResult(race);
            raceResult.GetResult();
            raceResult.Result[0].Should().NotBeNull();
            raceResult.Result[1].Should().NotBeNull();
            raceResult.Result[0].Driver.Name.Should().Be("testPosition1");
            raceResult.Result[0].Driver.DriverId.Should().Be(2);
            raceResult.Result[1].Driver.Name.Should().Be("testPosition2");
            raceResult.Result[1].Driver.DriverId.Should().Be(1);
            raceResult.Leavers.Should().NotBeEmpty();
            raceResult.Leavers[0].Driver.DriverId.Should().Be(3);
            raceResult.Leavers[0].Driver.Name.Should().Be("testPosition3");
        }

        [Fact]
        public void GetAverageSpeed_When_Valid_Parameters()
        {
            var laps = new List<Lap>
            {
                new Lap("12:01:12", "1", "testPosition2", "1", "1:11.111", "2"),
                new Lap("12:01:12", "1", "testPosition2", "2", "1:11.111", "2"),
                new Lap("12:01:12", "1", "testPosition2", "3", "1:11.111", "2"),
                new Lap("12:01:12", "1", "testPosition2", "4", "1:11.111", "2"),
                new Lap("12:01:12", "2", "testPosition1", "1", "0:11.111", "1"),
                new Lap("12:01:12", "2", "testPosition1", "2", "0:11.111", "1"),
                new Lap("12:01:12", "2", "testPosition1", "3", "0:11.111", "1"),
                new Lap("12:01:12", "2", "testPosition1", "4", "0:11.111", "1")
            };
            var race = new Race(laps);
            var raceResult = new RaceResult(race);
            var result = raceResult.GetAverageSpeed();
            result[0].AverageSpeed.Should().Be(2);
            result[1].AverageSpeed.Should().Be(1);
        }

        [Fact]
        public void GetCompletedTimeAfterWinner_When_Valid_Parameters()
        {
            var laps = new List<Lap>
            {
                new Lap("12:01:12", "1", "testPosition2", "1", "1:11.111", "2"),
                new Lap("12:01:12", "1", "testPosition2", "2", "1:11.111", "2"),
                new Lap("12:01:12", "1", "testPosition2", "3", "1:11.111", "2"),
                new Lap("12:01:12", "1", "testPosition2", "4", "1:11.111", "2"),
                new Lap("12:01:12", "2", "testPosition1", "1", "0:11.111", "1"),
                new Lap("12:01:12", "2", "testPosition1", "2", "0:11.111", "1"),
                new Lap("12:01:12", "2", "testPosition1", "3", "0:11.111", "1"),
                new Lap("12:01:12", "2", "testPosition1", "4", "0:11.111", "1")
            };
            var race = new Race(laps);
            var raceResult = new RaceResult(race);
            var result = raceResult.GetCompletedTimeAfterFirst();
            result[1].CompletedAfterFirst.Should().Be(TimeSpan.ParseExact("4:00.000", "m\\:ss\\.fff", null));
            result[0].CompletedAfterFirst.Should().Be(TimeSpan.ParseExact("0:00.000", "m\\:ss\\.fff", null));
        }

    }
}