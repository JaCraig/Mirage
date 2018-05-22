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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mirage.Generators
{
    /// <summary>
    /// Randomly generates strings
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public class StringGeneratorAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public StringGeneratorAttribute() : base("", "") { }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand)
        {
            return NextString(rand, 10);
        }

        /// <summary>
        /// Returns a randomly generated string of a specified length, containing only a set of
        /// characters, and at max a specified number of non alpha numeric characters.
        /// </summary>
        /// <param name="length">Length of the string</param>
        /// <param name="allowedCharacters">Characters allowed in the string</param>
        /// <param name="numberOfNonAlphaNumericsAllowed">
        /// Number of non alpha numeric characters allowed.
        /// </param>
        /// <param name="rand">Random number generator</param>
        /// <returns>
        /// A randomly generated string of a specified length, containing only a set of characters,
        /// and at max a specified number of non alpha numeric characters.
        /// </returns>
        protected string NextString(Random rand, int length, string allowedCharacters = ".", int numberOfNonAlphaNumericsAllowed = int.MaxValue)
        {
            if (length < 1)
                return "";
            var TempBuilder = new StringBuilder();
            var Comparer = new Regex(allowedCharacters);
            var AlphaNumbericComparer = new Regex("[0-9a-zA-Z]");
            int Counter = 0;
            while (TempBuilder.Length < length)
            {
                var TempValue = new string(Convert.ToChar(Convert.ToInt32(System.Math.Floor((94 * rand.NextDouble()) + 32))), 1);
                if (Comparer.IsMatch(TempValue))
                {
                    if (!AlphaNumbericComparer.IsMatch(TempValue) && numberOfNonAlphaNumericsAllowed > Counter)
                    {
                        TempBuilder.Append(TempValue);
                        ++Counter;
                    }
                    else if (AlphaNumbericComparer.IsMatch(TempValue))
                    {
                        TempBuilder.Append(TempValue);
                    }
                }
            }
            return TempBuilder.ToString();
        }
    }
}