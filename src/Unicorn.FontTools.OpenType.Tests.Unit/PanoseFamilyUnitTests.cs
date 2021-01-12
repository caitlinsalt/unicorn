using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class PanoseFamilyUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static PanoseFamily GetTestObject()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            byte testParam2 = _rnd.NextByte();
            byte testParam3 = _rnd.NextByte();
            byte testParam4 = _rnd.NextByte();
            byte testParam5 = _rnd.NextByte();
            byte testParam6 = _rnd.NextByte();
            byte testParam7 = _rnd.NextByte();
            byte testParam8 = _rnd.NextByte();
            byte testParam9 = _rnd.NextByte();

            return new PanoseFamily(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9);
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void PanoseFamilyStruct_ParameterlessConstructor_SetsFamilyTypePropertyToZero()
        {
            PanoseFamily testOutput = new PanoseFamily();

            Assert.AreEqual((byte)0, testOutput.FamilyType);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ParameterlessConstructor_SetsSerifStylePropertyToZero()
        {
            PanoseFamily testOutput = new PanoseFamily();

            Assert.AreEqual((byte)0, testOutput.SerifStyle);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ParameterlessConstructor_SetsWeightPropertyToZero()
        {
            PanoseFamily testOutput = new PanoseFamily();

            Assert.AreEqual((byte)0, testOutput.Weight);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ParameterlessConstructor_SetsProportionPropertyToZero()
        {
            PanoseFamily testOutput = new PanoseFamily();

            Assert.AreEqual((byte)0, testOutput.Proportion);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ParameterlessConstructor_SetsContrastPropertyToZero()
        {
            PanoseFamily testOutput = new PanoseFamily();

            Assert.AreEqual((byte)0, testOutput.Contrast);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ParameterlessConstructor_SetsStrokeVariationPropertyToZero()
        {
            PanoseFamily testOutput = new PanoseFamily();

            Assert.AreEqual((byte)0, testOutput.StrokeVariation);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ParameterlessConstructor_SetsArmStylePropertyToZero()
        {
            PanoseFamily testOutput = new PanoseFamily();

            Assert.AreEqual((byte)0, testOutput.ArmStyle);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ParameterlessConstructor_SetsLetterformPropertyToZero()
        {
            PanoseFamily testOutput = new PanoseFamily();

            Assert.AreEqual((byte)0, testOutput.Letterform);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ParameterlessConstructor_SetsMidlinePropertyToZero()
        {
            PanoseFamily testOutput = new PanoseFamily();

            Assert.AreEqual((byte)0, testOutput.Midline);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ParameterlessConstructor_SetsXHeightPropertyToZero()
        {
            PanoseFamily testOutput = new PanoseFamily();

            Assert.AreEqual((byte)0, testOutput.XHeight);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithTenByteParameters_SetsFamilyTypePropertyToValueOfFirstParameter()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            byte testParam2 = _rnd.NextByte();
            byte testParam3 = _rnd.NextByte();
            byte testParam4 = _rnd.NextByte();
            byte testParam5 = _rnd.NextByte();
            byte testParam6 = _rnd.NextByte();
            byte testParam7 = _rnd.NextByte();
            byte testParam8 = _rnd.NextByte();
            byte testParam9 = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam0, testOutput.FamilyType);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithTenByteParameters_SetsSerifStylePropertyToValueOfSecondParameter()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            byte testParam2 = _rnd.NextByte();
            byte testParam3 = _rnd.NextByte();
            byte testParam4 = _rnd.NextByte();
            byte testParam5 = _rnd.NextByte();
            byte testParam6 = _rnd.NextByte();
            byte testParam7 = _rnd.NextByte();
            byte testParam8 = _rnd.NextByte();
            byte testParam9 = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam1, testOutput.SerifStyle);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithTenByteParameters_SetsWeightPropertyToValueOfThirdParameter()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            byte testParam2 = _rnd.NextByte();
            byte testParam3 = _rnd.NextByte();
            byte testParam4 = _rnd.NextByte();
            byte testParam5 = _rnd.NextByte();
            byte testParam6 = _rnd.NextByte();
            byte testParam7 = _rnd.NextByte();
            byte testParam8 = _rnd.NextByte();
            byte testParam9 = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam2, testOutput.Weight);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithTenByteParameters_SetsProportionPropertyToValueOfFourthParameter()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            byte testParam2 = _rnd.NextByte();
            byte testParam3 = _rnd.NextByte();
            byte testParam4 = _rnd.NextByte();
            byte testParam5 = _rnd.NextByte();
            byte testParam6 = _rnd.NextByte();
            byte testParam7 = _rnd.NextByte();
            byte testParam8 = _rnd.NextByte();
            byte testParam9 = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam3, testOutput.Proportion);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithTenByteParameters_SetsContrastPropertyToValueOfFifthParameter()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            byte testParam2 = _rnd.NextByte();
            byte testParam3 = _rnd.NextByte();
            byte testParam4 = _rnd.NextByte();
            byte testParam5 = _rnd.NextByte();
            byte testParam6 = _rnd.NextByte();
            byte testParam7 = _rnd.NextByte();
            byte testParam8 = _rnd.NextByte();
            byte testParam9 = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam4, testOutput.Contrast);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithTenByteParameters_SetsStrokeVariationPropertyToValueOfSixthParameter()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            byte testParam2 = _rnd.NextByte();
            byte testParam3 = _rnd.NextByte();
            byte testParam4 = _rnd.NextByte();
            byte testParam5 = _rnd.NextByte();
            byte testParam6 = _rnd.NextByte();
            byte testParam7 = _rnd.NextByte();
            byte testParam8 = _rnd.NextByte();
            byte testParam9 = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam5, testOutput.StrokeVariation);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithTenByteParameters_SetsArmStylePropertyToValueOfSeventhParameter()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            byte testParam2 = _rnd.NextByte();
            byte testParam3 = _rnd.NextByte();
            byte testParam4 = _rnd.NextByte();
            byte testParam5 = _rnd.NextByte();
            byte testParam6 = _rnd.NextByte();
            byte testParam7 = _rnd.NextByte();
            byte testParam8 = _rnd.NextByte();
            byte testParam9 = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam6, testOutput.ArmStyle);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithTenByteParameters_SetsLetterformPropertyToValueOfEighthParameter()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            byte testParam2 = _rnd.NextByte();
            byte testParam3 = _rnd.NextByte();
            byte testParam4 = _rnd.NextByte();
            byte testParam5 = _rnd.NextByte();
            byte testParam6 = _rnd.NextByte();
            byte testParam7 = _rnd.NextByte();
            byte testParam8 = _rnd.NextByte();
            byte testParam9 = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam7, testOutput.Letterform);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithTenByteParameters_SetsMidlinePropertyToValueOfNinthParameter()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            byte testParam2 = _rnd.NextByte();
            byte testParam3 = _rnd.NextByte();
            byte testParam4 = _rnd.NextByte();
            byte testParam5 = _rnd.NextByte();
            byte testParam6 = _rnd.NextByte();
            byte testParam7 = _rnd.NextByte();
            byte testParam8 = _rnd.NextByte();
            byte testParam9 = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam8, testOutput.Midline);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithTenByteParameters_SetsXHeightPropertyToValueOfTenthParameter()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            byte testParam2 = _rnd.NextByte();
            byte testParam3 = _rnd.NextByte();
            byte testParam4 = _rnd.NextByte();
            byte testParam5 = _rnd.NextByte();
            byte testParam6 = _rnd.NextByte();
            byte testParam7 = _rnd.NextByte();
            byte testParam8 = _rnd.NextByte();
            byte testParam9 = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam9, testOutput.XHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void PanoseFamilyStruct_ConstructorWithArrayOfByteAndIntParameters_ThrowsNullReferenceException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = new PanoseFamily(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void PanoseFamilyStruct_ConstructorWithArrayOfByteAndIntParameters_ThrowsIndexOutOfRangeException_IfFirstParameterHasFewerThanTenElements()
        {
            int paramLength = _rnd.Next(10);
            byte[] testParam0 = new byte[paramLength];
            int testParam1 = 0;

            _ = new PanoseFamily(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void PanoseFamilyStruct_ConstructorWithArrayOfByteAndIntParameters_ThrowsIndexOutOfRangeException_IfSecondParameterIsNegative()
        {
            byte[] testParam0 = new byte[_rnd.Next(10, 128)];
            int testParam1 = _rnd.Next(int.MinValue, 0);

            _ = new PanoseFamily(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void PanoseFamilyStruct_ConstructorWithArrayOfByteAndIntParameters_ThrowsIndexOutOfRangeException_IfSecondParameterIsTooLarge()
        {
            byte[] testParam0 = new byte[_rnd.Next(10, 128)];
            int testParam1 = _rnd.Next(testParam0.Length - 10, int.MaxValue);

            _ = new PanoseFamily(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithArrayOfByteAndIntParameters_SetsFamilyTypePropertyToArrayElementAtOffset()
        {
            byte[] testParam0 = new byte[_rnd.Next(10, 128)];
            int testParam1 = _rnd.Next(testParam0.Length - 10);
            testParam0[testParam1] = _rnd.NextByte();
            testParam0[testParam1 + 1] = _rnd.NextByte();
            testParam0[testParam1 + 2] = _rnd.NextByte();
            testParam0[testParam1 + 3] = _rnd.NextByte();
            testParam0[testParam1 + 4] = _rnd.NextByte();
            testParam0[testParam1 + 5] = _rnd.NextByte();
            testParam0[testParam1 + 6] = _rnd.NextByte();
            testParam0[testParam1 + 7] = _rnd.NextByte();
            testParam0[testParam1 + 8] = _rnd.NextByte();
            testParam0[testParam1 + 9] = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1);

            Assert.AreEqual(testParam0[testParam1], testOutput.FamilyType);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithArrayOfByteAndIntParameters_SetsSerifStylePropertyToFirstArrayElementAfterOffset()
        {
            byte[] testParam0 = new byte[_rnd.Next(10, 128)];
            int testParam1 = _rnd.Next(testParam0.Length - 10);
            testParam0[testParam1] = _rnd.NextByte();
            testParam0[testParam1 + 1] = _rnd.NextByte();
            testParam0[testParam1 + 2] = _rnd.NextByte();
            testParam0[testParam1 + 3] = _rnd.NextByte();
            testParam0[testParam1 + 4] = _rnd.NextByte();
            testParam0[testParam1 + 5] = _rnd.NextByte();
            testParam0[testParam1 + 6] = _rnd.NextByte();
            testParam0[testParam1 + 7] = _rnd.NextByte();
            testParam0[testParam1 + 8] = _rnd.NextByte();
            testParam0[testParam1 + 9] = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1);

            Assert.AreEqual(testParam0[testParam1 + 1], testOutput.SerifStyle);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithArrayOfByteAndIntParameters_SetsWeightPropertyToSecondArrayElementAfterOffset()
        {
            byte[] testParam0 = new byte[_rnd.Next(10, 128)];
            int testParam1 = _rnd.Next(testParam0.Length - 10);
            testParam0[testParam1] = _rnd.NextByte();
            testParam0[testParam1 + 1] = _rnd.NextByte();
            testParam0[testParam1 + 2] = _rnd.NextByte();
            testParam0[testParam1 + 3] = _rnd.NextByte();
            testParam0[testParam1 + 4] = _rnd.NextByte();
            testParam0[testParam1 + 5] = _rnd.NextByte();
            testParam0[testParam1 + 6] = _rnd.NextByte();
            testParam0[testParam1 + 7] = _rnd.NextByte();
            testParam0[testParam1 + 8] = _rnd.NextByte();
            testParam0[testParam1 + 9] = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1);

            Assert.AreEqual(testParam0[testParam1 + 2], testOutput.Weight);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithArrayOfByteAndIntParameters_SetsProportionPropertyToThirdArrayElementAfterOffset()
        {
            byte[] testParam0 = new byte[_rnd.Next(10, 128)];
            int testParam1 = _rnd.Next(testParam0.Length - 10);
            testParam0[testParam1] = _rnd.NextByte();
            testParam0[testParam1 + 1] = _rnd.NextByte();
            testParam0[testParam1 + 2] = _rnd.NextByte();
            testParam0[testParam1 + 3] = _rnd.NextByte();
            testParam0[testParam1 + 4] = _rnd.NextByte();
            testParam0[testParam1 + 5] = _rnd.NextByte();
            testParam0[testParam1 + 6] = _rnd.NextByte();
            testParam0[testParam1 + 7] = _rnd.NextByte();
            testParam0[testParam1 + 8] = _rnd.NextByte();
            testParam0[testParam1 + 9] = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1);

            Assert.AreEqual(testParam0[testParam1 + 3], testOutput.Proportion);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithArrayOfByteAndIntParameters_SetsConstrastPropertyToFourthArrayElementAfterOffset()
        {
            byte[] testParam0 = new byte[_rnd.Next(10, 128)];
            int testParam1 = _rnd.Next(testParam0.Length - 10);
            testParam0[testParam1] = _rnd.NextByte();
            testParam0[testParam1 + 1] = _rnd.NextByte();
            testParam0[testParam1 + 2] = _rnd.NextByte();
            testParam0[testParam1 + 3] = _rnd.NextByte();
            testParam0[testParam1 + 4] = _rnd.NextByte();
            testParam0[testParam1 + 5] = _rnd.NextByte();
            testParam0[testParam1 + 6] = _rnd.NextByte();
            testParam0[testParam1 + 7] = _rnd.NextByte();
            testParam0[testParam1 + 8] = _rnd.NextByte();
            testParam0[testParam1 + 9] = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1);

            Assert.AreEqual(testParam0[testParam1 + 4], testOutput.Contrast);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithArrayOfByteAndIntParameters_SetsStrokeVariationPropertyToFifthArrayElementAfterOffset()
        {
            byte[] testParam0 = new byte[_rnd.Next(10, 128)];
            int testParam1 = _rnd.Next(testParam0.Length - 10);
            testParam0[testParam1] = _rnd.NextByte();
            testParam0[testParam1 + 1] = _rnd.NextByte();
            testParam0[testParam1 + 2] = _rnd.NextByte();
            testParam0[testParam1 + 3] = _rnd.NextByte();
            testParam0[testParam1 + 4] = _rnd.NextByte();
            testParam0[testParam1 + 5] = _rnd.NextByte();
            testParam0[testParam1 + 6] = _rnd.NextByte();
            testParam0[testParam1 + 7] = _rnd.NextByte();
            testParam0[testParam1 + 8] = _rnd.NextByte();
            testParam0[testParam1 + 9] = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1);

            Assert.AreEqual(testParam0[testParam1 + 5], testOutput.StrokeVariation);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithArrayOfByteAndIntParameters_SetsArmStylePropertyToSixthArrayElementAfterOffset()
        {
            byte[] testParam0 = new byte[_rnd.Next(10, 128)];
            int testParam1 = _rnd.Next(testParam0.Length - 10);
            testParam0[testParam1] = _rnd.NextByte();
            testParam0[testParam1 + 1] = _rnd.NextByte();
            testParam0[testParam1 + 2] = _rnd.NextByte();
            testParam0[testParam1 + 3] = _rnd.NextByte();
            testParam0[testParam1 + 4] = _rnd.NextByte();
            testParam0[testParam1 + 5] = _rnd.NextByte();
            testParam0[testParam1 + 6] = _rnd.NextByte();
            testParam0[testParam1 + 7] = _rnd.NextByte();
            testParam0[testParam1 + 8] = _rnd.NextByte();
            testParam0[testParam1 + 9] = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1);

            Assert.AreEqual(testParam0[testParam1 + 6], testOutput.ArmStyle);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithArrayOfByteAndIntParameters_SetsLetterformPropertyToSeventhArrayElementAfterOffset()
        {
            byte[] testParam0 = new byte[_rnd.Next(10, 128)];
            int testParam1 = _rnd.Next(testParam0.Length - 10);
            testParam0[testParam1] = _rnd.NextByte();
            testParam0[testParam1 + 1] = _rnd.NextByte();
            testParam0[testParam1 + 2] = _rnd.NextByte();
            testParam0[testParam1 + 3] = _rnd.NextByte();
            testParam0[testParam1 + 4] = _rnd.NextByte();
            testParam0[testParam1 + 5] = _rnd.NextByte();
            testParam0[testParam1 + 6] = _rnd.NextByte();
            testParam0[testParam1 + 7] = _rnd.NextByte();
            testParam0[testParam1 + 8] = _rnd.NextByte();
            testParam0[testParam1 + 9] = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1);

            Assert.AreEqual(testParam0[testParam1 + 7], testOutput.Letterform);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithArrayOfByteAndIntParameters_SetsMidlinePropertyToEighthArrayElementAfterOffset()
        {
            byte[] testParam0 = new byte[_rnd.Next(10, 128)];
            int testParam1 = _rnd.Next(testParam0.Length - 10);
            testParam0[testParam1] = _rnd.NextByte();
            testParam0[testParam1 + 1] = _rnd.NextByte();
            testParam0[testParam1 + 2] = _rnd.NextByte();
            testParam0[testParam1 + 3] = _rnd.NextByte();
            testParam0[testParam1 + 4] = _rnd.NextByte();
            testParam0[testParam1 + 5] = _rnd.NextByte();
            testParam0[testParam1 + 6] = _rnd.NextByte();
            testParam0[testParam1 + 7] = _rnd.NextByte();
            testParam0[testParam1 + 8] = _rnd.NextByte();
            testParam0[testParam1 + 9] = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1);

            Assert.AreEqual(testParam0[testParam1 + 8], testOutput.Midline);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ConstructorWithArrayOfByteAndIntParameters_SetsXHeightPropertyToNinthArrayElementAfterOffset()
        {
            byte[] testParam0 = new byte[_rnd.Next(10, 128)];
            int testParam1 = _rnd.Next(testParam0.Length - 10);
            testParam0[testParam1] = _rnd.NextByte();
            testParam0[testParam1 + 1] = _rnd.NextByte();
            testParam0[testParam1 + 2] = _rnd.NextByte();
            testParam0[testParam1 + 3] = _rnd.NextByte();
            testParam0[testParam1 + 4] = _rnd.NextByte();
            testParam0[testParam1 + 5] = _rnd.NextByte();
            testParam0[testParam1 + 6] = _rnd.NextByte();
            testParam0[testParam1 + 7] = _rnd.NextByte();
            testParam0[testParam1 + 8] = _rnd.NextByte();
            testParam0[testParam1 + 9] = _rnd.NextByte();

            PanoseFamily testOutput = new PanoseFamily(testParam0, testParam1);

            Assert.AreEqual(testParam0[testParam1 + 9], testOutput.XHeight);
        }

        [TestMethod]
        public void PanoseFamilyStruct_ToStringMethod_ReturnsCorrectData()
        {
            PanoseFamily testObject = GetTestObject();
            string expectedValue = testObject.FamilyType.ToString(CultureInfo.InvariantCulture) + " " + testObject.SerifStyle.ToString(CultureInfo.InvariantCulture) + 
                " " + testObject.Weight.ToString(CultureInfo.InvariantCulture) + " " + testObject.Proportion.ToString(CultureInfo.InvariantCulture) + " " + 
                testObject.Contrast.ToString(CultureInfo.InvariantCulture) + " " + testObject.StrokeVariation.ToString(CultureInfo.InvariantCulture) + " " +
                testObject.ArmStyle.ToString(CultureInfo.InvariantCulture) + " " + testObject.Letterform.ToString(CultureInfo.InvariantCulture) + " " + 
                testObject.Midline.ToString(CultureInfo.InvariantCulture) + " " + testObject.XHeight.ToString(CultureInfo.InvariantCulture);

            string testOutput = testObject.ToString();

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithPanoseFamilyParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            PanoseFamily testObject = GetTestObject();

            bool testOutput = testObject.Equals(testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithPanoseFamilyParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            PanoseFamily testObject = GetTestObject();
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithPanoseFamilyParameter_ReturnsFalse_IfParameterHasDifferentFamilyTypePropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.FamilyType);
            PanoseFamily testParam = new PanoseFamily(constrParam, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithPanoseFamilyParameter_ReturnsFalse_IfParameterHasDifferentSerifStylePropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.SerifStyle);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, constrParam, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithPanoseFamilyParameter_ReturnsFalse_IfParameterHasDifferentWeightPropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Weight);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, constrParam, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithPanoseFamilyParameter_ReturnsFalse_IfParameterHasDifferentProportionPropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Proportion);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, constrParam, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithPanoseFamilyParameter_ReturnsFalse_IfParameterHasDifferentContrastPropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Contrast);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, constrParam,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithPanoseFamilyParameter_ReturnsFalse_IfParameterHasDifferentStrokeVariationPropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.StrokeVariation);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                constrParam, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithPanoseFamilyParameter_ReturnsFalse_IfParameterHasDifferentArmStylePropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.ArmStyle);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, constrParam, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithPanoseFamilyParameter_ReturnsFalse_IfParameterHasDifferentLetterformPropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Letterform);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, constrParam, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithPanoseFamilyParameter_ReturnsFalse_IfParameterHasDifferentMidlinePropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Midline);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, constrParam, testObject.XHeight);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithPanoseFamilyParameter_ReturnsFalse_IfParameterHasDifferentXHeightPropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.XHeight);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, constrParam);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            PanoseFamily testObject = GetTestObject();

            bool testOutput = testObject.Equals((object)testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            PanoseFamily testObject = GetTestObject();
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasDifferentFamilyTypePropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.FamilyType);
            PanoseFamily testParam = new PanoseFamily(constrParam, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasDifferentSerifStylePropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.SerifStyle);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, constrParam, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasDifferentWeightPropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Weight);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, constrParam, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasDifferentProportionPropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Proportion);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, constrParam, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasDifferentContrastPropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Contrast);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, constrParam,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasDifferentStrokeVariationPropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.StrokeVariation);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                constrParam, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasDifferentArmStylePropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.ArmStyle);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, constrParam, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasDifferentLetterformPropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Letterform);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, constrParam, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithPanoseFamilyObjectParameter_ReturnsFalse_IfParameterHasDifferentMidlinePropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Midline);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, constrParam, testObject.XHeight);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasDifferentXHeightPropertyToValue()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.XHeight);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, constrParam);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            PanoseFamily testObject = GetTestObject();
            string testParam = testObject.ToString();

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualityOperator_ReturnsTrue_IfBothOperandsAreSameValue()
        {
            PanoseFamily testObject = GetTestObject();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testObject == testObject;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualityOperator_ReturnsTrue_IfOperandsAreConstructedFromSameData()
        {
            PanoseFamily testObject = GetTestObject();
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject == testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentFamilyTypeProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.FamilyType);
            PanoseFamily testParam = new PanoseFamily(constrParam, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentSerifStyleProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.SerifStyle);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, constrParam, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentWeightProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Weight);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, constrParam, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentProportionProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Proportion);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, constrParam, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentContrastProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Contrast);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, constrParam,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualityOperato_ReturnsFalse_IfOperandsHaveDifferentStrokeVariationProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.StrokeVariation);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                constrParam, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentArmStyleProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.ArmStyle);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, constrParam, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentLetterformProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Letterform);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, constrParam, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentMidlineProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Midline);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, constrParam, testObject.XHeight);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentXHeightProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.XHeight);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, constrParam);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_InequalityOperator_ReturnsFalse_IfBothOperandsAreSameValue()
        {
            PanoseFamily testObject = GetTestObject();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testObject != testObject;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_InequalityOperator_ReturnsFalse_IfOperandsAreConstructedFromSameData()
        {
            PanoseFamily testObject = GetTestObject();
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject != testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentFamilyTypeProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.FamilyType);
            PanoseFamily testParam = new PanoseFamily(constrParam, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentSerifStyleProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.SerifStyle);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, constrParam, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentWeightProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Weight);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, constrParam, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentProportionProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Proportion);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, constrParam, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentContrastProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Contrast);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, constrParam,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_InequalityOperato_ReturnsTrue_IfOperandsHaveDifferentStrokeVariationProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.StrokeVariation);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                constrParam, testObject.ArmStyle, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentArmStyleProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.ArmStyle);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, constrParam, testObject.Letterform, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentLetterformProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Letterform);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, constrParam, testObject.Midline, testObject.XHeight);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentMidlineProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.Midline);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, constrParam, testObject.XHeight);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentXHeightProperties()
        {
            PanoseFamily testObject = GetTestObject();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testObject.XHeight);
            PanoseFamily testParam = new PanoseFamily(testObject.FamilyType, testObject.SerifStyle, testObject.Weight, testObject.Proportion, testObject.Contrast,
                testObject.StrokeVariation, testObject.ArmStyle, testObject.Letterform, testObject.Midline, constrParam);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PanoseFamilyStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceOnSameValue()
        {
            PanoseFamily testObject0 = GetTestObject();
            PanoseFamily testObject1 = new PanoseFamily(testObject0.FamilyType, testObject0.SerifStyle, testObject0.Weight, testObject0.Proportion, 
                testObject0.Contrast, testObject0.StrokeVariation, testObject0.ArmStyle, testObject0.Letterform, testObject0.Midline, testObject0.XHeight);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
