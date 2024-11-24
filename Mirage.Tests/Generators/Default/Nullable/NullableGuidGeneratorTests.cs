using BigBook;
using Mirage.Generators.Default.Nullable;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators.Default.Nullable
{
    public class NullableGuidGeneratorTests : TestBaseClass<NullableGuidGeneratorAttribute>
    {
        public NullableGuidGeneratorTests()
        {
            TestObject = new NullableGuidGeneratorAttribute();
        }

        [Fact]
        public void Next()
        {
            var Generator = new NullableGuidGeneratorAttribute();
            var Rand = new Random();
            Assert.Contains(true, 100.Times(_ => Generator.Next(Rand).HasValue));
            Assert.Contains(false, 100.Times(_ => Generator.Next(Rand).HasValue));
            for (int x = 0; x < 100; ++x)
            {
                var Value = Generator.Next(Rand);
            }
        }
    }
}