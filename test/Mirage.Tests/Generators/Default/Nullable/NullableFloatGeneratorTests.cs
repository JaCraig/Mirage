using BigBook;
using Mirage.Generators.Default.Nullable;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators.Default.Nullable
{
    public class NullableFloatGeneratorTests : TestBaseClass<NullableFloatGeneratorAttribute>
    {
        public NullableFloatGeneratorTests()
        {
            TestObject = new NullableFloatGeneratorAttribute();
        }

        [Fact]
        public void Next()
        {
            var Generator = new NullableFloatGeneratorAttribute();
            var Rand = new Random();
            Assert.Contains(true, 100.Times(_ => Generator.Next(Rand).HasValue));
            Assert.Contains(false, 100.Times(_ => Generator.Next(Rand).HasValue));
            for (int x = 0; x < 100; ++x)
            {
                var Value = Generator.Next(Rand);
                if (Value.HasValue)
                    Assert.InRange(Value.Value, float.MinValue, float.MaxValue);
            }
        }
    }
}