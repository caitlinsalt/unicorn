using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Exceptions;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Unicorn.FontTools.Tests.Unit
{
    [TestClass]
    public class FontExceptionUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void FontExceptionClass_ParameterlessConstructor_RetutnsObjectWithInnerExceptionPropertyEqualToNull()
        {
            FontException testOutput = new FontException();

            Assert.IsNull(testOutput.InnerException);
        }

        [TestMethod]
        public void FontExceptionClass_ConstructorWithStringParameter_ReturnsObjectWithMessagePropertyEqualToParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(255));

            FontException testOutput = new FontException(testParam0);

            Assert.AreEqual(testParam0, testOutput.Message);
        }

        [TestMethod]
        public void FontExceptionClass_ConstructorWithStringParameter_RetutnsObjectWithInnerExceptionPropertyEqualToNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(255));

            FontException testOutput = new FontException(testParam0);

            Assert.IsNull(testOutput.InnerException);
        }

        [TestMethod]
        public void FontExceptionClass_ConstructorWithStringAndExceptionParameters_ReturnsObjectWithMessagePropertyEqualToFirstParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(255));
            Exception testParam1 = new TestException();

            FontException testOutput = new FontException(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.Message);
        }

        [TestMethod]
        public void FontExceptionClass_ConstructorWithStringAndExceptionParameters_ReturnsObjectWithInnerExceptionPropertyThatIsSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(255));
            Exception testParam1 = new TestException();

            FontException testOutput = new FontException(testParam0, testParam1);

            Assert.AreSame(testParam1, testOutput.InnerException);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
