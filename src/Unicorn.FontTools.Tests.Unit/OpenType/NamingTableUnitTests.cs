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
    public class NamingTableUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private NamingTable _testObject;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            int recordCount = _rnd.Next(1, 100);
            List<NameRecord> data = new(recordCount);
            for (int i = 0; i < recordCount; ++i)
            {
                data.Add(_rnd.NextNameRecord());
            }
            _testObject = new NamingTable(_rnd.NextUShort(), data);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObject()
        {
            var testOutput = _testObject.Dump();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingNameOfTable()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains("name", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingVersionProperty()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains("Version " + _testObject.Version.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void NamingTableClss_DumpMethod_ReturnsObjectWithInfoPropertyContainingNumberOfNamesInTable()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Names.Count.ToString(CultureInfo.CurrentCulture) + " name", StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFiveColumns()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(5, testOutput.BlockHeader.Count);
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFirstColumnNamedPlatform()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Platform", testOutput.BlockHeader[0].HeaderText);
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithSecondColumnNamedEncoding()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Encoding", testOutput.BlockHeader[1].HeaderText);
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithThirdColumnNamedLanguage()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Language", testOutput.BlockHeader[2].HeaderText);
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFourthColumnNamedName()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Name", testOutput.BlockHeader[3].HeaderText);
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFifthColumnNamedText()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Text", testOutput.BlockHeader[4].HeaderText);
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithBlockDataWithSameNumberOfRecordsAsThereAreNamesInTable()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(_testObject.Names.Count, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithBlockDataWithRecordsWhoseFirstValueMatchesThePlatformIdFieldOfEachNameRecord()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < testOutput.BlockData.Count; ++i)
            {
                Assert.AreEqual(_testObject.Names[i].PlatformId.ToString(), testOutput.BlockData[i][0]);
            }
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithBlockDataWithRecordsWhoseSecondValueMatchesTheEncodingIdFieldOfEachNameRecord()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < testOutput.BlockData.Count; ++i)
            {
                Assert.AreEqual(_testObject.Names[i].EncodingId.ToString(CultureInfo.CurrentCulture), testOutput.BlockData[i][1]);
            }
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithBlockDataWithRecordsWhoseThirdValueMatchesTheLanguageIdFieldOfEachNameRecord()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < testOutput.BlockData.Count; ++i)
            {
                Assert.AreEqual(_testObject.Names[i].LanguageId.ToString(CultureInfo.CurrentCulture), testOutput.BlockData[i][2]);
            }
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithBlockDataWithRecordsWhoseFourthValueMatchesTheNameIdFieldOfEachNameRecord()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < testOutput.BlockData.Count; ++i)
            {
                Assert.AreEqual(_testObject.Names[i].NameId.ToString(), testOutput.BlockData[i][3]);
            }
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithBlockDataWithRecordsWhoseFifthValueMatchesTheContentFieldOfEachNameRecord()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < testOutput.BlockData.Count; ++i)
            {
                Assert.AreEqual(_testObject.Names[i].Content, testOutput.BlockData[i][4]);
            }
        }

        [TestMethod]
        public void NamingTableClass_DumpMethod_ReturnsObjectWithNoNestedBlocks()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(0, testOutput.NestedData.Count());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
