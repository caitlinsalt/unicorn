using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Exceptions;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class OpenTypeFormatExceptionUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void OpenTypeFormatExceptionClass_ParameterlessConstructor_SetsInnerExceptionPropertyToNull()
        {
            OpenTypeFormatException testOutput = new OpenTypeFormatException();

            Assert.IsNull(testOutput.InnerException);
        }

        [TestMethod]
        public void OpenTypeFormatExceptionClass_ConstructorWithStringParameter_SetsMessagePropertyToEqualParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(128));

            OpenTypeFormatException testOutput = new OpenTypeFormatException(testParam0);

            Assert.AreEqual(testParam0, testOutput.Message);
        }

        [TestMethod]
        public void OpenTypeFormatExceptionClass_ConstructorWithStringParameter_SetsInnerExceptionPropertyToNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(128));

            OpenTypeFormatException testOutput = new OpenTypeFormatException(testParam0);

            Assert.IsNull(testOutput.InnerException);
        }

        [TestMethod]
        public void OpenTypeFormatExceptionClass_ConstructorWithStringAndExceptionParameters_SetsMessagePropertyToEqualFirstParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(128));
            Exception testParam1 = new TestException();

            OpenTypeFormatException testOutput = new OpenTypeFormatException(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.Message);
        }

        [TestMethod]
        public void OpenTypeFormatExceptionClass_ConstructorWithStringAndExceptionParameters_SetsInnerExceptionPropertyToSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(128));
            Exception testParam1 = new TestException();

            OpenTypeFormatException testOutput = new OpenTypeFormatException(testParam0, testParam1);

            Assert.AreSame(testParam1, testOutput.InnerException);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
