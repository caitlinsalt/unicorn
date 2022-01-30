using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Exceptions;

namespace Unicorn.Tests.Unit.Exceptions
{
    [TestClass]
    public class InvalidImageExceptionUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void InvalidImageException_ParameterlessConstructor_CreatesObjectWithInnerExceptionNull()
        {
            InvalidImageException testOutput = new();

            Assert.IsNull(testOutput.InnerException);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void InvalidImageException_ConstructorWithStringParameter_SetsMessagePropertyToParameter()
        {
            string testParam = _rnd.NextString(_rnd.Next(50));

            InvalidImageException testOutput = new(testParam);

            Assert.AreEqual(testParam, testOutput.Message);
        }

        [TestMethod]
        public void InvalidImageException_ConstructorWithStringParameter_CreatesObjectWithInnerExceptionNull()
        {
            string testParam = _rnd.NextString(_rnd.Next(50));

            InvalidImageException testOutput = new(testParam);

            Assert.IsNull(testOutput.InnerException);
        }

#pragma warning disable CA2201 // Do not raise reserved exception types

        [TestMethod]
        public void InvalidImageException_ConstructorWithStringAndExceptionParameters_SetsMessagePropertyToFirstParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(50));
            Exception testParam1 = new();

            InvalidImageException testOutput = new(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.Message);
        }

        [TestMethod]
        public void InvalidImageException_ConstructorWithStringAndExceptionParameters_SetsInnerExceptionPropertyToSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(50));
            Exception testParam1 = new();

            InvalidImageException testOutput = new(testParam0, testParam1);

            Assert.AreSame(testParam1, testOutput.InnerException);
        }

#pragma warning restore CA2201 // Do not raise reserved exception types

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
