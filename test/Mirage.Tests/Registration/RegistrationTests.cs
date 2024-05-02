using Canister.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Mirage.Tests.BaseClasses;
using NSubstitute;
using System;
using Xunit;

namespace Mirage.Tests.Registration
{
    public class MirageRegistrationTests : TestBaseClass
    {
        protected override Type ObjectType => typeof(MirageRegistration);

        [Fact]
        public void CanCallRegisterMirage()
        {
            // Arrange
            ICanisterConfiguration Bootstrapper = Substitute.For<ICanisterConfiguration>();

            // Act
            ICanisterConfiguration Results = Bootstrapper.RegisterMirage();

            // Assert
            Assert.NotNull(Results);
        }
    }
}