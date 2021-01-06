using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Xunit;

namespace Mirage.Tests.BaseClasses
{
    [Collection("DirectoryCollection")]
    public class TestingDirectoryFixture : IDisposable
    {
        public TestingDirectoryFixture()
        {
            if (Canister.Builder.Bootstrapper == null)
            {
                new ServiceCollection().AddCanisterModules(configure => configure
                       .AddAssembly(typeof(TestingDirectoryFixture).GetTypeInfo().Assembly)
                       .RegisterMirage()
                       .RegisterFileCurator()
                       .RegisterValkyrie());
            }
        }

        public void Dispose()
        {
        }
    }
}