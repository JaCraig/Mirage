using BigBook;
using Mirage.Generators.Nullable;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators.Nullable
{
    public class NullableBoolGenerator : TestingDirectoryFixture
    {
        [Fact]
        public void Next()
        {
            var Generator = new NullableBoolGeneratorAttribute();
            var Rand = new Random();
            Assert.Contains(true, 100.Times(_ => Generator.Next(Rand).HasValue));
            Assert.Contains(false, 100.Times(_ => Generator.Next(Rand).HasValue));
            Assert.Contains(true, 100.Times(_ => Generator.Next(Rand)));
            Assert.Contains(false, 100.Times(_ => Generator.Next(Rand)));
        }
    }
}