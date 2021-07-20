using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class IntegerGenerator : TestBaseClass<IntGeneratorAttribute>
    {
        public IntegerGenerator()
        {
            TestObject = new IntGeneratorAttribute(0, int.MaxValue);
        }

        [Fact]
        public void Next()
        {
            var Generator = new IntGeneratorAttribute(0, int.MaxValue);
            Assert.InRange(Generator.Next(new Random()), 0, int.MaxValue);
            Assert.InRange(Generator.Next(new Random(), 10, 300), 10, 300);
        }
    }
}