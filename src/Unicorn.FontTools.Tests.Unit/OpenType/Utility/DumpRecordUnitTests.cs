using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType.Utility;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit.OpenType.Utility
{
    [TestClass]
    public class DumpRecordUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;
        private List<string> _fieldValues;
        private DumpBlockHeader _header;
        private DumpRecord _testObject;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            int fieldCount = _rnd.Next(1, 20);
            _fieldValues = new List<string>(fieldCount);
            for (int i = 0; i < fieldCount; ++i)
            {
                _fieldValues.Add(_rnd.NextString(_rnd.Next(1, 20)));
            }
            _testObject = new DumpRecord(_fieldValues);
            _header = GetCorrectHeader();
            _header.MeasureColumnWidths(new[] { _testObject });
        }

        private static DumpBlockHeader GetHeader(int fieldCount)
        {
            List<DumpColumn> headerData = new(fieldCount);
            for (int i = 0; i < fieldCount; ++i)
            {
                headerData.Add(_rnd.NextDumpColumn());
            }
            return new DumpBlockHeader(headerData);
        }

        private DumpBlockHeader GetBrokenHeader() => GetHeader(_rnd.Next(_testObject.Count));

        private DumpBlockHeader GetCorrectHeader() => GetHeader(_testObject.Count);

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DumpRecordClass_ConstructorWithIEnumerableParameter_SetsCountToZero_IfParameterIsNull()
        {
            IEnumerable<string> testParam = null;

            DumpRecord testOutput = new(testParam);

            Assert.AreEqual(0, testOutput.Count);
        }

        [TestMethod]
        public void DumpRecordClass_ConstructorWithIEnumerableParameter_SetsCountToZero_IfParameterIsEmptySequence()
        {
            IEnumerable<string> testParam = Array.Empty<string>();

            DumpRecord testOutput = new(testParam);

            Assert.AreEqual(0, testOutput.Count);
        }

        [TestMethod]
        public void DumpRecordClass_ConstructorWithIEnumerableParameter_SetsCountToCorrectValue_IfParameterIsNotNull()
        {
            IEnumerable<string> testParam = _fieldValues;

            DumpRecord testOutput = new(testParam);

            Assert.AreEqual(_fieldValues.Count, testOutput.Count);
        }

        [TestMethod]
        public void DumpRecordClass_ConstructorWithIEnumerableParameter_CreatesObjectWithCorrectContent_IfParameterIsNotNull()
        {
            IEnumerable<string> testParam = _fieldValues;

            DumpRecord testOutput = new(testParam);

            for (int i = 0; i < _fieldValues.Count; ++i)
            {
                Assert.AreEqual(_fieldValues[i], testOutput[i]);
            }
        }

        [TestMethod]
        public void DumpRecordClass_ConstructorWithArrayParameter_SetsCountToZero_IfParameterIsEmptySequence()
        {
            string[] testParam = Array.Empty<string>();

            DumpRecord testOutput = new(testParam);

            Assert.AreEqual(0, testOutput.Count);
        }

        [TestMethod]
        public void DumpRecordClass_ConstructorWithArrayParameter_SetsCountToCorrectValue_IfParameterIsNotNull()
        {
            string[] testParam = _fieldValues.ToArray();

            DumpRecord testOutput = new(testParam);

            Assert.AreEqual(_fieldValues.Count, testOutput.Count);
        }

        [TestMethod]
        public void DumpRecordClass_ConstructorWithArrayParameter_CreatesObjectWithCorrectContent_IfParameterIsNotNull()
        {
            string[] testParam = _fieldValues.ToArray();

            DumpRecord testOutput = new(testParam);

            for (int i = 0; i < _fieldValues.Count; ++i)
            {
                Assert.AreEqual(_fieldValues[i], testOutput[i]);
            }
        }

        [TestMethod]
        public void DumpRecordClass_GetEnumeratorMethod_ReturnsEnumeratorThatBehavesAsExpected()
        {
            IEnumerator<string> testOutput = _testObject.GetEnumerator();

            for (int i = 0; i < _testObject.Count; ++i)
            {
                testOutput.MoveNext();
                Assert.AreEqual(_testObject[i], testOutput.Current);
            }
            Assert.IsFalse(testOutput.MoveNext());
        }

        [TestMethod]
        public void DumpRecordClass_NonGenericGetEnumeratorMethod_ReturnsEnumeratorThatBehavesAsExpected()
        {
            IEnumerator testOutput = (_testObject as IEnumerable).GetEnumerator();

            for (int i = 0; i < _testObject.Count; ++i)
            {
                testOutput.MoveNext();
                Assert.AreEqual(_testObject[i], (string)testOutput.Current);
            }
            Assert.IsFalse(testOutput.MoveNext());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DumpRecordClass_FormatRecordMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            _testObject.FormatRecord(null);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DumpRecordClass_FormatRecordMethod_ThrowsArgumentException_IfCountPropertyOfParameterIsLessThanCountPropertyOfObject()
        {
            _testObject.FormatRecord(GetBrokenHeader());

            Assert.Fail();
        }

        [TestMethod]
        public void DumpRecordClass_FormatRecordMethod_ReturnsOneLineOfText()
        {
            string testOutput = _testObject.FormatRecord(_header);

            Assert.IsTrue(!testOutput.Contains('\n', StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void DumpRecordClass_FormatRecordMethod_PadsRecordToCorrectLengthAsSpecifiedByHeader()
        {
            string testOutput = _testObject.FormatRecord(_header);
            // Total width of columns as set in header, plus one separator and two margins per column, plus one additional separator.
            int expectedValue = _header.ColumnWidths.Sum() + _testObject.Count * 3 + 1;

            Assert.AreEqual(expectedValue, testOutput.Length);
        }

        [TestMethod]
        public void DumpRecordClass_FormatRecordMethod_ReturnsStringContainingCorrectNumberOfSeparatorCharacters()
        {
            string testOutput = _testObject.FormatRecord(_header);

            string[] splitOutput = testOutput.Split('|');
            Assert.AreEqual(_testObject.Count + 2, splitOutput.Length);
        }

        [TestMethod]
        public void DumpRecordClass_FormatRecordMethod_ReturnsStringContainingCorrectlySpacedSeparatorCharacters()
        {
            string testOutput = _testObject.FormatRecord(_header);

            string[] splitOutput = testOutput.Split('|');
            for (int i = 0; i < _testObject.Count; ++i)
            {
                Assert.AreEqual(_header.ColumnWidths[i] + 2, splitOutput[i + 1].Length);
            }
        }

        [TestMethod]
        public void DumpRecordClass_FormatRecordMethod_ReturnsStringContainingCorrectData()
        {
            string testOutput = _testObject.FormatRecord(_header);

            string[] splitOutput = testOutput.Split('|');
            for (int i = 0; i < _testObject.Count; ++i)
            {
                Assert.IsTrue(splitOutput[i + 1].Contains(_testObject[i], StringComparison.InvariantCulture));
            }
        }

        [TestMethod]
        public void DumpRecordClass_FormatRecordMethod_ReturnsStringContainingCorrectlyPaddedData()
        {
            string testOutput = _testObject.FormatRecord(_header);

            string[] splitOutput = testOutput.Split('|');
            for (int i = 0; i < _testObject.Count; ++i)
            {
                if (_header[i].Alignment == DumpAlignment.Left)
                {
                    Assert.IsTrue(splitOutput[i + 1].StartsWith($" {_testObject[i]}", StringComparison.InvariantCulture));
                }
                else
                {
                    Assert.IsTrue(splitOutput[i + 1].EndsWith($"{_testObject[i]} ", StringComparison.InvariantCulture));
                }
            }
        }

        [TestMethod]
        public void DumpRecordClass_FormatRecord_ReturnsStringStartingWithSeparator()
        {
            string testOutput = _testObject.FormatRecord(_header);

            Assert.IsTrue(testOutput.StartsWith("|", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void DumpRecordClass_FormatRecord_ReturnsStringEndingWithSeparator()
        {
            string testOutput = _testObject.FormatRecord(_header);

            Assert.IsTrue(testOutput.EndsWith("|", StringComparison.InvariantCulture));
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
