using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Helpers;

namespace Unicorn.Tests.Unit.Helpers
{
    [TestClass]
    public class StreamExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StreamExtensionsClass_ReadBigEndianUShortMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            Stream testParam0 = null;

            _ = testParam0.ReadBigEndianUShort();

            Assert.Fail();
        }

        [TestMethod]
        public void StreamExtensionsClass_ReadBigEndianUShortMethod_ReturnsCorrectData()
        {
            int expectedResult = _rnd.NextUShort();
            byte[] testData = new[] { (byte)((expectedResult & 0xff00) >> 8), (byte)(expectedResult & 0xff) };
            using Stream testParam0 = new MemoryStream(testData);

            int testOutput = testParam0.ReadBigEndianUShort();

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StreamExtensionsClass_ReadLittleEndianUShortMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            Stream testParam0 = null;

            _ = testParam0.ReadLittleEndianUShort();

            Assert.Fail();
        }

        [TestMethod]
        public void StreamExtensionsClass_ReadLittleEndianUShortMethod_ReturnsCorrectData()
        {
            int expectedResult = _rnd.NextUShort();
            byte[] testData = new[] { (byte)((expectedResult & 0xff)), (byte)((expectedResult & 0xff00) >> 8) };
            using Stream testParam0 = new MemoryStream(testData);

            int testOutput = testParam0.ReadLittleEndianUShort();

            Assert.AreEqual(expectedResult, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
