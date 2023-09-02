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

namespace Mirage.Generators.Default.Nullable
{
    /// <summary>
    /// DateTime generator
    /// </summary>
    public class NullableDateTimeGenerator : IGenerator<DateTime?>
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
        public Type TypeGenerated => typeof(DateTime?);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public DateTime? Next(Random rand)
        {
            return !(rand?.Next<bool>() ?? false) ? null : (DateTime?)rand.Next(DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public DateTime? Next(Random rand, DateTime? min, DateTime? max)
        {
            if (!(rand?.Next<bool>() ?? false))
                return null;
            min ??= DateTime.MinValue;
            max ??= DateTime.MaxValue;
            return rand.Next(min.Value, max.Value);
        }

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">Random number generator</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>The next object</returns>
        public object? NextObj(Random rand, List<object> previouslySeen)
        {
            return !(rand?.Next<bool>() ?? false) ? null : (object)rand.Next(DateTime.MinValue, DateTime.MaxValue);
        }
    }

    /// <summary>
    /// NullableDateTime generator
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    public sealed class NullableDateTimeGeneratorAttribute : GeneratorAttributeBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NullableDateTimeGeneratorAttribute()
            : base(DateTime.MinValue.ToString(), DateTime.MaxValue.ToString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableDateTimeGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public NullableDateTimeGeneratorAttribute(string min, string max)
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
        public override Type TypeGenerated => typeof(DateTime?);

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">Random number generator</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>The next object</returns>
        public override object? NextObj(Random rand, List<object> previouslySeen)
        {
            if (Min is null || Max is null)
                return null;
            _ = DateTime.TryParse((string)Min, out var TempMin);
            _ = DateTime.TryParse((string)Max, out var TempMax);
            return !(rand?.Next<bool>() ?? false) ? null : (object)rand.Next(TempMin, TempMax);
        }
    }
}