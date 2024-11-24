using Mirage.Generators.ContactInfo;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators.ContactInfo
{
    public class CountryAttributeTests : TestBaseClass<CountryAttribute>
    {
        public CountryAttributeTests()
        {
            _testClass = new CountryAttribute();
        }

        private readonly CountryAttribute _testClass;

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
            var instance = new CountryAttribute();

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