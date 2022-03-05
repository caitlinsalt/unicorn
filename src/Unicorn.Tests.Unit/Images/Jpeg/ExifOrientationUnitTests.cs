using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unicorn.Images.Jpeg;

namespace Unicorn.Tests.Unit.Images.Jpeg
{
    /// <summary>
    /// These test are included because the enumeration values are defined in the EXIF specification,
    /// so any change to them is probably in error and should be flagged.
    /// </summary>
    [TestClass]
    public class ExifOrientationUnitTests
    {

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ExifOrientationEnum_NormalValue_Equals1()
        {
            int testOutput = (int)ExifOrientation.Normal;

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void ExifOrientationEnum_FlippedHorizontallyValue_Equals2()
        {
            int testOutput = (int)ExifOrientation.FlippedHorizontally;

            Assert.AreEqual(2, testOutput);
        }

        [TestMethod]
        public void ExifOrientationEnum_Rotated180Value_Equals3()
        {
            int testOutput = (int)ExifOrientation.Rotated180;

            Assert.AreEqual(3, testOutput);
        }

        [TestMethod]
        public void ExifOrientationEnum_FlippedVerticallyValue_Equals4()
        {
            int testOutput = (int)ExifOrientation.FlippedVertically;

            Assert.AreEqual(4, testOutput);
        }

        [TestMethod]
        public void ExifOrientationEnum_RotatedAnticlockwiseThenFlippedVerticallyValue_Equals5()
        {
            int testOutput = (int)ExifOrientation.RotatedAnticlockwiseThenFlippedVertically;

            Assert.AreEqual(5, testOutput);
        }

        [TestMethod]
        public void ExifOrientationEnum_RotatedClockwiseValue_Equals6()
        {
            int testOutput = (int)ExifOrientation.RotatedClockwise;

            Assert.AreEqual(6, testOutput);
        }

        [TestMethod]
        public void ExifOrientationEnum_RotatedClockwiseThenFlippedVerticallyValue_Equals7()
        {
            int testOutput = (int)ExifOrientation.RotatedClockwiseThenFlippedVertically;

            Assert.AreEqual(7, testOutput);
        }

        [TestMethod]
        public void ExifOrientationEnum_RotatedAnticlockwiseValue_Equals8()
        {
            int testOutput = (int)ExifOrientation.RotatedAnticlockwise;

            Assert.AreEqual(8, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
