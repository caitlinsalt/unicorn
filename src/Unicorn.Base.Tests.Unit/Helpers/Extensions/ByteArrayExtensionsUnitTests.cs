using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Base.Helpers.Extensions;

namespace Unicorn.Base.Tests.Unit.Helpers.Extensions
{
    [TestClass]
    public class ByteArrayExtensionsUnitTests
    {
        private readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ByteArrayExtensionsClass_ReadBigEndianShortMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ReadBigEndianShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadBigEndianShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ReadBigEndianShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadBigEndianShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[1];
            int testParam1 = 0;

            _ = testParam0.ReadBigEndianShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ReadBigEndianShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ReadBigEndianShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ReadBigEndianShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ReadBigEndianShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianShortMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);

            short testOutput = testParam0.ReadBigEndianShort(testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            short expectedValue = (short)_rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            short testOutput = testParam0.ReadBigEndianShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsPositiveAndWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            short expectedValue = (short)_rnd.Next(short.MaxValue);
            testParam0[testParam1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            short testOutput = testParam0.ReadBigEndianShort(testParam1);

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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
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
        public void ByteArrayExtensionsClass_ToShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsMinus1()
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
        public void ByteArrayExtensionsClass_ToShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsNegativeAndWithinRangeOfShort()
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
        public void ByteArrayExtensionsClass_ReadBigEndianUShortMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ReadBigEndianUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ReadBigEndianUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[1];
            int testParam1 = 0;

            _ = testParam0.ReadBigEndianUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ReadBigEndianUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ReadBigEndianUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ReadBigEndianUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ReadBigEndianUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianUShortMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);

            int testOutput = testParam0.ReadBigEndianUShort(testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            ushort expectedValue = (ushort)_rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ReadBigEndianUShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            ushort expectedValue = (ushort)_rnd.Next(short.MaxValue);
            testParam0[testParam1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ReadBigEndianUShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfUShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            ushort expectedValue = (ushort)_rnd.Next(short.MaxValue, ushort.MaxValue);
            testParam0[testParam1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ReadBigEndianUShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }
        
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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
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
        public void ByteArrayExtensionsClass_ReadLittleEndianUShortMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ReadLittleEndianUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ReadLittleEndianUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[1];
            int testParam1 = 0;

            _ = testParam0.ReadLittleEndianUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ReadLittleEndianUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ReadLittleEndianUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ReadLittleEndianUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUShortMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ReadLittleEndianUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianUShortMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);

            int testOutput = testParam0.ReadLittleEndianUShort(testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            ushort expectedValue = (ushort)_rnd.Next(byte.MaxValue);
            testParam0[testParam1] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ReadLittleEndianUShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            ushort expectedValue = (ushort)_rnd.Next(short.MaxValue);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ReadLittleEndianUShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfUShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            ushort expectedValue = (ushort)_rnd.Next(short.MaxValue, ushort.MaxValue);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ReadLittleEndianUShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUIntMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ReadBigEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ReadBigEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneToThreeAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(1, 3)];
            int testParam1 = 0;

            _ = testParam0.ReadBigEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ReadBigEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ReadBigEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ReadBigEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ReadBigEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ReadBigEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ReadBigEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianUIntMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);

            long testOutput = testParam0.ReadBigEndianUInt(testParam1);

            Assert.AreEqual(0u, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = (uint)_rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ReadBigEndianUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = (uint)_rnd.Next(short.MaxValue);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ReadBigEndianUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = (uint)_rnd.Next();
            testParam0[testParam1] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ReadBigEndianUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfUInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = (uint)_rnd.Next() * 2 + (uint)_rnd.Next(2);
            testParam0[testParam1] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ReadBigEndianUInt(testParam1);

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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
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
            uint expectedValue = (uint)_rnd.Next() * 2 + (uint)_rnd.Next(2);
            testParam0[testParam1] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            uint testOutput = testParam0.ToUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUIntMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ReadLittleEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ReadLittleEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneToThreeAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(1, 3)];
            int testParam1 = 0;

            _ = testParam0.ReadLittleEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ReadLittleEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ReadLittleEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ReadLittleEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ReadLittleEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ReadLittleEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianUIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ReadLittleEndianUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianUIntMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);

            long testOutput = testParam0.ReadLittleEndianUInt(testParam1);

            Assert.AreEqual(0u, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = (uint)_rnd.Next(byte.MaxValue);
            testParam0[testParam1] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ReadLittleEndianUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = (uint)_rnd.Next(short.MaxValue);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ReadLittleEndianUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = (uint)_rnd.Next();
            testParam0[testParam1 + 3] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ReadLittleEndianUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfUInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = (uint)_rnd.Next() * 2 + (uint)_rnd.Next(2);
            testParam0[testParam1 + 3] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ReadLittleEndianUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ReadBigEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ReadBigEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneToThreeAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(1, 3)];
            int testParam1 = 0;

            _ = testParam0.ReadBigEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ReadBigEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ReadBigEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ReadBigEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ReadBigEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ReadBigEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ReadBigEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);

            int testOutput = testParam0.ReadBigEndianInt(testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ReadBigEndianInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next(short.MaxValue);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ReadBigEndianInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsPositiveAndWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next();
            testParam0[testParam1] = (byte)(unchecked(expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ReadBigEndianInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsMinusOne()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = -1;
            testParam0[testParam1] = 0xff;
            testParam0[testParam1 + 1] = 0xff;
            testParam0[testParam1 + 2] = 0xff;
            testParam0[testParam1 + 3] = 0xff;

            int testOutput = testParam0.ReadBigEndianInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsNegativeAndWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next(int.MinValue, 0);
            testParam0[testParam1] = (byte)(unchecked(expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ReadBigEndianInt(testParam1);

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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
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
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ReadLittleEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ReadLittleEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneToThreeAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(1, 3)];
            int testParam1 = 0;

            _ = testParam0.ReadLittleEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ReadLittleEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ReadLittleEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ReadLittleEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ReadLittleEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ReadLittleEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ReadLittleEndianInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);

            int testOutput = testParam0.ReadLittleEndianInt(testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next(byte.MaxValue);
            testParam0[testParam1] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ReadLittleEndianInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next(short.MaxValue);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ReadLittleEndianInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsPositiveAndWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next();
            testParam0[testParam1 + 3] = (byte)(unchecked(expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ReadLittleEndianInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsMinusOne()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = -1;
            testParam0[testParam1 + 3] = 0xff;
            testParam0[testParam1 + 2] = 0xff;
            testParam0[testParam1 + 1] = 0xff;
            testParam0[testParam1] = 0xff;

            int testOutput = testParam0.ReadLittleEndianInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadLittleEndianIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsNegativeAndWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next(int.MinValue, 0);
            testParam0[testParam1 + 3] = (byte)(unchecked(expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ReadLittleEndianInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ReadBigEndianLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ReadBigEndianLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneToSevenAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(1, 7)];
            int testParam1 = 0;

            _ = testParam0.ReadBigEndianLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ThrowsIndexOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ReadBigEndianLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ReadBigEndianLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ReadBigEndianLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ReadBigEndianLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ReadBigEndianLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ReadBigEndianLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsFourLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 4;

            _ = testParam0.ReadBigEndianLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsFiveLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 5;

            _ = testParam0.ReadBigEndianLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsSixLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 6;

            _ = testParam0.ReadBigEndianLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ThrowsArgumentOutOFRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsSevenLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 7;

            _ = testParam0.ReadBigEndianLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);

            long testOutput = testParam0.ReadBigEndianLong(testParam1);

            Assert.AreEqual(0L, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            long expectedValue = _rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ReadBigEndianLong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            long expectedValue = _rnd.Next(short.MaxValue);
            testParam0[testParam1 + 6] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ReadBigEndianLong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            long expectedValue = _rnd.Next();
            testParam0[testParam1 + 4] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 5] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 6] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ReadBigEndianLong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfUInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            long expectedValue = _rnd.NextUInt();
            testParam0[testParam1 + 4] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 5] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 6] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ReadBigEndianLong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsPositiveAndWithinRangeOfLong()
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

            long testOutput = testParam0.ReadBigEndianLong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ReadBigEndianLongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsNegativeAndWithinRangeOfLong()
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

            long testOutput = testParam0.ReadBigEndianLong(testParam1);

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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsFourLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 4;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsFiveLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 5;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsSixLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 6;

            _ = testParam0.ToLong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToLongMethod_ThrowsArgumentOutOFRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsSevenLessThanLengthOfFirstParameter()
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
            long expectedValue = _rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            long testOutput = testParam0.ToLong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToLongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            long expectedValue = _rnd.Next(short.MaxValue);
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
            long expectedValue = _rnd.Next();
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

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
