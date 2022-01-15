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
    public class Trimmed32BitTableCharacterMappingUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        Trimmed32BitTableCharacterMapping _testObject;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            int dataLength = _rnd.Next(1, 256);
            List<int> data = new(dataLength);
            for (int i = 0; i < dataLength; ++i)
            {
                data.Add(_rnd.NextUShort());
            }
            _testObject = new Trimmed32BitTableCharacterMapping(_rnd.NextPlatformId(), _rnd.NextUShort(), _rnd.NextUShort(), 
                _rnd.NextUInt((uint)(uint.MaxValue - dataLength)), data);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void Trimmed32BitTableCharacterMappingClass_DumpMethod_ReturnsObject()
        {
            var testOutput = _testObject.Dump();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void Trimmed32BitTableCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingPlatform()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Platform.ToString(), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void Trimmed32BitTableCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingLanguage()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Language.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void Trimmed32BitTableCharacterMappingClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingEncoding()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(_testObject.Encoding.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture));
        }

        [TestMethod]
        public void Trimmed23BitTableCharacterMappingClass_DumpMethod_ReturnsObjectWithNoBlockData()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(0, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void Trimmed23BitTableCharacterMappingClass_DumpMethod_ReturnsObjectWithNoNestedBlocks()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(0, testOutput.NestedData.Count());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
