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

using System;
using System.Collections.Generic;

namespace Mirage.Interfaces
{
    /// <summary>
    /// Generator interface
    /// </summary>
    /// <typeparam name="T">Type it generates</typeparam>
    /// <seealso cref="IGenerator"/>
    public interface IGenerator<T> : IGenerator
    {
        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        T Next(Random rand);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        T Next(Random rand, T min, T max);
    }

    /// <summary>
    /// Generator interface
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        Type TypeGenerated { get; }

        /// <summary>
        /// Generates a random value and returns it as an object
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>A randomly generated object</returns>
        object NextObj(Random rand, List<object> previouslySeen);
    }
}