using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Tests.Unit.Mocks;

namespace Unicorn.Writer.Tests.Unit.Extensions
{
    [TestClass]
    public class IListExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static string[] GetStringData()
        {
            int len = _rnd.Next(100);
            string[] data = new string[len];
            for (int i = 0; i < len; ++i)
            {
                data[i] = _rnd.NextString(_rnd.Next(25));
            }
            return data;
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IListExtensionsClass_AddRangeMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            IList<string> testParam0 = null;
            IEnumerable<string> testParam1 = Array.Empty<string>();

            testParam0.AddRange(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IListExtensionsClass_AddRangeMethod_ThrowsArgumentNullException_IfFirstParameterIsAListAndSecondParameterIsNull()
        {
            IList<string> testParam0 = new List<string>();
            IEnumerable<string> testParam1 = null;

            testParam0.AddRange(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IListExtensionsClass_AddRangeMethod_ThrowsArgumentNullException_IfFirstParameterIsNotAListAndSecondParameterIsNull()
        {
            IList<string> testParam0 = new MockList<string>();
            IEnumerable<string> testParam1 = null;

            testParam0.AddRange(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void IListExtensionsClass_AddRangeMethod_ChangesLengthOfFirstParameterToExpectedValue_IfFirstParameterIsAListAndSecondParameterIsNotNull()
        {
            string[] baseData0 = GetStringData();
            string[] baseData1 = GetStringData();
            IList<string> testParam0 = baseData0.ToList();
            IEnumerable<string> testParam1 = baseData1.ToArray();

            testParam0.AddRange(testParam1);

            Assert.AreEqual(baseData0.Length + baseData1.Length, testParam0.Count);
        }

        [TestMethod]
        public void IListExtensionsClass_AddRangeMethod_ChangesLengthOfFirstParameterToExpectedValue_IfFirstParameterIsNotAListAndSecondParameterIsNotNull()
        {
            string[] baseData0 = GetStringData();
            string[] baseData1 = GetStringData();
            IList<string> testParam0 = MockList<string>.FromEnumerable(baseData0);
            IEnumerable<string> testParam1 = baseData1.ToArray();

            testParam0.AddRange(testParam1);

            Assert.AreEqual(baseData0.Length + baseData1.Length, testParam0.Count);
        }

        [TestMethod]
        public void IListExtensionsClass_AddRangeMethod_LeavesFirstParameterWithExpectedContent_IfFirstParameterIsAListAndSecondParameterIsNotNull()
        {
            string[] baseData0 = GetStringData();
            string[] baseData1 = GetStringData();
            IList<string> testParam0 = baseData0.ToList();
            IEnumerable<string> testParam1 = baseData1.ToArray();

            testParam0.AddRange(testParam1);

            for (int i = 0; i < baseData0.Length; ++i)
            {
                Assert.AreEqual(baseData0[i], testParam0[i]);
            }
            for (int i = 0; i < baseData1.Length; ++i)
            {
                Assert.AreEqual(baseData1[i], testParam0[baseData0.Length + i]);
            }
        }

        [TestMethod]
        public void IListExtensionsClass_AddRangeMethod_LeavesFirstParameterWithExpectedContent_IfFirstParameterIsNotAListAndSecondParameterIsNotNull()
        {
            string[] baseData0 = GetStringData();
            string[] baseData1 = GetStringData();
            IList<string> testParam0 = MockList<string>.FromEnumerable(baseData0);
            IEnumerable<string> testParam1 = baseData1.ToArray();

            testParam0.AddRange(testParam1);

            for (int i = 0; i < baseData0.Length; ++i)
            {
                Assert.AreEqual(baseData0[i], testParam0[i]);
            }
            for (int i = 0; i < baseData1.Length; ++i)
            {
                Assert.AreEqual(baseData1[i], testParam0[baseData0.Length + i]);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
