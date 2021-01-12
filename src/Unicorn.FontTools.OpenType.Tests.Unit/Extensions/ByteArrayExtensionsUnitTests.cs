using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.OpenType.Extensions;

namespace Unicorn.FontTools.OpenType.Tests.Unit.Extensions
{
    [TestClass]
    public class ByteArrayExtensionsUnitTests
    {
        private readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[1];
            int testParam1 = 0;

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsIndexOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUShortMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);

            ushort testOutput = testParam0.ToUShort(testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            ushort expectedValue = (ushort)_rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            ushort testOutput = testParam0.ToUShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            ushort expectedValue = (ushort)_rnd.Next(short.MaxValue);
            testParam0[testParam1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            ushort testOutput = testParam0.ToUShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfUShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            ushort expectedValue = (ushort)_rnd.Next(short.MaxValue, ushort.MaxValue);
            testParam0[testParam1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            ushort testOutput = testParam0.ToUShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[1];
            int testParam1 = 0;

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsIndexOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToShortMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);

            short testOutput = testParam0.ToShort(testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            short expectedValue = (short)_rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            short testOutput = testParam0.ToShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsPositiveAndWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            short expectedValue = (short)_rnd.Next(short.MaxValue);
            testParam0[testParam1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            short testOutput = testParam0.ToShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsMinus1()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            short expectedValue = -1;
            testParam0[testParam1] = 0xff;
            testParam0[testParam1 + 1] = 0xff;

            short testOutput = testParam0.ToShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsNegativeAndWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            short expectedValue = (short)_rnd.Next(short.MinValue, 0);
            testParam0[testParam1] = (byte)((unchecked((ushort)expectedValue) & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            short testOutput = testParam0.ToShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneToThreeAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(1, 3)];
            int testParam1 = 0;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsIndexOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUIntMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);

            uint testOutput = testParam0.ToUInt(testParam1);

            Assert.AreEqual(0u, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = (uint)_rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            uint testOutput = testParam0.ToUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = (uint)_rnd.Next(short.MaxValue);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            uint testOutput = testParam0.ToUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = (uint)_rnd.Next();
            testParam0[testParam1] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            uint testOutput = testParam0.ToUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfUInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = ((uint)_rnd.Next()) * 2 + (uint)_rnd.Next(2);
            testParam0[testParam1] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            uint testOutput = testParam0.ToUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneToThreeAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(1, 3)];
            int testParam1 = 0;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsIndexOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToIntMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);

            int testOutput = testParam0.ToInt(testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ToInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next(short.MaxValue);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ToInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsPositiveAndWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next();
            testParam0[testParam1] = (byte)(unchecked(expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ToInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsMinusOne()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = -1;
            testParam0[testParam1] = 0xff;
            testParam0[testParam1 + 1] = 0xff;
            testParam0[testParam1 + 2] = 0xff;
            testParam0[testParam1 + 3] = 0xff;

            int testOutput = testParam0.ToInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsNegativeAndWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next(int.MinValue, 0);
            testParam0[testParam1] = (byte)(unchecked(expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ToInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneToThreeAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(1, 3)];
            int testParam1 = 0;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsIndexOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToFixedMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsPositiveInteger()
        {
            short valueData = _rnd.NextShort();
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            decimal expectedValue = valueData;
            testParam0[testParam1] = (byte)((valueData & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(valueData & 0xff);

            decimal testOutput = testParam0.ToFixed(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToFixedMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsNegativeInteger()
        {
            short valueData = (short)_rnd.Next(short.MinValue, 0);
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            decimal expectedValue = valueData;
            testParam0[testParam1] = (byte)(unchecked((ushort)valueData & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(valueData & 0xff);

            decimal testOutput = testParam0.ToFixed(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToFixedMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsPositiveReal()
        {
            short valueData0 = _rnd.NextShort();
            ushort valueData1 = _rnd.NextUShort();
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            decimal expectedValue = valueData0 + (valueData1 / 65536m);
            testParam0[testParam1] = (byte)((valueData0 & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(valueData0 & 0xff);
            testParam0[testParam1 + 2] = (byte)((valueData1 & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(valueData1 & 0xff);

            decimal testOutput = testParam0.ToFixed(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToFixedMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsNegativeReal()
        {
            decimal expectedValue = _rnd.Next(int.MinValue, 0) / 65536m;
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            testParam0[testParam1] = (byte)((unchecked((uint)(int)(expectedValue * 65536)) & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((unchecked((uint)(int)(expectedValue * 65536)) & 0xff0000) >> 16); ;
            testParam0[testParam1 + 2] = (byte)((unchecked((uint)(int)(expectedValue * 65536)) & 0xff00) >> 8); ;
            testParam0[testParam1 + 3] = (byte)(unchecked((uint)(int)(expectedValue * 65536)) & 0xff); ;

            decimal testOutput = testParam0.ToFixed(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneToSevenAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(1, 7)];
            int testParam1 = 0;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsIndexOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsFourLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 4;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsFiveLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 5;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsSixLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 6;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsSevenLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 7;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToLongMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);

            long testOutput = testParam0.ToLong(testParam1);

            Assert.AreEqual(0L, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToLongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            long expectedValue = (long)_rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ToLong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToLongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            long expectedValue = (long)_rnd.Next(short.MaxValue);
            testParam0[testParam1 + 6] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ToLong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToLongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            long expectedValue = (long)_rnd.Next();
            testParam0[testParam1 + 4] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 5] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 6] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ToLong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToLongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfUInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            long expectedValue = _rnd.NextUInt();
            testParam0[testParam1 + 4] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 5] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 6] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ToLong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToLongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsPositiveAndWithinRangeOfLong()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            long expectedValue = _rnd.NextLong();
            testParam0[testParam1] = (byte)(((ulong)expectedValue & 0xff00000000000000) >> 56);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff000000000000) >> 48);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff0000000000) >> 40);
            testParam0[testParam1 + 3] = (byte)((expectedValue & 0xff00000000) >> 32);
            testParam0[testParam1 + 4] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 5] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 6] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ToLong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToLongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsNegativeAndWithinRangeOfLong()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            long expectedValue = -_rnd.NextLong();
            testParam0[testParam1] = (byte)(unchecked((ulong)expectedValue & 0xff00000000000000) >> 56);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff000000000000) >> 48);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff0000000000) >> 40);
            testParam0[testParam1 + 3] = (byte)((expectedValue & 0xff00000000) >> 32);
            testParam0[testParam1 + 4] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 5] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 6] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ToLong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneToSevenAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(1, 7)];
            int testParam1 = 0;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsIndexOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsFourLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 4;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsFiveLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 5;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsSixLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 6;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsSevenLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 7;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ReturnsJanuary1st1904_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);

            DateTime testOutput = testParam0.ToDateTime(testParam1);

            Assert.AreEqual(new DateTime(1904, 1, 1), testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRange()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            long maxTicks = (DateTime.MaxValue - new DateTime(1904, 1, 1)).Ticks;
            long valueTicks = _rnd.NextLong(maxTicks);
            long valueSeconds = valueTicks / 10_000_000;
            DateTime expectedValue = new DateTime(1904, 1, 1).AddTicks(valueSeconds * 10_000_000);
            testParam0[testParam1] = (byte)((valueSeconds & 0xf00000000000000) >> 56);
            testParam0[testParam1 + 1] = (byte)((valueSeconds & 0xff000000000000) >> 48);
            testParam0[testParam1 + 2] = (byte)((valueSeconds & 0xff0000000000) >> 40);
            testParam0[testParam1 + 3] = (byte)((valueSeconds & 0xff00000000) >> 32);
            testParam0[testParam1 + 4] = (byte)((valueSeconds & 0xff000000) >> 24);
            testParam0[testParam1 + 5] = (byte)((valueSeconds & 0xff0000) >> 16);
            testParam0[testParam1 + 6] = (byte)((valueSeconds & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(valueSeconds & 0xff);

            DateTime testOutput = testParam0.ToDateTime(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsArgumentOutOfRangeException_IfParametersAreValidAndExpectedValueIsTooLargeForAllowedRange()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            long maxSeconds = 255_485_232_000;
            long valueSeconds = _rnd.NextLong(long.MaxValue - maxSeconds) + maxSeconds + 1;
            testParam0[testParam1] = (byte)(unchecked((ulong)valueSeconds & 0xff00000000000000) >> 56);
            testParam0[testParam1 + 1] = (byte)((valueSeconds & 0xff000000000000) >> 48);
            testParam0[testParam1 + 2] = (byte)((valueSeconds & 0xff0000000000) >> 40);
            testParam0[testParam1 + 3] = (byte)((valueSeconds & 0xff00000000) >> 32);
            testParam0[testParam1 + 4] = (byte)((valueSeconds & 0xff000000) >> 24);
            testParam0[testParam1 + 5] = (byte)((valueSeconds & 0xff0000) >> 16);
            testParam0[testParam1 + 6] = (byte)((valueSeconds & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(valueSeconds & 0xff);

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
