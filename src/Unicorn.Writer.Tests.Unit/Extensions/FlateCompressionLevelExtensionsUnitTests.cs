using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;
using Unicorn.Writer.Extensions;

namespace Unicorn.Writer.Tests.Unit.Extensions
{
    [TestClass]
    public class FlateCompressionLevelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void FlateCompressionLevelExtensionsClass_ToSharpZipLibIntMethod_ReturnsZero_IfParameterEqualsNone()
        {
            FlateCompressionLevel testParam = FlateCompressionLevel.None;

            int testOutput = testParam.ToSharpZipLibInt();

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void FlateCompressionLevelExtensionsClass_ToSharpZipLibIntMethod_ReturnsOne_IfParameterEqualsFastest()
        {
            FlateCompressionLevel testParam = FlateCompressionLevel.Fastest;

            int testOutput = testParam.ToSharpZipLibInt();

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void FlateCompressionLevelExtensionsClass_ToSharpZipLibIntMethod_ReturnsEight_IfParameterEqualsDefault()
        {
            FlateCompressionLevel testParam = FlateCompressionLevel.Default;

            int testOutput = testParam.ToSharpZipLibInt();

            Assert.AreEqual(8, testOutput);
        }

        [TestMethod]
        public void FlateCompressionLevelExtensionsClass_ToSharpZipLibIntMethod_ReturnsNine_IfParameterEqualsBest()
        {
            FlateCompressionLevel testParam = FlateCompressionLevel.Best;

            int testOutput = testParam.ToSharpZipLibInt();

            Assert.AreEqual(9, testOutput);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void FlateCompressionLevelExtensionsClass_ToSharpZipLibIntMethod_ReturnsEight_IfParameterIsNotAValidFlateCompressionLevelValue()
        {
            FlateCompressionLevel testParam = (FlateCompressionLevel)_rnd.Next(3, int.MaxValue);

            int testOutput = testParam.ToSharpZipLibInt();

            Assert.AreEqual(8, testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
