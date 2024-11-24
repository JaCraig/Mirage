using Mirage.Generators.ContactInfo;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators.ContactInfo
{
    public class ProfileImageAttributeTests : TestBaseClass<ProfileImageAttribute>
    {
        public ProfileImageAttributeTests()
        {
            _testClass = new ProfileImageAttribute();
        }

        private readonly ProfileImageAttribute _testClass;

        [Fact]
        public void CanCallNext()
        {
            // Arrange
            var rand = new Random();

            // Act
            var Result = _testClass.Next(rand);

            // Assert
            Assert.NotNull(Result);
            Assert.NotEmpty(Result);
        }

        [Fact]
        public void CanCallNextWithNullRand() => _testClass.Next(default);

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ProfileImageAttribute();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanGetDefault()
        {
            // Assert
            var Result = Assert.IsType<bool>(_testClass.Default);

            Assert.False(Result);
        }
    }
}