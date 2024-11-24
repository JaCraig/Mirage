using Mirage.Generators.Names;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators.Names
{
    public class TitleAttributeTests : TestBaseClass<TitleAttribute>
    {
        public TitleAttributeTests()
        {
            _testClass = new TitleAttribute();
        }

        private readonly TitleAttribute _testClass;

        [Fact]
        public void CanCallNext()
        {
            // Arrange
            var rand = new Random();

            // Act
            var Results = _testClass.Next(rand);

            // Assert
            Assert.NotNull(Results);
            Assert.NotEmpty(Results);
        }

        [Fact]
        public void CanCallNextWithNullRand() => _testClass.Next(default);

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new TitleAttribute();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanGetDefault()
        {
            // Assert
            var Results = Assert.IsType<bool>(_testClass.Default);

            Assert.False(Results);
        }
    }
}