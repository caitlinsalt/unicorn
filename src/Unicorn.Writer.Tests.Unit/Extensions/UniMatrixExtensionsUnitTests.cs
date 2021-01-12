using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;
using Unicorn.CoreTypes.Tests.Utility.Extensions;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Tests.Unit.Extensions
{
    [TestClass]
    public class UniMatrixExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void UniMatrixExtensionsClass_ToPdfRealArrayMethod_ReturnsArrayofLengthSix()
        {
            UniMatrix testParam = _rnd.NextUniMatrix();

            PdfReal[] testOutput = testParam.ToPdfRealArray();

            Assert.AreEqual(6, testOutput.Length);
        }

        [TestMethod]
        public void UniMatrixExtensionsClass_ToPdfRealArrayMethod_ReturnsArrayWithFirstElementWithValueEqualToR0C0PropertyOfParameter()
        {
            UniMatrix testParam = _rnd.NextUniMatrix();

            PdfReal[] testOutput = testParam.ToPdfRealArray();

            Assert.AreEqual((decimal)testParam.R0C0, testOutput[0].Value);
        }

        [TestMethod]
        public void UniMatrixExtensionsClass_ToPdfRealArrayMethod_ReturnsArrayWithSecondElementWithValueEqualToR0C1PropertyOfParameter()
        {
            UniMatrix testParam = _rnd.NextUniMatrix();

            PdfReal[] testOutput = testParam.ToPdfRealArray();

            Assert.AreEqual((decimal)testParam.R0C1, testOutput[1].Value);
        }

        [TestMethod]
        public void UniMatrixExtensionsClass_ToPdfRealArrayMethod_ReturnsArrayWithThirdElementWithValueEqualToR1C0PropertyOfParameter()
        {
            UniMatrix testParam = _rnd.NextUniMatrix();

            PdfReal[] testOutput = testParam.ToPdfRealArray();

            Assert.AreEqual((decimal)testParam.R1C0, testOutput[2].Value);
        }

        [TestMethod]
        public void UniMatrixExtensionsClass_ToPdfRealArrayMethod_ReturnsArrayWithFourthElementWithValueEqualToR1C1PropertyOfParameter()
        {
            UniMatrix testParam = _rnd.NextUniMatrix();

            PdfReal[] testOutput = testParam.ToPdfRealArray();

            Assert.AreEqual((decimal)testParam.R1C1, testOutput[3].Value);
        }

        [TestMethod]
        public void UniMatrixExtensionsClass_ToPdfRealArrayMethod_ReturnsArrayWithFifthElementWithValueEqualToR2C0PropertyOfParameter()
        {
            UniMatrix testParam = _rnd.NextUniMatrix();

            PdfReal[] testOutput = testParam.ToPdfRealArray();

            Assert.AreEqual((decimal)testParam.R2C0, testOutput[4].Value);
        }

        [TestMethod]
        public void UniMatrixExtensionsClass_ToPdfRealArrayMethod_ReturnsArrayWithSixthElementWithValueEqualToR2C1PropertyOfParameter()
        {
            UniMatrix testParam = _rnd.NextUniMatrix();

            PdfReal[] testOutput = testParam.ToPdfRealArray();

            Assert.AreEqual((decimal)testParam.R2C1, testOutput[5].Value);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
