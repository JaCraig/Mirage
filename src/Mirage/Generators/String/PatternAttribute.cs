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
using System.Text;

namespace Mirage.Generators
{
    /// <summary>
    /// Randomly generates strings based on a pattern
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public class PatternAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pattern">Pattern to use: # = Number @ = Alpha character</param>
        public PatternAttribute(string pattern)
            : base("", "")
        {
            Pattern = pattern;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IGenerator"/> is a default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public override bool Default => false;

        /// <summary>
        /// Pattern to use
        /// </summary>
        public string Pattern { get; protected set; }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand)
        {
            if (string.IsNullOrEmpty(Pattern))
                return "";
            var TempBuilder = new StringBuilder();
            for (int x = 0; x < Pattern.Length; ++x)
            {
                if (Pattern[x] == '#')
                {
                    TempBuilder.Append(rand.Next(0, 9));
                }
                else if (Pattern[x] == '@')
                {
                    TempBuilder.Append(new RegexStringAttribute(1, "[a-zA-Z]", 0).Next(rand));
                }
                else
                {
                    TempBuilder.Append(Pattern[x]);
                }
            }
            return TempBuilder.ToString();
        }
    }
}