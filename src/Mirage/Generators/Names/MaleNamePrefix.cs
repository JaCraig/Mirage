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
using System.Text;

namespace Mirage.Generators
{
    /// <summary>
    /// MaleNamePrefix Generator
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public class MaleNamePrefixAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MaleNamePrefixAttribute()
            : base("", "")
        {
        }

        private readonly string[] MaleNamePrefixes = { "Mr.", "Dr.", "Prof.", "Rev." };

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand)
        {
            return rand.Next(MaleNamePrefixes);
        }
    }
}