using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Writer.Utility;

namespace Unicorn.Writer.Tests.Unit.Utility
{
    [TestClass]
    public class EnumerableStreamUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static byte[] GetTestData()
        {
            byte[] data = new byte[_rnd.Next(1024)];
            _rnd.NextBytes(data);
            return data;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EnumerableStreamClass_Constructor_ThrowsArgumentNullException_IfParameterIsNull()
        {
            using EnumerableStream testobject = new EnumerableStream(null);
            Assert.Fail();
        }

        [TestMethod]
        public void EnumerableStreamClass_CanReadProperty_EqualsTrue()
        {
            using EnumerableStream testObject = new EnumerableStream(GetTestData());

            bool testOutput = testObject.CanRead;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void EnumerableStreamClass_CanSeekProperty_EqualsFalse()
        {
            using EnumerableStream testObject = new EnumerableStream(GetTestData());

            bool testOutput = testObject.CanSeek;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void EnumerableStreamClass_CanWriteProperty_EqualsFalse()
        {
            using EnumerableStream testObject = new EnumerableStream(GetTestData());

            bool testOutput = testObject.CanWrite;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void EnumerableStreamClass_LengthProperty_EqualsZero()
        {
            using EnumerableStream testObject = new EnumerableStream(GetTestData());

            long testOutput = testObject.Length;

            Assert.AreEqual(0L, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EnumerableStreamClass_FlushMethod_ThrowsInvalidOperationException()
        {
            using EnumerableStream testObject = new EnumerableStream(GetTestData());

            testObject.Flush();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EnumerableStreamClass_SeekMethod_ThrowsInvalidOperationException()
        {
            using EnumerableStream testObject = new EnumerableStream(GetTestData());
            long testParam0 = _rnd.NextLong();
            SeekOrigin testParam1 = (SeekOrigin)_rnd.Next(3);

            testObject.Seek(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EnumerableStreamClass_SetLengthMethod_ThrowsInvalidOperationException()
        {
            using EnumerableStream testObject = new EnumerableStream(GetTestData());
            long testParam0 = _rnd.NextLong();

            testObject.SetLength(testParam0);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EnumerableStreamClass_WriteMethod_ThrowsInvalidOperationException()
        {
            using EnumerableStream testObject = new EnumerableStream(GetTestData());
            byte[] testParam0 = new byte[_rnd.Next(1, 1024)];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length);
            int testParam2 = _rnd.Next(1, testParam0.Length - testParam1);

            testObject.Write(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void EnumerableStreamClass_ReadMethod_BehavesAsExpectedWhenCalledOnce_IfBufferIsSmallerThanSourceData()
        {
            byte[] sourceData;
            do
            {
                sourceData = GetTestData();
            } while (sourceData.Length < 100);
            byte[] testParam0 = new byte[_rnd.Next(1, sourceData.Length)];
            int testParam1 = _rnd.Next(testParam0.Length);
            int testParam2 = _rnd.Next(testParam0.Length - testParam1);
            using EnumerableStream testObject = new EnumerableStream(sourceData);

            int testOutput = testObject.Read(testParam0, testParam1, testParam2);

            Assert.AreEqual(testOutput, testParam2);
            for (int i = 0; i < testOutput; ++i)
            {
                Assert.AreEqual(sourceData[i], testParam0[testParam1 + i]);
            }
        }

        [TestMethod]
        public void EnumerableStreamClass_ReadMethod_BehavesAsExpectedWhenCalledTwice_IfBufferIsSmallerThanSourceData()
        {
            byte[] sourceData;
            do
            {
                sourceData = GetTestData();
            } while (sourceData.Length < 100);
            byte[] testParam0 = new byte[_rnd.Next(1, sourceData.Length / 2)];
            int testParam1 = _rnd.Next(testParam0.Length);
            int testParam2 = _rnd.Next(testParam0.Length - testParam1);
            using EnumerableStream testObject = new EnumerableStream(sourceData);

            testObject.Read(testParam0, testParam1, testParam2);
            int testOutput = testObject.Read(testParam0, testParam1, testParam2);

            Assert.AreEqual(testOutput, testParam2);
            for (int i = 0; i < testOutput; ++i)
            {
                Assert.AreEqual(sourceData[testParam2 + i], testParam0[testParam1 + i]);
            }
        }

        [TestMethod]
        public void EnumerableStreamClass_ReadMethod_BehavesAsExpected_IfBufferIsLargerThanSourceData()
        {
            byte[] sourceData = GetTestData();
            byte[] testParam0 = new byte[_rnd.Next(sourceData.Length, sourceData.Length + 1024)];
            int testParam1 = _rnd.Next(testParam0.Length - sourceData.Length);
            int testParam2 = _rnd.Next(sourceData.Length, testParam0.Length - testParam1);
            using EnumerableStream testObject = new EnumerableStream(sourceData);

            int testOutput = testObject.Read(testParam0, testParam1, testParam2);

            Assert.AreEqual(testOutput, sourceData.Length);
            for (int i = 0; i < sourceData.Length; ++i)
            {
                Assert.AreEqual(sourceData[i], testParam0[testParam1 + i]);
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
