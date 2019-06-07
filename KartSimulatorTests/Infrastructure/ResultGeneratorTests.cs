using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using KartSimulator.Infrastructure;
using NSubstitute;
using Xunit;

namespace KartSimulatorTests.Infrastructure
{
    public class ResultGeneratorTests
    {
        private IFileReader _fileReader;
        public ResultGeneratorTests()
        {
            _fileReader = NSubstitute.Substitute.For<IFileReader>();
        }

        [Fact]
        public void Constructor_Throws_Exception_When_Null_Parameter()
        {
            Assert.Throws<ArgumentNullException>(() => new ResultGenerator(null));
        }
        [Fact]
        public void Constructor_When_Valid_Parameter()
        {
            var result = new ResultGenerator(_fileReader);
            result.Should().NotBeNull();
        }

        [Fact]
        public void GetAllLaps_When_Valid_File()
        {
            //arrange
            var mock = new List<string>();
            mock.Add("23:49:08.277      038 – F.MASSA                           1		1:02.852                        44,275");

            _fileReader.GetLines(Arg.Any<string>()).Returns(mock);
            var service = new ResultGenerator(_fileReader);
            //action
            var result = service.GetAllLaps();
            result.First().Driver.Name.Should().Be("F.MASSA");
            //assert 
            result.Should().NotBeNull();
        }

        [Fact]
        public void FindLap_When_Valid_File()
        {
            var mock = new List<string>();
            mock.Add("23:49:08.277      038 – F.MASSA                           1		1:02.852                        44,275");

            _fileReader.GetLines(Arg.Any<string>()).Returns(mock);
            var service = new ResultGenerator(_fileReader);
            var result = service.FindLap(38);
            result.Driver.Name.Should().Be("F.MASSA");
        }



    }
}
