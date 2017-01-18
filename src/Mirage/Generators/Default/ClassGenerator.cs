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
    /// Randomly generates a class
    /// </summary>
    /// <typeparam name="T">Class type to generate</typeparam>
    public class ClassGenerator<T> : IGenerator<T>
    {
        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public Type TypeGenerated => typeof(object);

        /// <summary>
        /// Generates a random version of the class
        /// </summary>
        /// <param name="rand">Random generator to use</param>
        /// <returns>The randomly generated class</returns>
        public T Next(Random rand)
        {
            var ReturnItem = Activator.CreateInstance<T>();
            System.Type ObjectType = typeof(T);
            foreach (PropertyInfo Property in ObjectType.GetProperties())
            {
                var Attribute = Property.Attribute<GeneratorAttributeBase>();
                if (Attribute != null)
                    ReturnItem.Property(Property, Attribute.NextObj(rand));
            }
            return ReturnItem;
        }

        /// <summary>
        /// Generates a random version of the class
        /// </summary>
        /// <param name="rand">Random generator to use</param>
        /// <param name="min">Min value (not used)</param>
        /// <param name="max">Max value (not used)</param>
        /// <returns>The randomly generated class</returns>
        public T Next(Random rand, T min, T max)
        {
            return Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Gets a random version of the class
        /// </summary>
        /// <param name="rand">Random generator used</param>
        /// <returns>The randonly generated class</returns>
        public object NextObj(Random rand)
        {
            return Activator.CreateInstance<T>();
        }
    }

    /// <summary>
    /// Class generator attribute
    /// </summary>
    /// <seealso cref="Mirage.Generators.BaseClasses.GeneratorAttributeBase"/>
    public class ClassGeneratorAttribute : GeneratorAttributeBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="classType">Type of the class.</param>
        public ClassGeneratorAttribute(Type classType) : base(classType, classType)
        {
            ClassType = classType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassGeneratorAttribute"/> class.
        /// </summary>
        public ClassGeneratorAttribute() : base(null, null)
        {
            ClassType = null;
        }

        /// <summary>
        /// Gets or sets the type of the class.
        /// </summary>
        /// <value>The type of the class.</value>
        public Type ClassType { get; set; }

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
            if (ClassType == null)
                return null;
            var FinalClassType = typeof(ClassGenerator<>).MakeGenericType(ClassType);
            var NextFunction = FinalClassType.GetTypeInfo().GetMethod("Next", new Type[] { typeof(Random) });
            var Generator = Canister.Builder.Bootstrapper.Resolve(FinalClassType);
            return NextFunction.Invoke(Generator, new object[] { rand });
        }
    }
}