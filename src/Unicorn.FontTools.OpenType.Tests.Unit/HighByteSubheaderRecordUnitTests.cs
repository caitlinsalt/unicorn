using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class HighByteSubheaderRecordUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static HighByteSubheaderRecord GetTestValue()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            short testParam2 = _rnd.NextShort();
            ushort testParam3 = _rnd.NextUShort();

            return new HighByteSubheaderRecord(testParam0, testParam1, testParam2, testParam3);
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void HighByteSubheaderRecordStruct_ParameterlessConstructor_SetsFirstBytePropertyToZero()
        {
            HighByteSubheaderRecord testOutput = new HighByteSubheaderRecord();

            Assert.AreEqual((byte)0, testOutput.FirstByte);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_ParameterlessConstructor_SetsLastBytePropertyToZero()
        {
            HighByteSubheaderRecord testOutput = new HighByteSubheaderRecord();

            Assert.AreEqual((byte)0, testOutput.LastByte);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_ParameterlessConstructor_SetsIdDeltaPropertyToZero()
        {
            HighByteSubheaderRecord testOutput = new HighByteSubheaderRecord();

            Assert.AreEqual((short)0, testOutput.FirstByte);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_ParameterlessConstructor_SetsStartIndexPropertyToZero()
        {
            HighByteSubheaderRecord testOutput = new HighByteSubheaderRecord();

            Assert.AreEqual((ushort)0, testOutput.FirstByte);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_ConstructorWithByteByteShortAndUShortParameters_SetsFirstBytePropertyToValueOfFirstParameter()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            short testParam2 = _rnd.NextShort();
            ushort testParam3 = _rnd.NextUShort();

            HighByteSubheaderRecord testOutput = new HighByteSubheaderRecord(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam0, testOutput.FirstByte);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_ConstructorWithByteByteShortAndUShortParameters_SetsLastBytePropertyToValueOfSecondParameter()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            short testParam2 = _rnd.NextShort();
            ushort testParam3 = _rnd.NextUShort();

            HighByteSubheaderRecord testOutput = new HighByteSubheaderRecord(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam1, testOutput.LastByte);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_ConstructorWithByteByteShortAndUShortParameters_SetsIdDeltaPropertyToValueOfThirdParameter()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            short testParam2 = _rnd.NextShort();
            ushort testParam3 = _rnd.NextUShort();

            HighByteSubheaderRecord testOutput = new HighByteSubheaderRecord(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam2, testOutput.IdDelta);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_ConstructorWithByteByteShortAndUShortParameters_SetsStartIndexPropertyToValueOfFourthParameter()
        {
            byte testParam0 = _rnd.NextByte();
            byte testParam1 = _rnd.NextByte();
            short testParam2 = _rnd.NextShort();
            ushort testParam3 = _rnd.NextUShort();

            HighByteSubheaderRecord testOutput = new HighByteSubheaderRecord(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam3, testOutput.StartIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HighByteSubheaderRecordStruct_FromBytesMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();
            int testParam2 = _rnd.Next();

            _ = HighByteSubheaderRecord.FromBytes(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void HighByteSubheaderRecordStruct_FromBytesMethod_ThrowsInvalidOperationException_IfFirstParameterIsLessThanEightBytesLong()
        {
            byte[] testParam0 = new byte[_rnd.Next(8)];
            int testParam1 = 0;
            int testParam2 = _rnd.Next();

            _ = HighByteSubheaderRecord.FromBytes(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void HighByteSubheaderRecordStruct_FromBytesMethod_ThrowsIndexOutOfRangeException_IfSecondParameterIsNegative()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(int.MinValue, 0);
            int testParam2 = _rnd.Next();

            _ = HighByteSubheaderRecord.FromBytes(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void HighByteSubheaderRecordStruct_FromBytesMethod_ThrowsIndexOutOfRangeException_IfSecondParameterIsTooLarge()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7, int.MaxValue);
            int testParam2 = _rnd.Next();

            _ = HighByteSubheaderRecord.FromBytes(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_FromBytesMethod_ReturnsObjectWithCorrectFirstByteProperty_IfParametersAreValid()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            byte testData0 = _rnd.NextByte();
            byte testData1 = _rnd.NextByte(byte.MaxValue - testData0);
            short testData2 = _rnd.NextShort();
            ushort testData3 = _rnd.NextUShort();
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            int testParam2 = _rnd.Next(testData3);
            testParam0[testParam1 + 1] = testData0;
            testParam0[testParam1 + 3] = testData1;
            testParam0[testParam1 + 4] = (byte)((testData2 & 0xff00) >> 8);
            testParam0[testParam1 + 5] = (byte)(testData2 & 0xff);
            testParam0[testParam1 + 6] = (byte)((testData3 & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(testData3 & 0xff);

            HighByteSubheaderRecord testOutput = HighByteSubheaderRecord.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(testData0, testOutput.FirstByte);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_FromBytesMethod_ReturnsObjectWithCorrectLastByteProperty_IfParametersAreValid()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            byte testData0 = _rnd.NextByte();
            byte testData1 = _rnd.NextByte(byte.MaxValue - testData0);
            short testData2 = _rnd.NextShort();
            ushort testData3 = _rnd.NextUShort();
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            int testParam2 = _rnd.Next(testData3);
            testParam0[testParam1 + 1] = testData0;
            testParam0[testParam1 + 3] = testData1;
            testParam0[testParam1 + 4] = (byte)((testData2 & 0xff00) >> 8);
            testParam0[testParam1 + 5] = (byte)(testData2 & 0xff);
            testParam0[testParam1 + 6] = (byte)((testData3 & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(testData3 & 0xff);

            HighByteSubheaderRecord testOutput = HighByteSubheaderRecord.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual((byte)(testData0 + testData1), testOutput.LastByte);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_FromBytesMethod_ReturnsObjectWithCorrectIdDeltaProperty_IfParametersAreValid()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            byte testData0 = _rnd.NextByte();
            byte testData1 = _rnd.NextByte(byte.MaxValue - testData0);
            short testData2 = _rnd.NextShort();
            ushort testData3 = _rnd.NextUShort();
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            int testParam2 = _rnd.Next(testData3);
            testParam0[testParam1 + 1] = testData0;
            testParam0[testParam1 + 3] = testData1;
            testParam0[testParam1 + 4] = (byte)((testData2 & 0xff00) >> 8);
            testParam0[testParam1 + 5] = (byte)(testData2 & 0xff);
            testParam0[testParam1 + 6] = (byte)((testData3 & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(testData3 & 0xff);

            HighByteSubheaderRecord testOutput = HighByteSubheaderRecord.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(testData2, testOutput.IdDelta);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_FromBytesMethod_ReturnsObjectWithCorrectStartIndexProperty_IfParametersAreValid()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            byte testData0 = _rnd.NextByte();
            byte testData1 = _rnd.NextByte(byte.MaxValue - testData0);
            short testData2 = _rnd.NextShort();
            ushort testData3 = _rnd.NextUShort();
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            int testParam2 = _rnd.Next(testData3);
            testParam0[testParam1 + 1] = testData0;
            testParam0[testParam1 + 3] = testData1;
            testParam0[testParam1 + 4] = (byte)((testData2 & 0xff00) >> 8);
            testParam0[testParam1 + 5] = (byte)(testData2 & 0xff);
            testParam0[testParam1 + 6] = (byte)((testData3 & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(testData3 & 0xff);

            HighByteSubheaderRecord testOutput = HighByteSubheaderRecord.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual((ushort)(testData3 - testParam2), testOutput.StartIndex);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualsMethodWithHighByteSubheaderRecordParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            HighByteSubheaderRecord testValue = GetTestValue();

            bool testOutput = testValue.Equals(testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualsMethodWithHighByteSubheaderRecordParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, testValue.LastByte, testValue.IdDelta, testValue.StartIndex);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualsMethodWithHighByteSubheaderRecordParameter_ReturnsFalse_IfParameterDiffersByFirstByteProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testValue.FirstByte);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(constrParam, testValue.LastByte, testValue.IdDelta, testValue.StartIndex);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualsMethodWithHighByteSubheaderRecordParameter_ReturnsFalse_IfParameterDiffersByLastByteProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testValue.LastByte);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, constrParam, testValue.IdDelta, testValue.StartIndex);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualsMethodWithHighByteSubheaderRecordParameter_ReturnsFalse_IfParameterDiffersByIdDeltaProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            short constrParam;
            do
            {
                constrParam = _rnd.NextShort();
            } while (constrParam == testValue.IdDelta);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, testValue.LastByte, constrParam, testValue.StartIndex);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualsMethodWithHighByteSubheaderRecordParameter_ReturnsFalse_IfParameterDiffersByStartIndexProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.StartIndex);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, testValue.LastByte, testValue.IdDelta, constrParam);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            HighByteSubheaderRecord testValue = GetTestValue();

            bool testOutput = testValue.Equals((object)testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, testValue.LastByte, testValue.IdDelta, testValue.StartIndex);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByFirstByteProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testValue.FirstByte);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(constrParam, testValue.LastByte, testValue.IdDelta, testValue.StartIndex);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByLastByteProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testValue.LastByte);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, constrParam, testValue.IdDelta, testValue.StartIndex);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByIdDeltaProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            short constrParam;
            do
            {
                constrParam = _rnd.NextShort();
            } while (constrParam == testValue.IdDelta);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, testValue.LastByte, constrParam, testValue.StartIndex);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByStartIndexProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.StartIndex);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, testValue.LastByte, testValue.IdDelta, constrParam);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            string testParam = _rnd.NextString(_rnd.Next(50));

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceOnSameValue()
        {
            HighByteSubheaderRecord testValue0 = GetTestValue();
            HighByteSubheaderRecord testValue1 = new HighByteSubheaderRecord(testValue0.FirstByte, testValue0.LastByte, testValue0.IdDelta, testValue0.StartIndex);

            int testOutput0 = testValue0.GetHashCode();
            int testOutput1 = testValue1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualityOperator_ReturnsTrue_IfOperandsAreSameValue()
        {
            HighByteSubheaderRecord testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue == testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualityOperator_ReturnsTrue_IfOperandsAreConstructedFromSameData()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, testValue.LastByte, testValue.IdDelta, testValue.StartIndex);

            bool testOutput = testValue == testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByFirstByteProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testValue.FirstByte);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(constrParam, testValue.LastByte, testValue.IdDelta, testValue.StartIndex);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByLastByteProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testValue.LastByte);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, constrParam, testValue.IdDelta, testValue.StartIndex);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByIdDeltaProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            short constrParam;
            do
            {
                constrParam = _rnd.NextShort();
            } while (constrParam == testValue.IdDelta);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, testValue.LastByte, constrParam, testValue.StartIndex);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByStartIndexProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.StartIndex);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, testValue.LastByte, testValue.IdDelta, constrParam);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_InequalityOperator_ReturnsFalse_IfOperandsAreSameValue()
        {
            HighByteSubheaderRecord testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue != testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_InequalityOperator_ReturnsFalse_IfOperandsAreConstructedFromSameData()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, testValue.LastByte, testValue.IdDelta, testValue.StartIndex);

            bool testOutput = testValue != testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByFirstByteProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testValue.FirstByte);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(constrParam, testValue.LastByte, testValue.IdDelta, testValue.StartIndex);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByLastByteProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            byte constrParam;
            do
            {
                constrParam = _rnd.NextByte();
            } while (constrParam == testValue.LastByte);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, constrParam, testValue.IdDelta, testValue.StartIndex);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByIdDeltaProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            short constrParam;
            do
            {
                constrParam = _rnd.NextShort();
            } while (constrParam == testValue.IdDelta);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, testValue.LastByte, constrParam, testValue.StartIndex);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HighByteSubheaderRecordStruct_IneEqualityOperator_ReturnsTruse_IfOperandsDifferByStartIndexProperty()
        {
            HighByteSubheaderRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.StartIndex);
            HighByteSubheaderRecord testParam = new HighByteSubheaderRecord(testValue.FirstByte, testValue.LastByte, testValue.IdDelta, constrParam);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
