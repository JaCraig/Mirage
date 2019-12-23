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
    /// Float generator
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    /// <seealso cref="IGenerator{Float}"/>
    public sealed class FloatGeneratorAttribute : GeneratorAttributeBase, IGenerator<float>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FloatGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public FloatGeneratorAttribute(float min, float max)
            : base(min, Math.Abs(min) < EPSILON && Math.Abs(max) < EPSILON ? 1 : max)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatGeneratorAttribute"/> class.
        /// </summary>
        public FloatGeneratorAttribute()
            : this(0, 1)
        {
        }

        private const float EPSILON = 0.0001f;

        /// <summary>
        /// Gets a value indicating whether this <see cref="IGenerator"/> is a default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public override bool Default => true;

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(float);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public float Next(Random rand)
        {
            return Min is null || Max is null ? (default) : Next(rand, (float)Min, (float)Max);
        }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public float Next(Random rand, float min, float max)
        {
            return min + ((max - min) * (float)rand.NextDouble());
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