using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.Tests.Unit.OpenType.Utility
{
    [TestClass]
    public class DumpBlockUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;
        private Mock<IDumpBlockHeader> _mockHeader;
        private string _formattedHeaderValue;
        private string _underlineValue;
        private List<Mock<IDumpRecord>> _mockData;
        private List<string> _mockFormattedData;
        private List<Mock<IDumpBlock>> _mockNestedBlocks;
        private List<List<string>> _mockNestedData;
        private string _infoValue;
        private DumpBlock _testObject;

        private IEnumerable<IDumpRecord> MockDataObjects => _mockData.Select(m => m.Object);

        private IEnumerable<IDumpBlock> MockNestedBlockObjects => _mockNestedBlocks.Select(m => m.Object);

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            _infoValue = _rnd.NextString(_rnd.Next(1, 100));
            _formattedHeaderValue = _rnd.NextString(_rnd.Next(1, 100));
            _underlineValue = _rnd.NextString("-+", _rnd.Next(1, 50));
            _mockHeader = new Mock<IDumpBlockHeader>();
            _mockHeader.Setup(h => h.FormatHeader()).Returns(_formattedHeaderValue);
            _mockHeader.Setup(h => h.GetUnderline()).Returns(_underlineValue);
            int recordCount = _rnd.Next(1, 10);
            _mockData = new List<Mock<IDumpRecord>>(recordCount);
            _mockFormattedData = new List<string>(recordCount);
            for (int i = 0; i < recordCount; ++i)
            {
                Mock<IDumpRecord> mockRecord = new();
                string mockValue = _rnd.NextString(_rnd.Next(40));
                mockRecord.Setup(r => r.FormatRecord(It.IsAny<IDumpBlockHeader>())).Returns(mockValue);
                _mockData.Add(mockRecord);
                _mockFormattedData.Add(mockValue);
            }
            int nestedBlockCount = _rnd.Next(1, 4);
            _mockNestedBlocks = new List<Mock<IDumpBlock>>(nestedBlockCount);
            _mockNestedData = new List<List<string>>(nestedBlockCount);
            for (int i = 0; i < nestedBlockCount; ++i)
            {
                int formattedRowCount = _rnd.Next(1, 10);
                List<string> nestedBlockData = new(formattedRowCount);
                for (int j = 0; j < formattedRowCount; ++j)
                {
                    nestedBlockData.Add(_rnd.NextString(_rnd.Next(1, 20)));
                }
                Mock<IDumpBlock> mockBlock = new();
                mockBlock.Setup(b => b.FormatBlock()).Returns(nestedBlockData);
                _mockNestedBlocks.Add(mockBlock);
                _mockNestedData.Add(nestedBlockData);
            }
            _testObject = GetDumpBlock();
        }

        private DumpBlock GetDumpBlock(bool withInfo = true, bool withData = true, bool withNestedBlocks = true)
            => new(withInfo ? _infoValue : null, _mockHeader.Object, withData ? MockDataObjects : null, withNestedBlocks ? MockNestedBlockObjects : null);

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DumpBlockClass_ConstructorWithFourParameters_SetsInfoPropertyToEmptyString_IfFirstParameterIsNull()
        {
            string testParam0 = null;
            IDumpBlockHeader testParam1 = _mockHeader.Object;
            IEnumerable<IDumpRecord> testParam2 = MockDataObjects;
            IEnumerable<IDumpBlock> testParam3 = MockNestedBlockObjects;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual("", testOutput.Info);
        }

        [TestMethod]
        public void DumpBlockClass_ConstructorWithFourParameters_SetsInfoPropertyToValueOfFirstParameter_IfFirstParameterIsNotNull()
        {
            string testParam0 = _infoValue;
            IDumpBlockHeader testParam1 = _mockHeader.Object;
            IEnumerable<IDumpRecord> testParam2 = MockDataObjects;
            IEnumerable<IDumpBlock> testParam3 = MockNestedBlockObjects;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(_infoValue, testOutput.Info);
        }

        [TestMethod]
        public void DumpBlockClass_ConstructorWithFourParameters_SetsBlockHeaderPropertyToDefaultValue_IfSecondParameterIsNull()
        {
            string testParam0 = _infoValue;
            IDumpBlockHeader testParam1 = null;
            IEnumerable<IDumpRecord> testParam2 = MockDataObjects;
            IEnumerable<IDumpBlock> testParam3 = MockNestedBlockObjects;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2, testParam3);

            Assert.IsNotNull(testOutput.BlockHeader);
            Assert.AreEqual(2, testOutput.BlockHeader.Count);
            Assert.AreEqual("Field", testOutput.BlockHeader[0].HeaderText);
            Assert.AreEqual("Value", testOutput.BlockHeader[1].HeaderText);
            Assert.IsTrue(testOutput.BlockHeader.All(c => c.Alignment == DumpAlignment.Left));
        }

        [TestMethod]
        public void DumpBlockClass_ConstructorWithFourParameters_SetsBlockHeaderPropertyToEqualSecondParameter_IfSecondParameterIsNotNull()
        {
            string testParam0 = _infoValue;
            IDumpBlockHeader testParam1 = _mockHeader.Object;
            IEnumerable<IDumpRecord> testParam2 = MockDataObjects;
            IEnumerable<IDumpBlock> testParam3 = MockNestedBlockObjects;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2, testParam3);

            Assert.AreSame(_mockHeader.Object, testOutput.BlockHeader);
        }

        [TestMethod]
        public void DumpBlockClass_ConstructorWithFourParameters_SetsBlockDataPropertyToEmptySequence_IfThirdParameterIsNull()
        {
            string testParam0 = _infoValue;
            IDumpBlockHeader testParam1 = _mockHeader.Object;
            IEnumerable<IDumpRecord> testParam2 = null;
            IEnumerable<IDumpBlock> testParam3 = MockNestedBlockObjects;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2, testParam3);

            Assert.IsNotNull(testOutput.BlockData);
            Assert.IsTrue(!testOutput.BlockData.Any());
        }

        [TestMethod]
        public void DumpBlockClass_ConstructorWithFourParameters_SetsBlockDataPropertyToValueContainingSameDataAsThirdParameter_IfThirdParameterIsNotNull()
        {
            string testParam0 = _infoValue;
            IDumpBlockHeader testParam1 = _mockHeader.Object;
            IEnumerable<IDumpRecord> testParam2 = MockDataObjects;
            IEnumerable<IDumpBlock> testParam3 = MockNestedBlockObjects;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2, testParam3);

            var outputData = testOutput.BlockData.ToList();
            Assert.AreEqual(_mockData.Count, outputData.Count);
            for (int i = 0; i < outputData.Count; ++i)
            {
                Assert.AreSame(_mockData[i].Object, outputData[i]);
            }
        }

        [TestMethod]
        public void DumpBlockClass_ConstructorWithFourParameters_SetsNestedDataPropertyToEmptySequence_IfFourthParameterIsNull()
        {
            string testParam0 = _infoValue;
            IDumpBlockHeader testParam1 = _mockHeader.Object;
            IEnumerable<IDumpRecord> testParam2 = MockDataObjects;
            IEnumerable<IDumpBlock> testParam3 = null;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2, testParam3);

            Assert.IsNotNull(testOutput.NestedData);
            Assert.IsTrue(!testOutput.NestedData.Any());
        }

        [TestMethod]
        public void DumpBlockClass_ConstructorWithFourParameters_SetsNestedDataPropertyToSequenceContainingSameDataAsFourthParameter_IfFourthParameterIsNotNull()
        {
            string testParam0 = _infoValue;
            IDumpBlockHeader testParam1 = _mockHeader.Object;
            IEnumerable<IDumpRecord> testParam2 = MockDataObjects;
            IEnumerable<IDumpBlock> testParam3 = MockNestedBlockObjects;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2, testParam3);

            var outputData = testOutput.NestedData.ToList();
            Assert.AreEqual(_mockNestedBlocks.Count, outputData.Count);
            for (int i = 0; i < outputData.Count; ++i)
            {
                Assert.AreSame(_mockNestedBlocks[i].Object, outputData[i]);
            }
        }

        [TestMethod]
        public void DumpBlockClass_ConstructorWithThreeParameters_SetsInfoPropertyToEmptyString_IfFirstParameterIsNull()
        {
            string testParam0 = null;
            IEnumerable<IDumpRecord> testParam1 = MockDataObjects;
            IEnumerable<IDumpBlock> testParam2 = MockNestedBlockObjects;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreEqual("", testOutput.Info);
        }

        [TestMethod]
        public void DumpBlockClass_ConstructorWithThreeParameters_SetsInfoPropertyToValueOfFirstParameter_IfFirstParameterIsNotNull()
        {
            string testParam0 = _infoValue;
            IEnumerable<IDumpRecord> testParam1 = MockDataObjects;
            IEnumerable<IDumpBlock> testParam2 = MockNestedBlockObjects;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreEqual(_infoValue, testOutput.Info);
        }

        [TestMethod]
        public void DumpBlockClass_ConstructorWithThreearameters_SetsBlockDataPropertyToEmptySequence_IfSecondParameterIsNull()
        {
            string testParam0 = _infoValue;
            IEnumerable<IDumpRecord> testParam1 = null;
            IEnumerable<IDumpBlock> testParam2 = MockNestedBlockObjects;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2);

            Assert.IsNotNull(testOutput.BlockData);
            Assert.IsTrue(!testOutput.BlockData.Any());
        }

        [TestMethod]
        public void DumpBlockClass_ConstructorWithThreeParameters_SetsBlockDataPropertyToValueContainingSameDataAsSecondParameter_IfSecondParameterIsNotNull()
        {
            string testParam0 = _infoValue;
            IEnumerable<IDumpRecord> testParam1 = MockDataObjects;
            IEnumerable<IDumpBlock> testParam2 = MockNestedBlockObjects;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2);

            var outputData = testOutput.BlockData.ToList();
            Assert.AreEqual(_mockData.Count, outputData.Count);
            for (int i = 0; i < outputData.Count; ++i)
            {
                Assert.AreSame(_mockData[i].Object, outputData[i]);
            }
        }

        [TestMethod]
        public void DumpBlockClass_ConstructorWithThreeParameters_SetsNestedDataPropertyToEmptySequence_IfThirdParameterIsNull()
        {
            string testParam0 = _infoValue;
            IEnumerable<IDumpRecord> testParam1 = MockDataObjects;
            IEnumerable<IDumpBlock> testParam2 = null;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2);

            Assert.IsNotNull(testOutput.NestedData);
            Assert.IsTrue(!testOutput.NestedData.Any());
        }

        [TestMethod]
        public void DumpBlockClass_ConstructorWithThreeParameters_SetsNestedDataPropertyToSequenceContainingSameDataAsThirdParameter_IfThirdParameterIsNotNull()
        {
            string testParam0 = _infoValue;
            IEnumerable<IDumpRecord> testParam1 = MockDataObjects;
            IEnumerable<IDumpBlock> testParam2 = MockNestedBlockObjects;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2);

            var outputData = testOutput.NestedData.ToList();
            Assert.AreEqual(_mockNestedBlocks.Count, outputData.Count);
            for (int i = 0; i < outputData.Count; ++i)
            {
                Assert.AreSame(_mockNestedBlocks[i].Object, outputData[i]);
            }
        }

        [TestMethod]
        public void DumpBlockClass_ConstructorWithThreeParameters_SetsBlockHeaderPropertyToDefaultValue()
        {
            string testParam0 = _infoValue;
            IEnumerable<IDumpRecord> testParam1 = MockDataObjects;
            IEnumerable<IDumpBlock> testParam2 = MockNestedBlockObjects;

            DumpBlock testOutput = new(testParam0, testParam1, testParam2);

            Assert.IsNotNull(testOutput.BlockHeader);
            Assert.AreEqual(2, testOutput.BlockHeader.Count);
            Assert.AreEqual("Field", testOutput.BlockHeader[0].HeaderText);
            Assert.AreEqual("Value", testOutput.BlockHeader[1].HeaderText);
            Assert.IsTrue(testOutput.BlockHeader.All(c => c.Alignment == DumpAlignment.Left));
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsNonNullObject()
        {
            var testOutput = _testObject.FormatBlock();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceWhichStartsWithInfoPropertyOfObject_IfBlockContainsDataAndInfoPropertyIsPopulated()
        {
            var testOutput = _testObject.FormatBlock();

            Assert.AreEqual(_testObject.Info, testOutput.First());
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceWhichStartsWithInfoPropertyOfObject_IfBlockContainsDataAndInfoPropertyIsEmptyString()
        {
            var testObject = GetDumpBlock(false, true, true);

            var testOutput = testObject.FormatBlock();

            Assert.AreEqual("", testOutput.First());
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceWhichStartsWithInfoPropertyOfObject_IfBlockContainsNoDataAndInfoPropertyIsPopulated()
        {
            var testObject = GetDumpBlock(true, false, false);

            var testOutput = testObject.FormatBlock();

            Assert.AreEqual(_infoValue, testOutput.First());
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceOfLength1_IfBlockContainsNoDataAndInfoPropertyIsPopulated()
        {
            var testObject = GetDumpBlock(true, false, false);

            var testOutput = testObject.FormatBlock();

            Assert.AreEqual(1, testOutput.Count());
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceWhichStartsWithInfoPropertyOfObject_IfBlockContainsNoDataAndInfoPropertyIsEmptyString()
        {
            var testObject = GetDumpBlock(false, false, false);

            var testOutput = testObject.FormatBlock();

            Assert.AreEqual("", testOutput.First());
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceOfLength1_IfBlockContainsNoDataAndInfoPropertyIsEmptyString()
        {
            var testObject = GetDumpBlock(false, false, false);

            var testOutput = testObject.FormatBlock();

            Assert.AreEqual(1, testOutput.Count());
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsEnumeratorWhichCallsIDumpBlockHeaderFormatHeaderMethodWhenIterated_IfBlockContainsData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), true, _rnd.NextBoolean());

            _ = testObject.FormatBlock().ToList(); ;

            _mockHeader.Verify(h => h.FormatHeader());
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceWithSecondElementEqualToValueReturnedFromIDumpBlockHeaderFormatHeaderMethod_IfBlockContainsData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), true, _rnd.NextBoolean());

            var testOutput = testObject.FormatBlock();
            
            var testOutputList = testOutput.ToList();
            Assert.AreEqual(_formattedHeaderValue, testOutputList[1]);
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsEnumeratorWhichDoesNotCallIDumpBlockHeaderFormatHeaderMethodWhenEnumerated_IfBlockContainsNoData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), false, _rnd.NextBoolean());

            _ = testObject.FormatBlock().ToList();

            _mockHeader.Verify(h => h.FormatHeader(), Times.Never());
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsEnumeratorWhichCallsIDumpBlockHeaderMeasureColumnWidthsMethodWhenEnumerated_IfBlockContainsData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), true, _rnd.NextBoolean());

            _ = testObject.FormatBlock().ToList();

            _mockHeader.Verify(h => h.MeasureColumnWidths(It.IsAny<IReadOnlyList<IDumpRecord>>()));
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsEnumeratorWhichCallsIDumpBlockHeaderMeasureColumnWidthsMethodWithBlockDataPropertyAsParameterWhenEnumerated_IfBlockContainsData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), true, _rnd.NextBoolean());

            _ = testObject.FormatBlock().ToList();

            _mockHeader.Verify(h => h.MeasureColumnWidths(_testObject.BlockData));
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsEnumeratorWhichDoesNotCallIDumpBlockHeaderMeasureColumnWidthsMethodWhenEnumerated_IfBlockDoesNotContainData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), false, _rnd.NextBoolean());

            _ = testObject.FormatBlock().ToList();

            _mockHeader.Verify(h => h.MeasureColumnWidths(It.IsAny<IReadOnlyList<IDumpRecord>>()), Times.Never());
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsEnumeratorWhichCallsIDumpBlockHeaderFormatHeaderMethodWhenEnumerated_IfBlockContainsData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), true, _rnd.NextBoolean());

            _ = testObject.FormatBlock().ToList();

            _mockHeader.Verify(h => h.FormatHeader());
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceWhichContainsOutputOfIDumpBlockHeaderFormatHeaderMethodAsTheSecondItemInTheSequence_IfBlockContainsData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), true, _rnd.NextBoolean());

            var testOutput = testObject.FormatBlock();
            
            var testOutputList = testOutput.ToList();
            Assert.AreEqual(_formattedHeaderValue, testOutputList[1]);
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsEnumeratorWhichDoesNotCallIDumpBlockHeaderFormatHeaderMethodWhenEnumerated_IfBlockDoesNotContainData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), false, _rnd.NextBoolean());

            _ = testObject.FormatBlock().ToList();

            _mockHeader.Verify(h => h.FormatHeader(), Times.Never());
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsEnumeratorWhichCallsIDumpRecordFormatRecordMethodOnEveryRecordWhenEnumerated_IfBlockContainsData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), true, _rnd.NextBoolean());

            _ = testObject.FormatBlock().ToList();

            foreach (var mockRecord in _mockData)
            {
                mockRecord.Verify(r => r.FormatRecord(It.IsAny<IDumpBlockHeader>()));
            }
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsEnumeratorWhichCallsIDumpRecordFormatRecordMethodOnEveryRecordWithCorrectDumpBlockHeaderParameterWhenEnumerated_IfBlockContainsData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), true, _rnd.NextBoolean());

            _ = testObject.FormatBlock().ToList();

            foreach (var mockRecord in _mockData)
            {
                mockRecord.Verify(r => r.FormatRecord(_testObject.BlockHeader));
            }
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceContainingOutputOfIDumpRecordFormatRecordMethodsInCorrectOrderStartingAtThirdElementOfSequence_IfBlockContainsData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), true, _rnd.NextBoolean());

            var testOutput = testObject.FormatBlock();

            var testOutputList = testOutput.ToList();
            for (int i = 0; i < _testObject.BlockData.Count; ++i)
            {
                Assert.AreEqual(_mockFormattedData[i], testOutputList[i + 2]);
            }
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsEnumeratorWhichCallsIDumpBlockHeaderGetUnderlineMethodWhenEnumerated_IfBlockContainsData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), true, _rnd.NextBoolean());

            _ = testObject.FormatBlock().ToList();

            _mockHeader.Verify(h => h.GetUnderline());
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceWhichContainsOutputOfIDumpBlockHeaderGetUnderlineMethodAtAppropriatePositionWhenEnumerated_IfBlockContainsData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), true, _rnd.NextBoolean());

            var testOutput = testObject.FormatBlock();

            var testOutputList = testOutput.ToList();
            Assert.AreEqual(_underlineValue, testOutputList[2 + testObject.BlockData.Count]);
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsEnumeratorWhichDoesNotCallIDumpBlockHeaderGetUnderlineMethodWhenEnumerated_IfBlockDoesNotContainData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), false, _rnd.NextBoolean());

            _ = testObject.FormatBlock().ToList();

            _mockHeader.Verify(h => h.GetUnderline(), Times.Never());
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceOfOneItem_IfBlockDoesNotContainDataOrNestedBlocks()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), false, false);

            int testOutput = testObject.FormatBlock().Count();

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceEqualInLengthToLengthOfDataPlusThree_IfBlockContainsDataButDoesNotContainNestedBlocks()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), true, false);
            int expectedResult = testObject.BlockData.Count + 3;

            int testOutput = testObject.FormatBlock().Count();

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsEnumeratorThatCallsFormatBlockMethodOfEachNestedBlockWhenEnumerated_IfBlockContainsNestedBlocks()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), _rnd.NextBoolean(), true);

            _ = testObject.FormatBlock().ToList();

            foreach (var nestedBlock in _mockNestedBlocks)
            {
                nestedBlock.Verify(b => b.FormatBlock());
            }
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceContainingOutputOfAllNestedBlockFormatBlockMethodCallsInCorrectOrderAtCorrectPlaceInSequence_IfBlockContainsNestedBlocksButNoData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), false, true);

            var testOutput = testObject.FormatBlock();

            var testOutputList = testOutput.ToList();
            int outputIdx = 1;
            for (int i = 0; i < _mockNestedBlocks.Count; ++i)
            {
                for (int j = 0; j < _mockNestedData[i].Count; ++j)
                {
                    Assert.AreEqual(_mockNestedData[i][j], testOutputList[outputIdx++]);
                }
            }
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceContainingOutputOfAllNestedBlockFormatBlockMethodCallsInCorrectOrderAtCorrectPlaceInSequence_IfBlockContainsDataAndNestedBlocks()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), true, true);

            var testOutput = testObject.FormatBlock();

            var testOutputList = testOutput.ToList();
            int outputIdx = 3 + testObject.BlockData.Count;
            for (int i = 0; i < _mockNestedBlocks.Count; ++i)
            {
                for (int j = 0; j < _mockNestedData[i].Count; ++j)
                {
                    Assert.AreEqual(_mockNestedData[i][j], testOutputList[outputIdx++]);
                }
            }
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceOfCorrectLength_IfBlockContainsNestedBlocksButNoData()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), false, true);
            int expectedValue = 1 + _mockNestedData.Sum(s => s.Count);

            int testOutput = testObject.FormatBlock().Count();

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void DumpBlockClass_FormatBlockMethod_ReturnsSequenceOfCorrectLength_IfBlockContainsDataAndNestedBlocks()
        {
            var testObject = GetDumpBlock(_rnd.NextBoolean(), true, true);
            int expectedValue = 3 + _mockData.Count + _mockNestedData.Sum(s => s.Count);

            int testOutput = testObject.FormatBlock().Count();

            Assert.AreEqual(expectedValue, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
