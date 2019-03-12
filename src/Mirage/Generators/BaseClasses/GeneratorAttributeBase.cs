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

using Mirage.Interfaces;
using System;
using System.Collections.Generic;

namespace Mirage.Generators.BaseClasses
{
    /// <summary>
    /// Attribute base class for generators
    /// </summary>
    /// <seealso cref="Attribute"/>
    /// <seealso cref="IGenerator"/>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public abstract class GeneratorAttributeBase : Attribute, IGenerator
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        protected GeneratorAttributeBase(object min, object max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IGenerator"/> is a default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public abstract bool Default { get; }

        /// <summary>
        /// Maximum allowed
        /// </summary>
        public object Max { get; protected set; }

        /// <summary>
        /// Minimum allowed
        /// </summary>
        public object Min { get; protected set; }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public abstract Type TypeGenerated { get; }

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">The rand.</param>
        /// <param name="previouslySeen">The previously seen.</param>
        /// <returns>The next object</returns>
        public abstract object NextObj(Random rand, List<object> previouslySeen);
    }
}