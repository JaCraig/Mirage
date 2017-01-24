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
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Mirage.Generators
{
    /// <summary>
    /// Randomly generates Enum
    /// </summary>
    public class EnumGenerator<T> : IGenerator<T>
    {
        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public Type TypeGenerated => typeof(Enum);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public T Next(Random rand)
        {
            return Next(rand, default(T), default(T));
        }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public T Next(Random rand, T min, T max)
        {
            var Values = Enum.GetValues(typeof(T));
            var Index = rand.Next(0, Values.Length);
            return (T)Values.GetValue(Index);
        }

        /// <summary>
        /// Randomly generates an object
        /// </summary>
        /// <param name="rand">Random number generator</param>
        /// <returns>A randomly generated object</returns>
        public object NextObj(Random rand)
        {
            return Next(rand);
        }
    }

    /// <summary>
    /// Class generator attribute
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    public class EnumGeneratorAttribute : GeneratorAttributeBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="enumType">Type of the class.</param>
        public EnumGeneratorAttribute(Type enumType) : base(enumType, enumType)
        {
            EnumType = enumType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumGeneratorAttribute"/> class.
        /// </summary>
        public EnumGeneratorAttribute() : base(null, null)
        {
            EnumType = null;
        }

        /// <summary>
        /// Gets or sets the type of the class.
        /// </summary>
        /// <value>The type of the class.</value>
        public Type EnumType { get; set; }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(object);

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">The rand.</param>
        /// <returns>The next object</returns>
        public override object NextObj(Random rand)
        {
            if (EnumType == null)
                return null;
            var FinalClassType = typeof(EnumGenerator<>).MakeGenericType(EnumType);
            var NextFunction = FinalClassType.GetTypeInfo().GetMethod("Next", new Type[] { typeof(Random) });
            var Generator = Canister.Builder.Bootstrapper.GetService(FinalClassType);
            return NextFunction.Invoke(Generator, new object[] { rand });
        }
    }
}