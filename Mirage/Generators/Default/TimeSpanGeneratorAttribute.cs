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
using System.Collections.Generic;

namespace Mirage.Generators
{
    /// <summary>
    /// TimeSpan generator
    /// </summary>
    /// <seealso cref="IGenerator{TimeSpan}"/>
    public class TimeSpanGenerator : IGenerator<TimeSpan>
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="IGenerator"/> is a default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public bool Default => true;

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
        public TimeSpan Next(Random rand) => Next(rand, TimeSpan.MinValue, TimeSpan.MaxValue);

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
            {
                (max, min) = (min, max);
            }
            return min + new TimeSpan((long)(new TimeSpan(max.Ticks - min.Ticks).Ticks * (rand?.NextDouble() ?? 0)));
        }

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">Random number generator</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>The next object</returns>
        public object NextObj(Random rand, List<object> previouslySeen) => TimeSpan.MinValue != default || TimeSpan.MaxValue != default ? Next(rand, TimeSpan.MinValue, TimeSpan.MaxValue) : (object)Next(rand);
    }

    /// <summary>
    /// TimeSpan generator
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    public sealed class TimeSpanGeneratorAttribute : GeneratorAttributeBase
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
        /// Gets a value indicating whether this <see cref="IGenerator"/> is a default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public override bool Default => true;

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(TimeSpan);

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">Random number generator</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>The next object</returns>
        public override object? NextObj(Random rand, List<object> previouslySeen)
        {
            if (Min is null || Max is null)
                return default;
            _ = TimeSpan.TryParse((string)Min, out TimeSpan TempMin);
            _ = TimeSpan.TryParse((string)Max, out TimeSpan TempMax);
            return TempMin != default || TempMax != default
                ? new TimeSpanGenerator().Next(rand, TempMin, TempMax)
                : (object)new TimeSpanGenerator().Next(rand);
        }
    }
}