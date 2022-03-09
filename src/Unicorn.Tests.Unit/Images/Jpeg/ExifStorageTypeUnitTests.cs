using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unicorn.Images.Jpeg;

namespace Unicorn.Tests.Unit.Images.Jpeg
{
    /// <summary>
    /// These test are included because the enumeration values are defined in the EXIF specification,
    /// so any change to them is probably in error and should be flagged.
    /// </summary>
    [TestClass]
    public class ExifStorageTypeUnitTests
    {

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ExifStorageTypeEnum_ByteValue_Equals1()
        {
            int testOutput = (int)ExifStorageType.Byte;

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void ExifStorageTypeEnum_AsciiValue_Equals2()
        {
            int testOutput = (int)ExifStorageType.Ascii;

            Assert.AreEqual(2, testOutput);
        }

        [TestMethod]
        public void ExifStorageTypeEnum_ShortValue_Equals3()
        {
            int testOutput = (int)ExifStorageType.Short;

            Assert.AreEqual(3, testOutput);
        }

        [TestMethod]
        public void ExifStorageTypeEnum_LongValue_Equals4()
        {
            int testOutput = (int)ExifStorageType.Long;

            Assert.AreEqual(4, testOutput);
        }

        [TestMethod]
        public void ExifStorageTypeEnum_RationalValue_Equals5()
        {
            int testOutput = (int)ExifStorageType.Rational;

            Assert.AreEqual(5, testOutput);
        }

        [TestMethod]
        public void ExifStorageTypeEnum_UndefinedValue_Equals7()
        {
            int testOutput = (int)ExifStorageType.Undefined;

            Assert.AreEqual(7, testOutput);
        }

        [TestMethod]
        public void ExifStorageTypeEnum_SlongValue_Equals9()
        {
            int testOutput = (int)ExifStorageType.Slong;

            Assert.AreEqual(9, testOutput);
        }

        [TestMethod]
        public void ExifStorageTypeEnum_SrationalValue_Equals10()
        {
            int testOutput = (int)ExifStorageType.Srational;

            Assert.AreEqual(10, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
