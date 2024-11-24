using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using System.Collections.Generic;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class EnumGenerator : TestBaseClass<EnumGeneratorAttribute>
    {
        public EnumGenerator()
        {
            TestObject = new EnumGeneratorAttribute(typeof(MyTest));
        }

        [Fact]
        public void Next()
        {
            var Generator = new EnumGeneratorAttribute(typeof(MyTest));
            Assert.InRange((MyTest)Generator.NextObj(new Random(), new List<object>()), MyTest.Item1, MyTest.Item3);
        }

        public enum MyTest
        {
            Item1,
            Item2,
            Item3
        }
    }
}