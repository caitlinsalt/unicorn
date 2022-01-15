using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit.OpenType
{
    [TestClass]
    public class HighByteSubheaderCharacterMappingUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private HighByteSubheaderCharacterMapping _testObject;

        [TestInitialize]
        public void SetUpTest()
        {
            _testObject = new HighByteSubheaderCharacterMapping(_rnd.NextPlatformId(), _rnd.NextUShort(), _rnd.NextUShort(), new int[256], 
                Array.Empty<HighByteSubheaderRecord>(), null);
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void HighByteSubheaderCharacterMappingClass_DumpMethod_ReturnsObject()
        {
            var testOutput = _testObject.Dump();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderCharacterMappingClass_DumpMethod_ReturnsObjectContainingNoBlockData()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(0, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void HighByteSubheaderCharacterMappingClass_DumpMethod_ReturnsObjectContainingNoNestedBlocks()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(0, testOutput.NestedData.Count());
        }

        [TestMethod]
        public void HighByteSubheaderCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingPlatformId()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Platform.ToString(), StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void HighByteSubheaderCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingLanguage()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Language.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void HighByteSubheaderCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingEncoding()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Encoding.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCulture));
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
