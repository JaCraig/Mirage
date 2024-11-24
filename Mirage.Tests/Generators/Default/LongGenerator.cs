using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class LongGenerator : TestBaseClass<LongGeneratorAttribute>
    {
        public LongGenerator()
        {
            TestObject = new LongGeneratorAttribute(0, long.MaxValue);
        }

        [Fact]
        public void Next()
        {
            var Generator = new LongGeneratorAttribute(0, long.MaxValue);
            Assert.InRange(Generator.Next(new Random()), 0, long.MaxValue);
            Assert.InRange(Generator.Next(new Random(), 10, 300), 10, 300);
        }
    }
}