using BigBook;
using Mirage.Generators.Default.Nullable;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators.Default.Nullable
{
    public class NullableShortGeneratorTests : TestingDirectoryFixture
    {
        [Fact]
        public void Next()
        {
            var Generator = new NullableShortGeneratorAttribute();
            var Rand = new Random();
            Assert.Contains(true, 100.Times(x => Generator.Next(Rand).HasValue));
            Assert.Contains(false, 100.Times(x => Generator.Next(Rand).HasValue));
            for (short x = 0; x < 100; ++x)
            {
                var Value = Generator.Next(Rand);
                if (Value.HasValue)
                    Assert.InRange(Value.Value, short.MinValue, short.MaxValue);
            }
        }
    }
}