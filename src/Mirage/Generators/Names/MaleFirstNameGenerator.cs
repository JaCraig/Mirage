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
    /// MaleFirstName Generator
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public class MaleFirstNameAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MaleFirstNameAttribute()
            : base("", "")
        {
        }

        private readonly string[] MaleFirstNames = { "Jacob", "Mason", "William", "Jayden", "Noah", "Michael", "Ethan",
                                              "Alexander", "Aiden", "Daniel", "Anthony", "Matthew", "Elijah", "Joshua",
                                              "Liam", "Andrew", "James", "David", "Benjamin", "Logan", "Christopher", "Joseph",
                                              "Jackson", "Gabriel", "Ryan", "Samuel", "John", "Nathan", "Lucas", "Christian",
                                              "Jonathan", "Caleb", "Dylan", "Landon", "Isaac", "Gavin", "Brayden", "Tyler",
                                              "Luke", "Evan", "Carter", "Nicholas", "Isaiah", "Owen", "Jack", "Jordan",
                                              "Brandon", "Wyatt", "Julian", "Aaron", "Jeremiah", "Angel", "Cameron", "Connor",
                                              "Hunter", "Adrian", "Henry", "Eli", "Justin", "Austin", "Robert", "Charles",
                                              "Thomas", "Zachary", "Jose", "Levi", "Kevin", "Sebastian", "Chase", "Ayden",
                                              "Jason", "Ian", "Blake", "Colton", "Bentley", "Dominic", "Xavier", "Oliver",
                                              "Parker", "Josiah", "Adam", "Cooper", "Brody", "Nathaniel", "Carson", "Jaxon",
                                              "Tristan", "Luis", "Juan", "Hayden", "Carlos", "Jesus", "Nolan", "Cole", "Alex",
                                              "Max", "Grayson", "Bryson", "Diego", "Jaden", "Vincent", "Easton", "Eric", "Micah",
                                              "Kayden", "Jace", "Aidan", "Ryder", "Ashton", "Bryan", "Riley", "Hudson", "Asher",
                                              "Bryce", "Miles", "Kaleb", "Giovanni", "Antonio", "Kaden", "Colin", "Kyle",
                                              "Brian", "Timothy", "Steven", "Sean", "Miguel", "Richard", "Ivan", "Jake",
                                              "Alejandro", "Santiago", "Axel", "Joel", "Maxwell", "Brady", "Caden", "Preston",
                                              "Damian", "Elias", "Jaxson", "Jesse", "Victor", "Patrick", "Jonah", "Marcus",
                                              "Rylan", "Emmanuel", "Edward", "Leonardo", "Cayden", "Grant", "Jeremy", "Braxton",
                                              "Gage", "Jude", "Wesley", "Devin", "Roman", "Mark", "Camden", "Kaiden", "Oscar",
                                              "Alan", "Malachi", "George", "Peyton", "Leo", "Nicolas", "Maddox", "Kenneth",
                                              "Mateo", "Sawyer", "Collin", "Conner", "Cody", "Andres", "Declan", "Lincoln",
                                              "Bradley", "Trevor", "Derek", "Tanner", "Silas", "Eduardo", "Seth", "Jaiden",
                                              "Paul", "Jorge", "Cristian", "Garrett", "Travis", "Abraham", "Omar", "Javier",
                                              "Ezekiel", "Tucker", "Harrison", "Peter", "Damien", "Greyson", "Avery", "Kai",
                                              "Weston", "Ezra", "Xander", "Jaylen", "Corbin", "Fernando", "Calvin", "Jameson",
                                              "Francisco", "Maximus", "Josue", "Ricardo", "Shane", "Trenton", "Cesar", "Chance",
                                              "Drake", "Zane", "Israel", "Emmett", "Jayce", "Mario", "Landen", "Kingston",
                                              "Spencer", "Griffin", "Stephen", "Manuel", "Theodore", "Erick", "Braylon",
                                              "Raymond", "Edwin", "Charlie", "Abel", "Myles", "Bennett", "Johnathan", "Andre",
                                              "Alexis", "Edgar", "Troy", "Zion", "Jeffrey", "Hector", "Shawn", "Lukas", "Amir" };

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand)
        {
            return rand.Next(MaleFirstNames);
        }
    }
}