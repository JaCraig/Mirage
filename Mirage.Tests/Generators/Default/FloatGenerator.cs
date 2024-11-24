using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class FloatGenerator : TestBaseClass<FloatGeneratorAttribute>
    {
        public FloatGenerator()
        {
            TestObject = new FloatGeneratorAttribute(0, 1);
        }

        [Fact]
        public void Next()
        {
            var Generator = new FloatGeneratorAttribute(0, 1);
            Assert.InRange(Generator.Next(new Random()), 0, 1);
            Assert.InRange(Generator.Next(new Random(), 1.05f, 1.1f), 1.05f, 1.1f);
        }
    }
}