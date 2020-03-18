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
    /// Company Generator
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public sealed class CompanyAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CompanyAttribute()
            : base("", "")
        {
        }

        private static readonly string[] CompanyNames = { "Ankh-Sto Associates", "Conglom-O","Cyberdyne Systems Corporation","Globex Corporation","LexCorp",
                                            "Stark Industries","Sto Plains Holdings","Tri-Optimum Corporation","Umbrella Corporation",
                                            "Wayne Enterprises","Acme Corp","Weyland-Yutani","ZiffCorp","Grand Trunk Semaphore Company",
                                            "Monsters, Inc.","SewerCom","Strickland Propane","The Dysk Theatre","The Muppet Theatre",
                                            "Phillips Broadcasting","Spaceland","Wally World","Ankh Futures","Big Apple Bank",
                                            "Nakatomi Trading Corporation","Extensive Enterprises","Fronty's Meat Market",
                                            "PlayTronics","Transworld Consortium","DivaDroid International","Genesis Android Company",
                                            "Mom's Friendly Robot Company","Tyrell Corporation","Incom Corporation","Kuat Drive Yards",
                                            "Hudsucker Industries","Videlectrix","Nirvana Corp.","Omni Consumer Products",
                                            "Spishak","Cogswell Cogs","Duff Brewing Corporation","Paper Street Soap Company",
                                            "Soylent Corporation","Oscorp Industries","Jupiter Mining Corporation",
                                            "Le Fin","Moe's","Quark's","Starfishbucks Coffee","S-Mart","Milliways",
                                            "Sebben & Sebben","Planet Express","Applied Cryogenics","Initech","Rekall, Inc.",
                                            "Zorg Industries","Blue Sun Corporation","Venture Industries" };

        private static readonly string[] CompanySuffix =
                {
            "Associates",
            "Corporation",
            "Corp",
            "Industries",
            "Holdings",
            "Enterprises",
            "Company",
            "Consortium",
            "International",
            "Creative",
            "Design",
            "Digital",
            "Media",
            "Studio",
            "Communications",
            "Productions",
            "Bank",
            "PC",
            "Limited",
            "Incorporated",
            "Ltd",
            "Trust",
            "Co",
            "GmbH",
            "LC",
            "LP",
            "LLLP",
            "LLP",
            "Inc",
            "and Sons",
            "LLC",
            "Group"
        };

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
            if (rand.Next<bool>())
            {
                return rand.Next(CompanyNames);
            }
            if (rand.Next<bool>())
            {
                return new LastNameAttribute().Next(rand) + " " + rand.Next(CompanySuffix);
            }
            return rand.Next<bool>()
                ? new LastNameAttribute().Next(rand) + " and " + new LastNameAttribute().Next(rand)
                : new LastNameAttribute().Next(rand) + ", " + new LastNameAttribute().Next(rand) + " and " + new LastNameAttribute().Next(rand);
        }
    }
}