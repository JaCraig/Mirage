using Mirage.Interfaces;
using System;
using System.Collections.Generic;

namespace Mirage.Generators.BaseClasses
{
    /// <summary>
    /// Abstract class for string generators
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    public abstract class StringGeneratorBase : GeneratorAttributeBase, IGenerator<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringGeneratorBase"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        protected StringGeneratorBase(string min, string max) : base(min, max)
        {
        }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(string);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public abstract string Next(Random rand);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public string Next(Random rand, string min, string max)
        {
            return Next(rand);
        }

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">The rand.</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>The next object</returns>
        public override object? NextObj(Random rand, List<object> previouslySeen)
        {
            return Next(rand);
        }
    }
}