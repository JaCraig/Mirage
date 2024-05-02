using Mirage.Generators.ContactInfo;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators.ContactInfo
{
    public class CountryAbbreviation3CharAttributeTests : TestBaseClass<CountryAbbreviation3CharAttribute>
    {
        public CountryAbbreviation3CharAttributeTests()
        {
            _testClass = new CountryAbbreviation3CharAttribute();
        }

        private readonly CountryAbbreviation3CharAttribute _testClass;

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
            Assert.Equal(3, Results.Length);
        }

        [Fact]
        public void CanCallNextWithNullRand() => _testClass.Next(default);

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new CountryAbbreviation3CharAttribute();

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