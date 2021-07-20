using BigBook;
using Mirage.Generators.Default.Nullable;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators.Default.Nullable
{
    public class NullableIntGeneratorTests : TestBaseClass<NullableIntGeneratorAttribute>
    {
        public NullableIntGeneratorTests()
        {
            TestObject = new NullableIntGeneratorAttribute();
        }

        [Fact]
        public void Next()
        {
            var Generator = new NullableIntGeneratorAttribute();
            var Rand = new Random();
            Assert.Contains(true, 100.Times(_ => Generator.Next(Rand).HasValue));
            Assert.Contains(false, 100.Times(_ => Generator.Next(Rand).HasValue));
            for (int x = 0; x < 100; ++x)
            {
                var Value = Generator.Next(Rand);
                if (Value.HasValue)
                    Assert.InRange(Value.Value, int.MinValue, int.MaxValue);
            }
        }
    }
}