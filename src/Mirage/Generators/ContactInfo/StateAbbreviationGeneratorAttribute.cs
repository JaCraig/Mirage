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
    /// StateAbbreviation Generator
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public sealed class StateAbbreviationAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public StateAbbreviationAttribute()
            : base("", "")
        {
        }

        private readonly string[] StateAndDistrictAbbreviations = { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI",
                                                             "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI",
                                                             "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC",
                                                             "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT",
                                                             "VT", "VA", "WA", "WV", "WI", "WY", "DC" };

        /// <summary>
        /// Gets a value indicating whether this <see cref="IGenerator"/> is a default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public override bool Default => false;

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand)
        {
            return rand.Next(StateAndDistrictAbbreviations);
        }
    }
}