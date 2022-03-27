using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Extensions;

namespace Unicorn.FontTools.Tests.Unit.Extensions
{
    [TestClass]
    public class ByteArrayExtensionsUnitTests
    {
        private readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        

        

        

        

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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
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
            decimal expectedValue = valueData0 + valueData1 / 65536m;
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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsArgumentOutOfangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsArgumentOutOFRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsFourLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 4;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsFiveLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 5;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsSixLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 6;

            _ = testParam0.ToDateTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToDateTimeMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsSevenLessThanLengthOfFirstParameter()
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
