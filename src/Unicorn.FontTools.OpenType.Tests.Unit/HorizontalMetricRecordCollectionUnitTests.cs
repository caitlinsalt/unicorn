using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType.Tests.Utility.Extensions;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class HorizontalMetricRecordCollectionUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static HorizontalMetricRecord[] GetTestData()
        {
            int count = _rnd.Next(1, 20);
            HorizontalMetricRecord[] data = new HorizontalMetricRecord[count];

            for (int i = 0; i < count; ++i)
            {
                data[i] = _rnd.NextHorizontalMetricRecord();
            }
            return data;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void HorizontalMetricRecordCollectionClass_Constructor_ReturnsObjectWithCountPropertyEqualToZero_IfParameterIsNull()
        {
            HorizontalMetricRecordCollection testObject = new HorizontalMetricRecordCollection(null);

            Assert.AreEqual(0, testObject.Count);
        }

        [TestMethod]
        public void HorizontalMetricRecordCollectionClass_Constructor_ReturnsObjectWithCountPropertyEqualToZero_IfParameterIsEmptyEnumeration()
        {
            IEnumerable<HorizontalMetricRecord> testParam = Array.Empty<HorizontalMetricRecord>();

            HorizontalMetricRecordCollection testObject = new HorizontalMetricRecordCollection(testParam);

            Assert.AreEqual(0, testObject.Count);
        }

        [TestMethod]
        public void HorizontalMetricRecordCollectionClass_Constructor_ReturnsObjectWithCorrectCountProperty_IfParameterIsNull()
        {
            HorizontalMetricRecord[] testParam = GetTestData();

            HorizontalMetricRecordCollection testOutput = new HorizontalMetricRecordCollection(testParam);

            Assert.AreEqual(testParam.Length, testOutput.Count);
        }

        [TestMethod]
        public void HorizontalMetricRecordCollectionClass_Indexer_ReturnsCorrectItems()
        {
            HorizontalMetricRecord[] testParam = GetTestData();
            HorizontalMetricRecordCollection testObject = new HorizontalMetricRecordCollection(testParam);

            for (int i = 0; i < testObject.Count; ++i)
            {
                Assert.AreEqual(testParam[i], testObject[i]);
            }
        }

        [TestMethod]
        public void HorizontalMetricRecordCollectionClass_Enumerator_ReturnsItemsInCorrectOrder()
        {
            HorizontalMetricRecord[] testParam = GetTestData();
            HorizontalMetricRecordCollection testObject = new HorizontalMetricRecordCollection(testParam);
            int idx = 0;

            IEnumerator<HorizontalMetricRecord> testEnumerator = testObject.GetEnumerator();

            while (testEnumerator.MoveNext())
            {
                Assert.AreEqual(testParam[idx++], testEnumerator.Current);
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
