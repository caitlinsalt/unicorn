using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Exceptions;

namespace Unicorn.Tests.Unit.Exceptions
{
    [TestClass]
    public class DrawableSplitExceptionUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DrawableSplitExceptionClass_ParameterlessConstructor_CreatesObjectWithInnerExceptionPropertyNull()
        {
            DrawableSplitException testObject = new();

            Assert.IsNull(testObject.InnerException);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void DrawableSplitExceptionClass_ConstructorWithStringParameter_CreatesObjectWithMessagePropertyEqualToParameter()
        {
            string testParameter = _rnd.NextString(_rnd.Next(50));

            DrawableSplitException testObject = new(testParameter);

            Assert.AreEqual(testParameter, testObject.Message);
        }

        [TestMethod]
        public void DrawableSplitExceptionClass_ConstructorWithStringParameter_CreatesObjectWithInnerExceptionPropertyNull()
        {
            string testParameter = _rnd.NextString(_rnd.Next(50));

            DrawableSplitException testObject = new(testParameter);

            Assert.IsNull(testObject.InnerException);
        }

#pragma warning disable CA2201 // Do not raise reserved exception types

        [TestMethod]
        public void DrawableSplitExceptionClass_ConstructorWithStringAndExceptionParameters_CreatesObjectWithMessagePropertyEqualToFirstParameter()
        {
            string testParameter0 = _rnd.NextString(_rnd.Next(50));
            Exception testParameter1 = new();

            DrawableSplitException testObject = new(testParameter0, testParameter1);

            Assert.AreEqual(testParameter0, testObject.Message);
        }

        [TestMethod]
        public void DrawableSplitExceptionClass_ConstructorWithStringAndExceptionParameters_CreatesObjectWithInnerExceptionPropertySameAsSecondParameter()
        {
            string testParameter0 = _rnd.NextString(_rnd.Next(50));
            Exception testParameter1 = new();

            DrawableSplitException testObject = new(testParameter0, testParameter1);

            Assert.AreSame(testParameter1, testObject.InnerException);
        }

#pragma warning restore CA2201 // Do not raise reserved exception types

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
