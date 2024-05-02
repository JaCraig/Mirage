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
using Mirage.Generators.Names;
using Mirage.Interfaces;

namespace Mirage.Generators.ContactInfo
{
    /// <summary>
    /// Email Address Generator
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public sealed class EmailAddressAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commonEndings">if set to <c>true</c> [common endings].</param>
        public EmailAddressAttribute(bool commonEndings = true)
            : base("", "")
        {
            CommonEndings = commonEndings;
        }

        /// <summary>
        /// Should common domain name endings be used?
        /// </summary>
        public bool CommonEndings { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IGenerator"/> is a default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public override bool Default => false;

        /// <summary>
        /// The endings
        /// </summary>
        private static readonly string[] _Endings = { ".ag", ".am", ".as", ".at", ".az", ".be", ".bi", ".bs", ".cc", ".cf", ".cg", ".ch", ".co.at", ".co.ck", ".co.gg", ".co.il", ".co.je", ".co.ma", ".co.mu", ".co.mz", ".co.nz", ".co.pn", ".co.ro", ".co.tt", ".co.uk", ".co.vi", ".co.za", ".com", ".com.ag", ".com.ar", ".com.az", ".com.bs", ".com.dm", ".com.do", ".com.ec", ".com.fj", ".com.gd", ".com.gi", ".com.gt", ".com.gy", ".com.jm", ".com.kh", ".com.kn", ".com.lc", ".com.lk", ".com.lv", ".com.ly", ".com.mx", ".com.nf", ".com.ni", ".com.pa", ".com.pe", ".com.ph", ".com.pl", ".com.pr", ".com.pt", ".com.ro", ".com.ru", ".com.sb", ".com.sc", ".com.tj", ".com.tp", ".com.ua", ".com.ve", ".cx", ".cz", ".dk", ".fm", ".gd", ".gen.tr", ".gg", ".gl", ".gs", ".gy", ".hm", ".io", ".je", ".jp", ".kg", ".kn", ".kz", ".li", ".lk", ".lt", ".lv", ".ly", ".ma", ".md", ".ms", ".mu", ".mw", ".net", ".net.tp", ".nu", ".off.ai", ".org", ".org.tp", ".org.uk", ".ph", ".pl", ".ro", ".ru", ".rw", ".sc", ".sh", ".sn", ".st", ".tc", ".tf", ".tj", ".to", ".tp", ".tt", ".uz", ".vg", ".vu", ".ws" };

        /// <summary>
        /// The free accounts
        /// </summary>
        private static readonly string[] _FreeAccounts = { "gmail", "yahoo", "hotmail" };

        /// <summary>
        /// The most common endings
        /// </summary>
        private static readonly string[] _MostCommonEndings = { ".com", ".net", ".org" };

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand)
        {
            var DomainName = rand.Next<bool>() ?
                rand.Next(_FreeAccounts) + (CommonEndings ? rand.Next(_MostCommonEndings) : rand.Next(_Endings)) :
                new DomainNameAttribute(CommonEndings).Next(rand);
            var AddressStyle = rand.Next(1, 6);
            return AddressStyle == 1
                ? new NameAttribute().Next(rand).Replace(" ", ".") + "@" + DomainName
                : AddressStyle == 2
                ? new NameAttribute(false, true, true, false).Next(rand).Replace(" ", ".") + "@" + DomainName
                : AddressStyle == 3
                ? rand.Next('a', 'z') + "." + new LastNameAttribute().Next(rand) + "@" + DomainName
                : AddressStyle == 4
                ? new NameAttribute(false, false, false, false).Next(rand).Replace(" ", ".") + "@" + DomainName
                : rand.Next('a', 'z') + "." + rand.Next('a', 'z') + "." + new LastNameAttribute().Next(rand) + "@" + DomainName;
        }
    }
}