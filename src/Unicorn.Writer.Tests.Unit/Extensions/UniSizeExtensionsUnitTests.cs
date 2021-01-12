using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Tests.Unit.Extensions
{
    [TestClass]
    public class UniSizeExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static UniSize GetUniSize()
        {
            return new UniSize(_rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void UniSizeExtensionsClass_ToPdfRectangleMethod_ReturnsObjectWithFirstElementEqualToZero()
        {
            UniSize testParam0 = GetUniSize();

            PdfRectangle testOutput = testParam0.ToPdfRectangle();

            Assert.AreEqual(new PdfReal(0), testOutput[0]);
        }

        [TestMethod]
        public void UniSizeExtensionsClass_ToPdfRectangleMethod_ReturnsObjectWithSecondElementEqualToZero()
        {
            UniSize testParam0 = GetUniSize();

            PdfRectangle testOutput = testParam0.ToPdfRectangle();

            Assert.AreEqual(new PdfReal(0), testOutput[1]);
        }

        [TestMethod]
        public void UniSizeExtensionsClass_ToPdfRectangleMethod_ReturnsObjectWithThirdElementEqualInValueToWidthOfFirstParameter()
        {
            UniSize testParam0 = GetUniSize();

            PdfRectangle testOutput = testParam0.ToPdfRectangle();

            Assert.AreEqual((decimal)testParam0.Width, (testOutput[2] as PdfReal).Value);
        }

        [TestMethod]
        public void UniSizeExtensionsClass_ToPdfRectangleMethod_ReturnsObjectWithFourthElementEqualInValueToHeightOfFirstParameter()
        {
            UniSize testParam0 = GetUniSize();

            PdfRectangle testOutput = testParam0.ToPdfRectangle();

            Assert.AreEqual((decimal)testParam0.Height, (testOutput[3] as PdfReal).Value);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
