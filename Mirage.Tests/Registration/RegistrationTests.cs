using Microsoft.Extensions.DependencyInjection;
using Mirage.Tests.BaseClasses;
using System;
using Xunit;

namespace Mirage.Tests.Registration
{
    public class MirageRegistrationTests : TestBaseClass
    {
        protected override Type ObjectType => null;

        [Fact]
        public void CanCallRegisterMirage()
        {
            // Arrange
            var Services = new ServiceCollection();

            // Act
            IServiceCollection Results = Services.RegisterMirage();

            // Assert
            Assert.NotNull(Results);
        }
    }
}