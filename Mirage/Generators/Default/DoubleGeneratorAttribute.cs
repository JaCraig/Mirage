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
    /// Double generator
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    /// <seealso cref="IGenerator{Double}"/>
    public sealed class DoubleGeneratorAttribute : GeneratorAttributeBase, IGenerator<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public DoubleGeneratorAttribute(double min, double max)
            : base(min, Math.Abs(min) < _EPSILON && Math.Abs(max) < _EPSILON ? 1 : max)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleGeneratorAttribute"/> class.
        /// </summary>
        public DoubleGeneratorAttribute()
            : this(0d, 1d)
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
        public override Type TypeGenerated => typeof(double);

        /// <summary>
        /// The epsilon
        /// </summary>
        private const double _EPSILON = 0.0001;

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public double Next(Random rand) => Min is null || Max is null ? default : Next(rand, (double)Min, (double)Max);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public double Next(Random rand, double min, double max) => min + ((max - min) * (rand?.NextDouble() ?? 0));

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">The rand.</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>The next object</returns>
        public override object? NextObj(Random rand, List<object> previouslySeen) => Next(rand);
    }
}