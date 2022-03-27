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
    public class Segmented32BitCharacterMappingUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static readonly CharacterMappingFormat[] _validCharacterMappingFormats = new[] 
        { 
            CharacterMappingFormat.Mixed32BitMapping, 
            CharacterMappingFormat.Trimmed32BitTableMapping, 
            CharacterMappingFormat.ManyToOneMapping 
        };

        private CharacterMappingFormat _testObjectVersion;
        private List<SequentialMapGroupRecord> _testSegments;
        private Segmented32BitCharacterMapping _testObject;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static CharacterMappingFormat NextValidCharacterMappingFormat() => _validCharacterMappingFormats[_rnd.Next(_validCharacterMappingFormats.Length)];

        [TestInitialize]
        public void SetUpTest()
        {
            int recordCount = _rnd.Next(1, 100);
            _testSegments = new(recordCount);
            for (int i = 0; i < recordCount; ++i)
            {
                _testSegments.Add(_rnd.NextOpenTypeSequentialMapGroupRecord());
            }
            _testObjectVersion = NextValidCharacterMappingFormat();
            _testObject = new Segmented32BitCharacterMapping(_rnd.NextPlatformId(), _rnd.NextUShort(), _rnd.NextUShort(), _testObjectVersion, _testSegments);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void Segmented32BitCharacterMappingClass_DumpMethod_ReturnsObject()
        {
            var testOutput = _testObject.Dump();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void Segmented32BitCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingPlatform()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Platform.ToString(), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void Segmented32BitCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingLanguage()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Language.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void Segmented32BitCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingEncoding()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Encoding.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void Segmented32BitCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingVersion()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObjectVersion.ToString(), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void Segmented32BitCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockHeaderWithThreeColumns()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(3, testOutput.BlockHeader.Count);
        }

        [TestMethod]
        public void Segmented32BitCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFirstColumnNamedStart()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Start", testOutput.BlockHeader[0].HeaderText);
        }

        [TestMethod]
        public void Segmented32BitCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockHeaderWithSecondColumnNamedEnd()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("End", testOutput.BlockHeader[1].HeaderText);
        }

        [TestMethod]
        public void Segmented32BitCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockHeaderWithThirdColumnNamedOffset()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Offset", testOutput.BlockHeader[2].HeaderText);
        }

        [TestMethod]
        public void Segmented23BitCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockDataWithSameNumberOfElementsAsDataSegmentsInObject()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(_testSegments.Count, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void Segmented32BitCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectStartCodeValuesInEachRecord()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < _testSegments.Count; ++i)
            {
                Assert.AreEqual(_testSegments[i].StartCode.ToString(CultureInfo.CurrentCulture), testOutput.BlockData[i][0]);
            }
        }

        [TestMethod]
        public void Segmented32BitCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectEndCodeValuesInEachRecord()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < _testSegments.Count; ++i)
            {
                Assert.AreEqual(_testSegments[i].EndCode.ToString(CultureInfo.CurrentCulture), testOutput.BlockData[i][1]);
            }
        }

        [TestMethod]
        public void Segmented32BitCharacterMappingClass_DumpMethod_ReturnsObjectWithBlockDataWithCorrectStartGlyphIdValuesInEachRecord()
        {
            var testOutput = _testObject.Dump();

            for (int i = 0; i < _testSegments.Count; ++i)
            {
                Assert.AreEqual(_testSegments[i].StartGlyphId.ToString(CultureInfo.CurrentCulture), testOutput.BlockData[i][2]);
            }
        }

        [TestMethod]
        public void Segmented32BitCharacterMappingClass_DumpMethod_ReturnsObjectWithNoNestedBlocks()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(0, testOutput.NestedData.Count());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
