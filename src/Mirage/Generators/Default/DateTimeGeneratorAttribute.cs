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
    /// DateTime generator
    /// </summary>
    /// <seealso cref="Interfaces.IGenerator{DateTime}"/>
    public class DateTimeGenerator : IGenerator<DateTime>
    {
        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public Type TypeGenerated => typeof(DateTime);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public DateTime Next(Random rand)
        {
            return Next(rand, DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public DateTime Next(Random rand, DateTime min, DateTime max)
        {
            if (min > max)
                throw new ArgumentException("The minimum value must be less than the maximum value");
            return min + new TimeSpan((long)(new TimeSpan(max.Ticks - min.Ticks).Ticks * rand.NextDouble()));
        }

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">Random number generator</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>The next object</returns>
        public object NextObj(Random rand, List<object> previouslySeen)
        {
            if (DateTime.MinValue != default(DateTime) || DateTime.MaxValue != default(DateTime))
                return Next(rand, DateTime.MinValue, DateTime.MaxValue);
            return Next(rand);
        }
    }

    /// <summary>
    /// DateTime generator attribute
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    public class DateTimeGeneratorAttribute : GeneratorAttributeBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DateTimeGeneratorAttribute()
            : base(DateTime.MinValue.ToString(), DateTime.MaxValue.ToString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public DateTimeGeneratorAttribute(string min, string max)
            : base(min, max)
        {
        }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(DateTime);

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">Random number generator</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>The next object</returns>
        public override object NextObj(Random rand, List<object> previouslySeen)
        {
            DateTime.TryParse((string)Min, out DateTime TempMin);
            DateTime.TryParse((string)Max, out DateTime TempMax);
            if (TempMin != default(DateTime) || TempMax != default(DateTime))
                return new DateTimeGenerator().Next(rand, TempMin, TempMax);
            return new DateTimeGenerator().Next(rand);
        }
    }
}