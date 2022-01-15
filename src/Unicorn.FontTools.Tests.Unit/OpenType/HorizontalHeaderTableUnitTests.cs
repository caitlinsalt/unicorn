using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType;

namespace Unicorn.FontTools.Tests.Unit.OpenType
{
    [TestClass]
    public class HorizontalHeaderTableUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private HorizontalHeaderTable _testObject;

        [TestInitialize]
        public void SetUpTest()
        {
            _testObject = new HorizontalHeaderTable(_rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort(),
                _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort());
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObject()
        {
            var testOutput = _testObject.Dump();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingNameOfTable()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains("hhea", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithTwoColumns()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(2, testOutput.BlockHeader.Count);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFirstColumnNamedField()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Field", testOutput.BlockHeader[0].HeaderText);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFirstColumnNamedValue()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Value", testOutput.BlockHeader[1].HeaderText);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectMajorVersion()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MajorVersion");
            Assert.AreEqual(_testObject.MajorVersion.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectMinorVersion()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MinorVersion");
            Assert.AreEqual(_testObject.MinorVersion.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectAscender()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "Ascender");
            Assert.AreEqual(_testObject.Ascender.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectDescender()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "Descender");
            Assert.AreEqual(_testObject.Descender.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectLineGap()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "LineGap");
            Assert.AreEqual(_testObject.LineGap.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectMaxAdvanceWidth()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxAdvanceWidth");
            Assert.AreEqual(_testObject.MaxAdvanceWidth.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectMinLeftSideBearing()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MinLeftSideBearing");
            Assert.AreEqual(_testObject.MinLeftSideBearing.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectMinRightSideBearing()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MinRightSideBearing");
            Assert.AreEqual(_testObject.MinRightSideBearing.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectXMaxExtent()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "XMaxExtent");
            Assert.AreEqual(_testObject.XMaxExtent.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectCaretSlopeRise()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "CaretSlopeRise");
            Assert.AreEqual(_testObject.CaretSlopeRise.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectCaretSlopeRun()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "CaretSlopeRun");
            Assert.AreEqual(_testObject.CaretSlopeRun.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectCaretOffset()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "CaretOffset");
            Assert.AreEqual(_testObject.CaretOffset.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectMetricDataFormat()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MetricDataFormat");
            Assert.AreEqual(_testObject.MetricDataFormat.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectHmtxHMetricCount()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "HmtxHMetricCount");
            Assert.AreEqual(_testObject.HmtxHMetricCount.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HorizontalHeaderTableClass_DumpMethod_ReturnsObjectWithNoNestedBlocks()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(0, testOutput.NestedData.Count());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
