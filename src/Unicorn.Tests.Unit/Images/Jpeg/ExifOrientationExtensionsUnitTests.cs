using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unicorn.Images.Jpeg;

namespace Unicorn.Tests.Unit.Images.Jpeg
{
    [TestClass]
    public class ExifOrientationExtensionsUnitTests
    {

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ExifOrientationExtensionsClass_IsQuarterRotatedMethod_ReturnsFalse_IfFirstParameterEqualsNormal()
        {
            ExifOrientation testParam = ExifOrientation.Normal;

            bool testOutput = testParam.IsQuarterRotated();

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void ExifOrientationExtensionsClass_IsQuarterRotatedMethod_ReturnsFalse_IfFirstParameterEqualsFlippedHorizontally()
        {
            ExifOrientation testParam = ExifOrientation.FlippedHorizontally;

            bool testOutput = testParam.IsQuarterRotated();

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void ExifOrientationExtensionsClass_IsQuarterRotatedMethod_ReturnsFalse_IfFirstParameterEqualsRotated180()
        {
            ExifOrientation testParam = ExifOrientation.Rotated180;

            bool testOutput = testParam.IsQuarterRotated();

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void ExifOrientationExtensionsClass_IsQuarterRotatedMethod_ReturnsFalse_IfFirstParameterEqualsFlippedVertically()
        {
            ExifOrientation testParam = ExifOrientation.FlippedVertically;

            bool testOutput = testParam.IsQuarterRotated();

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void ExifOrientationExtensionsClass_IsQuarterRotatedMethod_ReturnsTrue_IfFirstParameterEqualsRotatedAnticlockwiseThenFlippedVertically()
        {
            ExifOrientation testParam = ExifOrientation.RotatedAnticlockwiseThenFlippedVertically;

            bool testOutput = testParam.IsQuarterRotated();

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void ExifOrientationExtensionsClass_IsQuarterRotatedMethod_ReturnsTrue_IfFirstParameterEqualsRotatedClockwise()
        {
            ExifOrientation testParam = ExifOrientation.RotatedClockwise;

            bool testOutput = testParam.IsQuarterRotated();

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void ExifOrientationExtensionsClass_IsQuarterRotatedMethod_ReturnsTrue_IfFirstParameterEqualsRotatedClockwiseThenFlippedVertically()
        {
            ExifOrientation testParam = ExifOrientation.RotatedClockwiseThenFlippedVertically;

            bool testOutput = testParam.IsQuarterRotated();

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void ExifOrientationExtensionsClass_IsQuarterRotatedMethod_ReturnsTrue_IfFirstParameterEqualsRotatedAnticlockwise()
        {
            ExifOrientation testParam = ExifOrientation.RotatedAnticlockwise;

            bool testOutput = testParam.IsQuarterRotated();

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
