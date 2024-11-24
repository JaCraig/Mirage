using BigBook;
using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class BoolGenerator : TestBaseClass<BoolGeneratorAttribute>
    {
        public BoolGenerator()
        {
            TestObject = new BoolGeneratorAttribute();
        }

        [Fact]
        public void Next()
        {
            var Generator = new BoolGeneratorAttribute();
            var Rand = new Random();
            Assert.Contains(true, 100.Times(_ => Generator.Next(Rand)));
            Assert.Contains(false, 100.Times(_ => Generator.Next(Rand)));
        }
    }
}