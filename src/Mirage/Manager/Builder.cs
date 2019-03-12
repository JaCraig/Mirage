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

using BigBook;
using Mirage.Generators;
using Mirage.Generators.Default;
using Mirage.Interfaces;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            foreach (IGenerator Generator in generators.Where(x => !(x.GetType().Namespace.IndexOf("MIRAGE", StringComparison.InvariantCultureIgnoreCase) >= 0)))
            {
                Generators.Add(Generator.TypeGenerated, Generator);
            }
            foreach (IGenerator Generator in generators.Where(x => x.Default))
            {
                if (!Generators.ContainsKey(Generator.TypeGenerated))
                {
                    Generators.Add(Generator.TypeGenerated, Generator);
                }
            }
        }

        /// <summary>
        /// Gets the generators.
        /// </summary>
        /// <value>The generators.</value>
        public IDictionary<Type, IGenerator> Generators { get; }

        /// <summary>
        /// Gets the generator specified
        /// </summary>
        /// <typeparam name="T">The type to generate</typeparam>
        /// <returns>The generator specified</returns>
        public IGenerator<T> GetGenerator<T>()
        {
            return GetGenerator(typeof(T)) as IGenerator<T>;
        }

        /// <summary>
        /// Gets the generator specified
        /// </summary>
        /// <param name="classType">Type of the class.</param>
        /// <returns>The generator specified</returns>
        public IGenerator GetGenerator(Type classType)
        {
            if (Generators.TryGetValue(classType, out IGenerator Generator))
                return Generator;
            var TypeGeneratedInfo = classType.GetTypeInfo();
            if (TypeGeneratedInfo.IsEnum)
                return new EnumGeneratorAttribute(classType);
            if (TypeGeneratedInfo.IsArray)
                return new ArrayGeneratorAttribute(classType.GetElementType(), 1, 100);
            if (TypeGeneratedInfo.GetInterfaces().Any(x => x == typeof(IDictionary)))
                return new DictionaryGeneratorAttribute(classType.GetGenericArguments()[0], classType.GetGenericArguments()[1], 1, 100);
            if (TypeGeneratedInfo.GetInterfaces().Any(x => x == typeof(IList)))
                return new ListGeneratorAttribute(classType.GetGenericArguments()[0], 1, 100);
            if (TypeGeneratedInfo.GetInterfaces().Any(x => x == typeof(IEnumerable)))
                return new IEnumerableGeneratorAttribute(classType, 1, 100);
            if (TypeGeneratedInfo.IsClass)
                return new ClassGeneratorAttribute(classType);
            return null;
        }
    }
}