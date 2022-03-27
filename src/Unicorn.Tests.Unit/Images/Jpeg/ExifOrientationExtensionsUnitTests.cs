using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unicorn.Base;
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

        [TestMethod]
        public void ExifOrientationExtensionsClass_ToRightAngleRotationMethod_ReturnsClockwise90_IfParameterEqualsRotatedClockwise()
        {
            ExifOrientation testParam = ExifOrientation.RotatedClockwise;

            RightAngleRotation testOutput = testParam.ToRightAngleRotation();

            Assert.AreEqual(RightAngleRotation.Clockwise90, testOutput);
        }

        [TestMethod]
        public void ExifOrientationExtensionsClass_ToRightAngleRotationMethod_ReturnsClockwise90_IfParameterEqualsRotatedClockwiseThenFlippedVertically()
        {
            ExifOrientation testParam = ExifOrientation.RotatedClockwiseThenFlippedVertically;

            RightAngleRotation testOutput = testParam.ToRightAngleRotation();

            Assert.AreEqual(RightAngleRotation.Clockwise90, testOutput);
        }

        [TestMethod]
        public void ExifOrientationExtensionsClass_ToRightAngleRotationMethod_ReturnsAnticlockwise90_IfParameterEqualsRotatedAnticlockwise()
        {
            ExifOrientation testParam = ExifOrientation.RotatedAnticlockwise;

            RightAngleRotation testOutput = testParam.ToRightAngleRotation();

            Assert.AreEqual(RightAngleRotation.Anticlockwise90, testOutput);
        }

        [TestMethod]
        public void ExifOrientationExtensionsClass_ToRightAngleRotationMethod_ReturnsAnticlockwise90_IfParameterEqualsRotatedAnticlockwiseThenFlippedVertically()
        {
            ExifOrientation testParam = ExifOrientation.RotatedAnticlockwiseThenFlippedVertically;

            RightAngleRotation testOutput = testParam.ToRightAngleRotation();

            Assert.AreEqual(RightAngleRotation.Anticlockwise90, testOutput);
        }

        [TestMethod]
        public void ExifOrientationExtensionsClass_ToRightAngleRotationMethod_ReturnsFull180_IfParameterEqualsRotatedRotated180()
        {
            ExifOrientation testParam = ExifOrientation.Rotated180;

            RightAngleRotation testOutput = testParam.ToRightAngleRotation();

            Assert.AreEqual(RightAngleRotation.Full180, testOutput);
        }

        [TestMethod]
        public void ExifOrientationExtensionsClass_ToRightAngleRotationMethod_ReturnsNone_IfParameterEqualsRotatedNormal()
        {
            ExifOrientation testParam = ExifOrientation.Normal;

            RightAngleRotation testOutput = testParam.ToRightAngleRotation();

            Assert.AreEqual(RightAngleRotation.None, testOutput);
        }

        [TestMethod]
        public void ExifOrientationExtensionsClass_ToRightAngleRotationMethod_ReturnsNone_IfParameterEqualsRotatedFlippedHorizontally()
        {
            ExifOrientation testParam = ExifOrientation.FlippedHorizontally;

            RightAngleRotation testOutput = testParam.ToRightAngleRotation();

            Assert.AreEqual(RightAngleRotation.None, testOutput);
        }

        [TestMethod]
        public void ExifOrientationExtensionsClass_ToRightAngleRotationMethod_ReturnsNone_IfParameterEqualsRotatedFlippedVerticallyl()
        {
            ExifOrientation testParam = ExifOrientation.FlippedVertically;

            RightAngleRotation testOutput = testParam.ToRightAngleRotation();

            Assert.AreEqual(RightAngleRotation.None, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
