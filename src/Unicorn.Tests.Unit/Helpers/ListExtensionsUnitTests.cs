using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Helpers;

namespace Unicorn.Tests.Unit.Helpers
{
    [TestClass]
    public class ListExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private List<string> _testParam0;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void TestSetup()
        {
            int count = _rnd.Next(1, 50);
            _testParam0 = new List<string>(count);
            for (int i = 0; i < count; ++i)
            {
                _testParam0.Add(_rnd.NextString(_rnd.Next(32)));
            }
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ListExtensionsClass_RemoveAfterMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            List<string> testParam0 = null;
            int testParam1 = _rnd.Next();

            testParam0.RemoveAfter(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListExtensionsClass_RemoveAfterMethod_ThrowsArgumentOutOfRangeException_IfSecondParameterIsLessThanZero()
        {
            int testParam1 = _rnd.Next(int.MinValue, 0);

            _testParam0.RemoveAfter(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListExtensionsClass_RemoveAfterMethod_ThrowsArgumentOutOfRangeException_IfSecondParameterIsEqualToCountPropertyOfFirstParameter()
        {
            int testParam1 = _testParam0.Count;

            _testParam0.RemoveAfter(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListExtensionsClass_RemoveAfterMethod_ThrowsArgumentOutOfRangeException_IfSecondParameterIsGreaterThanCountPropertyOfFirstParameter()
        {
            int testParam1 = _rnd.Next(_testParam0.Count, int.MaxValue);

            _testParam0.RemoveAfter(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ListExtensionsClass_RemoveAfterMethod_RemovesAllElementsFromFirstParameter_IfSecondParameterIsZero()
        {
            int testParam1 = 0;

            _testParam0.RemoveAfter(testParam1);

            Assert.IsFalse(_testParam0.Any());
        }

        [TestMethod]
        public void ListExtensionsClass_RemoveAfterMethod_ChangesCountPropertyOfFirstParameterToEqualSecondParameter_IfSecondParameterIsWithinValidRange()
        {
            int testParam1 = _rnd.Next(_testParam0.Count);

            _testParam0.RemoveAfter(testParam1);

            Assert.AreEqual(testParam1, _testParam0.Count);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores
#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
