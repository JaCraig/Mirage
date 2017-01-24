using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class TimeSpanGenerator : TestingDirectoryFixture
    {
        [Fact]
        public void Next()
        {
            var Generator = new TimeSpanGeneratorAttribute();
            Assert.InRange(Generator.Next(new Random()), TimeSpan.MinValue, TimeSpan.MaxValue);
            Assert.InRange(Generator.Next(new Random(), new TimeSpan(10, 1, 1), new TimeSpan(12, 2, 3)), new TimeSpan(10, 1, 1), new TimeSpan(12, 2, 3));
        }
    }
}