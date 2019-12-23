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
using System.Collections.Generic;

namespace Mirage.Generators
{
    /// <summary>
    /// Char generator
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    /// <seealso cref="IGenerator{Char}"/>
    public sealed class CharGeneratorAttribute : GeneratorAttributeBase, IGenerator<char>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CharGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public CharGeneratorAttribute(char min, char max)
            : base(min, min == 0 && max == 0 ? char.MaxValue : max)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharGeneratorAttribute"/> class.
        /// </summary>
        public CharGeneratorAttribute()
            : this(char.MinValue, char.MaxValue)
        {
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IGenerator"/> is a default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public override bool Default => true;

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(char);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public char Next(Random rand)
        {
            return Min is null || Max is null ? (default) : Next(rand, (char)Min, (char)Max);
        }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public char Next(Random rand, char min, char max)
        {
            return (char)(min + (char)((max - min) * rand.NextDouble()));
        }

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">The rand.</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>The next object</returns>
        public override object? NextObj(Random rand, List<object> previouslySeen)
        {
            return Next(rand);
        }
    }
}