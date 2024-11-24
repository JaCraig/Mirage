using Mirage.Generators.Default;
using Mirage.Tests.BaseClasses;
using System;
using Xunit;

namespace Mirage.Tests.Generators.Default
{
    public class GuidGeneratorTests : TestBaseClass<GuidGeneratorAttribute>
    {
        public GuidGeneratorTests()
        {
            TestObject = new GuidGeneratorAttribute();
        }

        [Fact]
        public void Next()
        {
            var Generator = new GuidGeneratorAttribute();
            var Rand = new Random();
            var Result = Generator.Next(Rand);
            Assert.NotEqual(Guid.Empty, Result);
        }
    }
}