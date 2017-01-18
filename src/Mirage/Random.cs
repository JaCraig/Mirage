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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            GeneratorBuilder = Canister.Builder.Bootstrapper.Resolve<Manager.Builder>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Seed">Seed value</param>
        public Random(int Seed)
            : base(Seed)
        {
            GeneratorBuilder = Canister.Builder.Bootstrapper.Resolve<Manager.Builder>();
        }

        /// <summary>
        /// Gets or sets the generator builder.
        /// </summary>
        /// <value>The generator builder.</value>
        private Manager.Builder GeneratorBuilder { get; set; }

        [ThreadStatic]
        private static System.Random Local;

        /// <summary>
        /// The global seed
        /// </summary>
        private readonly System.Random GlobalSeed = new System.Random();

        /// <summary>
        /// Randomly generates a value of the specified type
        /// </summary>
        /// <typeparam name="T">Type to generate</typeparam>
        /// <returns>The randomly generated value</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The type specified, " + typeof(T).Name + ", does not have a default generator.
        /// </exception>
        public T Next<T>()
        {
            var Generator = GeneratorBuilder.GetGenerator<T>();
            if (Generator == null)
                throw new ArgumentOutOfRangeException("The type specified, " + typeof(T).Name + ", does not have a default generator.");
            return Generator.Next(this);
        }

        /// <summary>
        /// Randomly generates a value of the specified type
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>The randomly generated value</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The type specified, " + typeof(T).Name + ", does not have a default generator.
        /// </exception>
        public object Next(Type objectType)
        {
            var Generator = GeneratorBuilder.GetGenerator(objectType);
            if (Generator == null)
                throw new ArgumentOutOfRangeException("The type specified, " + objectType.Name + ", does not have a default generator.");
            return Generator.NextObj(this);
        }

        /// <summary>
        /// Randomly generates a value of the specified type
        /// </summary>
        /// <typeparam name="T">Type to generate</typeparam>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>The randomly generated value</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The type specified, " + typeof(T).Name + ", does not have a default generator.
        /// </exception>
        public T Next<T>(T min, T max)
        {
            var Generator = GeneratorBuilder.GetGenerator<T>();
            if (Generator == null)
                throw new ArgumentOutOfRangeException("The type specified, " + typeof(T).Name + ", does not have a default generator.");
            return Generator.Next(this, min, max);
        }

        /// <summary>
        /// Randomly generates a list of values of the specified type
        /// </summary>
        /// <typeparam name="T">Type to the be generated</typeparam>
        /// <param name="amount">Number of items to generate</param>
        /// <returns>The randomly generated value</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The type specified, " + typeof(T).Name + ", does not have a default generator.
        /// </exception>
        public IEnumerable<T> Next<T>(int amount)
        {
            var Generator = GeneratorBuilder.GetGenerator<T>();
            if (Generator == null)
                throw new ArgumentOutOfRangeException("The type specified, " + typeof(T).Name + ", does not have a default generator.");
            return amount.Times(x => Generator.Next(this));
        }

        /// <summary>
        /// Randomly generates a list of values of the specified type
        /// </summary>
        /// <typeparam name="T">Type to the be generated</typeparam>
        /// <param name="amount">Number of items to generate</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>The randomly generated value</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The type specified, " + typeof(T).Name + ", does not have a default generator.
        /// </exception>
        public IEnumerable<T> Next<T>(int amount, T min, T max)
        {
            var Generator = GeneratorBuilder.GetGenerator<T>();
            if (Generator == null)
                throw new ArgumentOutOfRangeException("The type specified, " + typeof(T).Name + ", does not have a default generator.");
            return amount.Times(x => Generator.Next(this, min, max));
        }

        /// <summary>
        /// Picks a random item from the list
        /// </summary>
        /// <typeparam name="T">Type of object in the list</typeparam>
        /// <param name="list">List to pick from</param>
        /// <returns>Item that is returned</returns>
        public T Next<T>(IEnumerable<T> list)
        {
            int x = 0;
            var Position = Next(0, list.Count());
            foreach (T Item in list)
            {
                if (x == Position)
                    return Item;
                ++x;
            }
            return default(T);
        }

        /// <summary>
        /// Shuffles a list randomly
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="list">List of objects to shuffle</param>
        /// <returns>The shuffled list</returns>
        public IEnumerable<T> Shuffle<T>(IEnumerable<T> list)
        {
            if (list == null || list.Count() == 0)
                return list;
            return list.OrderBy(x => Next());
        }

        /// <summary>
        /// A thread safe version of a random number generation
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>A randomly generated value</returns>
        public int ThreadSafeNext(int min = int.MinValue, int max = int.MaxValue)
        {
            if (Local == null)
            {
                int Seed;
                lock (GlobalSeed)
                    Seed = GlobalSeed.Next();
                Local = new Random(Seed);
            }
            return Local.Next(min, max);
        }
    }
}