using System;
using System.Collections.Generic;
using System.Text;
using Domain.Classes;
using FluentAssertions;
using Xunit;

namespace DomainTests.Classes
{
    public class DriverTests
    {
        [Fact]
        public void Constructor_Returns_Exception_When_Null_Name()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Driver(0, "Julio"));
        }

        [Fact]
        public void Constructor_Returns_Exception_When_DriverId_Is_0()
        {
            Assert.Throws<ArgumentNullException>(() => new Driver(1, null));
        }

        [Fact]
        public void Constructor_Returns_Driver_When_Valid_Parameter_Are_Given()
        {
            var driver = new Driver(1, "Julio");
            driver.Should().NotBeNull();
            driver.Name.Should().Be("Julio");
            driver.DriverId.Should().Be(1);
        }
    }
}
