using Mirage.Generators;
using Mirage.Generators.Default;
using Mirage.Generators.String;
using Mirage.Tests.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Mirage.Tests.Generators.Default
{
    public class ClassGeneratorTests : TestBaseClass<ClassGenerator<TestClass>>
    {
        public ClassGeneratorTests()
        {
            _Generator = new ClassGenerator<TestClass>();
            TestObject = new ClassGenerator<TestClass>();
        }

        private readonly ClassGenerator<TestClass> _Generator;

        [Fact]
        public void CanGenerateRandomClass()
        {
            // Arrange
            var Rand = new Random();

            // Act
            TestClass Result = _Generator.Next(Rand);

            // Assert
            Assert.NotNull(Result);
            _ = Assert.IsType<TestClass>(Result);
        }

        [Fact]
        public void CanGenerateRandomClassWithMinMax()
        {
            // Arrange
            var Rand = new Random();
            var Min = new TestClass();
            var Max = new TestClass();

            // Act
            TestClass Result = _Generator.Next(Rand, Min, Max);

            // Assert
            Assert.NotNull(Result);
            _ = Assert.IsType<TestClass>(Result);
        }

        [Fact]
        public void CanGenerateRandomClassWithPreviouslySeen()
        {
            // Arrange
            var Rand = new Random();
            var PreviouslySeen = new List<object>();

            // Act
            var Result = _Generator.NextObj(Rand, PreviouslySeen);

            // Assert
            Assert.NotNull(Result);
            _ = Assert.IsType<TestClass>(Result);
        }

        [Fact]
        public void GeneratedClassHasValidProperties()
        {
            // Arrange
            var Rand = new Random(10);

            // Act
            TestClass Result = _Generator.Next(Rand);

            // Assert
            Assert.NotNull(Result);
            Assert.All(Result.GetType().GetProperties(), property =>
            {
                var ValidationAttributes = property.GetCustomAttributes(typeof(ValidationAttribute), true);
                Assert.All(ValidationAttributes, _ =>
                {
                    var ValidationContext = new ValidationContext(Result) { MemberName = property.Name };
                    var ActualValue = property.GetValue(Result);
                    Assert.True(Validator.TryValidateProperty(ActualValue, ValidationContext, null));
                });
            });
        }
    }

    public class TestClass
    {
        [Range(1, 100)]
        [IntGenerator(1, 100)]
        public int Age { get; set; }

        [Required]
        [StringGenerator(10)]
        public string Name { get; set; }
    }
}