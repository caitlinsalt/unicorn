using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;
using Unicorn.CoreTypes.Tests.Utility.Extensions;
using Unicorn.Writer.Filters;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Tests.Unit.Filters
{
    [TestClass]
    public class FlateEncoderUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void FlateEncoderClass_Constructor_SetsCompressionLevelPropertyToValueOfParameter()
        {
            FlateCompressionLevel testParam0 = _rnd.NextFlateCompressionLevel();

            FlateEncoder testOutput = new FlateEncoder(testParam0);

            Assert.AreEqual(testParam0, testOutput.CompressionLevel);
        }

        [TestMethod]
        public void FlateEncoderClass_FilterNameProperty_EqualsObjectWithCorrectName()
        {
            FlateCompressionLevel constrParam = _rnd.NextFlateCompressionLevel();
            FlateEncoder testObject = new FlateEncoder(constrParam);

            PdfName testOutput = testObject.FilterName;

            Assert.AreEqual("FlateDecode", testOutput.Value);
        }

        [TestMethod]
        public void FlateEncoderClass_InstanceProperty_HasCompressionLevelPropertyEqualToBest()
        {
            FlateEncoder testOutput = FlateEncoder.Instance;

            Assert.AreEqual(FlateCompressionLevel.Best, testOutput.CompressionLevel);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
