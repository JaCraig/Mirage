using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class DoubleGenerator : TestingDirectoryFixture
    {
        [Fact]
        public void Next()
        {
            DoubleGeneratorAttribute Generator = new DoubleGeneratorAttribute(0, 1);
            Assert.InRange(Generator.Next(new Random()), 0, 1);
            Assert.InRange(Generator.Next(new Random(), 1.05d, 1.1d), 1.05d, 1.1d);
        }
    }
}