﻿using Domain.Classes;
using FluentAssertions;
using System;
using Xunit;

namespace DomainTests.Classes
{
    public class RoundTests
    {
        [Fact]
        public void Constructor_Returns_Exception_When_Null_Parameter()
        {
            Assert.Throws<ArgumentNullException>(() => new Lap(null, "1", "test", "1", "1:11.111", "1"));
            Assert.Throws<ArgumentNullException>(() => new Lap("12:01:12", null, "test", "1", "1:11.111", "1"));
            Assert.Throws<ArgumentNullException>(() => new Lap("12:01:12", "1", null, "1", "1:11.111", "1"));
            Assert.Throws<ArgumentNullException>(() => new Lap("12:01:12", "1", "test", null, "1:11.111", "1"));
            Assert.Throws<ArgumentNullException>(() => new Lap("12:01:12", "1", "test", "1", null, "1"));
            Assert.Throws<ArgumentNullException>(() => new Lap("12:01:12", "1", "test", "1", "1:11.111", null));
        }

        [Fact]
        public void Constructor_Returns_New_round_When_Valid_Parameters()
        {
            var round = new Lap("12:01:12", "1", "test", "1", "1:11.111", "1");
            round.Should().NotBeNull();
            round.Hour.Should().Be(Convert.ToDateTime("12:01:12"));
            round.Racer.RacerId.Should().Be(1);
            round.Racer.Name.Should().Be("test");
            round.LapCount.Should().Be(1);
            round.LapTime.Should().Be(TimeSpan.ParseExact("1:11.111", "m\\:ss\\.fff", null));
            round.AverageSpeed.Should().Be(1);
        }
    }
}