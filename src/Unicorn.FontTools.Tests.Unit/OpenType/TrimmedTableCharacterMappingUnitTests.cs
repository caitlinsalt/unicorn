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
    public class TrimmedTableCharacterMappingUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private List<int> _testData;
        private int _codePointOffset;
        private TrimmedTableCharacterMapping _testObject;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            int dataLength = _rnd.Next(1, 256);
            _testData = new List<int>(dataLength);
            for (int i = 0; i < dataLength; ++i)
            {
                _testData.Add(_rnd.NextUShort());
            }
            _codePointOffset = _rnd.NextUShort((ushort)(ushort.MaxValue - dataLength));
            _testObject = new TrimmedTableCharacterMapping(_rnd.NextPlatformId(), _rnd.NextUShort(), _rnd.NextUShort(), _codePointOffset, _testData);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrimmedTableCharacterMappingClass_DumpMethod_ReturnsObject()
        {
            var testOutput = _testObject.Dump();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void TrimmedTableCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingPlatform()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Platform.ToString(), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void TrimmedTableCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingEncoding()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Encoding.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void TrimmedTableCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingLanguage()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Language.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void TrimmedTableCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockHeaderWithTwoColumns()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(2, testOutput.BlockHeader.Count);
        }

        [TestMethod]
        public void TrimmedTableCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFirstColumnNamedCodePoint()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Code point", testOutput.BlockHeader[0].HeaderText);
        }

        [TestMethod]
        public void TrimmedTableCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockHeaderWithSecondColumnNamedGlyph()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Glyph", testOutput.BlockHeader[1].HeaderText);
        }

        [TestMethod]
        public void TrimmedTableCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectNumberOfRecords()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(_testData.Count, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void TrimmedTableCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockDataContainingRecordForEachMapping()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < _testData.Count; ++i)
            {
                var testRecord = testOutput.BlockData.Single(r => r[0] == (i + _codePointOffset).ToString(CultureInfo.CurrentCulture));
                Assert.AreEqual(_testData[i].ToString(CultureInfo.CurrentCulture), testRecord[1]);
            }
        }

        [TestMethod]
        public void TrimmedTableCharacterMappingClass_DumpMethod_ReturnsObjectWithNoNestedBlocks()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(0, testOutput.NestedData.Count());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
