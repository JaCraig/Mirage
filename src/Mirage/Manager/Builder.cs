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

using Mirage.Generators;
using Mirage.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Mirage.Manager
{
    /// <summary>
    /// Builder for getting the generators
    /// </summary>
    public class Builder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Builder"/> class.
        /// </summary>
        /// <param name="generators">The generators.</param>
        public Builder(IEnumerable<IGenerator> generators)
        {
            Generators = new ConcurrentDictionary<Type, IGenerator>();
            foreach (IGenerator Generator in generators.Where(x => !x.GetType().Namespace.ToUpperInvariant().Contains("MIRAGE")))
            {
                Generators.Add(Generator.TypeGenerated, Generator);
            }
            foreach (IGenerator Generator in generators.Where(x => x.GetType().Namespace.ToUpperInvariant().Contains("MIRAGE")))
            {
                if (!Generators.ContainsKey(Generator.TypeGenerated) && Generator.TypeGenerated != typeof(string))
                {
                    Generators.Add(Generator.TypeGenerated, Generator);
                }
            }
            if (!Generators.ContainsKey(typeof(string)))
                Generators.Add(typeof(string), new StringGeneratorAttribute());
        }

        /// <summary>
        /// Gets the generators.
        /// </summary>
        /// <value>The generators.</value>
        public IDictionary<Type, IGenerator> Generators { get; private set; }

        /// <summary>
        /// Gets the generator specified
        /// </summary>
        /// <typeparam name="T">The type to generate</typeparam>
        /// <returns>The generator specified</returns>
        public IGenerator<T> GetGenerator<T>()
        {
            var TypeGenerated = typeof(T);
            IGenerator Generator = null;
            if (Generators.TryGetValue(TypeGenerated, out Generator))
                return Generator as IGenerator<T>;
            var TypeGeneratedInfo = TypeGenerated.GetTypeInfo();
            if (TypeGeneratedInfo.IsEnum)
                return new EnumGenerator<T>();
            if (TypeGeneratedInfo.IsClass)
                return new ClassGenerator<T>();
            return null;
        }

        /// <summary>
        /// Gets the generator specified
        /// </summary>
        /// <param name="classType">Type of the class.</param>
        /// <returns>The generator specified</returns>
        public IGenerator GetGenerator(Type classType)
        {
            IGenerator Generator = null;
            if (Generators.TryGetValue(classType, out Generator))
                return Generator;
            var TypeGeneratedInfo = classType.GetTypeInfo();
            if (TypeGeneratedInfo.IsEnum)
                return new EnumGeneratorAttribute(classType);
            if (TypeGeneratedInfo.IsClass)
                return new ClassGeneratorAttribute(classType);
            return null;
        }
    }
}