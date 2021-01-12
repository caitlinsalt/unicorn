using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType.Tests.Utility.Extensions;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class NameRecordCollectionUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static NameRecord[] GetTestData()
        {
            int count = _rnd.Next(1, 20);
            NameRecord[] data = new NameRecord[count];

            for (int i = 0; i < count; ++i)
            {
                data[i] = _rnd.NextNameRecord();
            }
            return data;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void NameRecordCollectionClass_Constructor_ReturnsObjectWithCountPropertyEqualToZero_IfParameterIsNull()
        {
            NameRecordCollection testObject = new NameRecordCollection(null);

            Assert.AreEqual(0, testObject.Count);
        }

        [TestMethod]
        public void NameRecordCollectionClass_Constructor_ReturnsObjectWithCountPropertyEqualToZero_IfParameterIsEmptyEnumeration()
        {
            IEnumerable<NameRecord> testParam = Array.Empty<NameRecord>();

            NameRecordCollection testObject = new NameRecordCollection(testParam);

            Assert.AreEqual(0, testObject.Count);
        }

        [TestMethod]
        public void NameRecordCollectionClass_Constructor_ReturnsObjectWithCorrectCountProperty_IfParameterIsNull()
        {
            NameRecord[] testParam = GetTestData();

            NameRecordCollection testOutput = new NameRecordCollection(testParam);

            Assert.AreEqual(testParam.Length, testOutput.Count);
        }

        [TestMethod]
        public void NameRecordCollectionClass_Indexer_ReturnsCorrectItems()
        {
            NameRecord[] testParam = GetTestData();
            NameRecordCollection testObject = new NameRecordCollection(testParam);

            for (int i = 0; i < testObject.Count; ++i)
            {
                Assert.AreEqual(testParam[i], testObject[i]);
            }
        }

        [TestMethod]
        public void NameRecordCollectionClass_Enumerator_ReturnsItemsInCorrectOrder()
        {
            NameRecord[] testParam = GetTestData();
            NameRecordCollection testObject = new NameRecordCollection(testParam);
            int idx = 0;

            IEnumerator<NameRecord> testEnumerator = testObject.GetEnumerator();

            while (testEnumerator.MoveNext())
            {
                Assert.AreEqual(testParam[idx++], testEnumerator.Current);
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
