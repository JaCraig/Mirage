﻿/*
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
using BigBook.ExtensionMethods;
using Mirage.Generators.BaseClasses;
using Mirage.Interfaces;
using System.Text;

namespace Mirage.Generators
{
    /// <summary>
    /// Lorem Ipsum Generator
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public sealed class LoremIpsumAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="numberOfParagraphs">Number of paragraphs</param>
        /// <param name="numberOfSentences">Number of sentences per paragraph</param>
        /// <param name="minSentenceLength">Minimum sentence length</param>
        /// <param name="maxSentenceLength">Maximum sentence length</param>
        public LoremIpsumAttribute(int numberOfParagraphs = 1, int numberOfSentences = 1,
            int minSentenceLength = 4, int maxSentenceLength = 10)
            : base("", "")
        {
            NumberOfParagraphs = numberOfParagraphs;
            NumberOfSentences = numberOfSentences;
            MinSentenceLength = minSentenceLength;
            MaxSentenceLength = maxSentenceLength;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IGenerator"/> is a default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public override bool Default => false;

        /// <summary>
        /// Maximum sentence length
        /// </summary>
        public int MaxSentenceLength { get; }

        /// <summary>
        /// Minimum sentence length
        /// </summary>
        public int MinSentenceLength { get; }

        /// <summary>
        /// Number of paragraphs
        /// </summary>
        public int NumberOfParagraphs { get; }

        /// <summary>
        /// Number of sentences
        /// </summary>
        public int NumberOfSentences { get; }

        private static readonly string[] _Words = { "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod",
        "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua",
        "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita",
        "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet",
        "lorem", "ipsum", "dolor", "sit", "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod",
        "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua",
        "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita",
        "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet",
        "lorem", "ipsum", "dolor", "sit", "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod",
        "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua",
        "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita",
        "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "duis",
        "autem", "vel", "eum", "iriure", "dolor", "in", "hendrerit", "in", "vulputate", "velit", "esse", "molestie",
        "consequat", "vel", "illum", "dolore", "eu", "feugiat", "nulla", "facilisis", "at", "vero", "eros", "et",
        "accumsan", "et", "iusto", "odio", "dignissim", "qui", "blandit", "praesent", "luptatum", "zzril", "delenit",
        "augue", "duis", "dolore", "te", "feugait", "nulla", "facilisi", "lorem", "ipsum", "dolor", "sit", "amet",
        "consectetuer", "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod", "tincidunt", "ut", "laoreet",
        "dolore", "magna", "aliquam", "erat", "volutpat", "ut", "wisi", "enim", "ad", "minim", "veniam", "quis",
        "nostrud", "exerci", "tation", "ullamcorper", "suscipit", "lobortis", "nisl", "ut", "aliquip", "ex", "ea",
        "commodo", "consequat", "duis", "autem", "vel", "eum", "iriure", "dolor", "in", "hendrerit", "in", "vulputate",
        "velit", "esse", "molestie", "consequat", "vel", "illum", "dolore", "eu", "feugiat", "nulla", "facilisis", "at",
        "vero", "eros", "et", "accumsan", "et", "iusto", "odio", "dignissim", "qui", "blandit", "praesent", "luptatum",
        "zzril", "delenit", "augue", "duis", "dolore", "te", "feugait", "nulla", "facilisi", "nam", "liber", "tempor",
        "cum", "soluta", "nobis", "eleifend", "option", "congue", "nihil", "imperdiet", "doming", "id", "quod", "mazim",
        "placerat", "facer", "possim", "assum", "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer", "adipiscing",
        "elit", "sed", "diam", "nonummy", "nibh", "euismod", "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam",
        "erat", "volutpat", "ut", "wisi", "enim", "ad", "minim", "veniam", "quis", "nostrud", "exerci", "tation",
        "ullamcorper", "suscipit", "lobortis", "nisl", "ut", "aliquip", "ex", "ea", "commodo", "consequat", "duis",
        "autem", "vel", "eum", "iriure", "dolor", "in", "hendrerit", "in", "vulputate", "velit", "esse", "molestie",
        "consequat", "vel", "illum", "dolore", "eu", "feugiat", "nulla", "facilisis", "at", "vero", "eos", "et", "accusam",
        "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea",
        "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor", "sit",
        "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut",
        "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua", "at", "vero", "eos", "et",
        "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no",
        "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor", "sit",
        "amet", "consetetur", "sadipscing", "elitr", "at", "accusam", "aliquyam", "diam", "diam", "dolore", "dolores",
        "duo", "eirmod", "eos", "erat", "et", "nonumy", "sed", "tempor", "et", "et", "invidunt", "justo", "labore",
        "stet", "clita", "ea", "et", "gubergren", "kasd", "magna", "no", "rebum", "sanctus", "sea", "sed", "takimata",
        "ut", "vero", "voluptua", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor", "sit",
        "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut",
        "labore", "et", "dolore", "magna", "aliquyam", "erat", "consetetur", "sadipscing", "elitr", "sed", "diam",
        "nonumy", "eirmod", "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed",
        "diam", "voluptua", "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea",
        "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum" };

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand)
        {
            var Builder = new StringBuilder();
            _ = Builder.Append("Lorem ipsum dolor sit amet. ");
            for (var y = 1; y < NumberOfSentences; ++y)
                _ = Builder.Append(NextSentence(rand, rand.Next(MinSentenceLength, MaxSentenceLength))).Append(' ');
            for (var x = 1; x < NumberOfParagraphs; ++x)
            {
                for (var y = 0; y < NumberOfSentences; ++y)
                    _ = Builder.Append(NextSentence(rand, rand.Next(MinSentenceLength, MaxSentenceLength))).Append(' ');
                _ = Builder.AppendLine().AppendLine();
            }
            return Builder.ToString();
        }

        /// <summary>
        /// Creates a Lorem Ipsum sentence.
        /// </summary>
        /// <param name="rand">Random number generator using</param>
        /// <param name="numberOfWords">Number of words for the sentence</param>
        /// <returns>A string containing Lorem Ipsum text</returns>
        private static string NextSentence(Random rand, int numberOfWords)
        {
            var Builder = new StringBuilder();
            _ = Builder.Append(_Words[rand.Next(_Words.Length)].ToString(StringCase.FirstCharacterUpperCase));
            for (var x = 1; x < numberOfWords; ++x)
                _ = Builder.Append(' ').Append(_Words[rand.Next(_Words.Length)]);
            _ = Builder.Append('.');
            return Builder.ToString();
        }
    }
}