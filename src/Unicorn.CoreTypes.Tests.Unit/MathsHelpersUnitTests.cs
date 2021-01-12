using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Unicorn.CoreTypes.Tests.Unit
{
    [TestClass]
    public class MathsHelpersUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void MathsHelpersClass_DegToRadMethod_ReturnsCorrectValue()
        {
            double testParam = _rnd.NextDouble() * 720 * (_rnd.NextBoolean() ? 1 : -1);
            double expectedValue = (testParam / 180) * Math.PI;

            double testOutput = MathsHelpers.DegToRad(testParam);

            Assert.AreEqual(expectedValue, testOutput, 0.00000000001);
        }

        [TestMethod]
        public void MathsHelpersClass_RadToDegMethod_ReturnsCorrectValue()
        {
            double testParam = _rnd.NextDouble() * 4 * Math.PI * (_rnd.NextBoolean() ? 1 : -1);
            double expectedValue = (testParam / Math.PI) * 180;

            double testOutput = MathsHelpers.RadToDeg(testParam);

            Assert.AreEqual(expectedValue, testOutput, 0.00000000001);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
