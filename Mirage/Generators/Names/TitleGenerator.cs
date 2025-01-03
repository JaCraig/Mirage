﻿using Mirage.Generators.BaseClasses;
using Mirage.Interfaces;

namespace Mirage.Generators.Names
{
    /// <summary>
    /// Title generator
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public sealed class TitleAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TitleAttribute()
            : base("", "")
        {
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IGenerator"/> is a default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public override bool Default => false;

        /// <summary>
        /// The job
        /// </summary>
        private static readonly string[] _Job = { "Supervisor",
        "Associate",
        "Executive",
        "Liaison",
        "Officer",
        "Manager",
        "Engineer",
        "Specialist",
        "Director",
        "Coordinator",
        "Administrator",
        "Architect",
        "Analyst",
        "Designer",
        "Planner",
        "Orchestrator",
        "Technician",
        "Developer",
        "Producer",
        "Consultant",
        "Assistant",
        "Facilitator",
        "Agent",
        "Representative",
        "Strategist"};

        private static readonly string[] _Prefix = { "Lead",
        "Senior",
        "Direct",
        "Corporate",
        "Dynamic",
        "Future",
        "Product",
        "National",
        "Regional",
        "District",
        "Central",
        "Global",
        "Customer",
        "Investor",
        "Dynamic",
        "International",
        "Legacy",
        "Forward",
        "Internal",
        "Human",
        "Chief",
        "Principal",
        "Junior"};

        /// <summary>
        /// The type name
        /// </summary>
        private static readonly string[] _TypeName = {"Solutions",
        "Program",
        "Brand",
        "Security",
        "Research",
        "Marketing",
        "Directives",
        "Implementation",
        "Integration",
        "Functionality",
        "Response",
        "Paradigm",
        "Tactics",
        "Identity",
        "Markets",
        "Group",
        "Division",
        "Applications",
        "Optimization",
        "Operations",
        "Infrastructure",
        "Intranet",
        "Communications",
        "Web",
        "Branding",
        "Quality",
        "Assurance",
        "Mobility",
        "Accounts",
        "Data",
        "Creative",
        "Configuration",
        "Accountability",
        "Interactions",
        "Factors",
        "Usability",
        "Metrics"};

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand) => rand is null ? "" : rand.Next(_Prefix) + " " + rand.Next(_TypeName) + " " + rand.Next(_Job);
    }
}