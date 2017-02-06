using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using System;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class DateTimeGeneratorTests : TestingDirectoryFixture
    {
        [Fact]
        public void Next()
        {
            var Generator = new DateTimeGenerator();
            Assert.InRange(Generator.Next(new Random()), DateTime.MinValue, DateTime.MaxValue);
            Assert.InRange(Generator.Next(new Random(), new DateTime(1900, 1, 1), new DateTime(2000, 1, 1)), new DateTime(1900, 1, 1), new DateTime(2000, 1, 1));
        }
    }
}