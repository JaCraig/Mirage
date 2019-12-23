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

using Mirage.Generators.BaseClasses;
using Mirage.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mirage.Generators.Default
{
    /// <summary>
    /// Dictionary generator attribute
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    public sealed class DictionaryGeneratorAttribute : GeneratorAttributeBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="keyType">Type of the key.</param>
        /// <param name="valueType">Type of the value.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public DictionaryGeneratorAttribute(Type? keyType, Type? valueType, int min, int max)
            : base(min == 0 && max == 0 ? 1 : min, min == 0 && max == 0 ? 100 : max)
        {
            KeyType = keyType;
            ValueType = valueType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryGeneratorAttribute"/> class.
        /// </summary>
        public DictionaryGeneratorAttribute()
            : this(null, null, 1, 100)
        {
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IGenerator"/> is a default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public override bool Default => true;

        /// <summary>
        /// Gets the type of the key.
        /// </summary>
        /// <value>The type of the key.</value>
        public Type? KeyType { get; }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(object);

        /// <summary>
        /// Gets the type of the value.
        /// </summary>
        /// <value>The type of the value.</value>
        public Type? ValueType { get; }

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">The rand.</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>The next object</returns>
        public override object? NextObj(Random rand, List<object> previouslySeen)
        {
            if (KeyType is null || ValueType is null || Min is null || Max is null)
                return null;
            var Count = rand.Next((int)Min, (int)Max);
            var KeyResults = rand.Next(KeyType, Count).ToArray();
            var ValueResults = rand.Next(ValueType, Count).ToArray();
            var ReturnObject = (IDictionary)Activator.CreateInstance(typeof(Dictionary<,>).MakeGenericType(KeyType, ValueType));
            for (int x = 0; x < Count; ++x)
            {
                if (ReturnObject.Contains(KeyResults[x]))
                    ReturnObject[KeyResults[x]] = ValueResults[x];
                else
                    ReturnObject.Add(KeyResults[x], ValueResults[x]);
            }
            return ReturnObject;
        }
    }
}