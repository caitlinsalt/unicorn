using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;

namespace Unicorn.CoreTypes.Tests.Unit
{
    [TestClass]
    public class PhysicalPageSizeExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithOneParameter_ReturnsCorrectValueWhenParameterEqualsA1()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A1;

            UniSize testOutput = testParam0.ToUniSize();

            Assert.AreEqual(1683, testOutput.Width);
            Assert.AreEqual(2383, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithOneParameter_ReturnsCorrectValueWhenParameterEqualsA2()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A2;

            UniSize testOutput = testParam0.ToUniSize();

            Assert.AreEqual(1190, testOutput.Width);
            Assert.AreEqual(1683, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithOneParameter_ReturnsCorrectValueWhenParameterEqualsA3()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A3;

            UniSize testOutput = testParam0.ToUniSize();

            Assert.AreEqual(841, testOutput.Width);
            Assert.AreEqual(1190, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithOneParameter_ReturnsCorrectValueWhenParameterEqualsA4()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A4;

            UniSize testOutput = testParam0.ToUniSize();

            Assert.AreEqual(595, testOutput.Width);
            Assert.AreEqual(841, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithOneParameter_ReturnsCorrectValueWhenParameterEqualsA5()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A5;

            UniSize testOutput = testParam0.ToUniSize();

            Assert.AreEqual(419, testOutput.Width);
            Assert.AreEqual(595, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithOneParameter_ReturnsCorrectValueWhenParameterEqualsA6()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A6;

            UniSize testOutput = testParam0.ToUniSize();

            Assert.AreEqual(297, testOutput.Width);
            Assert.AreEqual(419, testOutput.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithOneParameter_ThrowsArgumentOutOfRangeExceptionWhenParameterIsLessThanZero()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(_rnd.Next(2048) * -1 - 1);

            testParam0.ToUniSize();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithOneParameter_ThrowsArgumentOutOfRangeExceptionWhenParameterIsEqualToSix()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)6;

            testParam0.ToUniSize();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithOneParameter_ThrowsArgumentOutOfRangeExceptionWhenParameterIsGreaterThanSix()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(6 + _rnd.Next(2048));

            testParam0.ToUniSize();

            Assert.Fail();
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA1AndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A1;
            PageOrientation testParam1 = PageOrientation.Portrait;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(1683, testOutput.Width);
            Assert.AreEqual(2383, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA2AndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A2;
            PageOrientation testParam1 = PageOrientation.Portrait;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(1190, testOutput.Width);
            Assert.AreEqual(1683, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA3AndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A3;
            PageOrientation testParam1 = PageOrientation.Portrait;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(841, testOutput.Width);
            Assert.AreEqual(1190, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA4AndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A4;
            PageOrientation testParam1 = PageOrientation.Portrait;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(595, testOutput.Width);
            Assert.AreEqual(841, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA5AndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A5;
            PageOrientation testParam1 = PageOrientation.Portrait;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(419, testOutput.Width);
            Assert.AreEqual(595, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA6AndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A6;
            PageOrientation testParam1 = PageOrientation.Portrait;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(297, testOutput.Width);
            Assert.AreEqual(419, testOutput.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsLessThanZeroAndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(_rnd.Next(2048) * -1 - 1);
            PageOrientation testParam1 = PageOrientation.Portrait;

            testParam0.ToUniSize(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsEqualToSixAndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)6;
            PageOrientation testParam1 = PageOrientation.Portrait;

            testParam0.ToUniSize(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsGreaterThanSixAndSecondParameterEqualsPortrait()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(6 + _rnd.Next(2048));
            PageOrientation testParam1 = PageOrientation.Portrait;

            testParam0.ToUniSize(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA1AndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A1;
            PageOrientation testParam1 = PageOrientation.Landscape;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(1683, testOutput.Height);
            Assert.AreEqual(2383, testOutput.Width);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA2AndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A2;
            PageOrientation testParam1 = PageOrientation.Landscape;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(1190, testOutput.Height);
            Assert.AreEqual(1683, testOutput.Width);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA3AndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A3;
            PageOrientation testParam1 = PageOrientation.Landscape;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(841, testOutput.Height);
            Assert.AreEqual(1190, testOutput.Width);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA4AndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A4;
            PageOrientation testParam1 = PageOrientation.Landscape;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(595, testOutput.Height);
            Assert.AreEqual(841, testOutput.Width);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA5AndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A5;
            PageOrientation testParam1 = PageOrientation.Landscape;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(419, testOutput.Height);
            Assert.AreEqual(595, testOutput.Width);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA6AndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A6;
            PageOrientation testParam1 = PageOrientation.Landscape;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(297, testOutput.Height);
            Assert.AreEqual(419, testOutput.Width);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsLessThanZeroAndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(_rnd.Next(2048) * -1 - 1);
            PageOrientation testParam1 = PageOrientation.Landscape;

            testParam0.ToUniSize(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsEqualToSixAndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)6;
            PageOrientation testParam1 = PageOrientation.Landscape;

            testParam0.ToUniSize(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsGreaterThanSixAndSecondParameterEqualsLandscape()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(6 + _rnd.Next(2048));
            PageOrientation testParam1 = PageOrientation.Landscape;

            testParam0.ToUniSize(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA1AndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A1;
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(1683, testOutput.Width);
            Assert.AreEqual(2383, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA2AndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A2;
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(1190, testOutput.Width);
            Assert.AreEqual(1683, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA3AndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A3;
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(841, testOutput.Width);
            Assert.AreEqual(1190, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA4AndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A4;
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(595, testOutput.Width);
            Assert.AreEqual(841, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA5AndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A5;
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(419, testOutput.Width);
            Assert.AreEqual(595, testOutput.Height);
        }

        [TestMethod]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ReturnsCorrectValueWhenFirstParameterEqualsA6AndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = PhysicalPageSize.A6;
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            UniSize testOutput = testParam0.ToUniSize(testParam1);

            Assert.AreEqual(297, testOutput.Width);
            Assert.AreEqual(419, testOutput.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsLessThanZeroAndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(_rnd.Next(2048) * -1 - 1);
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            testParam0.ToUniSize(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsEqualToSixAndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)6;
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            testParam0.ToUniSize(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhysicalPageSizeExtensionsClass_ToUniSizeMethodWithTwoParameters_ThrowsArgumentOutOfRangeExceptionWhenFirstParameterIsGreaterThanSixAndSecondParameterEqualsArbitrary()
        {
            PhysicalPageSize testParam0 = (PhysicalPageSize)(6 + _rnd.Next(2048));
            PageOrientation testParam1 = PageOrientation.Arbitrary;

            testParam0.ToUniSize(testParam1);

            Assert.Fail();
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
