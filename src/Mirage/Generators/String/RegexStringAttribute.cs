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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mirage.Generators
{
    /// <summary>
    /// Randomly generates strings based on a Regex
    /// </summary>
    public class RegexStringAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="length">Length of the string to generate</param>
        /// <param name="allowedCharacters">Characters that are allowed</param>
        /// <param name="numberOfNonAlphaNumericsAllowed">
        /// Number of non alphanumeric characters to allow
        /// </param>
        public RegexStringAttribute(int length, string allowedCharacters = ".", int numberOfNonAlphaNumericsAllowed = int.MaxValue)
            : base("", "")
        {
            Length = length;
            AllowedCharacters = allowedCharacters;
            NumberOfNonAlphaNumericsAllowed = numberOfNonAlphaNumericsAllowed;
        }

        /// <summary>
        /// Characters allowed
        /// </summary>
        public string AllowedCharacters { get; protected set; }

        /// <summary>
        /// Length to generate
        /// </summary>
        public int Length { get; protected set; }

        /// <summary>
        /// Number of non alpha numeric characters allowed
        /// </summary>
        public int NumberOfNonAlphaNumericsAllowed { get; protected set; }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand)
        {
            if (Length < 1)
                return "";
            var TempBuilder = new StringBuilder();
            var Comparer = new Regex(AllowedCharacters);
            var AlphaNumbericComparer = new Regex("[0-9a-zA-Z]");
            int Counter = 0;
            while (TempBuilder.Length < Length)
            {
                var TempValue = new string(Convert.ToChar(Convert.ToInt32(System.Math.Floor(94 * rand.NextDouble() + 32))), 1);
                if (Comparer.IsMatch(TempValue))
                {
                    if (!AlphaNumbericComparer.IsMatch(TempValue) && NumberOfNonAlphaNumericsAllowed > Counter)
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