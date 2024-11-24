using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class DecimalGenerator : TestBaseClass<DecimalGeneratorAttribute>
    {
        public DecimalGenerator()
        {
            TestObject = new DecimalGeneratorAttribute(0, 1);
        }

        [Fact]
        public void Next()
        {
            var Generator = new DecimalGeneratorAttribute(0, 1);
            Assert.InRange(Generator.Next(new Random()), 0, 1);
            Assert.InRange(Generator.Next(new Random(), 1.05m, 1.1m), 1.05m, 1.1m);
        }
    }
}