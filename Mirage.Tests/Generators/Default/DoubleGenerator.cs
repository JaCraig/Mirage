using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class DoubleGenerator : TestBaseClass<DoubleGeneratorAttribute>
    {
        public DoubleGenerator()
        {
            TestObject = new DoubleGeneratorAttribute(0, 1);
        }

        [Fact]
        public void Next()
        {
            var Generator = new DoubleGeneratorAttribute(0, 1);
            Assert.InRange(Generator.Next(new Random()), 0, 1);
            Assert.InRange(Generator.Next(new Random(), 1.05d, 1.1d), 1.05d, 1.1d);
        }
    }
}