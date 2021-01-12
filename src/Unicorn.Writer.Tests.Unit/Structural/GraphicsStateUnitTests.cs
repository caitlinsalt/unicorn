using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;
using Unicorn.CoreTypes.Tests.Utility.Extensions;
using Unicorn.Writer.Structural;

namespace Unicorn.Writer.Tests.Unit.Structural
{
    [TestClass]
    public class GraphicsStateUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void GraphicsStateClass_Constructor_SetsLineWidthPropertyToValueOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble() * 5;
            UniDashStyle testParam1 = _rnd.NextUniDashStyle();

            GraphicsState testOutput = new GraphicsState(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.LineWidth);
        }

        [TestMethod]
        public void GraphicsStateClass_Constructor_SetsDashStylePropertyToValueOfSecondParameter()
        {
            double testParam0 = _rnd.NextDouble() * 5;
            UniDashStyle testParam1 = _rnd.NextUniDashStyle();

            GraphicsState testOutput = new GraphicsState(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.DashStyle);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
