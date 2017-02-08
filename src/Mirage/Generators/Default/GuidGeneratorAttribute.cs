using Mirage.Generators.BaseClasses;
using Mirage.Interfaces;
using System;

namespace Mirage.Generators.Default
{
    /// <summary>
    /// Guid generator attribute
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    /// <seealso cref="IGenerator{Guid}"/>
    public class GuidGeneratorAttribute : GeneratorAttributeBase, IGenerator<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidGeneratorAttribute"/> class.
        /// </summary>
        public GuidGeneratorAttribute()
            : base(Guid.Empty, Guid.Empty)
        {
        }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(Guid);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public Guid Next(Random rand)
        {
            return Guid.NewGuid();
        }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public Guid Next(Random rand, Guid min, Guid max)
        {
            return Guid.NewGuid();
        }

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">The rand.</param>
        /// <returns>The next object</returns>
        public override object NextObj(Random rand)
        {
            return Next(rand);
        }
    }
}