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
    /// TimeSpan generator
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    /// <seealso cref="Interfaces.IGenerator{TimeSpan}"/>
    public class TimeSpanGeneratorAttribute : GeneratorAttributeBase, IGenerator<TimeSpan>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TimeSpanGeneratorAttribute() : base(TimeSpan.MinValue, TimeSpan.MaxValue) { }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(TimeSpan);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public TimeSpan Next(Random rand)
        {
            return Next(rand, (TimeSpan)Min, (TimeSpan)Max);
        }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public TimeSpan Next(Random rand, TimeSpan min, TimeSpan max)
        {
            if (min > max)
                throw new ArgumentException("The minimum value must be less than the maximum value");
            return min + new TimeSpan((long)(new TimeSpan(max.Ticks - min.Ticks).Ticks * rand.NextDouble()));
        }

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">Random number generator</param>
        /// <returns>The next object</returns>
        public override object NextObj(Random rand)
        {
            if ((TimeSpan)Min != default(TimeSpan) || (TimeSpan)Max != default(TimeSpan))
                return Next(rand, (TimeSpan)Min, (TimeSpan)Max);
            return Next(rand);
        }
    }
}