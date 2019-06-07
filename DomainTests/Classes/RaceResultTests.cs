using System;
using System.Collections.Generic;
using System.Text;
using Domain.Classes;
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
    }
}
