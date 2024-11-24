using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using System;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class TimeSpanGeneratorTests : TestBaseClass<TimeSpanGenerator>
    {
        public TimeSpanGeneratorTests()
        {
            TestObject = new TimeSpanGenerator();
        }

        [Fact]
        public void Next()
        {
            var Generator = new TimeSpanGenerator();
            Assert.InRange(Generator.Next(new Random()), TimeSpan.MinValue, TimeSpan.MaxValue);
            Assert.InRange(Generator.Next(new Random(), new TimeSpan(10, 1, 1), new TimeSpan(12, 2, 3)), new TimeSpan(10, 1, 1), new TimeSpan(12, 2, 3));
        }
    }
}