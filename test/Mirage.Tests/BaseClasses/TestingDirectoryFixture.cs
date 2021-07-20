using Mecha.Core;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Mirage.Tests.BaseClasses
{
    /// <summary>
    /// Test base class
    /// </summary>
    /// <typeparam name="TTestObject">The type of the test object.</typeparam>
    public abstract class TestBaseClass<TTestObject> : TestBaseClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestBaseClass{TTestObject}"/> class.
        /// </summary>
        protected TestBaseClass()
        {
            ObjectType = null;
        }

        /// <summary>
        /// Gets the type of the object.
        /// </summary>
        /// <value>The type of the object.</value>
        protected override Type ObjectType { get; }

        /// <summary>
        /// Gets or sets the test object.
        /// </summary>
        /// <value>The test object.</value>
        protected TTestObject TestObject { get; set; }

        /// <summary>
        /// Attempts to break the object.
        /// </summary>
        /// <returns>The async task.</returns>
        [Fact]
        public Task BreakObject()
        {
            return Mech.BreakAsync(TestObject, new Options
            {
                MaxDuration = 1000,
                DiscoverInheritedMethods = false,
                ExceptionHandlers = new ExceptionHandler().IgnoreException<ArgumentOutOfRangeException>((_, __) => true)
                .IgnoreException<OutOfMemoryException>((_, __) => true)
                .IgnoreException<OverflowException>((_, __) => true)
            });
        }
    }

    /// <summary>
    /// Test base class
    /// </summary>
    public abstract class TestBaseClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestBaseClass{TTestObject}"/> class.
        /// </summary>
        protected TestBaseClass()
        {
            lock (LockObject)
            {
                _ = Mech.Default;
            }
        }

        /// <summary>
        /// Gets the type of the object.
        /// </summary>
        /// <value>The type of the object.</value>
        protected abstract Type ObjectType { get; }

        /// <summary>
        /// The lock object
        /// </summary>
        private static readonly object LockObject = new();

        /// <summary>
        /// Attempts to break the object.
        /// </summary>
        /// <returns>The async task.</returns>
        [Fact]
        public Task BreakType()
        {
            return Mech.BreakAsync(ObjectType, new Options { MaxDuration = 1000 });
        }
    }
}