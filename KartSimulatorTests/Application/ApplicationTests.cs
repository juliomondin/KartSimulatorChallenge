using System;
using System.Collections.Generic;
using System.Text;
using Domain.Classes;
using FluentAssertions;
using KartSimulator.Application;
using Xunit;

namespace KartSimulatorTests.Application
{
    public class ApplicationTests
    {
        [Fact]
        public void GetInitialMenu_Returns_Initial_Menu()
        {
            var app = new KartSimulator.Application.Application();
            var result = app.GetInitialMenu();
            result.Should().NotBeEmpty();
            result.Should().Be("To find the race final result, press 1 \nTo find who made the faster lap, press 2 \n" +
                               "To find the best lap from each driver, press 3 \nTo find each driver average speed, press 4\n" +
                               "To find when each driver arrived after the first, press 5\n");
        }

        [Fact]
        public void GetFinalResult_Returns_Final_Result()
        {
            var mockRacers = new List<Position>
            {
                new Position() {ArrivingPosition = 1, AverageSpeed = 1, Driver = new Driver(1,"julio"), FinalTime = new TimeSpan(1,1,1),NumberOfCompletedLaps = 1},
                new Position() {ArrivingPosition = 2, AverageSpeed = 2, Driver = new Driver(1,"massa"), FinalTime = new TimeSpan(1,1,1),NumberOfCompletedLaps = 1}
            };
            var mockLeavers = new List<Position>
            {
                new Position()
                {
                    ArrivingPosition = 1, AverageSpeed = 1, Driver = new Driver(1, "vettel"),
                    FinalTime = new TimeSpan(1, 1, 1), NumberOfCompletedLaps = 1
                },
            };
            var app = new KartSimulator.Application.Application();
            var result = app.GetFinalResult(mockRacers, mockLeavers).Should().NotBeNullOrEmpty();

        }

        [Fact]
        public void GetBestLap_Returns_Best_Lap()
        {
            var bestLap = new Lap("12:01:12", "1", "testPosition2", "1", "1:11.111", "1");
            var app = new KartSimulator.Application.Application();
            var result = app.GetBestLap(bestLap);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetBestLapFromEachRacer_Returns_Best_Laps()
        {
            var bestLaps = new List<Lap>
            {
                new Lap("12:01:12", "1", "testPosition2", "1", "1:11.111", "1"),
                new Lap("12:01:12", "1", "testPosition2", "1", "1:11.111", "1")
            };
            var app = new KartSimulator.Application.Application();
            var result = app.GetBestLapFromEachRacer(bestLaps);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetAverageSpeedFromEachDriver_Returns_Average_Speed()
        {
            var mockRacers = new List<Position>
            {
                new Position() {ArrivingPosition = 1, AverageSpeed = 1, Driver = new Driver(1,"julio"), FinalTime = new TimeSpan(1,1,1),NumberOfCompletedLaps = 1},
                new Position() {ArrivingPosition = 2, AverageSpeed = 2, Driver = new Driver(1,"massa"), FinalTime = new TimeSpan(1,1,1),NumberOfCompletedLaps = 1}
            };
            var app = new KartSimulator.Application.Application();
            var result = app.GetAverageSpeedFromEachRacer(mockRacers);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetCompletedTimeAfterFirst_Returns_List_Of_Completed_Time_After_Firs()
        {
            var mockRacers = new List<Position>
            {
                new Position() {ArrivingPosition = 1, AverageSpeed = 1, Driver = new Driver(1,"julio"), FinalTime = new TimeSpan(1,1,1),NumberOfCompletedLaps = 1},
                new Position() {ArrivingPosition = 2, AverageSpeed = 2, Driver = new Driver(1,"massa"), FinalTime = new TimeSpan(1,1,1),NumberOfCompletedLaps = 1}
            };
            var app = new KartSimulator.Application.Application();
            var result = app.GetCompletedTimeAfterFirst(mockRacers);
            result.Should().NotBeNullOrEmpty();
        }

    }
}
