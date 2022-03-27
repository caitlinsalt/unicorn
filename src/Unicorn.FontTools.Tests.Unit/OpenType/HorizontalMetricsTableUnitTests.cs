using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit.OpenType
{
    [TestClass]
    public class HorizontalMetricsTableUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private HorizontalMetricsTable _testObject;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            int metricsCount = _rnd.Next(1, 256);
            List<HorizontalMetricRecord> data = new(metricsCount);
            for (int i = 0; i < metricsCount; ++i)
            {
                data.Add(_rnd.NextHorizontalMetricRecord());
            }
            _testObject = new HorizontalMetricsTable(data);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void HorizontalMetricsTableClass_DumpMethod_ReturnsObject()
        {
            var testOutput = _testObject.Dump();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricsTableClass_DumpMethod_ReturnsObjectWithInfoContainingNameOfTable()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains("hmtx", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void HorizontalMetricsTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithThreeColumns()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(3, testOutput.BlockHeader.Count);
        }

        [TestMethod]
        public void HorizontalMetricsTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFirstColumnNamedGlyph()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Glyph", testOutput.BlockHeader[0].HeaderText);
        }

        [TestMethod]
        public void HorizontalMetricsTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithSecondColumnNamedAdvanceWidth()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Advance Width", testOutput.BlockHeader[1].HeaderText);
        }

        [TestMethod]
        public void HorizontalMetricsTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithThirdColumnNamedLSB()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("LSB", testOutput.BlockHeader[2].HeaderText);
        }

        [TestMethod]
        public void HorizontalMetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataWithAsManyRowsAsElementsInObjectMetricsProperty()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(_testObject.Metrics.Count, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void HorizontalMetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataWhereFirstMemberOfEachRecordIsMonotonicallyIncreasing()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < testOutput.BlockData.Count; ++i)
            {
                Assert.AreEqual(i.ToString(CultureInfo.CurrentCulture), testOutput.BlockData[i][0]);
            }
        }

        [TestMethod]
        public void HorizontalMetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataWhereSecondMemberOfEachRecordIsAdvanceWidthPropertyOfMetric()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < testOutput.BlockData.Count; ++i)
            {
                Assert.AreEqual(_testObject.Metrics[i].AdvanceWidth.ToString(CultureInfo.CurrentCulture), testOutput.BlockData[i][1]);
            }
        }

        [TestMethod]
        public void HorizontalMetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataWhereThirdMemberOfEachRecordIsLeftSideBearingPropertyOfMetric()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < testOutput.BlockData.Count; ++i)
            {
                Assert.AreEqual(_testObject.Metrics[i].LeftSideBearing.ToString(CultureInfo.CurrentCulture), testOutput.BlockData[i][2]);
            }
        }

        [TestMethod]
        public void HorizontalMetricsTableClass_DumpMethod_ReturnsObjectWithNoNestedBlocks()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(0, testOutput.NestedData.Count());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
