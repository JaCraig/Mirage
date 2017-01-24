using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class DecimalGenerator : TestingDirectoryFixture
    {
        [Fact]
        public void Next()
        {
            var Generator = new DecimalGeneratorAttribute(0, 1);
            Assert.InRange(Generator.Next(new Random()), 0, 1);
            Assert.InRange(Generator.Next(new Random(), 1.05m, 1.1m), 1.05m, 1.1m);
        }
    }
}