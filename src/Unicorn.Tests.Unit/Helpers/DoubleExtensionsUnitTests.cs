using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Helpers;

namespace Unicorn.Tests.Unit.Helpers
{
    [TestClass]
    public class DoubleExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DoubleExtensionsClass_ScaleToByteMethod_ReturnsByteMaxValue_IfParameterIsGreaterThan1()
        {
            double testParam = _rnd.NextDouble(500) + 1;

            byte testOutput = testParam.ScaleToByte();

            Assert.AreEqual(byte.MaxValue, testOutput);
        }

        [TestMethod]
        public void DoubleExtensionsClass_ScaleToByteMethod_ReturnsByteMaxValue_IfParameterIsEqualTo1()
        {
            double testParam = 1d;

            byte testOutput = testParam.ScaleToByte();

            Assert.AreEqual(byte.MaxValue, testOutput);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void DoubleExtensionsClass_ScaleToByteMethod_ReturnsExpectedValue_IfParameterIsBetweenZeroAndOne()
        {
            int expectedValue = _rnd.Next(byte.MaxValue + 1);
            double testParam = expectedValue / 256d;

            byte testOutput = testParam.ScaleToByte();

            Assert.AreEqual(expectedValue, testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

        [TestMethod]
        public void DoubleExtensionsClass_ScaleToByteMethod_Returns0_IfParameterIs0()
        {
            double testParam = 0d;

            byte testOutput = testParam.ScaleToByte();

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void DoubleExtensionsClass_ScaleToByteMethod_Returns0_IfParameterIsNegative()
        {
            double testParam = _rnd.NextDouble(-500) - double.Epsilon;

            byte testOutput = testParam.ScaleToByte();

            Assert.AreEqual(0, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
