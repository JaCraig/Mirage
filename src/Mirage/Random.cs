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

using BigBook;
using Microsoft.Extensions.DependencyInjection;
using Mirage.Interfaces;
using Mirage.Manager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mirage
{
    /// <summary>
    /// Utility class for handling random information.
    /// </summary>
    /// <seealso cref="Random"/>
    public class Random : System.Random
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Random()
        {
            GeneratorBuilder = Services.ServiceProvider?.GetService<Manager.Builder>() ?? new Manager.Builder(Array.Empty<IGenerator>());
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="seed">Seed value</param>
        public Random(int seed)
            : base(seed)
        {
            GeneratorBuilder = Services.ServiceProvider?.GetService<Manager.Builder>() ?? new Manager.Builder(Array.Empty<IGenerator>());
        }

        /// <summary>
        /// Gets or sets the generator builder.
        /// </summary>
        /// <value>The generator builder.</value>
        private Manager.Builder GeneratorBuilder { get; }

        /// <summary>
        /// The local seed
        /// </summary>
        [ThreadStatic]
        private static System.Random? _Local;

        /// <summary>
        /// The global seed
        /// </summary>
        private readonly System.Random _GlobalSeed = new();

        /// <summary>
        /// Randomly generates a value of the specified type
        /// </summary>
        /// <typeparam name="T">Type to generate</typeparam>
        /// <returns>The randomly generated value</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The type specified, " + typeof(T).Name + ", does not have a default generator.
        /// </exception>
        public T Next<T>() => (T)Next(typeof(T))!;

        /// <summary>
        /// Randomly generates an IEnumerable of the specified type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="amount">The amount.</param>
        /// <returns>The randomly generated value</returns>
        public IEnumerable<object?> Next(Type objectType, int amount) => amount.Times(_ => Next(objectType));

        /// <summary>
        /// Randomly generates a value of the specified type
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>The randomly generated value</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The type specified, " + typeof(T).Name + ", does not have a default generator.
        /// </exception>
        public object? Next(Type objectType)
        {
            if (objectType is null)
                return null;
            IGenerator? Generator = GeneratorBuilder.GetGenerator(objectType);
            return Generator is null
                ? throw new ArgumentOutOfRangeException("The type specified, " + objectType.Name + ", does not have a default generator.")
                : Generator.NextObj(this, new List<object>());
        }

        /// <summary>
        /// Randomly generates a value of the specified type
        /// </summary>
        /// <typeparam name="T">Type to generate</typeparam>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>The randomly generated value</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The type specified, " + typeof(T).Name + ", does not have a default generator.
        /// </exception>
        public T Next<T>(T min, T max)
        {
            IGenerator<T>? Generator = GeneratorBuilder.GetGenerator<T>();
            return Generator is null
                ? throw new ArgumentOutOfRangeException("The type specified, " + typeof(T).Name + ", does not have a default generator.")
                : Generator.Next(this, min, max);
        }

        /// <summary>
        /// Randomly generates a list of values of the specified type
        /// </summary>
        /// <typeparam name="T">Type to the be generated</typeparam>
        /// <param name="amount">Number of items to generate</param>
        /// <returns>The randomly generated value</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The type specified, " + typeof(T).Name + ", does not have a default generator.
        /// </exception>
        public IEnumerable<T> Next<T>(int amount) => Next(typeof(T), amount).Select(x => (T)x!);

        /// <summary>
        /// Randomly generates a list of values of the specified type
        /// </summary>
        /// <typeparam name="T">Type to the be generated</typeparam>
        /// <param name="amount">Number of items to generate</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>The randomly generated value</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The type specified, " + typeof(T).Name + ", does not have a default generator.
        /// </exception>
        public IEnumerable<T> Next<T>(int amount, T min, T max)
        {
            IGenerator<T>? Generator = GeneratorBuilder.GetGenerator<T>();
            return Generator is null
                ? throw new ArgumentOutOfRangeException("The type specified, " + typeof(T).Name + ", does not have a default generator.")
                : amount.Times(_ => Generator.Next(this, min, max));
        }

        /// <summary>
        /// Picks a random item from the list
        /// </summary>
        /// <typeparam name="T">Type of object in the list</typeparam>
        /// <param name="list">List to pick from</param>
        /// <returns>Item that is returned</returns>
        public T Next<T>(IEnumerable<T> list)
        {
            if (list is null)
                return default!;
            var Position = Next(0, list.Count());
            return list.ElementAt(Position);
        }

        /// <summary>
        /// Picks a list of items from an existing list.
        /// </summary>
        /// <typeparam name="T">Type of object in the list</typeparam>
        /// <param name="list">The list to pick from.</param>
        /// <param name="count">The number of items to return.</param>
        /// <param name="unique">if set to <c>true</c> each item is [unique].</param>
        /// <returns>The resulting list.</returns>
        public IEnumerable<T>? Next<T>(IEnumerable<T>? list, int count, bool unique = false)
        {
            list ??= Array.Empty<T>();
            if (count >= list.Count() && unique)
                return Shuffle(list);
            var ReturnValue = new List<T>();
            var PreviousPositions = new int[count];
            for (var x = 0; x < PreviousPositions.Length; ++x)
            {
                PreviousPositions[x] = -1;
            }
            for (var x = 0; x < count; ++x)
            {
                while (true)
                {
                    var Position = Next(0, list.Count());
                    if (!unique || !PreviousPositions.Contains(Position))
                    {
                        PreviousPositions[x] = Position;
                        break;
                    }
                }
                ReturnValue.Add(list.ElementAt(PreviousPositions[x]));
            }
            return ReturnValue;
        }

        /// <summary>
        /// Returns a list of items from an original weighted list.
        /// </summary>
        /// <typeparam name="T">Type of object in the list</typeparam>
        /// <param name="list">The list to pick from.</param>
        /// <param name="weights">The weights used for the list (higher numbers mean higher weight).</param>
        /// <param name="count">The number of items to return.</param>
        /// <param name="unique">if set to <c>true</c> each item is [unique].</param>
        /// <returns>The resulting list.</returns>
        public IEnumerable<T>? Next<T>(IEnumerable<T>? list, IEnumerable<decimal> weights, int count, bool unique = false)
        {
            list ??= Array.Empty<T>();
            weights ??= Array.Empty<decimal>();
            if (count >= list.Count() && unique)
                return Shuffle(list);
            var ReturnValue = new List<T>();
            var PreviousPositions = new int[count];
            for (var x = 0; x < PreviousPositions.Length; ++x)
            {
                PreviousPositions[x] = -1;
            }
            var TotalWeight = weights.Sum();
            for (var x = 0; x < count; ++x)
            {
                while (true)
                {
                    var TempWeight = Next(0, TotalWeight);
                    var Position = 0;
                    for (var y = 0; y < weights.Count(); ++y)
                    {
                        TempWeight -= weights.ElementAt(y);
                        if (TempWeight <= 0)
                        {
                            Position = y;
                            break;
                        }
                    }
                    if (!unique || !PreviousPositions.Contains(Position))
                    {
                        PreviousPositions[x] = Position;
                        break;
                    }
                }
                ReturnValue.Add(list.ElementAt(PreviousPositions[x]));
            }
            return ReturnValue;
        }

        /// <summary>
        /// Returns two normally distributed random numbers. Uses Box-Muller transformation.
        /// </summary>
        /// <param name="mean">The mean.</param>
        /// <param name="standardDeviation">The standard deviation.</param>
        /// <returns>The resulting values.</returns>
        public (double X, double Y) NextNormal(double mean, double standardDeviation)
        {
            var Radius = Math.Sqrt(-2 * Math.Log(Next<double>())) * standardDeviation;
            var Angle = 2 * Math.PI * Next<double>();
            return (mean + (Radius * Math.Cos(Angle)), mean + (Radius * Math.Sin(Angle)));
        }

        /// <summary>
        /// Shuffles a list randomly
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="list">List of objects to shuffle</param>
        /// <returns>The shuffled list</returns>
        public IEnumerable<T>? Shuffle<T>(IEnumerable<T>? list) => list?.Any() != true ? list : list.OrderBy(_ => Next());

        /// <summary>
        /// A thread safe version of a random number generation
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>A randomly generated value</returns>
        public int ThreadSafeNext(int min = int.MinValue, int max = int.MaxValue)
        {
            if (_Local is null)
            {
                int Seed;
                lock (_GlobalSeed)
                    Seed = _GlobalSeed.Next();
                _Local = new Random(Seed);
            }
            return _Local.Next(min, max);
        }
    }
}