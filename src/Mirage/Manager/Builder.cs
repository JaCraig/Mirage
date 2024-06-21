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
            Assembly MirageAssembly = typeof(Builder).Assembly;
            foreach (IGenerator? Generator in generators.Where(x => x.GetType().Assembly != MirageAssembly))
            {
                Generators.Add(Generator.TypeGenerated, Generator);
            }
            foreach (IGenerator? Generator in generators.Where(x => x.Default))
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
        public IGenerator<T>? GetGenerator<T>() => GetGenerator(typeof(T)) as IGenerator<T>;

        /// <summary>
        /// Gets the generator specified
        /// </summary>
        /// <param name="classType">Type of the class.</param>
        /// <returns>The generator specified</returns>
        public IGenerator? GetGenerator(Type classType)
        {
            if (classType is null)
                return null;
            if (Generators.TryGetValue(classType, out IGenerator? Generator))
                return Generator;
            TypeInfo TypeGeneratedInfo = classType.GetTypeInfo();
            if (TypeGeneratedInfo.IsEnum)
                return new EnumGeneratorAttribute(classType);
            if (TypeGeneratedInfo.IsArray)
                return new ArrayGeneratorAttribute(classType.GetElementType(), 1, 100);
            _ = TypeGeneratedInfo.GetInterfaces();

            if (IsDictionary(TypeGeneratedInfo, out Type? Arg1, out Type? Arg2))
                return new DictionaryGeneratorAttribute(Arg1, Arg2, 1, 100);
            if (IsList(TypeGeneratedInfo, out Type? ListArg))
                return new ListGeneratorAttribute(ListArg, 1, 100);
            if (IsIEnumerable(TypeGeneratedInfo, out Type? IEnumerableArg))
                return new IEnumerableGeneratorAttribute(IEnumerableArg, 1, 100);

            if (TypeGeneratedInfo.IsClass && TypeGeneratedInfo.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IList<>)))
                return (IGenerator?)new ClassListGeneratorAttribute(classType);

            if (TypeGeneratedInfo.IsClass || (TypeGeneratedInfo.IsValueType && !TypeGeneratedInfo.IsPrimitive))
                return (IGenerator?)new ClassGeneratorAttribute(classType);

            return null;
        }

        /// <summary>
        /// Determines if the class is a dictionary
        /// </summary>
        /// <param name="classType">Type of the class.</param>
        /// <param name="argument1">The argument1.</param>
        /// <param name="argument2">The argument2.</param>
        /// <returns>True if it is a dictionary, false otherwise</returns>
        private static bool IsDictionary(Type classType, out Type? argument1, out Type? argument2)
        {
            argument1 = null;
            argument2 = null;
            if (classType == typeof(IDictionary))
            {
                argument1 = typeof(string);
                argument2 = typeof(string);
                return true;
            }
            if (!classType.IsGenericType)
                return false;

            Type[] GenericArguments = classType.GetGenericArguments();
            if (GenericArguments.Length < 2)
                return false;

            argument1 = GenericArguments[0];
            argument2 = GenericArguments[1];
            return classType.IsAssignableTo(typeof(IDictionary<,>).MakeGenericType(GenericArguments[0], GenericArguments[1]));
        }

        /// <summary>
        /// Determines if the class is an IEnumerable
        /// </summary>
        /// <param name="classType">Type of the class.</param>
        /// <param name="arg">The argument.</param>
        /// <returns>True if it is an IEnumerable, false otherwise</returns>
        private static bool IsIEnumerable(Type classType, out Type? arg)
        {
            arg = null;
            if (classType == typeof(IEnumerable))
            {
                arg = typeof(string);
                return true;
            }
            if (!classType.IsGenericType)
                return false;

            Type[] GenericArguments = classType.GetGenericArguments();
            arg = GenericArguments[0];
            return classType.IsAssignableTo(typeof(IEnumerable<>).MakeGenericType(GenericArguments[0]));
        }

        /// <summary>
        /// Determines if the class is a list
        /// </summary>
        /// <param name="classType">Type of the class.</param>
        /// <param name="arg">The argument.</param>
        /// <returns>True if it is a list, false otherwise</returns>
        private static bool IsList(Type classType, out Type? arg)
        {
            arg = null;
            if (classType == typeof(IList))
            {
                arg = typeof(string);
                return true;
            }
            if (!classType.IsGenericType)
                return false;

            Type[] GenericArguments = classType.GetGenericArguments();
            arg = GenericArguments[0];
            return classType.IsAssignableTo(typeof(IList<>).MakeGenericType(GenericArguments[0]));
        }
    }
}