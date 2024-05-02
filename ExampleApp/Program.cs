using BigBook;
using Microsoft.Extensions.DependencyInjection;
using Mirage.Generators;
using Mirage.Generators.ContactInfo;
using Mirage.Generators.Default;
using Mirage.Generators.Names;
using System;
using System.Collections.Generic;

namespace ExampleApp
{
    /// <summary>
    /// Role class
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Title]
        public string Name { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents this instance.</returns>
        public override string ToString() => Name;
    }

    /// <summary>
    /// User class
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the hashed password.
        /// </summary>
        /// <value>The hashed password.</value>
        [Pattern("@@#@#@#@#@@#@#@#@#@#@#@#@#@#@#@#@#@#")]
        public string HashedPassword { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        [ListGenerator(typeof(Role), 1, 5)]
        public List<Role> Roles { get; set; } = new List<Role>();

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [EmailAddress]
        public string UserName { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents this instance.</returns>
        public override string ToString() => $"{UserName} : {Roles.ToString(x => x.ToString())}";
    }

    /// <summary>
    /// Main program class
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            // Wire up Mirage and other libraries using Canister.
            _ = new ServiceCollection().AddCanisterModules()?.BuildServiceProvider();

            // Create a new instance of the random generator and generate 1000 random users.
            var RandomGenerator = new Mirage.Random();
            for (var x = 0; x < 10; ++x)
            {
                // Generate a new user
                User NewUser = RandomGenerator.Next<User>();
                // Write the user to the console
                Console.WriteLine(NewUser);
            }
        }
    }
}