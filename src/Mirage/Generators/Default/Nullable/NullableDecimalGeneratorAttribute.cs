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

namespace Mirage.Generators.Default.Nullable
{
    /// <summary>
    /// NullableDecimal generator
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    public class NullableDecimalGeneratorAttribute : GeneratorAttributeBase, IGenerator<decimal?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableDecimalGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public NullableDecimalGeneratorAttribute(decimal? min, decimal? max)
            : base(min, min == 0 && max == 0 ? 1 : max)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableDecimalGeneratorAttribute"/> class.
        /// </summary>
        public NullableDecimalGeneratorAttribute() : base(0, 1)
        {
        }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(decimal?);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public decimal? Next(Random rand)
        {
            if (!rand.Next<bool>())
                return null;
            return rand.Next<decimal>();
        }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public decimal? Next(Random rand, decimal? min, decimal? max)
        {
            if (!rand.Next<bool>())
                return null;
            min = min ?? decimal.MinValue;
            max = max ?? decimal.MaxValue;
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