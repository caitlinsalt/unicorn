using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class SupportedCodePagesUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SupportedCodePagesClass_FromBytesMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SupportedCodePagesClass_FromBytesMethod_ThrowsArgumentOutOfRangeException_IfSecondParameterIsLessThan0()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = -_rnd.Next(1, testParam0.Length);

            _ = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SupportedCodePagesClass_FromBytesMethod_ThrowsArgumentOfOfRangeException_IfSecondParameterIsMoreThanTheLengthOfFirstParameterMinusSix()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5, int.MaxValue);

            _ = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMacRomanPropertyEqualToTrue_IfBit5OfByte0IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b00100000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.MacRoman);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMacRomanPropertyEqualToFalse_IfBit5OfByte0IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] &= 0b11011111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.MacRoman);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithOEMPropertyEqualToTrue_IfBit6OfByte0IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b01000000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.OEM);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithOEMPropertyEqualToFalse_IfBit6OfByte0IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] &= 0b10111111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.OEM);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithSymbolPropertyEqualToTrue_IfBit7OfByte0IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b10000000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Symbol);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithSymbolPropertyEqualToFalse_IfBit7OfByte0IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] &= 0b01111111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Symbol);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithThaiPropertyEqualToTrue_IfBit0OfByte1IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00000001;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Thai);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithThaiPropertyEqualToFalse_IfBit0OfByte1IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] &= 0b11111110;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Thai);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithJISPropertyEqualToTrue_IfBit1OfByte1IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00000010;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.JIS);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithJISPropertyEqualToFalse_IfBit1OfByte1IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] &= 0b11111101;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.JIS);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithChineseSimplifiedPropertyEqualToTrue_IfBit2OfByte1IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00000100;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.ChineseSimplified);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithChineseSimplifiedPropertyEqualToFalse_IfBit2OfByte1IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] &= 0b11111011;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.ChineseSimplified);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithKoreanWansungPropertyEqualToTrue_IfBit3OfByte1IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00001000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.KoreanWansung);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithKoreanWansungPropertyEqualToFalse_IfBit3OfByte1IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] &= 0b11110111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.KoreanWansung);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithChineseTraditionalPropertyEqualToTrue_IfBit4OfByte1IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00010000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.ChineseTraditional);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithChineseTraditionalPropertyEqualToFalse_IfBit4OfByte1IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] &= 0b11101111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.ChineseTraditional);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithKoreanJohabPropertyEqualToTrue_IfBit5OfByte1IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00100000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.KoreanJohab);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithKoreanJohabPropertyEqualToFalse_IfBit5OfByte1IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] &= 0b11011111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.KoreanJohab);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithVietnamesePropertyEqualToTrue_IfBit0OfByte2IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b00000001;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Vietnamese);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithVietnamesePropertyEqualToFalse_IfBit0OfByte2IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] &= 0b11111110;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Vietnamese);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithLatin1PropertyEqualToTrue_IfBit0OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00000001;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Latin1);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithLatin1PropertyEqualToFalse_IfBit0OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b11111110;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Latin1);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithLatin2PropertyEqualToTrue_IfBit1OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00000010;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Latin2);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithLatin2PropertyEqualToFalse_IfBit1OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b11111101;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Latin2);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithCyrillicPropertyEqualToTrue_IfBit2OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00000100;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Cyrillic);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithCyrillicPropertyEqualToFalse_IfBit2OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b11111011;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Cyrillic);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithGreekPropertyEqualToTrue_IfBit3OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00001000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Greek);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithGreekPropertyEqualToFalse_IfBit3OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b11110111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Greek);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithTurkishPropertyEqualToTrue_IfBit4OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00010000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Turkish);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithTurkishPropertyEqualToFalse_IfBit4OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b11101111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Turkish);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithHebrewPropertyEqualToTrue_IfBit5OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00100000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Hebrew);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithHebrewPropertyEqualToFalse_IfBit5OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b11011111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Hebrew);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithArabicPropertyEqualToTrue_IfBit6OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b01000000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Arabic);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithArabicPropertyEqualToFalse_IfBit6OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b10111111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Arabic);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithWindowsBalticPropertyEqualToTrue_IfBit7OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b10000000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.WindowsBaltic);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithWindowsBalticPropertyEqualToFalse_IfBit7OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b01111111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.WindowsBaltic);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithIBMTurkishPropertyEqualToTrue_IfBit0OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00000001;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.IBMTurkish);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithIBMTurkishPropertyEqualToFalse_IfBit0OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b11111110;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.IBMTurkish);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithIBMCyrillicPropertyEqualToTrue_IfBit1OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00000010;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.IBMCyrillic);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithIBMCyrillicPropertyEqualToFalse_IfBit1OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b11111101;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.IBMCyrillic);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosLatin2PropertyEqualToTrue_IfBit2OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00000100;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.MSDosLatin2);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosLatin2PropertyEqualToFalse_IfBit2OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b11111011;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.MSDosLatin2);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosBalticPropertyEqualToTrue_IfBit3OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00001000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.MSDosBaltic);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosBalticPropertyEqualToFalse_IfBit3OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b11110111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.MSDosBaltic);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithGreek737PropertyEqualToTrue_IfBit4OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00010000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Greek737);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithGreek737PropertyEqualToFalse_IfBit4OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b11101111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Greek737);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithArabic708PropertyEqualToTrue_IfBit5OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00100000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Arabic708);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithArabic708PropertyEqualToFalse_IfBit5OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b11011111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Arabic708);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithWELatin1PropertyEqualToTrue_IfBit6OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b01000000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.WELatin1);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithWELatin1PropertyEqualToFalse_IfBit6OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b10111111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.WELatin1);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithUSPropertyEqualToTrue_IfBit7OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b10000000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.US);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithUSPropertyEqualToFalse_IfBit7OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b01111111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.US);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithIBMGreekPropertyEqualToTrue_IfBit0OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00000001;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.IBMGreek);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithIBMGreekPropertyEqualToFalse_IfBit0OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b11111110;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.IBMGreek);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosRussianPropertyEqualToTrue_IfBit1OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00000010;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.MSDosRussian);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosRussianPropertyEqualToFalse_IfBit1OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b11111101;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.MSDosRussian);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosNordicPropertyEqualToTrue_IfBit2OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00000100;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.MSDosNordic);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosNordicPropertyEqualToFalse_IfBit2OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b11111011;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.MSDosNordic);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosArabicPropertyEqualToTrue_IfBit3OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00001000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.MSDosArabic);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosArabicPropertyEqualToFalse_IfBit3OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b11110111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.MSDosArabic);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosCanadianFrenchPropertyEqualToTrue_IfBit4OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00010000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.MSDosCanadianFrench);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosCanadianFrenchPropertyEqualToFalse_IfBit4OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b11101111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.MSDosCanadianFrench);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosHebrewPropertyEqualToTrue_IfBit5OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00100000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.MSDosHebrew);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosHebrewPropertyEqualToFalse_IfBit5OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b11011111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.MSDosHebrew);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosIslenskPropertyEqualToTrue_IfBit6OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b01000000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.MSDosIslensk);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosIslenskPropertyEqualToFalse_IfBit6OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b10111111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.MSDosIslensk);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosPortuguesePropertyEqualToTrue_IfBit7OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b10000000;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.MSDosPortuguese);
        }

        [TestMethod]
        public void SupportedCodePagesClass_FromBytesMethod_ReturnsObjectWithMSDosPortuguesePropertyEqualToFalse_IfBit7OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b01111111;

            SupportedCodePages testOutput = SupportedCodePages.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.MSDosPortuguese);
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsCorrectValue_IfNoPropertiesAreSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("no flags set", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMacRomanPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b00100000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("MacRoman", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfOEMPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b01000000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("OEM", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfSymbolPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b10000000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Symbol", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfThaiPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00000001;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Thai", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfJISPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00000010;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("JIS", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfChineseSimplifiedPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00000100;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("ChineseSimplified", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfKoreanWansungPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00001000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("KoreanWansung", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfChineseTraditionalPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00010000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("ChineseTraditional", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfKoreanJohabPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00100000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("KoreanJohab", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfVietnamesePropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b00000001;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Vietnamese", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfLatin1PropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00000001;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Latin1", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfLatin2PropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00000010;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Latin2", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCyrillicPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00000100;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Cyrillic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfGreekPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00001000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Greek", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfTurkishPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00010000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Turkish", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfHebrewPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00100000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Hebrew", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfArabicPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b01000000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Arabic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfWindowsBalticPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b10000000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("WindowsBaltic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfIBMTurkishPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00000001;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("IBMTurkish", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfIBMCyrillicPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00000010;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("IBMCyrillic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMSDosLatin2PropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00000100;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("MSDosLatin2", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMSDosBalticPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00001000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("MSDosBaltic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfGreek737PropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00010000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Greek737", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfArabic708PropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00100000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Arabic708", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfWELatin1PropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b01000000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("WELatin1", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfUSPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b10000000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("US", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfIBMGreekPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00000001;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("IBMGreek", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMSDosRussianPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00000010;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("MSDosRussian", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMSDosNordicPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00000100;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("MSDosNordic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMSDosArabicPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00001000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("MSDosArabic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMSDosCanadianFrenchPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00010000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("MSDosCanadianFrench", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMSDosHebrewPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00100000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("MSDosHebrew", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMSDosIslenskPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b01000000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("MSDosIslensk", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void SupportedCodePagesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMSDosPortuguesePropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(6, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 5);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b10000000;
            SupportedCodePages testObject = SupportedCodePages.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("MSDosPortuguese", StringComparison.InvariantCulture));
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
