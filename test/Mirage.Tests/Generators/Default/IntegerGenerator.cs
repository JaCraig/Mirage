using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class IntegerGenerator : TestingDirectoryFixture
    {
        [Fact]
        public void Next()
        {
            IntGeneratorAttribute Generator = new IntGeneratorAttribute(0, int.MaxValue);
            Assert.InRange(Generator.Next(new Random()), 0, int.MaxValue);
            Assert.InRange(Generator.Next(new Random(), 10, 300), 10, 300);
        }
    }
}