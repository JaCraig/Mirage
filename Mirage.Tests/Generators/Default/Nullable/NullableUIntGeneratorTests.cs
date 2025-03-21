﻿using BigBook;
using Mirage.Generators.Default.Nullable;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators.Default.Nullable
{
    public class NullableUIntGeneratorTests : TestBaseClass<NullableUIntGeneratorAttribute>
    {
        public NullableUIntGeneratorTests()
        {
            TestObject = new NullableUIntGeneratorAttribute();
        }

        [Fact]
        public void Next()
        {
            var Generator = new NullableUIntGeneratorAttribute();
            var Rand = new Random();
            Assert.Contains(true, 100.Times(_ => Generator.Next(Rand).HasValue));
            Assert.Contains(false, 100.Times(_ => Generator.Next(Rand).HasValue));
            for (uint x = 0; x < 100; ++x)
            {
                var Value = Generator.Next(Rand);
                if (Value.HasValue)
                    Assert.InRange(Value.Value, uint.MinValue, uint.MaxValue);
            }
        }
    }
}