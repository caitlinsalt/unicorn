using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Utility.Providers;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class UnicodeRangesUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UnicodeRangesClass_FromBytesMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UnicodeRangesClass_FromBytesMethod_ThrowsArgumentOutOfRangeException_IfSecondParameterIsLessThan0()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = -_rnd.Next(1, testParam0.Length);

            _ = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UnicodeRangesClass_FromBytesMethod_ThrowsArgumentOfOfRangeException_IfSecondParameterIsMoreThanTheLengthOfFirstParameterMinusSix()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15, int.MaxValue);

            _ = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsCorrectValue_IfNoPropertiesAreSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("no flags set", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithThaiPropertyEqualToTrue_IfBit0OfByte0IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Thai);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithThaiPropertyEqualToFalse_IfBit0OfByte0IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Thai);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfThaiPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b000000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Thai", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLaoPropertyEqualToTrue_IfBit1OfByte0IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Lao);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLaoPropertyEqualToFalse_IfBit1OfByte0IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Lao);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfLaoPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b000000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Lao", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGeorgianPropertyEqualToTrue_IfBit2OfByte0IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Georgian);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGeorgianPropertyEqualToFalse_IfBit2OfByte0IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Georgian);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfGeorgianPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b000000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Georgian", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBalinesePropertyEqualToTrue_IfBit3OfByte0IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b00001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Balinese);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBalinesePropertyEqualToFalse_IfBit3OfByte0IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Balinese);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfBalinesePropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b000001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Balinese", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithHangulJamoPropertyEqualToTrue_IfBit4OfByte0IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.HangulJamo);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithHangulJamoPropertyEqualToFalse_IfBit4OfByte0IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.HangulJamo);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfHangulJamoPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b000010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("HangulJamo", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLatinExtendedAdditionalPropertyEqualToTrue_IfBit5OfByte0IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.LatinExtendedAdditional);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLatinExtendedAdditionalPropertyEqualToFalse_IfBit5OfByte0IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.LatinExtendedAdditional);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfLatinExtendedAdditionalPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b000100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("LatinExtendedAdditional", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGreekExtendedPropertyEqualToTrue_IfBit6OfByte0IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.GreekExtended);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGreekExtendedPropertyEqualToFalse_IfBit6OfByte0IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.GreekExtended);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfGreekExtendedPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("GreekExtended", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGeneralPunctuationPropertyEqualToTrue_IfBit7OfByte0IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.GeneralPunctuation);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGeneralPunctuationPropertyEqualToFalse_IfBit7OfByte0IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.GeneralPunctuation);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfGeneralPunctuationPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("GeneralPunctuation", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBengaliPropertyEqualToTrue_IfBit0OfByte1IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Bengali);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBengaliPropertyEqualToFalse_IfBit0OfByte1IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Bengali);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfBengaliPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b000000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Bengali", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGurmukhiPropertyEqualToTrue_IfBit1OfByte1IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Gurmukhi);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGurmukhiPropertyEqualToFalse_IfBit1OfByte1IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Gurmukhi);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfGurmukhiPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b000000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Gurmukhi", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGujuratiPropertyEqualToTrue_IfBit2OfByte1IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Gujurati);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGujuratiPropertyEqualToFalse_IfBit2OfByte1IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Gujurati);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfGujuratiPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b000000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Gujurati", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithOriyaPropertyEqualToTrue_IfBit3OfByte1IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Oriya);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithOriyaPropertyEqualToFalse_IfBit3OfByte1IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Oriya);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfOriyaPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b000001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Oriya", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTamilPropertyEqualToTrue_IfBit4OfByte1IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Tamil);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTamilPropertyEqualToFalse_IfBit4OfByte1IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Tamil);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfTamilPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b000010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Tamil", StringComparison.InvariantCulture));
        }
        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTeluguPropertyEqualToTrue_IfBit5OfByte1IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Telugu);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTeluguPropertyEqualToFalse_IfBit5OfByte1IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Telugu);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfTeluguPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b000100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Telugu", StringComparison.InvariantCulture));
        }
        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithKannadaPropertyEqualToTrue_IfBit6OfByte1IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Kannada);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithKannadaPropertyEqualToFalse_IfBit6OfByte1IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Kannada);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfKannadaPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Kannada", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithMalayalamPropertyEqualToTrue_IfBit7OfByte1IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Malayalam);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithMalayalamPropertyEqualToFalse_IfBit7OfByte1IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Malayalam);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMalayalamPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 1] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Malayalam", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCopticPropertyEqualToTrue_IfBit0OfByte2IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Coptic);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCopticPropertyEqualToFalse_IfBit0OfByte2IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Coptic);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCopticPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b000000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Coptic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCyrillicPropertyEqualToTrue_IfBit1OfByte2IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Cyrillic);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCyrillicPropertyEqualToFalse_IfBit1OfByte2IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Cyrillic);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCyrillicPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b000000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Cyrillic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithArmenianPropertyEqualToTrue_IfBit2OfByte2IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Armenian);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCyrillicPropertyEqualToFalse_IfBit2OfByte2IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Armenian);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfArmenianPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b000000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Armenian", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithHebrewPropertyEqualToTrue_IfBit3OfByte2IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b00001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Hebrew);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithHebrewPropertyEqualToFalse_IfBit3OfByte2IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Hebrew);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfHebrewPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b000001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Hebrew", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithVaiPropertyEqualToTrue_IfBit4OfByte2IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Vai);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithVaiPropertyEqualToFalse_IfBit4OfByte2IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Vai);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfVaiPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b000010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Vai", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithArabicPropertyEqualToTrue_IfBit5OfByte2IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Arabic);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithArabicPropertyEqualToFalse_IfBit5OfByte2IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Arabic);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfArabicPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b000100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Arabic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithNKoPropertyEqualToTrue_IfBit6OfByte2IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.NKo);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithNKoPropertyEqualToFalse_IfBit6OfByte2IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.NKo);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfNKoPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("NKo", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithDevanagariPropertyEqualToTrue_IfBit7OfByte2IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Devanagari);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithDevanagariPropertyEqualToFalse_IfBit7OfByte2IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Devanagari);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfDevanagariPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 2] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Devanagari", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBasicLatinPropertyEqualToTrue_IfBit0OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.BasicLatin);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBasicLatinPropertyEqualToFalse_IfBit0OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.BasicLatin);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfBasicLatinPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b000000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("BasicLatin", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLatin1SupplementPropertyEqualToTrue_IfBit1OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Latin1Supplement);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLatin1SupplementPropertyEqualToFalse_IfBit1OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Latin1Supplement);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfLatin1SupplementPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b000000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Latin1Supplement", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLatinExtendedAPropertyEqualToTrue_IfBit2OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.LatinExtendedA);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLatinExtendedAPropertyEqualToFalse_IfBit2OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.LatinExtendedA);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfLatinExtendedAPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b000000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("LatinExtendedA", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLatinExtendedBPropertyEqualToTrue_IfBit3OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.LatinExtendedB);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLatinExtendedBPropertyEqualToFalse_IfBit3OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.LatinExtendedB);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfLatinExtendedBPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b000001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("LatinExtendedB", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithIPAExtensionsPropertyEqualToTrue_IfBit4OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.IPAExtensions);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithIPAExtensionsPropertyEqualToFalse_IfBit4OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.IPAExtensions);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfIPAExtensionsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b000010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("IPAExtensions", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSpacingModifiersPropertyEqualToTrue_IfBit5OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.SpacingModifiers);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSpacingModifiersPropertyEqualToFalse_IfBit5OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.SpacingModifiers);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfSpacingModifiersPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b00100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("SpacingModifiers", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCombiningDiacriticalMarksPropertyEqualToTrue_IfBit6OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.CombiningDiacriticalMarks);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCombiningDiacriticalMarksPropertyEqualToFalse_IfBit6OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.CombiningDiacriticalMarks);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCombiningDiacriticalMarksPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("CombiningDiacriticalMarks", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGreekAndCopticPropertyEqualToTrue_IfBit7OfByte3IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.GreekAndCoptic);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGreekAndCopticPropertyEqualToFalse_IfBit7OfByte3IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.GreekAndCoptic);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfGreekAndCopticPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 3] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("GreekAndCoptic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithHangulSyllablesPropertyEqualToTrue_IfBit0OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.HangulSyllables);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithHangulSyllablesPropertyEqualToFalse_IfBit0OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.HangulSyllables);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfHangulSyllablesPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b000000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("HangulSyllables", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithNonPlane0PropertyEqualToTrue_IfBit1OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.NonPlane0);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithNonPlane0PropertyEqualToFalse_IfBit1OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.NonPlane0);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfNonPlane0PropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b000000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("NonPlane0", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithPhoenicianPropertyEqualToTrue_IfBit2OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Phoenician);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithPhoenicianPropertyEqualToFalse_IfBit2OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Phoenician);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfPhoenicianPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b000000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Phoenician", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCJKUnifiedIdegraphsPropertyEqualToTrue_IfBit3OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.CJKUnifiedIdeographs);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCJKUnifiedIdeographsPropertyEqualToFalse_IfBit3OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.CJKUnifiedIdeographs);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCJKUnifiedIdeographsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b000001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("CJKUnifiedIdeographs", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithPrivateUseArea0PropertyEqualToTrue_IfBit4OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.PrivateUseArea0);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithPrivateUseArea0PropertyEqualToFalse_IfBit4OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.PrivateUseArea0);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfPrivateUseArea0PropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b000010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("PrivateUseArea0", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCJKStrokesPropertyEqualToTrue_IfBit5OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.CJKStrokes);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCJKStrokesPropertyEqualToFalse_IfBit5OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.CJKStrokes);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCJKStrokesPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b000100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("CJKStrokes", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithAlphabeticPresentationFormsPropertyEqualToTrue_IfBit6OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.AlphabeticPresentationForms);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithAlphabeticPresentationFormsPropertyEqualToFalse_IfBit6OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.AlphabeticPresentationForms);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfAlphabeticPresentationFormsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("AlphabeticPresentationForms", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithArabicPresentationFormsAPropertyEqualToTrue_IfBit7OfByte4IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.ArabicPresentationFormsA);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithArabicPresentationFormsAPropertyEqualToFalse_IfBit7OfByte4IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.ArabicPresentationFormsA);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfArabicPresentationFormsAPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 4] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("ArabicPresentationFormsA", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCJKSymbolsPropertyEqualToTrue_IfBit0OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.CJKSymbols);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCJKSymbolsPropertyEqualToFalse_IfBit0OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.CJKSymbols);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCJKSymbolsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b000000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("CJKSymbols", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithHiraganaPropertyEqualToTrue_IfBit1OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Hiragana);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithHiraganaPropertyEqualToFalse_IfBit1OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Hiragana);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfHiraganaPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b000000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Hiragana", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithKatakanaPropertyEqualToTrue_IfBit2OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Katakana);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithKatakanaPropertyEqualToFalse_IfBit2OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Katakana);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfKatakanaPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b000000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Katakana", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBopomofoPropertyEqualToTrue_IfBit3OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Bopomofo);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBopomofoPropertyEqualToFalse_IfBit3OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Bopomofo);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfBopomofoPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b000001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Bopomofo", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithHangulCompatibilityJamoPropertyEqualToTrue_IfBit4OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.HangulCompatibilityJamo);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithHangulCompatibilityJamoPropertyEqualToFalse_IfBit4OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.HangulCompatibilityJamo);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfHangulCompatibilityJamoPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b000010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("HangulCompatibilityJamo", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithPhagsPaPropertyEqualToTrue_IfBit5OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.PhagsPa);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithPhagsPaPropertyEqualToFalse_IfBit5OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.PhagsPa);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfPhagsPaPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b000100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("PhagsPa", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithEnclosedCJKLetterPropertyEqualToTrue_IfBit6OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.EnclosedCJKLetters);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithEnclosedCJKLettersPropertyEqualToFalse_IfBit6OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.EnclosedCJKLetters);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfEnclosedCJKLettersPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("EnclosedCJKLetters", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCJKCompatibilityPropertyEqualToTrue_IfBit7OfByte5IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.CJKCompatibility);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCJKCompatibilityPropertyEqualToFalse_IfBit7OfByte5IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.CJKCompatibility);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCJKCompatibilityPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 5] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("CJKCompatibility", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithControlPicturesPropertyEqualToTrue_IfBit0OfByte6IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.ControlPictures);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithControlPicturesPropertyEqualToFalse_IfBit0OfByte6IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.ControlPictures);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfControlPicturesPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b000000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("ControlPictures", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithOCRPropertyEqualToTrue_IfBit1OfByte6IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.OCR);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithOCRPropertyEqualToFalse_IfBit1OfByte6IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.OCR);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfOCRPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b000000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("OCR", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithEnclosedAlphanumericsPropertyEqualToTrue_IfBit2OfByte6IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.EnclosedAlphanumerics);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithEnclosedAlphanumericsPropertyEqualToFalse_IfBit2OfByte6IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.EnclosedAlphanumerics);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfEnclosedAlphanumericsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b000000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("EnclosedAlphanumerics", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBoxDrawingPropertyEqualToTrue_IfBit3OfByte6IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b00001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.BoxDrawing);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBoxDrawingPropertyEqualToFalse_IfBit3OfByte6IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.BoxDrawing);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfBoxDrawingPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b000001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("BoxDrawing", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBlockElementsPropertyEqualToTrue_IfBit4OfByte6IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.BlockElements);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBlockElementsPropertyEqualToFalse_IfBit4OfByte6IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.BlockElements);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfBlockElementsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b00010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("BlockElements", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGeometricShapesPropertyEqualToTrue_IfBit5OfByte6IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.GeometricShapes);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGeometricShapesPropertyEqualToFalse_IfBit5OfByte6IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.GeometricShapes);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfGeometricShapesPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b00100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("GeometricShapes", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithMiscSymbolsPropertyEqualToTrue_IfBit6OfByte6IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.MiscSymbols);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithMiscSymbolsPropertyEqualToFalse_IfBit6OfByte6IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.MiscSymbols);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMiscSymbolsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("MiscSymbols", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithDingbatsPropertyEqualToTrue_IfBit7OfByte6IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Dingbats);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithDingbatsPropertyEqualToFalse_IfBit7OfByte6IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Dingbats);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfDingbatsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 6] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Dingbats", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSuperscriptsSubscriptsPropertyEqualToTrue_IfBit0OfByte7IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.SuperscriptsSubscripts);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSuperscriptsSubscriptsPropertyEqualToFalse_IfBit0OfByte7IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.SuperscriptsSubscripts);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfSuperscriptsSubscriptsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b00000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("SuperscriptsSubscripts", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCurrencyPropertyEqualToTrue_IfBit1OfByte7IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Currency);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCurrencyPropertyEqualToFalse_IfBit1OfByte7IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Currency);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCurrencyPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b00000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Currency", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCombiningDiacriticalsForSymbolsPropertyEqualToTrue_IfBit2OfByte7IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.CombiningDiacriticalsForSymbols);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCombiningDiacriticalsForSymbolsPropertyEqualToFalse_IfBit2OfByte7IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.CombiningDiacriticalsForSymbols);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCombiningDiacriticalsForSymbolsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b00000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("CombiningDiacriticalsForSymbols", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLetterlikeSymbolsPropertyEqualToTrue_IfBit3OfByte7IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b00001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.LetterlikeSymbols);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLetterlikeSymbolsPropertyEqualToFalse_IfBit3OfByte7IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.LetterlikeSymbols);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfLetterlikeSymbolsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b00001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("LetterlikeSymbols", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithNumberFormsPropertyEqualToTrue_IfBit4OfByte7IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.NumberForms);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithNumberFormsPropertyEqualToFalse_IfBit4OfByte7IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.NumberForms);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfNumberFormsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b00010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("NumberForms", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithArrowsPropertyEqualToTrue_IfBit5OfByte7IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Arrows);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithArrowsPropertyEqualToFalse_IfBit5OfByte7IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Arrows);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfArrowsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b00100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Arrows", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithMathsOperatorsPropertyEqualToTrue_IfBit6OfByte7IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.MathsOperators);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithMathsOperatorsPropertyEqualToFalse_IfBit6OfByte7IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.MathsOperators);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMathsOperatorsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("MathsOperators", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithMiscTechnicalPropertyEqualToTrue_IfBit7OfByte7IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.MiscTechnical);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithMiscTechnicalPropertyEqualToFalse_IfBit7OfByte7IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.MiscTechnical);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMiscTechnicalPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 7] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("MiscTechnical", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithByzantineMusicPropertyEqualToTrue_IfBit0OfByte8IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.ByzantineMusic);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithByzantineMusicPropertyEqualToFalse_IfBit0OfByte8IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.ByzantineMusic);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfByzantineMusicPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b00000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("ByzantineMusic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithMathsAlphanumericalSymbolsPropertyEqualToTrue_IfBit1OfByte8IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.MathsAlphanumericalSymbols);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithMathsAlphanumericalSymbolsPropertyEqualToFalse_IfBit1OfByte8IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.MathsAlphanumericalSymbols);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMathsAlphanumericalSymbolsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b00000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("MathsAlphanumericalSymbols", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithPrivatePlane15PropertyEqualToTrue_IfBit2OfByte8IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.PrivatePlane15);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithPrivatePlane15PropertyEqualToFalse_IfBit2OfByte8IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.PrivatePlane15);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfPrivatePlane15PropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b00000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("PrivatePlane15", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithVariationSelectorsPropertyEqualToTrue_IfBit3OfByte8IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b00000001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.VariationSelectors);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithVariationSelectorsPropertyEqualToFalse_IfBit3OfByte8IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.VariationSelectors);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfVariationSelectorsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b00001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("VariationSelectors", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTagsPropertyEqualToTrue_IfBit4OfByte8IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Tags);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTagsPropertyEqualToFalse_IfBit4OfByte8IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Tags);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfTagsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b00010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Tags", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLimbuPropertyEqualToTrue_IfBit5OfByte8IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Limbu);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLimbuPropertyEqualToFalse_IfBit5OfByte8IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Limbu);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfLimbuPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b00100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Limbu", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTaiLePropertyEqualToTrue_IfBit6OfByte8IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.TaiLe);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTaiLePropertyEqualToFalse_IfBit6OfByte8IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.TaiLe);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfTaiLePropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("TaiLe", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithNewTaiLuePropertyEqualToTrue_IfBit7OfByte8IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.NewTaiLue);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithnewTaiLuePropertyEqualToFalse_IfBit0OfByte8IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.NewTaiLue);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfNewTaiLuePropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 8] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("NewTaiLue", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithKhmerPropertyEqualToTrue_IfBit0OfByte9IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Khmer);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithKhmerPropertyEqualToFalse_IfBit0OfByte9IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Khmer);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfKhmerPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b00000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Khmer", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithMongolianPropertyEqualToTrue_IfBit1OfByte9IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Mongolian);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithMongolianPropertyEqualToFalse_IfBit1OfByte9IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Mongolian);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMongolianPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b00000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Mongolian", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBraillePropertyEqualToTrue_IfBit2OfByte9IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Braille);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBraillePropertyEqualToFalse_IfBit2OfByte9IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Braille);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfBraillePropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b00000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Braille", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithYiSyllablesPropertyEqualToTrue_IfBit3OfByte9IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b00001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.YiSyllables);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithYiSyllablesPropertyEqualToFalse_IfBit3OfByte9IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.YiSyllables);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfYiSyllablesPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b00001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("YiSyllables", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTagalogPropertyEqualToTrue_IfBit4OfByte9IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Tagalog);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTagalogPropertyEqualToFalse_IfBit4OfByte9IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Tagalog);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfTagalogPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b00010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Tagalog", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithOldItalicPropertyEqualToTrue_IfBit5OfByte9IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.OldItalic);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithOldItalicPropertyEqualToFalse_IfBit5OfByte9IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.OldItalic);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfOldItalicPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b00100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("OldItalic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGothicPropertyEqualToTrue_IfBit6OfByte9IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Gothic);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGothicPropertyEqualToFalse_IfBit6OfByte9IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Gothic);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfGothicPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Gothic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithDeseretPropertyEqualToTrue_IfBit7OfByte9IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Deseret);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithDeseretPropertyEqualToFalse_IfBit7OfByte9IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Deseret);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfDeseretPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 9] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Deseret", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithThaanaPropertyEqualToTrue_IfBit0OfByte10IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Thaana);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithThaanaPropertyEqualToFalse_IfBit0OfByte10IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Thaana);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfThaanaPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b00000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Thaana", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSinhalaPropertyEqualToTrue_IfBit1OfByte10IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Sinhala);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSinhalaPropertyEqualToFalse_IfBit1OfByte10IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Sinhala);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfSinhalaPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b00000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Sinhala", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithMyanmarPropertyEqualToTrue_IfBit2OfByte10IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Myanmar);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithMyanmarPropertyEqualToFalse_IfBit2OfByte10IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Myanmar);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfMyanmarPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b00000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Myanmar", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithEthiopicPropertyEqualToTrue_IfBit3OfByte10IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b00001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Ethiopic);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithEthiopicPropertyEqualToFalse_IfBit3OfByte10IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Ethiopic);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfEthiopicPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b00001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Ethiopic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCherokeePropertyEqualToTrue_IfBit4OfByte10IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Cherokee);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCherokeePropertyEqualToFalse_IfBit4OfByte10IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Cherokee);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCherokeePropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b00010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Cherokee", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithUnifiedCanadianAboriginalSyllabicsPropertyEqualToTrue_IfBit5OfByte10IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.UnifiedCanadianAboriginalSyllabics);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithUnifiedCanadianAboriginalSyllabicsPropertyEqualToFalse_IfBit5OfByte10IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.UnifiedCanadianAboriginalSyllabics);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfUnifiedCanadianAboriginalSyllabicsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b00100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("UnifiedCanadianAboriginalSyllabics", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithOghamPropertyEqualToTrue_IfBit6OfByte10IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Ogham);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithOghamPropertyEqualToFalse_IfBit6OfByte10IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Ogham);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfOghamPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Ogham", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithRunicPropertyEqualToTrue_IfBit7OfByte10IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Runic);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithRunicPropertyEqualToFalse_IfBit7OfByte10IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Runic);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfRunicPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 10] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Runic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCombiningHalfMarksPropertyEqualToTrue_IfBit0OfByte11IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.CombiningHalfMarks);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCombiningHalfMarksPropertyEqualToFalse_IfBit0OfByte11IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.CombiningHalfMarks);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCombiningHalfMarksPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b00000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("CombiningHalfMarks", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithVerticalFormsPropertyEqualToTrue_IfBit1OfByte11IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.VerticalForms);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithVerticalFormsPropertyEqualToFalse_IfBit1OfByte11IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.VerticalForms);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfVerticalFormsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b00000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("VerticalForms", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSmallFormVariantsPropertyEqualToTrue_IfBit2OfByte11IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.SmallFormVariants);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSmallFormVariantsPropertyEqualToFalse_IfBit2OfByte11IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.SmallFormVariants);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfSmallFormVariantsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b00000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("SmallFormVariants", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithArabicPresentationFormsBPropertyEqualToTrue_IfBit3OfByte11IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b00001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.ArabicPresentationFormsB);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithArabicPresentationFormsBPropertyEqualToFalse_IfBit3OfByte11IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.ArabicPresentationFormsB);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfArabicPresentationFormsBPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b00001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("ArabicPresentationFormsB", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithHalfAndFullWidthFormsPropertyEqualToTrue_IfBit4OfByte11IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.HalfAndFullWidthForms);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithHalfAndFullWidthFormsPropertyEqualToFalse_IfBit4OfByte11IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.HalfAndFullWidthForms);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfHalfAndFullWidthFormsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b00010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("HalfAndFullWidthForms", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSpecialsPropertyEqualToTrue_IfBit5OfByte11IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Specials);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSpecialsPropertyEqualToFalse_IfBit5OfByte11IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Specials);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfSpecialsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b00100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Specials", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTibetanPropertyEqualToTrue_IfBit6OfByte11IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Tibetan);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTibetanPropertyEqualToFalse_IfBit6OfByte11IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Tibetan);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfTibetanPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Tibetan", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSyriacPropertyEqualToTrue_IfBit7OfByte11IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Syriac);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSyriacPropertyEqualToFalse_IfBit7OfByte11IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Syriac);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfSyriacPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 11] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Syriac", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithPhaistosDiscPropertyEqualToTrue_IfBit0OfByte12IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 12] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.PhaistosDisc);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithPhaistosDiscPropertyEqualToFalse_IfBit0OfByte12IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 12] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.PhaistosDisc);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfPhaistosDiscPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 12] |= 0b00000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("PhaistosDisc", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCarianPropertyEqualToTrue_IfBit1OfByte12IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 12] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Carian);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCarianPropertyEqualToFalse_IfBit1OfByte12IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 12] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Carian);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCarianPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 12] |= 0b00000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Carian", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithDominosPropertyEqualToTrue_IfBit2OfByte12IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 12] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Dominos);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithDominosPropertyEqualToFalse_IfBit2OfByte12IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 12] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Dominos);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfDominosPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 12] |= 0b00000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Dominos", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSundanesePropertyEqualToTrue_IfBit0OfByte13IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Sundanese);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSundanesePropertyEqualToFalse_IfBit0OfByte13IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Sundanese);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfSundanesePropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b00000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Sundanese", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLepchaPropertyEqualToTrue_IfBit1OfByte13IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Lepcha);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLepchaPropertyEqualToFalse_IfBit1OfByte13IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Lepcha);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfLepchaPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b00000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Lepcha", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithOlChikiPropertyEqualToTrue_IfBit2OfByte13IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.OlChiki);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithOlChikiPropertyEqualToFalse_IfBit2OfByte13IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.OlChiki);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfOlChikiPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b00000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("OlChiki", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSaurashtraPropertyEqualToTrue_IfBit3OfByte13IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b00001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Saurashtra);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSaurashtraPropertyEqualToFalse_IfBit3OfByte13IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Saurashtra);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfSaurashtraPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b00001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Saurashtra", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithKayahLiPropertyEqualToTrue_IfBit4OfByte13IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.KayahLi);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithKayahLiPropertyEqualToFalse_IfBit4OfByte13IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.KayahLi);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfKayahLiPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b00010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("KayahLi", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithRejangPropertyEqualToTrue_IfBit5OfByte13IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Rejang);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithRejangPropertyEqualToFalse_IfBit5OfByte13IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Rejang);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfRejangPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b00100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Rejang", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithChamPropertyEqualToTrue_IfBit6OfByte13IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Cham);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithChamPropertyEqualToFalse_IfBit6OfByte13IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Cham);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfChamPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Cham", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithAncientSymbolsPropertyEqualToTrue_IfBit7OfByte13IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.AncientSymbols);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithAncientSymbolsPropertyEqualToFalse_IfBit7OfByte13IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.AncientSymbols);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfAncientSymbolsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 13] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("AncientSymbols", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithOldPersianPropertyEqualToTrue_IfBit0OfByte14IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.OldPersian);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithOldPersianPropertyEqualToFalse_IfBit0OfByte14IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.OldPersian);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfOldPersianPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b00000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("OldPersian", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithShavianPropertyEqualToTrue_IfBit1OfByte14IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Shavian);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithShavianPropertyEqualToFalse_IfBit1OfByte14IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Shavian);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfShavianPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b00000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Shavian", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithOsmanyaPropertyEqualToTrue_IfBit2OfByte14IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Osmanya);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithOsmanyaPropertyEqualToFalse_IfBit2OfByte14IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Osmanya);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfOsmanyaPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b00000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Osmanya", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCypriotSyllablesPropertyEqualToTrue_IfBit3OfByte14IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b00001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.CypriotSyllables);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCypriotSyllablesPropertyEqualToFalse_IfBit3OfByte14IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.CypriotSyllables);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCypriotSyllablesPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b00001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("CypriotSyllables", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithKharoshthiPropertyEqualToTrue_IfBit4OfByte14IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Kharoshthi);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithKharoshthiPropertyEqualToFalse_IfBit4OfByte14IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Kharoshthi);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfKharoshthiPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b00010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Kharoshthi", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTaiXuanJingSymbolsPropertyEqualToTrue_IfBit5OfByte14IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.TaiXuanJingSymbols);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTaiXuanJingPropertyEqualToFalse_IfBit5OfByte14IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.TaiXuanJingSymbols);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfTaiXuanJingPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b00100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("TaiXuanJing", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCuneiformPropertyEqualToTrue_IfBit6OfByte14IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Cuneiform);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCuneiformPropertyEqualToFalse_IfBit6OfByte14IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Cuneiform);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCuneiformPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Cuneiform", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCountingRodNumbersPropertyEqualToTrue_IfBit7OfByte14IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.CountingRodNumbers);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithCountingRodNumbersPropertyEqualToFalse_IfBit7OfByte14IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.CountingRodNumbers);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfCountingRodNumbersPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 14] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("CountingRodNumbers", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBuginesePropertyEqualToTrue_IfBit0OfByte15IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b00000001;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Buginese);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithBuginesePropertyEqualToFalse_IfBit0OfByte15IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] &= 0b11111110;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Buginese);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfBuginesePropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b00000001;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Buginese", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGlagoliticPropertyEqualToTrue_IfBit1OfByte15IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b00000010;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Glagolitic);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithGlagoliticPropertyEqualToFalse_IfBit1OfByte15IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] &= 0b11111101;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Glagolitic);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfGlagoliticPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b00000010;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Glagolitic", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTifinaghPropertyEqualToTrue_IfBit2OfByte15IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b00000100;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Tifinagh);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithTifinaghPropertyEqualToFalse_IfBit2OfByte15IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] &= 0b11111011;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Tifinagh);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfTifinaghPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b00000100;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Tifinagh", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithYijingHexagramsPropertyEqualToTrue_IfBit3OfByte15IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b00001000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.YijingHexagrams);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithYijingHexagramsPropertyEqualToFalse_IfBit3OfByte15IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] &= 0b11110111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.YijingHexagrams);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfYijingHexagramsPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b00001000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("YijingHexagrams", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSylotiNagriPropertyEqualToTrue_IfBit4OfByte15IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b00010000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.SylotiNagri);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithSylotiNagriPropertyEqualToFalse_IfBit4OfByte15IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] &= 0b11101111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.SylotiNagri);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfSylotiNagriPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b00010000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("SylotiNagri", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLinearBSyllablesPropertyEqualToTrue_IfBit5OfByte15IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b00100000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.LinearBSyllables);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithLinearBSyllablesPropertyEqualToFalse_IfBit5OfByte15IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] &= 0b11011111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.LinearBSyllables);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfLinearBSyllablesPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b00100000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("LinearBSyllables", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithAncientGreenNumbersPropertyEqualToTrue_IfBit6OfByte15IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b01000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.AncientGreekNumbers);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithAncientGreekNumbersPropertyEqualToFalse_IfBit6OfByte15IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] &= 0b10111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.AncientGreekNumbers);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfAncientGreekNumbersPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b01000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("AncientGreekNumbers", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithUgariticPropertyEqualToTrue_IfBit7OfByte15IsSet()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b10000000;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsTrue(testOutput.Ugaritic);
        }

        [TestMethod]
        public void UnicodeRangesClass_FromBytesMethod_ReturnsObjectWithUgariticPropertyEqualToFalse_IfBit7OfByte15IsUnset()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] &= 0b01111111;

            UnicodeRanges testOutput = UnicodeRanges.FromBytes(testParam0, testParam1);

            Assert.IsFalse(testOutput.Ugaritic);
        }

        [TestMethod]
        public void UnicodeRangesClass_ToStringMethod_ReturnsValueContainingNameOfProperty_IfUgariticPropertyIsTrue()
        {
            byte[] testParam0 = new byte[_rnd.Next(16, 240)];
            int testParam1 = _rnd.Next(testParam0.Length - 15);
            _rnd.NextBytes(testParam0);
            testParam0[testParam1 + 15] |= 0b10000000;
            UnicodeRanges testObject = UnicodeRanges.FromBytes(testParam0, testParam1);

            string testOutput = testObject.ToString();

            Assert.IsTrue(testOutput.Contains("Ugaritic", StringComparison.InvariantCulture));
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
