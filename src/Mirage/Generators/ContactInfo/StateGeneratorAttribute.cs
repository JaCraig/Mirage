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

namespace Mirage.Generators
{
    /// <summary>
    /// State Generator
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public sealed class StateAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public StateAttribute()
            : base("", "")
        {
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IGenerator"/> is a default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public override bool Default => false;

        /// <summary>
        /// The states and districts
        /// </summary>
        private static readonly string[] _StatesAndDistricts = { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado",
                                                  "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho",
                                                  "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine",
                                                  "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi",
                                                  "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey",
                                                  "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma",
                                                  "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota",
                                                  "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia",
                                                  "Wisconsin", "Wyoming", "District of Columbia" };

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand) => rand.Next(_StatesAndDistricts);
    }
}