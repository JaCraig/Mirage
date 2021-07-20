using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class ShortGenerator : TestBaseClass<ShortGeneratorAttribute>
    {
        public ShortGenerator()
        {
            TestObject = new ShortGeneratorAttribute(0, short.MaxValue);
        }

        [Fact]
        public void Next()
        {
            var Generator = new ShortGeneratorAttribute(0, short.MaxValue);
            Assert.InRange(Generator.Next(new Random()), 0, short.MaxValue);
            Assert.InRange(Generator.Next(new Random(), 10, 300), 10, 300);
        }
    }
}