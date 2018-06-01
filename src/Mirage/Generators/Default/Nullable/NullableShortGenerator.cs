﻿/*
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

namespace Mirage.Generators.Default.Nullable
{
    /// <summary>
    /// long generator
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    /// <seealso cref="Interfaces.IGenerator{Int}"/>
    public class NullableShortGeneratorAttribute : GeneratorAttributeBase, IGenerator<short?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableShortGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public NullableShortGeneratorAttribute(short min, short max)
            : base(min == 0 && max == 0 ? short.MinValue : min, min == 0 && max == 0 ? short.MaxValue : max)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableShortGeneratorAttribute"/> class.
        /// </summary>
        public NullableShortGeneratorAttribute()
            : this(short.MinValue, short.MaxValue)
        {
        }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(short?);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public short? Next(Random rand)
        {
            if (!rand.Next<bool>())
                return null;
            return rand.Next<short>();
        }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public short? Next(Random rand, short? min, short? max)
        {
            if (!rand.Next<bool>())
                return null;
            min = min ?? short.MinValue;
            max = max ?? short.MaxValue;
            return rand.Next(min.Value, max.Value);
        }

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">The rand.</param>
        /// <returns>The next object</returns>
        public override object NextObj(Random rand)
        {
            return Next(rand);
        }
    }
}