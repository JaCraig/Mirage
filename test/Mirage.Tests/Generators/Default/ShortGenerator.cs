using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class ShortGenerator : TestingDirectoryFixture
    {
        [Fact]
        public void Next()
        {
            ShortGeneratorAttribute Generator = new ShortGeneratorAttribute(0, short.MaxValue);
            Assert.InRange(Generator.Next(new Random()), 0, short.MaxValue);
            Assert.InRange(Generator.Next(new Random(), 10, 300), 10, 300);
        }
    }
}