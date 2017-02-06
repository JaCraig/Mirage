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
    /// TimeSpan generator
    /// </summary>
    /// <seealso cref="Interfaces.IGenerator{TimeSpan}"/>
    public class TimeSpanGenerator : IGenerator<TimeSpan>
    {
        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public Type TypeGenerated => typeof(TimeSpan);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public TimeSpan Next(Random rand)
        {
            return Next(rand, TimeSpan.MinValue, TimeSpan.MaxValue);
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
        public object NextObj(Random rand)
        {
            if (TimeSpan.MinValue != default(TimeSpan) || TimeSpan.MaxValue != default(TimeSpan))
                return Next(rand, TimeSpan.MinValue, TimeSpan.MaxValue);
            return Next(rand);
        }
    }

    /// <summary>
    /// TimeSpan generator
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    public class TimeSpanGeneratorAttribute : GeneratorAttributeBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TimeSpanGeneratorAttribute()
            : base(TimeSpan.MinValue.ToString(), TimeSpan.MaxValue.ToString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSpanGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public TimeSpanGeneratorAttribute(string min, string max)
            : base(min, max)
        {
        }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(TimeSpan);

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">Random number generator</param>
        /// <returns>The next object</returns>
        public override object NextObj(Random rand)
        {
            TimeSpan TempMin;
            TimeSpan TempMax;
            TimeSpan.TryParse((string)Min, out TempMin);
            TimeSpan.TryParse((string)Max, out TempMax);
            if (TempMin != default(TimeSpan) || TempMax != default(TimeSpan))
                return new TimeSpanGenerator().Next(rand, TempMin, TempMax);
            return new TimeSpanGenerator().Next(rand);
        }
    }
}