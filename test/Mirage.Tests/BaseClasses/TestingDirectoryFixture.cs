using Microsoft.Extensions.DependencyInjection;
using System;
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
                new ServiceCollection().AddCanisterModules();
            }
        }

        public void Dispose()
        {
        }
    }
}