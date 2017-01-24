using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class FloatGenerator : TestingDirectoryFixture
    {
        [Fact]
        public void Next()
        {
            var Generator = new FloatGeneratorAttribute(0, 1);
            Assert.InRange(Generator.Next(new Random()), 0, 1);
            Assert.InRange(Generator.Next(new Random(), 1.05f, 1.1f), 1.05f, 1.1f);
        }
    }
}