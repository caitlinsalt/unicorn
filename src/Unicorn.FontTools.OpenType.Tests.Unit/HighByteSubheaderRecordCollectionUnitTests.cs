using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType.Tests.Utility.Extensions;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class HighByteSubheaderRecordCollectionUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static HighByteSubheaderRecord[] GetTestData()
        {
            int count = _rnd.Next(1, 20);
            HighByteSubheaderRecord[] data = new HighByteSubheaderRecord[count];

            for (int i = 0; i < count; ++i)
            {
                data[i] = _rnd.NextHighByteSubheaderRecord();
            }
            return data;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void HighByteSubheaderRecordCollectionClass_Constructor_ReturnsObjectWithCountPropertyEqualToZero_IfParameterIsNull()
        {
            HighByteSubheaderRecordCollection testObject = new HighByteSubheaderRecordCollection(null);

            Assert.AreEqual(0, testObject.Count);
        }

        [TestMethod]
        public void HighByteSubheaderRecordCollectionClass_Constructor_ReturnsObjectWithCountPropertyEqualToZero_IfParameterIsEmptyEnumeration()
        {
            IEnumerable<HighByteSubheaderRecord> testParam = Array.Empty<HighByteSubheaderRecord>();

            HighByteSubheaderRecordCollection testObject = new HighByteSubheaderRecordCollection(testParam);

            Assert.AreEqual(0, testObject.Count);
        }

        [TestMethod]
        public void HighByteSubheaderRecordCollectionClass_Constructor_ReturnsObjectWithCorrectCountProperty_IfParameterIsNull()
        {
            HighByteSubheaderRecord[] testParam = GetTestData();

            HighByteSubheaderRecordCollection testOutput = new HighByteSubheaderRecordCollection(testParam);

            Assert.AreEqual(testParam.Length, testOutput.Count);
        }

        [TestMethod]
        public void HighByteSubheaderRecordCollectionClass_Indexer_ReturnsCorrectItems()
        {
            HighByteSubheaderRecord[] testParam = GetTestData();
            HighByteSubheaderRecordCollection testObject = new HighByteSubheaderRecordCollection(testParam);

            for (int i = 0; i < testObject.Count; ++i)
            {
                Assert.AreEqual(testParam[i], testObject[i]);
            }
        }

        [TestMethod]
        public void HighByteSubheaderRecordCollectionClass_Enumerator_ReturnsItemsInCorrectOrder()
        {
            HighByteSubheaderRecord[] testParam = GetTestData();
            HighByteSubheaderRecordCollection testObject = new HighByteSubheaderRecordCollection(testParam);
            int idx = 0;

            IEnumerator<HighByteSubheaderRecord> testEnumerator = testObject.GetEnumerator();

            while (testEnumerator.MoveNext())
            {
                Assert.AreEqual(testParam[idx++], testEnumerator.Current);
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
