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
using System.Linq;
using System.Threading.Tasks;

namespace Mirage.Generators
{
    /// <summary>
    /// ULong generator
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    /// <seealso cref="Interfaces.IGenerator{ULong}"/>
    public class ULongGeneratorAttribute : GeneratorAttributeBase, IGenerator<ulong>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ULongGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public ULongGeneratorAttribute(ulong min, ulong max) : base(min, max)
        {
        }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(ulong);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public ulong Next(Random rand)
        {
            return Next(rand, (ulong)Min, (ulong)Max);
        }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public ulong Next(Random rand, ulong min, ulong max)
        {
            return min + (ulong)((max - min) * rand.NextDouble());
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