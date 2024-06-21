using Mirage.Generators.Default;
using Mirage.Tests.BaseClasses;
using System.Collections.Generic;
using Xunit;

namespace Mirage.Tests.Generators.Default
{
    public class ClassListGeneratorTests : TestBaseClass<ClassListGenerator<TestListClass, string>>
    {
        public ClassListGeneratorTests()
        {
            _Generator = new ClassListGenerator<TestListClass, string>();
            TestObject = new ClassListGenerator<TestListClass, string>();
        }

        private readonly ClassListGenerator<TestListClass, string> _Generator;

        [Fact]
        public void CanGenerateRandomClass()
        {
            // Arrange
            var Rand = new Random();

            // Act
            TestListClass Result = _Generator.Next(Rand);

            // Assert
            Assert.NotNull(Result);
            _ = Assert.IsAssignableFrom<IList<string>>(Result);
        }

        [Fact]
        public void CanGenerateRandomClassWithMinMax()
        {
            // Arrange
            var Rand = new Random();
            var Min = new TestListClass();
            var Max = new TestListClass();

            // Act
            TestListClass Result = _Generator.Next(Rand, Min, Max);

            // Assert
            Assert.NotNull(Result);
            _ = Assert.IsAssignableFrom<IList<string>>(Result);
        }

        [Fact]
        public void CanGenerateRandomClassWithPreviouslySeen()
        {
            // Arrange
            var Rand = new Random();
            var PreviouslySeen = new List<object>();

            // Act
            var Result = _Generator.NextObj(Rand, PreviouslySeen);

            // Assert
            Assert.NotNull(Result);
            _ = Assert.IsAssignableFrom<IList<string>>(Result);
        }
    }
}