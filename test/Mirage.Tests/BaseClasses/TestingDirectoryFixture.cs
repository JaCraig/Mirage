using FileCurator.Registration;
using Microsoft.Extensions.DependencyInjection;
using Mirage.Registration;
using System;
using System.Collections.Generic;
using System.Reflection;
using Valkyrie.Registration;
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
                Canister.Builder.CreateContainer(new List<ServiceDescriptor>())
                       .AddAssembly(typeof(TestingDirectoryFixture).GetTypeInfo().Assembly)
                       .RegisterMirage()
                       .RegisterFileCurator()
                       .RegisterValkyrie()
                       .Build();
            }
        }

        public void Dispose()
        {
        }
    }
}