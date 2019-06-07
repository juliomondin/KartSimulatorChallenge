using Domain.Classes;
using FluentAssertions;
using KartSimulator.Infrastructure;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace KartSimulatorTests.Infrastructure
{
    public class RepositoryTests
    {
        private readonly IResultGenerator<Lap> _mock = Substitute.For<IResultGenerator<Lap>>();

        [Fact]
        public void Constructor_Test_When_Dependency_Injection_Failed()
        {
            Assert.Throws<ArgumentNullException>(() => new Repository<Lap>(null));
        }

        [Fact]
        public void GetAll_Returns_What_It_Gets_Successfully()
        {
            var mockReturn = new List<Lap>();
            _mock.GetAllLaps().Returns(mockReturn);
            var repository = new Repository<Lap>(_mock);
            repository.GetAll().Should().AllBeEquivalentTo(mockReturn);
        }

        [Fact]
        public void Find_Returns_What_It_Gets_Successfully()
        {
            var mockReturn = new Lap("12:01:12","1","test","1","1:11.111","1");
            _mock.FindLap(1).Returns(mockReturn);
            var repository = new Repository<Lap>(_mock);
            repository.Find(1).Should().Be(mockReturn);
        }
    }
}