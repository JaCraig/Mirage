using Mirage.Generators;
using Mirage.Generators.Default;
using Mirage.Generators.String;
using Mirage.Tests.BaseClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Valkyrie;
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

        [StringGenerator(100)]
        [Contains(']')]
        public string TestString { get; set; }
    }

    public class RandomTests : TestBaseClass<Random>
    {
        public RandomTests()
        {
            TestObject = new Random(1231415);
        }

        [Fact]
        public void CircularReferenceClassGenerator()
        {
            var Rand = new Random(1231415);
            SelfReferenceClass1 Item = Rand.Next<SelfReferenceClass1>();
            Assert.NotNull(Item.Other);
            Assert.Same(Item, Item.Other.Other);
            Assert.NotSame(Item.Other, Item.Other2);
        }

        [Fact]
        public void ClassGenerator()
        {
            var Rand = new Random(1231415);
            RandomTestClass Item = Rand.Next<RandomTestClass>();
            Assert.Equal(-82, Item.A);
            Assert.Equal("Lorem ipsum dolor sit amet. ", Item.B);
            Assert.Equal("]w@&BJUzH`W$;oz'Rw7Qaf+l53!$Kg-QX5vr1*JKfPkn_`rSHJrQYZktkRn/IQO^S&I%v'sGLih0x;,S>LZ!sZv{G!&]9;\"5!-:X", Item.TestString);
            Assert.Equal(Math.Round(0.9043f, 4), Math.Round(Item.C, 4));
            Assert.InRange(Item.D, 1, 100);
        }

        [Fact]
        public void IEnumerableTests()
        {
            var Rand = new Random(1231415);
            TestListClass Result = Rand.Next<TestListClass>();
            Assert.Equal(9, Result.Count());
            Assert.Equal("u&DPH\\-Vu=", Result[0]);
            Assert.Equal("x0YnH>KT4W", Result[1]);
            Assert.Equal(",;jFdF4Cz2", Result[2]);
            Assert.Equal("Ui?Ioj7P1k", Result[3]);
            Assert.Equal(".-+2\"}_\\UG", Result[4]);
            Assert.Equal("!eq yY9|i!", Result[5]);
            Assert.Equal("GhYbf/o0}\\", Result[6]);
            Assert.Equal("'yBFH}0WDe", Result[7]);
            Assert.Equal("dVkR0mv>M6", Result[8]);
        }

        [Fact]
        public void Next()
        {
            var Random = new Random();
            _ = Random.Next<bool>();
            _ = Random.Next<byte>();
            _ = Random.Next<char>();
            _ = Random.Next<decimal>();
            _ = Random.Next<double>();
            _ = Random.Next<float>();
            _ = Random.Next<int>();
            _ = Random.Next<long>();
            _ = Random.Next<sbyte>();
            _ = Random.Next<short>();
            _ = Random.Next<uint>();
            _ = Random.Next<ulong>();
            _ = Random.Next<ushort>();
            _ = Random.Next<DateTime>();
            _ = Random.Next<TimeSpan>();
            _ = Random.Next<string>();
            _ = Random.Next<byte[]>();
            _ = Random.Next<Guid>();
            _ = Random.Next<bool?>();
            _ = Random.Next<byte?>();
            _ = Random.Next<char?>();
            _ = Random.Next<DateTime?>();
            _ = Random.Next<decimal?>();
            _ = Random.Next<double?>();
            _ = Random.Next<float?>();
            _ = Random.Next<Guid?>();
            _ = Random.Next<int?>();
            _ = Random.Next<long?>();
            _ = Random.Next<sbyte?>();
            _ = Random.Next<short?>();
            _ = Random.Next<TimeSpan?>();
            _ = Random.Next<uint?>();
            _ = Random.Next<ulong?>();
            _ = Random.Next<ushort?>();
        }

        [Fact]
        public void Next2()
        {
            var Random = new Random();
            _ = Random.Next<bool>(false, true);
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
            _ = Random.Next<bool?>(false, true);
            _ = Random.Next<byte?>(0, 255);
            _ = Random.Next<char?>(char.MinValue, char.MaxValue);
            _ = Random.Next<DateTime?>(new DateTime(1900, 1, 1), new DateTime(2000, 1, 1));
            _ = Random.Next<decimal?>(-1, 1);
            _ = Random.Next<double?>(-1, 1);
            _ = Random.Next<float?>(-1, 1);
            _ = Random.Next<Guid?>(Guid.NewGuid(), Guid.NewGuid());
            _ = Random.Next<int?>(1, 29);
            _ = Random.Next<long?>(1, 29);
            _ = Random.Next<sbyte?>(1, 29);
            _ = Random.Next<short?>(1, 29);
            _ = Random.Next<TimeSpan?>(TimeSpan.MinValue, TimeSpan.MaxValue);
            _ = Random.Next<uint?>(1, 29);
            _ = Random.Next<ulong?>(1, 29);
            _ = Random.Next<ushort?>(1, 29);
        }

        [Fact]
        public void NextGenerateArray()
        {
            var Random = new Random(1234);
            var Result = Random.Next<int[]>();
            Assert.Equal(40, Result.Length);
            Assert.Equal(new int[] { 1700375256,-776517466,1918723096,-689617024,1927487866,1322815094,
89038738,618295176,-805053188,-354859800,1584585456,1920991542,-152410590,1062719026,812406020,367059544,
-1827437004,-1795133540,-1608823114,1198949030,401736470,189343436,-1608721718,596967862,-1227849308,
1649198610,-928389186,-456759040,1695845860,1084297792,-11400240,77938428,1828338310,125064976,-1107774690,
-1230773970,-641900650,721543750,543116448,1468561234}, Result);
        }

        [Fact]
        public void NextGenerateDictionary()
        {
            var Random = new Random(1234);
            Dictionary<string, int> Result = Random.Next<Dictionary<string, int>>();
            Assert.Equal(40, Result.Keys.Count);
            Assert.Equal(new string[] { "t>x?ykP\\=G","qyKf`W''+i","WS+\\4s:Etf","NPwQ64@^Zo",
"S-vPO0ja=h","sIs:kA2<+&","Q+fTv@\"wOL","6FJ:5IZY,$","(V'+q%[\\ds","!$ST=GEAX.","-p2oRL|X$A","dV0'{x$[`p",
"cC3YJ2qtzk","$9!|t6D5VD","'\"XB/HqKWC","Bh^eHh\\VD@","Y([7=JU21d","Tl$<iahoJ!",">E<WH:X:S+","Xko5i|DA$b",
"q_9qmScBye","}j,B\"3i$l#","p;\\&,f{mPk","<Gke.\\,Ihr","T5>k+k_M3U","2@R!pU\"3e'","Vtp.IU}D3C","'@:wLZzox>",
"&NYyXzrisW","Yvb`<^C0BS","l;9mMo%YR5","X18F (:tSM","a3NZh/\\W[l","6iLEPi4jKf","t97^|G];`4","CLZspXj]%>",
"3K|c|lcqt5","qNIkVGzn[@","PAuGIg.WRu","|Ue,SH;Q_/" }, Result.Keys);
            Assert.Equal(new int[] { 888839358,1209436310,-483541996,-187641764,-665815636,1660641810,
-1998371140,1399510598,-823674428,-276738728,569906786,1965444398,-2074956352,909252126,1346393786,
1496143792,244051186,271319124,-929108374,-1187565812,678913494,-1611644038,-718617048,2103926530,
-1116498766,-853546542,1102506616,-827928130,-1041697206,-1540116470,-1591039518,-249048774,-1454478656,
-130811534,593273356,984068946,2014015170,-201588446,-1837143778,220572294}, Result.Values);
        }

        [Fact]
        public void NextGenerateIEnumerable()
        {
            var Random = new Random(1234);
            IEnumerable<int> Result = Random.Next<IEnumerable<int>>();
            Assert.Equal(40, Result.Count());
            Assert.Equal(new int[] { 1700375256,-776517466,1918723096,-689617024,1927487866,1322815094,
89038738,618295176,-805053188,-354859800,1584585456,1920991542,-152410590,1062719026,812406020,367059544,
-1827437004,-1795133540,-1608823114,1198949030,401736470,189343436,-1608721718,596967862,-1227849308,
1649198610,-928389186,-456759040,1695845860,1084297792,-11400240,77938428,1828338310,125064976,-1107774690,
-1230773970,-641900650,721543750,543116448,1468561234}, Result);
        }

        [Fact]
        public void NextGenerateList()
        {
            var Random = new Random(1234);
            List<int> Result = Random.Next<List<int>>();
            Assert.Equal(40, Result.Count);
            Assert.Equal(new int[] { 1700375256,-776517466,1918723096,-689617024,1927487866,1322815094,
89038738,618295176,-805053188,-354859800,1584585456,1920991542,-152410590,1062719026,812406020,367059544,
-1827437004,-1795133540,-1608823114,1198949030,401736470,189343436,-1608721718,596967862,-1227849308,
1649198610,-928389186,-456759040,1695845860,1084297792,-11400240,77938428,1828338310,125064976,-1107774690,
-1230773970,-641900650,721543750,543116448,1468561234}.ToList(), Result);
        }

        [Fact]
        public void NextIEnumerable()
        {
            var Random = new Random();
            Assert.InRange(Random.Next<int>(new int[] { 1, 2, 3, 4, 5 }), 1, 5);
        }

        [Fact]
        public void NextListNotUnique()
        {
            var Random = new Random(1234);
            IEnumerable<int> Result = Random.Next<int>(new int[] { 1, 2, 3, 4, 5 }, 5);
            Assert.Equal(5, Result.Count());
            Assert.Equal(2, Result.Distinct().Count());
            Assert.True(Result.All(x => x is <= 5 and >= 1));
            Assert.Equal(2, Result.ElementAt(0));
            Assert.Equal(5, Result.ElementAt(1));
            Assert.Equal(2, Result.ElementAt(2));
            Assert.Equal(5, Result.ElementAt(3));
            Assert.Equal(2, Result.ElementAt(4));
        }

        [Fact]
        public void NextListUnique()
        {
            var Random = new Random(1234);
            IEnumerable<int> Result = Random.Next<int>(new int[] { 1, 2, 3, 4, 5 }, 3, true);
            Assert.Equal(3, Result.Count());
            Assert.Equal(3, Result.Distinct().Count());
            Assert.True(Result.All(x => x is <= 5 and >= 1));
            Assert.Equal(2, Result.ElementAt(0));
            Assert.Equal(5, Result.ElementAt(1));
            Assert.Equal(3, Result.ElementAt(2));
        }

        [Fact]
        public void NextNormal()
        {
            var Random = new Random(1234);
            (var X, var Y) = Random.NextNormal(0.123, 2.41);
            Assert.Equal(2.7153771346516837, X);
            Assert.Equal(-1.8644900545154903, Y);
        }

        [Fact]
        public void NextStringTest()
        {
            var Rand = new Random();
            Assert.NotNull(Rand.Next<string>());
        }

        [Fact]
        public void NextWeightedListNotUnique()
        {
            var Random = new Random(1234);
            IEnumerable<int> Result = Random.Next<int>(new int[] { 1, 2, 3, 4, 5 }, new decimal[] { .35m, .25m, .15m, .15m, .1m }, 5);
            Assert.Equal(5, Result.Count());
            Assert.Equal(4, Result.Distinct().Count());
            Assert.True(Result.All(x => x is <= 5 and >= 1));
            Assert.Equal(2, Result.ElementAt(0));
            Assert.Equal(4, Result.ElementAt(1));
            Assert.Equal(1, Result.ElementAt(2));
            Assert.Equal(5, Result.ElementAt(3));
            Assert.Equal(1, Result.ElementAt(4));
        }

        [Fact]
        public void NextWeightedListUnique()
        {
            var Random = new Random(1234);
            IEnumerable<int> Result = Random.Next<int>(new int[] { 1, 2, 3, 4, 5 }, new decimal[] { .35m, .25m, .15m, .15m, .1m }, 3, true);
            Assert.Equal(3, Result.Count());
            Assert.Equal(3, Result.Distinct().Count());
            Assert.True(Result.All(x => x is <= 5 and >= 1));
            Assert.Equal(2, Result.ElementAt(0));
            Assert.Equal(4, Result.ElementAt(1));
            Assert.Equal(1, Result.ElementAt(2));
        }

        [Fact]
        public void ProblemStrings()
        {
            var Rand = new Random(1231415);
            var Result = new ProblemStringsAttribute().Next(Rand);
            Assert.Equal("0,,0", Result);
        }

        [Fact]
        public void Shuffle()
        {
            var Rand = new Random(1231415);
            Assert.Equal(new int[] { 3, 1, 4, 5, 2 }, Rand.Shuffle(new int[] { 1, 2, 3, 4, 5 }));
        }

        [Fact]
        public void StructGenerator()
        {
            var Rand = new Random(1231415);
            CancellationToken Item = Rand.Next<CancellationToken>();
            Assert.False(Item.CanBeCanceled);
            Assert.False(Item.IsCancellationRequested);
        }

        [Fact]
        public void ThreadSafeNext() => Parallel.For(0, 100, _ => Assert.InRange(new Random().ThreadSafeNext(-20, 20), -20, 20));
    }

    public class SelfReferenceClass1
    {
        [ClassGenerator(typeof(SelfReferenceClass2))]
        public SelfReferenceClass2 Other { get; set; }

        [ClassGenerator(typeof(SelfReferenceClass2))]
        public SelfReferenceClass2 Other2 { get; set; }
    }

    public class SelfReferenceClass2
    {
        [ClassGenerator(typeof(SelfReferenceClass1))]
        public SelfReferenceClass1 Other { get; set; }
    }

    public class TestListClass : IList<string>
    {
        private readonly List<string> Items = new();
        public int Count => Items.Count;
        public bool IsReadOnly => false;

        public string this[int index]
        {
            get => Items[index];
            set => Items[index] = value;
        }

        public void Add(string item) => Items.Add(item);

        public void Clear() => Items.Clear();

        public bool Contains(string item) => Items.Contains(item);

        public void CopyTo(string[] array, int arrayIndex) => Items.CopyTo(array, arrayIndex);

        public IEnumerator<string> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

        public int IndexOf(string item) => Items.IndexOf(item);

        public void Insert(int index, string item) => Items.Insert(index, item);

        public bool Remove(string item) => Items.Remove(item);

        public void RemoveAt(int index) => Items.RemoveAt(index);
    }
}