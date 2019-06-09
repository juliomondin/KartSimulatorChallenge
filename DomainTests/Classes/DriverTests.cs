using Domain.Classes;
using FluentAssertions;
using System;
using Xunit;

namespace DomainTests.Classes
{
    public class RacerTests
    {
        [Fact]
        public void Constructor_Returns_Exception_When_Null_Name()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Racer(0, "Julio"));
        }

        [Fact]
        public void Constructor_Returns_Exception_When_RacerId_Is_0()
        {
            Assert.Throws<ArgumentNullException>(() => new Racer(1, null));
        }

        [Fact]
        public void Constructor_Returns_Racer_When_Valid_Parameter_Are_Given()
        {
            var racer = new Racer(1, "Julio");
            racer.Should().NotBeNull();
            racer.Name.Should().Be("Julio");
            racer.RacerId.Should().Be(1);
        }
    }
}