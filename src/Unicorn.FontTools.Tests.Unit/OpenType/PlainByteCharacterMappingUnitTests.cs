using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit.OpenType
{
    [TestClass]
    public class PlainByteCharacterMappingUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private PlainByteCharacterMapping _testObject;
        private byte[] _mapData;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            _mapData = new byte[256];
            _rnd.NextBytes(_mapData);
            _testObject = new PlainByteCharacterMapping(_rnd.NextPlatformId(), _rnd.NextUShort(), _rnd.NextUShort(), _mapData);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void PlainByteCharacterMappingClass_DumpMethod_ReturnsObject()
        {
            var testOutput = _testObject.Dump();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void PlainByteCharacterMappingClass_DumpMethod_ReturnsObjectWithNoBlockData()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(0, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void PlainByteCharacterMappingClass_DumpMethod_ReturnsObjectWithNoNestedBlocks()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(0, testOutput.NestedData.Count());
        }

        [TestMethod]
        public void PlainByteCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingPlatformInFirstLine()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Split('\n').First().Contains(_testObject.Platform.ToString(), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void PlainByteCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingEncodingInFirstLine()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Split('\n').First().Contains(_testObject.Encoding.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void PlainByteCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingLanguageInFirstLine()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Split('\n').First().Contains(_testObject.Language.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void PlainByteCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyConsistingOf19Rows()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(20, testOutput.Info.Split('\n').Length);
        }

        [TestMethod]
        public void PlainByteCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingDataAtCorrectPlaceInEachRow()
        {
            var testOutput = _testObject.Dump();

            var splitOutput = testOutput.Info.Split('\n');
            for (int i = 0; i < 256; ++i)
            {
                int row = i / 16 + 3;
                int col = (i % 16) * 3 + 5;
                string code = splitOutput[row].Substring(col, 2);
                Assert.AreEqual(_mapData[i].ToString("x2", CultureInfo.CurrentCulture), code);
            }

        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
