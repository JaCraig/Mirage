using Mirage.Tests.BaseClasses;
using BigBook;
using Mirage.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class BoolGenerator : TestingDirectoryFixture
    {
        [Fact]
        public void Next()
        {
            var Generator = new BoolGeneratorAttribute();
            var Rand = new Random();
            Assert.Contains(true, 100.Times(x => Generator.Next(Rand)));
            Assert.Contains(false, 100.Times(x => Generator.Next(Rand)));
        }
    }
}