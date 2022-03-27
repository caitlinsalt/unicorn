using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Exceptions;

namespace Unicorn.Tests.Unit.Exceptions
{
    [TestClass]
    public class PageClosedExceptionUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void PageClosedException_ParameterlessConstructor_CreatesObjectWithInnerExceptionNull()
        {
            PageClosedException testOutput = new();

            Assert.IsNull(testOutput.InnerException);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void PageClosedException_ConstructorWithStringParameter_SetsMessagePropertyToParameter()
        {
            string testParam = _rnd.NextString(_rnd.Next(50));

            PageClosedException testOutput = new(testParam);

            Assert.AreEqual(testParam, testOutput.Message);
        }

        [TestMethod]
        public void PageClosedException_ConstructorWithStringParameter_CreatesObjectWithInnerExceptionNull()
        {
            string testParam = _rnd.NextString(_rnd.Next(50));

            PageClosedException testOutput = new(testParam);

            Assert.IsNull(testOutput.InnerException);
        }

#pragma warning disable CA2201 // Do not raise reserved exception types

        [TestMethod]
        public void PageClosedException_ConstructorWithStringAndExceptionParameters_SetsMessagePropertyToFirstParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(50));
            Exception testParam1 = new();

            PageClosedException testOutput = new(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.Message);
        }

        [TestMethod]
        public void PageClosedException_ConstructorWithStringAndExceptionParameters_SetsInnerExceptionPropertyToSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(50));
            Exception testParam1 = new();

            PageClosedException testOutput = new(testParam0, testParam1);

            Assert.AreSame(testParam1, testOutput.InnerException);
        }

#pragma warning restore CA2201 // Do not raise reserved exception types

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
