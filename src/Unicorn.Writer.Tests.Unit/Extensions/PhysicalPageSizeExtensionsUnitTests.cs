using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Tests.Unit.Extensions
{
    [TestClass]
    public class PhysicalPageSizeExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;
        private static readonly PdfReal _zero = new PdfReal(0);

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithOneParameter_ReturnsCorrectValueWhenParameterEqualsA1()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A1;

            PdfRectangle testOutput = testParam0.ToPdfRectangle();

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(1683), testOutput[2]);
            Assert.AreEqual(new PdfReal(2383), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithOneParameter_ReturnsCorrectValueWhenParameterEqualsA2()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A2;

            PdfRectangle testOutput = testParam0.ToPdfRectangle();

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(1190), testOutput[2]);
            Assert.AreEqual(new PdfReal(1683), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithOneParameter_ReturnsCorrectValueWhenParameterEqualsA3()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A3;

            PdfRectangle testOutput = testParam0.ToPdfRectangle();

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(841), testOutput[2]);
            Assert.AreEqual(new PdfReal(1190), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithOneParameter_ReturnsCorrectValueWhenParameterEqualsA4()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A4;

            PdfRectangle testOutput = testParam0.ToPdfRectangle();

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(595), testOutput[2]);
            Assert.AreEqual(new PdfReal(841), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithOneParameter_ReturnsCorrectValueWhenParameterEqualsA5()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A5;

            PdfRectangle testOutput = testParam0.ToPdfRectangle();

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(419), testOutput[2]);
            Assert.AreEqual(new PdfReal(595), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithOneParameter_ReturnsCorrectValueWhenParameterEqualsA6()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A6;

            PdfRectangle testOutput = testParam0.ToPdfRectangle();

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(297), testOutput[2]);
            Assert.AreEqual(new PdfReal(419), testOutput[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithOneParameter_ThrowsArgumentOutOfRangeExceptionWhenParameterIsLessThanZero()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(_rnd.Next(2048) * -1 - 1);

            testParam0.ToPdfRectangle();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithOneParameter_ThrowsArgumentOutOfRangeExceptionWhenParameterIsEqualToSix()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)6;

            testParam0.ToPdfRectangle();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithOneParameter_ThrowsArgumentOutOfRangeExceptionWhenParameterIsGreaterThanSix()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(6 + _rnd.Next(2048));

            testParam0.ToPdfRectangle();

            Assert.Fail();
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA1AndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A1;
            PageOrientation testParam1 = PageOrientation.Portrait;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(1683), testOutput[2]);
            Assert.AreEqual(new PdfReal(2383), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA2AndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A2;
            PageOrientation testParam1 = PageOrientation.Portrait;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(1190), testOutput[2]);
            Assert.AreEqual(new PdfReal(1683), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA3AndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A3;
            PageOrientation testParam1 = PageOrientation.Portrait;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(841), testOutput[2]);
            Assert.AreEqual(new PdfReal(1190), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA4AndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A4;
            PageOrientation testParam1 = PageOrientation.Portrait;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(595), testOutput[2]);
            Assert.AreEqual(new PdfReal(841), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA5AndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A5;
            PageOrientation testParam1 = PageOrientation.Portrait;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(419), testOutput[2]);
            Assert.AreEqual(new PdfReal(595), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA6AndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A6;
            PageOrientation testParam1 = PageOrientation.Portrait;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(297), testOutput[2]);
            Assert.AreEqual(new PdfReal(419), testOutput[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsLessThanZeroAndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(_rnd.Next(2048) * -1 - 1);
            PageOrientation testParam1 = PageOrientation.Portrait;

            testParam0.ToPdfRectangle(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsEqualToSixAndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)6;
            PageOrientation testParam1 = PageOrientation.Portrait;

            testParam0.ToPdfRectangle(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectanglethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsGreaterThanSixAndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(6 + _rnd.Next(2048));
            PageOrientation testParam1 = PageOrientation.Portrait;

            testParam0.ToPdfRectangle(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA1AndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A1;
            PageOrientation testParam1 = PageOrientation.Landscape;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(1683), testOutput[3]);
            Assert.AreEqual(new PdfReal(2383), testOutput[2]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA2AndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A2;
            PageOrientation testParam1 = PageOrientation.Landscape;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(1190), testOutput[3]);
            Assert.AreEqual(new PdfReal(1683), testOutput[2]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA3AndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A3;
            PageOrientation testParam1 = PageOrientation.Landscape;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(841), testOutput[3]);
            Assert.AreEqual(new PdfReal(1190), testOutput[2]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA4AndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A4;
            PageOrientation testParam1 = PageOrientation.Landscape;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(595), testOutput[3]);
            Assert.AreEqual(new PdfReal(841), testOutput[2]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA5AndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A5;
            PageOrientation testParam1 = PageOrientation.Landscape;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(419), testOutput[3]);
            Assert.AreEqual(new PdfReal(595), testOutput[2]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA6AndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A6;
            PageOrientation testParam1 = PageOrientation.Landscape;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(297), testOutput[3]);
            Assert.AreEqual(new PdfReal(419), testOutput[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsLessThanZeroAndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(_rnd.Next(2048) * -1 - 1);
            PageOrientation testParam1 = PageOrientation.Landscape;

            testParam0.ToPdfRectangle(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsEqualToSixAndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)6;
            PageOrientation testParam1 = PageOrientation.Landscape;

            testParam0.ToPdfRectangle(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsGreaterThanSixAndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(6 + _rnd.Next(2048));
            PageOrientation testParam1 = PageOrientation.Landscape;

            testParam0.ToPdfRectangle(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA1AndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A1;
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(1683), testOutput[2]);
            Assert.AreEqual(new PdfReal(2383), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA2AndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A2;
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(1190), testOutput[2]);
            Assert.AreEqual(new PdfReal(1683), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA3AndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A3;
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(841), testOutput[2]);
            Assert.AreEqual(new PdfReal(1190), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA4AndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A4;
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(595), testOutput[2]);
            Assert.AreEqual(new PdfReal(841), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA5AndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A5;
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(419), testOutput[2]);
            Assert.AreEqual(new PdfReal(595), testOutput[3]);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA6AndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A6;
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            PdfRectangle testOutput = testParam0.ToPdfRectangle(testParam1);

            Assert.AreEqual(_zero, testOutput[0]);
            Assert.AreEqual(_zero, testOutput[1]);
            Assert.AreEqual(new PdfReal(297), testOutput[2]);
            Assert.AreEqual(new PdfReal(419), testOutput[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsLessThanZeroAndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(_rnd.Next(2048) * -1 - 1);
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            testParam0.ToPdfRectangle(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsEqualToSixAndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)6;
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            testParam0.ToPdfRectangle(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToPdfRectangleMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsGreaterThanSixAndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(6 + _rnd.Next(2048));
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            testParam0.ToPdfRectangle(testParam1);

            Assert.Fail();
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}