using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Tests.Utility.Providers;
using Unicorn.Base;
using Unicorn.Base.Tests.Utility;
using Unicorn.Writer.Structural;

namespace Unicorn.Tests.Unit.Writer.Structural
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
            IFontDescriptor testParam2 = new Mock<IFontDescriptor>().Object;

            GraphicsState testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam0, testOutput.LineWidth);
        }

        [TestMethod]
        public void GraphicsStateClass_Constructor_SetsDashStylePropertyToValueOfSecondParameter()
        {
            double testParam0 = _rnd.NextDouble() * 5;
            UniDashStyle testParam1 = _rnd.NextUniDashStyle();
            IFontDescriptor testParam2 = new Mock<IFontDescriptor>().Object;

            GraphicsState testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam1, testOutput.DashStyle);
        }

        [TestMethod]
        public void GraphicsStateClass_Constructor_SetsFontPropertyToValueOfThirdParameter()
        {
            double testParam0 = _rnd.NextDouble() * 5;
            UniDashStyle testParam1 = _rnd.NextUniDashStyle();
            IFontDescriptor testParam2 = new Mock<IFontDescriptor>().Object;

            GraphicsState testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreSame(testParam2, testOutput.Font);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
