using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Unicorn.FontTools.OpenType.Utility;
using Unicorn.FontTools.Tests.Utility;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using System.Linq;
using System.Collections;

namespace Unicorn.FontTools.Tests.Unit.OpenType.Utility
{
    [TestClass]
    public class DumpBlockHeaderUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;
        private List<DumpColumn> _headerData;
        private DumpBlockHeader _testObject;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            int testCount = _rnd.Next(1, 50);
            _headerData = new List<DumpColumn>(testCount);
            for (int i = 0; i < testCount; ++i)
            {
                _headerData.Add(_rnd.NextDumpColumn());
            }
            _testObject = new DumpBlockHeader(_headerData);
        }

        private IReadOnlyList<IDumpRecord> GetDataWithShortRow()
        {
            int rowCount = _rnd.Next(1, 100);
            int shortRow = _rnd.Next(rowCount);
            List<IDumpRecord> data = new(rowCount);
            for (int i = 0; i < rowCount; ++i)
            {
                int fieldCount;
                if (i == shortRow)
                {
                    fieldCount = _rnd.Next(_headerData.Count);
                }
                else
                {
                    fieldCount = _rnd.Next(_headerData.Count, _headerData.Count + 5);
                }
                List<string> rowData = new();
                for (int j = 0; j < fieldCount; ++j)
                {
                    rowData.Add(_rnd.NextString(10));
                }
                data.Add(new DumpRecord(rowData));
            }
            return data;
        }

        private IReadOnlyList<IDumpRecord> GetDataWithShortValues() => GetData(GenerateShorterValue);

        private IReadOnlyList<IDumpRecord> GetDataWithLongValues() => GetData(GenerateLongerValue);

        private IReadOnlyList<IDumpRecord> GetData() => GetData(GenerateAnyValue);

        private IReadOnlyList<IDumpRecord> GetData(Func<int, string> valueGenerator)
        {
            int rowCount = _rnd.Next(1, 100);
            List<IDumpRecord> data = new(rowCount);
            for (int i = 0; i < rowCount; ++i)
            {
                List<string> rowData = new();
                for (int j = 0; j < _testObject.Count; ++j)
                {
                    rowData.Add(valueGenerator(j));
                }
                data.Add(new DumpRecord(rowData));
            }
            return data;
        }

        private string GenerateShorterValue(int col) => _rnd.NextString(_rnd.Next(_testObject[col].HeaderText.Length));

        private string GenerateLongerValue(int col) => _rnd.NextString(_rnd.Next(_testObject[col].HeaderText.Length + 1, _testObject[col].HeaderText.Length + 20));

        private static string GenerateAnyValue(int col) => _rnd.NextString(_rnd.Next(30));

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DumpBlockHeaderClass_ConstructorWithIEnumerableParameter_CreatesObjectWithCountPropertyOfZero_IfParameterIsNull()
        {
            IEnumerable<DumpColumn> testParam = null;

            DumpBlockHeader testOutput = new(testParam);

            Assert.AreEqual(0, testOutput.Count);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_ConstructorWithIEnumerableParameter_CreatesObjectWithCountPropertyOfZero_IfParameterIsEmptySequence()
        {
            IEnumerable<DumpColumn> testParam = Array.Empty<DumpColumn>();

            DumpBlockHeader testOutput = new(testParam);

            Assert.AreEqual(0, testOutput.Count);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_ConstructorWithIEnumerableParameter_CreatesObjectWithCorrectCountProperty_IfParameterIsNotNull()
        {
            IEnumerable<DumpColumn> testParam = _headerData;

            DumpBlockHeader testOutput = new(testParam);

            Assert.AreEqual(_headerData.Count, testOutput.Count);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_ConstructorWithIEnumerableParameter_CreatesObjectWithCorrectContent_IfParameterIsNotNull()
        {
            IEnumerable<DumpColumn> testParam = _headerData;

            DumpBlockHeader testOutput = new(testParam);

            for (int i = 0; i < _headerData.Count; ++i)
            {
                Assert.AreEqual(_headerData[i], testOutput[i]);
            }
        }

        [TestMethod]
        public void DumpBlockHeaderClass_ConstructorWithIEnumerableParameter_CreatesObjectWithColumnWidthsPropertyOfNull()
        {
            IEnumerable<DumpColumn> testParam = _headerData;

            DumpBlockHeader testOutput = new(testParam);

            Assert.IsNull(testOutput.ColumnWidths);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_ConstructorWithArrayParameter_CreatesObjectWithCountPropertyOfZero_IfParameterIsEmptySequence()
        {
            DumpColumn[] testParam = Array.Empty<DumpColumn>();

            DumpBlockHeader testOutput = new(testParam);

            Assert.AreEqual(0, testOutput.Count);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_ConstructorWithArrayParameter_CreatesObjectWithCorrectCountProperty_IfParameterIsNotNull()
        {
            DumpColumn[] testParam = _headerData.ToArray();

            DumpBlockHeader testOutput = new(testParam);

            Assert.AreEqual(_headerData.Count, testOutput.Count);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_ConstructorWithArrayParameter_CreatesObjectWithCorrectContent_IfParameterIsNotNull()
        {
            DumpColumn[] testParam = _headerData.ToArray();

            DumpBlockHeader testOutput = new(testParam);

            for (int i = 0; i < _headerData.Count; ++i)
            {
                Assert.AreEqual(_headerData[i], testOutput[i]);
            }
        }

        [TestMethod]
        public void DumpBlockHeaderClass_ConstructorWithArrayParameter_CreatesObjectWithColumnWidthsPropertyOfNull()
        {
            DumpColumn[] testParam = _headerData.ToArray();

            DumpBlockHeader testOutput = new(testParam);

            Assert.IsNull(testOutput.ColumnWidths);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DumpBlockHeaderClass_MeasureColumnWidthsMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            _testObject.MeasureColumnWidths(null);

            Assert.Fail();
        }

        [TestMethod]
        public void DumpBlockHeaderClass_MeasureColumnWidthsMethod_SetsColumnWidthsPropertyToNonNullValue_IfParameterIsEmptyArray()
        {
            _testObject.MeasureColumnWidths(Array.Empty<IDumpRecord>());

            Assert.IsNotNull(_testObject.ColumnWidths);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_MeasureColumnWidthsMethod_SetsCountPropertyOfColumnWidthsPropertyToEqualCountPropertyOfObject_IfParameterIsEmptyArray()
        {
            _testObject.MeasureColumnWidths(Array.Empty<IDumpRecord>());

            Assert.AreEqual(_testObject.Count, _testObject.ColumnWidths.Count);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_MeasureColumnWidthsMethod_SetsElementsOfColumnWidthsPropertyToEqualLengthsOfHeaderTextPropertiesOfData_IfParameterIsEmptyArray()
        {
            _testObject.MeasureColumnWidths(Array.Empty<IDumpRecord>());

            for (int i = 0; i < _testObject.Count; ++i)
            {
                Assert.AreEqual(_testObject[i].HeaderText.Length, _testObject.ColumnWidths[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DumpBlockHeaderClass_MeasureColumnWidthsMethod_ThrowsArgumentException_IfParameterContainsElementWithFewerElementsThanObject()
        {
            var testParam = GetDataWithShortRow();

            _testObject.MeasureColumnWidths(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void DumpBlockHeaderClass_MeasureColumnWidthsMethod_SetsColumnWidthsPropertyToNonNullValue_IfParameterIsNotNullAndContainsDataWithShorterValuesThanHeaderTextProperties()
        {
            _testObject.MeasureColumnWidths(GetDataWithShortValues());

            Assert.IsNotNull(_testObject.ColumnWidths);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_MeasureColumnWidthsMethod_SetsCountPropertyOfColumnWidthsPropertyToEqualCountPropertyOfObject_IfParameterIsNotNullAndContainsDataWithShorterValuesThanHeaderTextProperties()
        {
            _testObject.MeasureColumnWidths(GetDataWithShortValues());

            Assert.AreEqual(_testObject.Count, _testObject.ColumnWidths.Count);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_MeasureColumnWidthsMethod_SetsElementsOfColumnWidthsPropertyToEqualLengthsOfHeaderTextPropertiesOfData_IfParameterIsNotNullButContainsDataThatIsAlwaysShorterThanHeaderText()
        {
            var testParam = GetDataWithShortValues();

            _testObject.MeasureColumnWidths(testParam);

            for (int i = 0; i < _testObject.Count; ++i)
            {
                Assert.AreEqual(_testObject[i].HeaderText.Length, _testObject.ColumnWidths[i]);
            }
        }

        [TestMethod]
        public void DumpBlockHeaderClass_MeasureColumnWidthsMethod_SetsColumnWidthsPropertyToNonNullValue_IfParameterIsNotNullAndContainsDataWithLongerValuesThanHeaderTextProperties()
        {
            _testObject.MeasureColumnWidths(GetDataWithLongValues());

            Assert.IsNotNull(_testObject.ColumnWidths);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_MeasureColumnWidthsMethod_SetsCountPropertyOfColumnWidthsPropertyToEqualCountPropertyOfObject_IfParameterIsNotNullAndContainsDataWithLongerValuesThanHeaderTextProperties()
        {
            _testObject.MeasureColumnWidths(GetDataWithLongValues());

            Assert.AreEqual(_testObject.Count, _testObject.ColumnWidths.Count);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_MeasureColumnWidthsMethod_SetsElementsOfColumnWidthsPropertyToEqualMaxLengthOfDataInColumn_IfParameterIsNotNullButContainsDataThatIsAlwaysLongerThanHeaderText()
        {
            var testParam = GetDataWithLongValues();

            _testObject.MeasureColumnWidths(testParam);

            for (int i = 0; i < _testObject.Count; ++i)
            {
                Assert.AreEqual(testParam.Select(r => r[i].Length).Max(), _testObject.ColumnWidths[i]);
            }
        }

        [TestMethod]
        public void DumpBlockHeaderClass_MeasureColumnWidthsMethod_SetsColumnWidthsPropertyToNonNullValue_IfParameterIsNotNullAndContainsData()
        {
            _testObject.MeasureColumnWidths(GetData());

            Assert.IsNotNull(_testObject.ColumnWidths);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_MeasureColumnWidthsMethod_SetsCountPropertyOfColumnWidthsPropertyToEqualCountPropertyOfObject_IfParameterIsNotNullAndContainsData()
        {
            _testObject.MeasureColumnWidths(GetData());

            Assert.AreEqual(_testObject.Count, _testObject.ColumnWidths.Count);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_MeasureColumnWidthsMethod_SetsElementsOfColumnWidthsPropertyToCorrectValues_IfParameterIsNotNullButContainsData()
        {
            var testParam = GetData();

            _testObject.MeasureColumnWidths(testParam);

            for (int i = 0; i < _testObject.Count; ++i)
            {
                int headerLen = _testObject[i].HeaderText.Length;
                int dataLen = testParam.Select(r => r[i].Length).Max();
                int maxLen = headerLen > dataLen ? headerLen : dataLen;
                Assert.AreEqual(maxLen, _testObject.ColumnWidths[i]);
            }
        }

        [TestMethod]
        public void DumpBlockHeaderClass_GetUnderlineMethod_ReturnsStringOfCorrectLength_IfMeasureColumnWidthsHasBeenCalled()
        {
            _testObject.MeasureColumnWidths(GetData());

            string testOutput = _testObject.GetUnderline();

            // This value consists of: the total width of all columns, plus two margin chars and one left-side separator per column, plus one right-side separator.
            Assert.AreEqual(_testObject.ColumnWidths.Sum() + _testObject.Count * 3 + 1, testOutput.Length);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_GetUnderlineMethod_ReturnsStringContainingCorrectCharacters_IfMeasureColumnWidthsHasBeenCalled()
        {
            _testObject.MeasureColumnWidths(GetData());

            string testOutput = _testObject.GetUnderline();

            Assert.IsFalse(testOutput.Any(c => c != '-' && c != '+'));
        }

        [TestMethod]
        public void DumpBlockHeaderClass_GetUnderlineMethod_ReturnsStringContainingCorrectNumberOfSeparators_IfMeasureColumnWidthsHasBeenCalled()
        {
            _testObject.MeasureColumnWidths(GetData());

            string testOutput = _testObject.GetUnderline();

            // One left-side separator per column, plus one right-side separator.
            Assert.AreEqual(_testObject.Count + 1, testOutput.Count(c => c == '+'));
        }

        [TestMethod]
        public void DumpBlockHeaderClass_GetUnderlineMethod_ReturnsStringContainingSeparatorsInCorrectPositions_IfMeasureColumnWidthsHasBeenCalled()
        {
            _testObject.MeasureColumnWidths(GetData());

            string testOutput = _testObject.GetUnderline();

            string[] splitOutput = testOutput.Split('+');
            for (int i = 0; i < _testObject.Count; ++i)
            {
                Assert.AreEqual(_testObject.ColumnWidths[i] + 2, splitOutput[i + 1].Length);
            }
        }

        [TestMethod]
        public void DumpBlockHeaderClass_GetUnderlineMethod_ReturnsStringOfCorrectLength_IfMeasureColumnWidthsHasNotBeenCalled()
        {
            string testOutput = _testObject.GetUnderline();

            // This value consists of: the total width of all columns, plus two margin chars and one left-side separator per column, plus one right-side separator.
            Assert.AreEqual(_testObject.ColumnWidths.Sum() + _testObject.Count * 3 + 1, testOutput.Length);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_GetUnderlineMethod_ReturnsStringContainingCorrectCharacters_IfMeasureColumnWidthsHasNotBeenCalled()
        {
            string testOutput = _testObject.GetUnderline();

            Assert.IsFalse(testOutput.Any(c => c != '-' && c != '+'));
        }

        [TestMethod]
        public void DumpBlockHeaderClass_GetUnderlineMethod_ReturnsStringContainingCorrectNumberOfSeparators_IfMeasureColumnWidthsHasNotBeenCalled()
        {
            string testOutput = _testObject.GetUnderline();

            // One left-side separator per column, plus one right-side separator.
            Assert.AreEqual(_testObject.Count + 1, testOutput.Count(c => c == '+'));
        }

        [TestMethod]
        public void DumpBlockHeaderClass_GetUnderlineMethod_ReturnsStringContainingSeparatorsInCorrectPositions_IfMeasureColumnWidthsHasNotBeenCalled()
        {
            string testOutput = _testObject.GetUnderline();

            string[] splitOutput = testOutput.Split('+');
            for (int i = 0; i < _testObject.Count; ++i)
            {
                Assert.AreEqual(_testObject.ColumnWidths[i] + 2, splitOutput[i + 1].Length);
            }
        }

        [TestMethod]
        public void DumpBlockHeaderClass_GetEnumeratorMethod_ReturnsEnumeratorThatBehavesAsExpected()
        {
            IEnumerator<DumpColumn> testOutput = _testObject.GetEnumerator();

            for (int i = 0; i < _testObject.Count; ++i)
            {
                testOutput.MoveNext();
                Assert.AreEqual(_testObject[i], testOutput.Current);
            }
            Assert.IsFalse(testOutput.MoveNext());
        }

        [TestMethod]
        public void DumpBlockHeaderClass_NonGenericIEnumeratorMethod_ReturnsEnumeratorThatBehavesAsExpected()
        {
            IEnumerator testOutput = (_testObject as IEnumerable).GetEnumerator();

            for (int i = 0; i < _testObject.Count; ++i)
            {
                testOutput.MoveNext();
                Assert.AreEqual(_testObject[i], (DumpColumn)testOutput.Current);
            }
            Assert.IsFalse(testOutput.MoveNext());
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_ReturnsThreeLinesOfText_IfMeasureColumnWidthsHasBeenCalled()
        {
            _testObject.MeasureColumnWidths(GetData());

            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            Assert.AreEqual(3, splitOutput.Length);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_FirstLineOfReturnedDataEqualsOutputOfGetUnderlineMethod_IfMeasureColumnWidthsHasBeenCalled()
        {
            _testObject.MeasureColumnWidths(GetData());
            string expectedOutput = _testObject.GetUnderline();

            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            Assert.AreEqual(expectedOutput, splitOutput.First());
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_LastLineOfReturnedDataEqualsOutputOfGetUnderlineMethod_IfMeasureColumnWidthsHasBeenCalled()
        {
            _testObject.MeasureColumnWidths(GetData());
            string expectedOutput = _testObject.GetUnderline();

            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            Assert.AreEqual(expectedOutput, splitOutput[^1]);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_AllLinesOfDataAreSameLength_IfMeasureColumnWidthsHasBeenCalled()
        {
            _testObject.MeasureColumnWidths(GetData());

            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            Assert.IsTrue(splitOutput.All(r => r.Length == splitOutput[0].Length));
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_SecondLineContainsCorrectNumberOfSeparatorCharacters_IfMeasureColumnWidthsHasBeenCalled()
        {
            _testObject.MeasureColumnWidths(GetData());

            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            var splitRow = splitOutput[1].Split('|');
            Assert.AreEqual(_testObject.Count + 2, splitRow.Length);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_SecondLineContainsCorrectlySpacedSeparatorCharacters_IfMeasureColumnWidthsHasBeenCalled()
        {
            _testObject.MeasureColumnWidths(GetData());

            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            var splitRow = splitOutput[1].Split('|');
            for (int i = 0; i < _testObject.Count; ++i)
            {
                Assert.AreEqual(_testObject.ColumnWidths[i] + 2, splitRow[i + 1].Length);
            }
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_SecondLineContainsCorrectHeaderText_IfMeasureColumnWidthsHasBeenCalled()
        {
            _testObject.MeasureColumnWidths(GetData());

            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            var splitRow = splitOutput[1].Split('|');
            for (int i = 0; i < _testObject.Count; ++i)
            {
                Assert.IsTrue(splitRow[i + 1].Contains(_testObject[i].HeaderText, StringComparison.InvariantCulture));
            }
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_SecondLineContainsFieldsPaddedInCorrectDirection_IfMeasureColumnWidthsHasBeenCalled()
        {
            _testObject.MeasureColumnWidths(GetData());

            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            var splitRow = splitOutput[1].Split('|');
            for (int i = 0; i < _testObject.Count; ++i)
            {
                if (_testObject[i].Alignment == DumpAlignment.Left)
                {
                    Assert.IsTrue(splitRow[i + 1].StartsWith($" {_testObject[i].HeaderText}", StringComparison.InvariantCulture));
                }
                else
                {
                    Assert.IsTrue(splitRow[i + 1].EndsWith($"{_testObject[i].HeaderText} ", StringComparison.InvariantCulture));
                }
            }
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_ReturnsThreeLinesOfText_IfMeasureColumnWidthsHasNotBeenCalled()
        {
            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            Assert.AreEqual(3, splitOutput.Length);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_FirstLineOfReturnedDataEqualsOutputOfGetUnderlineMethod_IfMeasureColumnWidthsHasNotBeenCalled()
        {
            string expectedOutput = _testObject.GetUnderline();

            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            Assert.AreEqual(expectedOutput, splitOutput.First());
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_LastLineOfReturnedDataEqualsOutputOfGetUnderlineMethod_IfMeasureColumnWidthsHasNotBeenCalled()
        {
            string expectedOutput = _testObject.GetUnderline();

            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            Assert.AreEqual(expectedOutput, splitOutput[^1]);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_AllLinesOfDataAreSameLength_IfMeasureColumnWidthsHasNotBeenCalled()
        {
            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            Assert.IsTrue(splitOutput.All(r => r.Length == splitOutput[0].Length));
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_SecondLineContainsCorrectNumberOfSeparatorCharacters_IfMeasureColumnWidthsHasNotBeenCalled()
        {
            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            var splitRow = splitOutput[1].Split('|');
            Assert.AreEqual(_testObject.Count + 2, splitRow.Length);
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_SecondLineContainsCorrectlySpacedSeparatorCharacters_IfMeasureColumnWidthsHasNotBeenCalled()
        {
            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            var splitRow = splitOutput[1].Split('|');
            for (int i = 0; i < _testObject.Count; ++i)
            {
                Assert.AreEqual(_testObject.ColumnWidths[i] + 2, splitRow[i + 1].Length);
            }
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_SecondLineContainsCorrectHeaderText_IfMeasureColumnWidthsHasNotBeenCalled()
        {
            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            var splitRow = splitOutput[1].Split('|');
            for (int i = 0; i < _testObject.Count; ++i)
            {
                Assert.IsTrue(splitRow[i + 1].Contains(_testObject[i].HeaderText, StringComparison.InvariantCulture));
            }
        }

        [TestMethod]
        public void DumpBlockHeaderClass_FormatHeaderMethod_SecondLineContainsFieldsPaddedInCorrectDirection_IfMeasureColumnWidthsHasNotBeenCalled()
        {
            string testOutput = _testObject.FormatHeader();

            var splitOutput = testOutput.Split('\n');
            var splitRow = splitOutput[1].Split('|');
            for (int i = 0; i < _testObject.Count; ++i)
            {
                if (_testObject[i].Alignment == DumpAlignment.Left)
                {
                    Assert.IsTrue(splitRow[i + 1].StartsWith($" {_testObject[i].HeaderText}", StringComparison.InvariantCulture));
                }
                else
                {
                    Assert.IsTrue(splitRow[i + 1].EndsWith($"{_testObject[i].HeaderText} ", StringComparison.InvariantCulture));
                }
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
