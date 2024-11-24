/*
Copyright 2017 James Craig

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using BigBook.Registration;
using Canister.Interfaces;
using Mirage;
using Mirage.Generators;
using Mirage.Generators.Default;
using Mirage.Interfaces;
using Mirage.Manager;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Registration extension methods
    /// </summary>
    public static class MirageRegistration
    {
        /// <summary>
        /// Registers the library with the bootstrapper.
        /// </summary>
        /// <param name="bootstrapper">The bootstrapper.</param>
        /// <returns>The bootstrapper</returns>
        public static ICanisterConfiguration? RegisterMirage(this ICanisterConfiguration? bootstrapper)
        {
            return bootstrapper?.AddAssembly(typeof(MirageRegistration).GetTypeInfo().Assembly)
                               .RegisterBigBookOfDataTypes();
        }

        /// <summary>
        /// Registers the Mirage services with the specified service collection.
        /// </summary>
        /// <param name="services">The service collection to add the services to.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection? RegisterMirage(this IServiceCollection? services)
        {
            if (services.Exists<Builder>())
                return services;
            Services.ServiceCollection = services;
            return services?.AddAllTransient<IGenerator>()
                ?.AddTransient(typeof(EnumGenerator<>))
                .AddTransient(typeof(ClassGenerator<>))
                .AddTransient(typeof(ClassListGenerator<,>))
                .AddTransient(typeof(IEnumerableGenerator<>))
                .AddSingleton<Builder>()
                .AddTransient<Random>()
                .RegisterBigBookOfDataTypes();
        }
    }
}