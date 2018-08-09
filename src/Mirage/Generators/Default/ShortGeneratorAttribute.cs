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

namespace Mirage.Generators
{
    /// <summary>
    /// Short generator
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    /// <seealso cref="Interfaces.IGenerator{Short}"/>
    public class ShortGeneratorAttribute : GeneratorAttributeBase, IGenerator<short>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShortGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public ShortGeneratorAttribute(short min, short max)
            : base(min == 0 && max == 0 ? short.MinValue : min, min == 0 && max == 0 ? short.MaxValue : max)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortGeneratorAttribute"/> class.
        /// </summary>
        public ShortGeneratorAttribute()
            : this(short.MinValue, short.MaxValue)
        {
        }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(short);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public short Next(Random rand)
        {
            return Next(rand, (short)Min, (short)Max);
        }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public short Next(Random rand, short min, short max)
        {
            return (short)((int)min + (int)(((int)max - (int)min) * rand.NextDouble()));
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