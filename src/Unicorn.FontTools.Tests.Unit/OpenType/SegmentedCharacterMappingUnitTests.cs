using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit.OpenType
{
    [TestClass]
    public class SegmentedCharacterMappingUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private List<SegmentSubheaderRecord> _testSegments;
        private SegmentedCharacterMapping _testObject;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            int segmentCount = _rnd.Next(1, 20);
            _testSegments = new List<SegmentSubheaderRecord>(segmentCount);
            for (int i = 0; i < segmentCount; ++i)
            {
                _testSegments.Add(_rnd.NextSegmentSubheaderRecord());
            }
            int glyphDataCount = _rnd.Next(1, 50);
            List<int> glyphData = new(glyphDataCount);
            for (int i = 0; i < glyphDataCount; ++i)
            {
                glyphData.Add(_rnd.NextUShort());
            }
            _testObject = new SegmentedCharacterMapping(_rnd.NextPlatformId(), _rnd.NextUShort(), _rnd.NextUShort(), _testSegments, glyphData);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObject()
        {
            var testOutput = _testObject.Dump();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingPlatform()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Platform.ToString(), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingLanguage()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Language.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingEncoding()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Encoding.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingNumberOfSegments()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains($"{_testSegments.Count} segments", StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFiveColumns()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(5, testOutput.BlockHeader.Count);
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFirstColumnNamedSegment()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Segment", testOutput.BlockHeader[0].HeaderText);
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockHeaderWithSecondColumnNamedStart()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Start", testOutput.BlockHeader[1].HeaderText);
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockHeaderWithThirdColumnNamedEnd()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("End", testOutput.BlockHeader[2].HeaderText);
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFourthColumnNamedDelta()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Delta", testOutput.BlockHeader[3].HeaderText);
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFifthColumnNamedOffset()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Offset", testOutput.BlockHeader[4].HeaderText);
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockDataWithSameNumberOfRecordsAsNumberOfSegmentsInObject()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(_testSegments.Count, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockDataWithEachRecordHavingIndexNumberOfRecordInTheFirstColumn()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < testOutput.BlockData.Count; ++i)
            {
                Assert.AreEqual(i.ToString(CultureInfo.CurrentCulture), testOutput.BlockData[i][0]);
            }
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockDataWithEachRecordContainingStartCodeInTheSecondColumn()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < testOutput.BlockData.Count; ++i)
            {
                Assert.AreEqual(_testSegments[i].StartCode.ToString(CultureInfo.CurrentCulture), testOutput.BlockData[i][1]);
            }
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockDataWithEachRecordContainingEndCodeInTheThirdColumn()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < testOutput.BlockData.Count; ++i)
            {
                Assert.AreEqual(_testSegments[i].EndCode.ToString(CultureInfo.CurrentCulture), testOutput.BlockData[i][2]);
            }
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockDataWithEachRecordContainingIdDeltaInTheFourthColumn()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < testOutput.BlockData.Count; ++i)
            {
                Assert.AreEqual(_testSegments[i].IdDelta.ToString(CultureInfo.CurrentCulture), testOutput.BlockData[i][3]);
            }
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockDataWithEachRecordContainingStartOffsetInTheFifthColumn()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < testOutput.BlockData.Count; ++i)
            {
                Assert.AreEqual(_testSegments[i].StartOffset.ToString(CultureInfo.CurrentCulture), testOutput.BlockData[i][4]);
            }
        }

        [TestMethod]
        public void SegmentedCharacterMappingClass_DumpMethod_ReturnsObjectWithNoNestedBlocks()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(0, testOutput.NestedData.Count());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
