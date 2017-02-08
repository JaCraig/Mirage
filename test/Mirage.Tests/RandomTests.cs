using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Mirage.Tests
{
    public class RandomTestClass
    {
        [IntGenerator(-100, 100)]
        public int A { get; set; }

        [LoremIpsum]
        public string B { get; set; }

        [FloatGenerator(0, 1)]
        public float C { get; set; }

        [IntGenerator(1, 100)]
        public int D { get; set; }
    }

    public class RandomTests : TestingDirectoryFixture
    {
        [Fact]
        public void ClassGenerator()
        {
            var Rand = new Random(1231415);
            var Item = Rand.Next<RandomTestClass>();
            Assert.Equal(-82, Item.A);
            Assert.Equal("Lorem ipsum dolor sit amet. ", Item.B);
            Assert.Equal(System.Math.Round(0.9043f, 4), System.Math.Round(Item.C, 4));
            Assert.InRange(Item.D, 1, 100);
        }

        [Fact]
        public void Next()
        {
            var Random = new Random();
            Random.Next<bool>();
            Random.Next<byte>();
            Random.Next<char>();
            Random.Next<decimal>();
            Random.Next<double>();
            Random.Next<float>();
            Random.Next<int>();
            Random.Next<long>();
            Random.Next<sbyte>();
            Random.Next<short>();
            Random.Next<uint>();
            Random.Next<ulong>();
            Random.Next<ushort>();
            Random.Next<DateTime>();
            Random.Next<TimeSpan>();
            Random.Next<string>();
            Random.Next<byte[]>();
            Random.Next<Guid>();
        }

        [Fact]
        public void Next2()
        {
            var Random = new Random();
            Random.Next<bool>(false, true);
            Assert.InRange(Random.Next<byte>(1, 29), 1, 29);
            Assert.InRange(Random.Next<char>('a', 'z'), 'a', 'z');
            Assert.InRange(Random.Next<decimal>(1.0m, 102.1m), 1, 102.1m);
            Assert.InRange(Random.Next<double>(1.0d, 102.1d), 1, 102.1d);
            Assert.InRange(Random.Next<float>(1, 102.1f), 1, 102.1f);
            Assert.InRange(Random.Next<int>(1, 29), 1, 29);
            Assert.InRange(Random.Next<long>(1, 29), 1, 29);
            Assert.InRange(Random.Next<sbyte>(1, 29), 1, 29);
            Assert.InRange(Random.Next<short>(1, 29), 1, 29);
            Assert.InRange(Random.Next<uint>(1, 29), (uint)1, (uint)29);
            Assert.InRange(Random.Next<ulong>(1, 29), (ulong)1, (ulong)29);
            Assert.InRange(Random.Next<ushort>(1, 29), (ushort)1, (ushort)29);
            Assert.InRange(Random.Next<DateTime>(new DateTime(1900, 1, 1), new DateTime(2000, 1, 1)), new DateTime(1900, 1, 1), new DateTime(2000, 1, 1));
            Assert.Equal(10, Random.Next<string>().Length);
            Assert.InRange(Random.Next<byte[]>().Length, 1, 100);
        }

        [Fact]
        public void NextIEnumerable()
        {
            var Random = new Random();
            Assert.InRange(Random.Next<int>(new int[] { 1, 2, 3, 4, 5 }), 1, 5);
        }

        [Fact]
        public void NextStringTest()
        {
            var Rand = new Random();
            Assert.NotNull(Rand.Next<string>());
        }

        [Fact]
        public void Shuffle()
        {
            var Rand = new Random(1231415);
            Assert.Equal(new int[] { 3, 1, 4, 5, 2 }, Rand.Shuffle(new int[] { 1, 2, 3, 4, 5 }));
        }

        [Fact]
        public void ThreadSafeNext()
        {
            Parallel.For(0, 100, x =>
            {
                Assert.InRange(new Random().ThreadSafeNext(-20, 20), -20, 20);
            });
        }
    }
}