# Mirage

[![Build status](https://ci.appveyor.com/api/projects/status/auo9ubhxab10lqv6?svg=true)](https://ci.appveyor.com/project/JaCraig/mirage)

Mirage is an open source library for .Net designed to create random data for POCOs, unit tests, etc. Supports .Net Core as well as full .Net.

## Setting Up the Library

Mirage relies on [Canister](https://github.com/JaCraig/Canister) in order to hook itself up. In order for this to work, you must do the following at startup:

    Canister.Builder.CreateContainer(new List<ServiceDescriptor>())
                    .RegisterMirage()
                    .Build();
					
The RegisterMirage function is an extension method that registers it with the IoC container. When this is done, Mirage is ready to use.

## Basic Usage

The main class of interest is the Random class:

    Mirage.Random RandomObj = new Mirage.Random();
	
This class has a number of helper functions including a generic Next function:

    RandomObj.Next<short>();
	RandomObj.Next<float>();
	RandomObj.Next<TimeSpan>();
	
You can also Specify a number of items that you want returned:

    var MyList = RandomObj.Next<short>(4);
	
The MyList object would contain four shorts. You can similarly pull a random item from a list:

    var Item = RandomObj.Next(MyList);
	
This would return a random short from the MyList object specified above. Or you can simply shuffle a list into a random order:

    MyList = RandomObj.Shuffle(MyList);
	
There is also a thread safe version of Next that is available:

    var RandomValue=RandomObj.ThreadSafeNext();
	
Lastly you can randomly generate an entire class as needed:

    public class RandomTestClass
    {
        [IntGenerator(-100, 100)]
        public int A { get; set; }

        [LoremIpsum]
        public string B { get; set; }

        [FloatGenerator(0, 1)]
        public float C { get; set; }

        [IntGenerator(1, 100)]
        public int D { get; set; }
    }
	
	...
	
	var Rand = new Mirage.Random();
	var Class = Rand.Next<RandomTestClass>();
	
This will create an object of the type specified and randomly assign values to the properties based on the attributes placed on them. The system has one for all of the basic types as well as a number of string generators including:

1. Company
2. Full Address
3. City
4. Domain name
5. Email address
6. Phone number
7. State abbreviation
8. State
9. Zip Code
10. Street Address
11. Female/male first name
12. Last name
13. Female/Male name
14. Female/male prefix
15. Name suffix
16. Full name generator that is male/female/either
17. Lorem Ipsum
18. Pattern based
19. Regex based
20. ["Problem" strings](https://github.com/minimaxir/big-list-of-naughty-strings)


## Adding Your Own Generator

You may wish to create your own random generator or replace one that is already in the system. In order to do this simply create a class that implements the IGenerator class. Simply specify in the class what type it generates and the system will either add it to the list of generators or replace the existing one with your own. In order to have this new class be picked up, you must add the assembly that it is in to Canister:

    Canister.Builder.CreateContainer(new List<ServiceDescriptor>())
                    .RegisterMirage()
					.AddAssembly(typeof(MyTypeGenerator).GetTypeInfo().Assembly)
                    .Build();

The system will then pick it up automatically and call it as requested. Similarly if you wish for it to be picked up when generating a class, make sure your class inherits from GeneratorAttributeBase. If it does, the random class generation will pick it up.

## Installation

The library is available via Nuget with the package name "Mirage". To install it run the following command in the Package Manager Console:

Install-Package Mirage

## Build Process

In order to build the library you will require the following:

1. Visual Studio 2017

Other than that, just clone the project and you should be able to load the solution and build without too much effort.

## Other Info

The problem strings generator is based off of the Max Woolf's ["Big List of Naughty Strings"](https://github.com/minimaxir/big-list-of-naughty-strings) which is MIT licensed.