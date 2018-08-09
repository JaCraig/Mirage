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
    /// UShort generator
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    /// <seealso cref="Interfaces.IGenerator{UShort}"/>
    public class UShortGeneratorAttribute : GeneratorAttributeBase, IGenerator<ushort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UShortGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public UShortGeneratorAttribute(ushort min, ushort max)
            : base(min == 0 && max == 0 ? ushort.MinValue : min, min == 0 && max == 0 ? ushort.MaxValue : max)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UShortGeneratorAttribute"/> class.
        /// </summary>
        public UShortGeneratorAttribute()
            : this(ushort.MinValue, ushort.MaxValue)
        {
        }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(ushort);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public ushort Next(Random rand)
        {
            return Next(rand, (ushort)Min, (ushort)Max);
        }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public ushort Next(Random rand, ushort min, ushort max)
        {
            return (ushort)((uint)min + (uint)(((uint)max - (uint)min) * rand.NextDouble()));
        }

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">The rand.</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>The next object</returns>
        public override object NextObj(Random rand, List<object> previouslySeen)
        {
            return Next(rand);
        }
    }
}