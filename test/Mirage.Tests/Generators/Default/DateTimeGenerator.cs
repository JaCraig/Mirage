using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class DateTimeGenerator : TestingDirectoryFixture
    {
        [Fact]
        public void Next()
        {
            var Generator = new DateTimeGeneratorAttribute();
            Assert.InRange(Generator.Next(new Random()), DateTime.MinValue, DateTime.MaxValue);
            Assert.InRange(Generator.Next(new Random(), new DateTime(1900, 1, 1), new DateTime(2000, 1, 1)), new DateTime(1900, 1, 1), new DateTime(2000, 1, 1));
        }
    }
}