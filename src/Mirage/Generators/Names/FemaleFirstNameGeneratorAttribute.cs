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
    /// FemaleFirstName Generator
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public class FemaleFirstNameAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FemaleFirstNameAttribute()
            : base("", "")
        {
        }

        private readonly string[] FemaleFirstNames = { "Sophia", "Isabella", "Emma", "Olivia", "Ava", "Emily",
                                                "Abigail", "Madison", "Mia", "Chloe", "Elizabeth",
                                                "Ella", "Addison", "Natalie", "Lily", "Grace", "Samantha"
                                                , "Avery", "Sofia", "Aubrey", "Brooklyn", "Lillian",
                                                "Victoria", "Evelyn", "Hannah", "Alexis", "Charlotte",
                                                "Zoey", "Leah", "Amelia", "Zoe", "Hailey", "Layla",
                                                "Gabriella", "Nevaeh", "Kaylee", "Alyssa", "Anna", "Sarah",
                                                "Allison", "Savannah", "Ashley", "Audrey", "Taylor",
                                                "Brianna", "Aaliyah", "Riley", "Camila", "Khloe", "Claire",
                                                "Sophie", "Arianna", "Peyton", "Harper", "Alexa", "Makayla",
                                                "Julia", "Kylie", "Kayla", "Bella", "Katherine", "Lauren",
                                                "Gianna", "Maya", "Sydney", "Serenity", "Kimberly", "Mackenzie",
                                                "Autumn", "Jocelyn", "Faith", "Lucy", "Stella", "Jasmine",
                                                "Morgan", "Alexandra", "Trinity", "Molly", "Madelyn",
                                                "Scarlett", "Andrea", "Genesis", "Eva", "Ariana", "Madeline",
                                                "Brooke", "Caroline", "Bailey", "Melanie", "Kennedy",
                                                "Destiny", "Maria", "Naomi", "London", "Payton", "Lydia",
                                                "Ellie", "Mariah", "Aubree", "Kaitlyn", "Violet", "Rylee",
                                                "Lilly", "Angelina", "Katelyn", "Mya", "Paige", "Natalia",
                                                "Ruby", "Piper", "Annabelle", "Mary", "Jade", "Isabelle",
                                                "Liliana", "Nicole", "Rachel", "Vanessa", "Gabrielle", "Jessica",
                                                "Jordyn", "Reagan", "Kendall", "Sadie", "Valeria", "Brielle",
                                                "Lyla", "Isabel", "Brooklynn", "Reese", "Sara", "Adriana",
                                                "Aliyah", "Jennifer", "Mckenzie", "Gracie", "Nora", "Kylee",
                                                "Makenzie", "Izabella", "Laila", "Alice", "Amy", "Michelle",
                                                "Skylar", "Stephanie", "Juliana", "Rebecca", "Jayla", "Eleanor",
                                                "Clara", "Giselle", "Valentina", "Vivian", "Alaina", "Eliana",
                                                "Aria", "Valerie", "Haley", "Elena", "Catherine", "Elise", "Lila",
                                                "Megan", "Gabriela", "Daisy", "Jada", "Daniela", "Penelope",
                                                "Jenna", "Ashlyn", "Delilah", "Summer", "Mila", "Kate", "Keira",
                                                "Adrianna", "Hadley", "Julianna", "Maci", "Eden", "Josephine",
                                                "Aurora", "Melissa", "Hayden", "Alana", "Margaret", "Quinn",
                                                "Angela", "Brynn", "Alivia", "Katie", "Ryleigh", "Kinley",
                                                "Paisley", "Jordan", "Aniyah", "Allie", "Miranda", "Jacquelin",
                                                "Melody", "Willow", "Diana", "Cora", "Alexandria", "Mikayla",
                                                "Danielle", "Londyn", "Addyson", "Amaya", "Hazel", "Callie",
                                                "Teagan", "Adalyn", "Ximena", "Angel", "Kinsley", "Shelby",
                                                "Makenna", "Ariel", "Jillian", "Chelsea", "Alayna", "Harmony",
                                                "Sienna", "Amanda", "Presley", "Maggie", "Tessa", "Leila", "Hope",
                                                "Genevieve", "Erin", "Briana", "Delaney", "Esther", "Kathryn",
                                                "Ana", "Mckenna", "Camille", "Cecilia", "Lucia", "Lola", "Leilani",
                                                "Leslie", "Ashlynn", "Kayleigh", "Alondra", "Alison", "Haylee" };

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand)
        {
            return rand.Next(FemaleFirstNames);
        }
    }
}