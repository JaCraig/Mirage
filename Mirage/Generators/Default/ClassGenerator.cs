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

using BigBook;
using Mirage.Generators.BaseClasses;
using Mirage.Interfaces;
using Mirage.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Mirage.Generators.Default
{
    /// <summary>
    /// Randomly generates a class
    /// </summary>
    /// <typeparam name="T">Class type to generate</typeparam>
    public class ClassGenerator<T> : IGenerator<T>
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
        public Type TypeGenerated => typeof(object);

        /// <summary>
        /// Generates a random version of the class
        /// </summary>
        /// <param name="rand">Random generator to use</param>
        /// <returns>The randomly generated class</returns>
        public T Next(Random rand) => (T)NextObj(rand, new List<object>())!;

        /// <summary>
        /// Generates a random version of the class
        /// </summary>
        /// <param name="rand">Random generator to use</param>
        /// <param name="min">Min value (not used)</param>
        /// <param name="max">Max value (not used)</param>
        /// <returns>The randomly generated class</returns>
        public T Next(Random rand, T min, T max) => Activator.CreateInstance<T>();

        /// <summary>
        /// Gets a random version of the class
        /// </summary>
        /// <param name="rand">Random generator used</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>The randonly generated class</returns>
        public object? NextObj(Random rand, List<object> previouslySeen)
        {
            if (rand is null)
                return default;
            previouslySeen ??= new List<object>();
            var PreviousItem = previouslySeen.Find(x => x?.GetType() == typeof(T));
            if (PreviousItem != null)
                return PreviousItem;
            if (!IsStruct(typeof(T)) && !typeof(T).HasDefaultConstructor())
                return default;
            T? ReturnItem = Activator.CreateInstance<T>();
            if (ReturnItem is null)
                return default;
            previouslySeen = previouslySeen.ToList();
            previouslySeen.Add(ReturnItem);
            Type ObjectType = typeof(T);
            foreach (PropertyInfo Property in ObjectType.GetProperties())
            {
                var Generated = false;
                ValidationAttribute[] ValidationAttributes = Property.Attributes<ValidationAttribute>();
                GeneratorAttributeBase? Attribute = Property.Attribute<GeneratorAttributeBase>();
                if (Attribute is not null)
                {
                    do
                    {
                        var TempValue = Attribute.NextObj(rand, previouslySeen);
                        if (ValidationAttributes.All(x => x.IsValid(TempValue)))
                        {
                            _ = ReturnItem.Property(Property, TempValue!);
                            Generated = true;
                        }
                    }
                    while (!Generated);
                }
            }
            return ReturnItem;
        }

        /// <summary>
        /// Determines if the type is a struct
        /// </summary>
        /// <param name="type">Type to check</param>
        /// <returns>True if it is a struct, false otherwise</returns>
        private static bool IsStruct(Type? type) => type?.IsValueType == true && !type.IsEnum;
    }

    /// <summary>
    /// Class generator attribute
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    public sealed class ClassGeneratorAttribute : GeneratorAttributeBase
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
        public Type? ClassType { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Mirage.Interfaces.IGenerator"/> is a
        /// default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public override bool Default => true;

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(object);

        /// <summary>
        /// Gets the method input types.
        /// </summary>
        /// <value>The method input types.</value>
        private Type[] MethodInputTypes { get; } = new Type[] { typeof(Random), typeof(List<object>) };

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">The rand.</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>The next object</returns>
        public override object? NextObj(Random rand, List<object> previouslySeen)
        {
            if (ClassType is null)
                return null;
            Type FinalClassType = typeof(ClassGenerator<>).MakeGenericType(ClassType);
            MethodInfo? NextFunction = FinalClassType.GetTypeInfo().GetMethod(nameof(NextObj), MethodInputTypes);
            var Generator = Services.ServiceProvider?.GetService(FinalClassType);
            return NextFunction?.Invoke(Generator, new object[] { rand, previouslySeen });
        }
    }
}