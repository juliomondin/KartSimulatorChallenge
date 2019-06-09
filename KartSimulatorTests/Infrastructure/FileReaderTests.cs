using KartSimulator.Infrastructure;
using System.IO;
using Xunit;

namespace KartSimulatorTests.Infrastructure
{
    public class FileReaderTests
    {
        [Fact]
        public void GetLines_Throws_Exception_When_InvalidFileName()
        {
            Assert.Throws<FileLoadException>(() => (new FileReader()).GetLines("noFileLocation"));
        }

        //[Fact]
        //public void GetLines_Returns_File_When_ValidFileName()
        //{
        //    var result = new FileReader().GetLines(@"FileReader.cs");
        //    result.Should().NotBeNullOrEmpty();
        //}
    }
}