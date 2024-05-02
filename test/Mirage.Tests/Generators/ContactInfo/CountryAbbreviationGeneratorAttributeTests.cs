using Mirage.Generators.ContactInfo;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators.ContactInfo
{
    public class CountryAbbreviationAttributeTests : TestBaseClass<CountryAbbreviationAttribute>
    {
        public CountryAbbreviationAttributeTests()
        {
            _testClass = new CountryAbbreviationAttribute();
        }

        private readonly CountryAbbreviationAttribute _testClass;

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
            Assert.Equal(2, Results.Length);
        }

        [Fact]
        public void CanCallNextWithNullRand() => _testClass.Next(default);

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new CountryAbbreviationAttribute();

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