using Mirage.Generators.Default;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators.Default
{
    public class ByteArrayGeneratorTests : TestBaseClass<ByteArrayGeneratorAttribute>
    {
        public ByteArrayGeneratorTests()
        {
            TestObject = new ByteArrayGeneratorAttribute(1, 100);
        }

        [Fact]
        public void Next()
        {
            var Generator = new ByteArrayGeneratorAttribute(1, 100);
            var Rand = new Random();
            var Result = Generator.Next(Rand);
            Assert.InRange(Result.Length, 1, 100);
        }
    }
}