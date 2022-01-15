using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.CharacterEncoding;

namespace Unicorn.FontTools.Tests.Unit.CharacterEncoding
{
    [TestClass]
    public class PdfCharacterMappingDictionaryUnitTests
    {
        private static readonly int[] expectedMappingWindows = new int[]
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 
            0x2a, 0x2b, 0x2c, 0x2d, 0x2e, 0x2f, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3a, 0x3b, 0x3c, 0x3d, 0x3e, 0x3f, 0x40, 0x41, 0x42, 0x43,
            0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4a, 0x4b, 0x4c, 0x4d, 0x4e, 0x4f, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5a, 0x5b, 0x5c, 0x5d,
            0x5e, 0x5f, 0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a, 0x6b, 0x6c, 0x6d, 0x6e, 0x6f, 0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77,
            0x78, 0x79, 0x7a, 0x7b, 0x7c, 0x7d, 0x7e, 0x2022, 0x20ac, 0x2022, 0x201a, 0x192, 0x201e, 0x2026, 0x2020, 0x2021, 0x2c6, 0x2030, 0x160, 0x2039, 0x152, 
            0x2022, 0x17d, 0x2022, 0x2022, 0x2018, 0x2019, 0x201c, 0x201d, 0x2022, 0x2013, 0x2014, 0x2dc, 0x2122, 0x161, 0x203a, 0x153, 0x2022, 0x17e, 0x178, 0x20, 
            0xa1, 0xa2, 0xa3, 0xa4, 0xa5, 0xa6, 0xa7, 0xa8, 0xa9, 0xaa, 0xab, 0xac, 0x2022, 0xae, 0xaf, 0xb0, 0xb1, 0xb2, 0xb3, 0xb4, 0xb5, 0xb6, 0xb7, 0xb8, 0xb9,
            0xba, 0xbb, 0xbc, 0xbd, 0xbe, 0xbf, 0xc0, 0xc1, 0xc2, 0xc3, 0xc4, 0xc5, 0xc6, 0xc7, 0xc8, 0xc9, 0xca, 0xcb, 0xcc, 0xcd, 0xce, 0xcf, 0xd0, 0xd1, 0xd2, 0xd3, 
            0xd4, 0xd5, 0xd6, 0xd7, 0xd8, 0xd9, 0xda, 0xdb, 0xdc, 0xdd, 0xde, 0xdf, 0xe0, 0xe1, 0xe2, 0xe3, 0xe4, 0xe5, 0xe6, 0xe7, 0xe8, 0xe9, 0xea, 0xeb, 0xec, 0xed, 
            0xee, 0xef, 0xf0, 0xf1, 0xf2, 0xf3, 0xf4, 0xf5, 0xf6, 0xf7, 0xf8, 0xf9, 0xfa, 0xfb, 0xfc, 0xfd, 0xfe, 0xff
        };

        private static readonly int[] expectedMappingMac = new int[]
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 
            0x2a, 0x2b, 0x2c, 0x2d, 0x2e, 0x2f, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3a, 0x3b, 0x3c, 0x3d, 0x3e, 0x3f, 0x40, 0x41, 0x42, 0x43, 
            0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4a, 0x4b, 0x4c, 0x4d, 0x4e, 0x4f, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5a, 0x5b, 0x5c, 0x5d, 
            0x5e, 0x5f, 0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a, 0x6b, 0x6c, 0x6d, 0x6e, 0x6f, 0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 
            0x78, 0x79, 0x7a, 0x7b, 0x7c, 0x7d, 0x7e, 0, 0xc4, 0xc5, 0xc7, 0xc9, 0xd1, 0xd6, 0xdc, 0xe1, 0xe0, 0xe2, 0xe4, 0xe3, 0xe5, 0xe7, 0xe9, 0xe8, 0xea, 0xeb, 
            0xed, 0xec, 0xee, 0xef, 0xf1, 0xf3, 0xf2, 0xf4, 0xf6, 0xf5, 0xfa, 0xf9, 0xfb, 0xfc, 0x2020, 0xb0, 0xa2, 0xa3, 0xa7, 0x2022, 0xb6, 0xdf, 0xae, 0xa9, 0x2122, 
            0xb4, 0xa8, 0, 0xc6, 0xd8, 0, 0xb1, 0, 0, 0xa5, 0xb5, 0, 0, 0, 0, 0, 0xaa, 0xba, 0, 0xe6, 0xf8, 0xbf, 0xa1, 0xac, 0, 0x192, 0, 0, 0xab, 0xbb, 0x2026, 0x20, 
            0xc0, 0xc3, 0xd5, 0x152, 0x153, 0x2013, 0x2014, 0x201c, 0x201d, 0x2018, 0x2019, 0xf7, 0, 0xff, 0x178, 0x2044, 0xa4, 0x2039, 0x203a, 0xfb01, 0xfb02, 0x2021, 
            0xb7, 0x201a, 0x201e, 0x2030, 0xc2, 0xca, 0xc1, 0xcb, 0xc8, 0xcd, 0xce, 0xcf, 0xcc, 0xd3, 0xd4, 0, 0xd2, 0xda, 0xdb, 0xd9, 0x131, 0x2c6, 0x2dc, 0xaf, 0x2d8, 
            0x2d9, 0x2da, 0xb8, 0x2dd, 0x2db, 0x2c7
        };

        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_Indexer_ReturnsCorrectValue_IfObjectIsFromWinAnsiEncodingPropertyAndMappingExistsForParam()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.WinAnsiEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingWindows[testParam] == 0);
            int expectedValue = expectedMappingWindows[testParam];

            int testOutput = testObject[testParam];

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void PdfCharacterMappingDictionaryClass_Indexer_ThrowsKeyNotFoundException_IfObjectIsFromWinAnsiEncodingPropertyAndMappingDoesNotExistForParam()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.WinAnsiEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingWindows[testParam] != 0);

            _ = testObject[testParam];

            Assert.Fail();
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_Indexer_ReturnsCorrectValue_IfObjectIsFromMacRomanEncodingPropertyAndMappingExistsForParam()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.MacRomanEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingMac[testParam] == 0);
            int expectedValue = expectedMappingMac[testParam];

            int testOutput = testObject[testParam];

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void PdfCharacterMappingDictionaryClass_Indexer_ThrowsKeyNotFoundException_IfObjectIsFromMacRomanEncodingPropertyAndMappingDoesNotExistForParam()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.MacRomanEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingMac[testParam] != 0);

            _ = testObject[testParam];

            Assert.Fail();
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_KeysProperty_ReturnsValuesOfAllBytesThatHaveAMapping_IfObjectIsFromWinAnsiEncoding()
        {
            List<int> expectedResult = expectedMappingWindows.Select((val, idx) => val == 0 ? -1 : idx).Where(idx => idx >= 0).ToList();
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.WinAnsiEncoding;

            List<byte> testOutput = testObject.Keys.ToList();
            testOutput.Sort();

            Assert.AreEqual(testOutput.Count, expectedResult.Count);
            for (int i = 0; i < testOutput.Count; ++i)
            {
                Assert.AreEqual(expectedResult[i], testOutput[i]);
            }
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_KeysProperty_ReturnsValuesOfAllBytesThatHaveAMapping_IfObjectIsFromMacRomanEncoding()
        {
            List<int> expectedResult = expectedMappingMac.Select((val, idx) => val == 0 ? -1 : idx).Where(idx => idx >= 0).ToList();
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.MacRomanEncoding;

            List<byte> testOutput = testObject.Keys.ToList();
            testOutput.Sort();

            Assert.AreEqual(expectedResult.Count, testOutput.Count);
            for (int i = 0; i < testOutput.Count; ++i)
            {
                Assert.AreEqual(expectedResult[i], testOutput[i]);
            }
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_ValuesProperty_ReturnsAllTargetValuesOfMapping_IfObjectIsFromWinAnsiEncodingProperty()
        {
            List<int> expectedResult = expectedMappingWindows.Where(v => v != 0).OrderBy(v => v).ToList();
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.WinAnsiEncoding;

            List<int> testOutput = testObject.Values.ToList();
            testOutput.Sort();

            Assert.AreEqual(testOutput.Count, expectedResult.Count);
            for (int i = 0; i < testOutput.Count; ++i)
            {
                Assert.AreEqual(expectedResult[i], testOutput[i]);
            }
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_ValuesProperty_ReturnsAllTargetValuesOfMapping_IfObjectIsFromMacRomanEncodingProperty()
        {
            List<int> expectedResult = expectedMappingMac.Where(v => v != 0).OrderBy(v => v).ToList();
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.MacRomanEncoding;

            List<int> testOutput = testObject.Values.ToList();
            testOutput.Sort();

            Assert.AreEqual(testOutput.Count, expectedResult.Count);
            for (int i = 0; i < testOutput.Count; ++i)
            {
                Assert.AreEqual(expectedResult[i], testOutput[i]);
            }
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_CountProperty_ReturnsCorrectValue_IfObjectIsFromWinAnsiEncodingProperty()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.WinAnsiEncoding;
            int expectedValue = 224;

            int testOutput = testObject.Count;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_CountProperty_ReturnsCorrectValue_IfObjectIsFromMacRomanEncodingProperty()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.MacRomanEncoding;
            int expectedValue = 208;

            int testOutput = testObject.Count;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_ContainsKeyMethod_ReturnsTrue_IfObjectIsFromWinAnsiEncodingPropertyAndParamIsMapped()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.WinAnsiEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingWindows[testParam] == 0);

            bool testOutput = testObject.ContainsKey(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_ContainsKeyMethod_ReturnsFalse_IfObjectIsFromWinAnsiEncodingPropertyAndParamIsNotMapped()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.WinAnsiEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingWindows[testParam] != 0);

            bool testOutput = testObject.ContainsKey(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_ContainsKeyMethod_ReturnsTrue_IfObjectIsFromMacRomanEncodingPropertyAndParamIsMapped()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.MacRomanEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingMac[testParam] == 0);

            bool testOutput = testObject.ContainsKey(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_ContainsKeyMethod_ReturnsFalse_IfObjectIsFromMacRomanEncodingPropertyAndParamIsNotMapped()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.MacRomanEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingMac[testParam] != 0);

            bool testOutput = testObject.ContainsKey(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_TryGetValueMethod_ReturnsTrue_IfObjectIsFromWinAnsiEncodingPropertyAndParamIsMapped()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.WinAnsiEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingWindows[testParam] == 0);

            bool testOutput0 = testObject.TryGetValue(testParam, out _);

            Assert.IsTrue(testOutput0);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_TryGetValueMethod_SetsSecondParameterToCorrectValue_IfObjectIsFromWinAnsiEncodingPropertyAndParamIsMapped()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.WinAnsiEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingWindows[testParam] == 0);
            int expectedValue = expectedMappingWindows[testParam];

            _ = testObject.TryGetValue(testParam, out int testOutput1);

            Assert.AreEqual(expectedValue, testOutput1);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_TryGetValueMethod_ReturnsFalse_IfObjectIsFromWinAnsiEncodingPropertyAndParamIsNotMapped()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.WinAnsiEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingWindows[testParam] != 0);

            bool testOutput0 = testObject.TryGetValue(testParam, out _);

            Assert.IsFalse(testOutput0);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_TryGetValueMethod_ReturnsTrue_IfObjectIsFromMacRomanEncodingPropertyAndParamIsMapped()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.MacRomanEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingMac[testParam] == 0);

            bool testOutput0 = testObject.TryGetValue(testParam, out _);

            Assert.IsTrue(testOutput0);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_TryGetValueMethod_SetsSecondParameterToCorrectvalue_IfObjectIsFromMacRomanEncodingPropertyAndParamIsMapped()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.MacRomanEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingMac[testParam] == 0);
            int expectedValue = expectedMappingMac[testParam];

            _ = testObject.TryGetValue(testParam, out int testOutput1);

            Assert.AreEqual(expectedValue, testOutput1);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_TryGetValueMethod_ReturnsFalse_IfObjectIsFromMacRomanEncodingPropertyAndParamIsNotMapped()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.MacRomanEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingMac[testParam] != 0);

            bool testOutput0 = testObject.TryGetValue(testParam, out _);

            Assert.IsFalse(testOutput0);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_TransformMethod_ReturnsCorrectValue_IfObjectIsFromWinAnsiEncodingPropertyAndParamIsMapped()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.WinAnsiEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingWindows[testParam] == 0);
            int expectedValue = expectedMappingWindows[testParam];

            int testOutput = testObject.Transform(testParam);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_TransformMethod_ReturnsZero_IfObjectIsFromWinAnsiEncodingPropertyAndParamIsNotMapped()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.WinAnsiEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingWindows[testParam] != 0);

            int testOutput = testObject.Transform(testParam);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_TransformMethod_ReturnsCorrectValue_IfObjectIsFromMacRomanEncodingPropertyAndParamIsMapped()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.MacRomanEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingWindows[testParam] == 0);
            int expectedValue = expectedMappingMac[testParam];

            int testOutput = testObject.Transform(testParam);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void PdfCharacterMappingDictionaryClass_TransformMethod_ReturnsZero_IfObjectIsFromMacRomanEncodingPropertyAndParamIsNotMapped()
        {
            PdfCharacterMappingDictionary testObject = PdfCharacterMappingDictionary.MacRomanEncoding;
            byte testParam;
            do
            {
                testParam = _rnd.NextByte();
            } while (expectedMappingMac[testParam] != 0);

            int testOutput = testObject.Transform(testParam);

            Assert.AreEqual(0, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
