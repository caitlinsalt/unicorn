using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType.Tests.Utility.Extensions;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class SegmentSubheaderRecordCollectionUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static SegmentSubheaderRecord[] GetTestData()
        {
            int count = _rnd.Next(1, 20);
            SegmentSubheaderRecord[] data = new SegmentSubheaderRecord[count];

            for (int i = 0; i < count; ++i)
            {
                data[i] = _rnd.NextSegmentSubheaderRecord();
            }
            return data;
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void SegmentSubheaderRecordCollectionClass_Constructor_ReturnsObjectWithCountPropertyEqualToZero_IfParameterIsNull()
        {
            SegmentSubheaderRecordCollection testObject = new SegmentSubheaderRecordCollection(null);

            Assert.AreEqual(0, testObject.Count);
        }

        [TestMethod]
        public void SegmentSubheaderRecordCollectionClass_Constructor_ReturnsObjectWithCountPropertyEqualToZero_IfParameterIsEmptyEnumeration()
        {
            IEnumerable<SegmentSubheaderRecord> testParam = Array.Empty<SegmentSubheaderRecord>();

            SegmentSubheaderRecordCollection testObject = new SegmentSubheaderRecordCollection(testParam);

            Assert.AreEqual(0, testObject.Count);
        }

        [TestMethod]
        public void SegmentSubheaderRecordCollectionClass_Constructor_ReturnsObjectWithCorrectCountProperty_IfParameterIsNull()
        {
            SegmentSubheaderRecord[] testParam = GetTestData();

            SegmentSubheaderRecordCollection testOutput = new SegmentSubheaderRecordCollection(testParam);

            Assert.AreEqual(testParam.Length, testOutput.Count);
        }

        [TestMethod]
        public void SegmentSubheaderRecordCollectionClass_Indexer_ReturnsCorrectItems()
        {
            SegmentSubheaderRecord[] testParam = GetTestData();
            SegmentSubheaderRecordCollection testObject = new SegmentSubheaderRecordCollection(testParam);

            for (int i = 0; i < testObject.Count; ++i)
            {
                Assert.AreEqual(testParam[i], testObject[i]);
            }
        }

        [TestMethod]
        public void SegmentSubheaderRecordCollectionClass_Enumerator_ReturnsItemsInCorrectOrder()
        {
            SegmentSubheaderRecord[] testParam = GetTestData();
            SegmentSubheaderRecordCollection testObject = new SegmentSubheaderRecordCollection(testParam);
            int idx = 0;

            IEnumerator<SegmentSubheaderRecord> testEnumerator = testObject.GetEnumerator();

            while (testEnumerator.MoveNext())
            {
                Assert.AreEqual(testParam[idx++], testEnumerator.Current);
            }
        }
    }
}
