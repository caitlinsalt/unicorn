using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class SequentialMapGroupRecordUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static SequentialMapGroupRecord GetTestValue()
        {
            return new SequentialMapGroupRecord(_rnd.NextUInt(), _rnd.NextUInt(), _rnd.NextUShort());
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void SequentialMapGroupRecordStruct_ParameterlessConstructor_SetsStartCodePropertyToZero()
        {
            SequentialMapGroupRecord testOutput = new SequentialMapGroupRecord();

            Assert.AreEqual(0u, testOutput.StartCode);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_ParameterlessConstructor_SetsEndCodePropertyToZero()
        {
            SequentialMapGroupRecord testOutput = new SequentialMapGroupRecord();

            Assert.AreEqual(0u, testOutput.EndCode);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_ParameterlessConstructor_SetsStartGlyphIdPropertyToZero()
        {
            SequentialMapGroupRecord testOutput = new SequentialMapGroupRecord();

            Assert.AreEqual((ushort)0, testOutput.StartGlyphId);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_ConstructorWithUintUintAndUshortParameters_SetsStartCodePropertyToValueOfFirstParameter()
        {
            uint testParam0 = _rnd.NextUInt();
            uint testParam1 = _rnd.NextUInt();
            ushort testParam2 = _rnd.NextUShort();

            SequentialMapGroupRecord testOutput = new SequentialMapGroupRecord(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam0, testOutput.StartCode);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_ConstructorWithUintUintAndUshortParameters_SetsEndCodePropertyToValueOfSecondParameter()
        {
            uint testParam0 = _rnd.NextUInt();
            uint testParam1 = _rnd.NextUInt();
            ushort testParam2 = _rnd.NextUShort();

            SequentialMapGroupRecord testOutput = new SequentialMapGroupRecord(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam1, testOutput.EndCode);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_ConstructorWithUintUintAndUshortParameters_SetsStartGlyphIdPropertyToValueOfThirdParameter()
        {
            uint testParam0 = _rnd.NextUInt();
            uint testParam1 = _rnd.NextUInt();
            ushort testParam2 = _rnd.NextUShort();

            SequentialMapGroupRecord testOutput = new SequentialMapGroupRecord(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam2, testOutput.StartGlyphId);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualsMethodWithSequentialMapGroupRecordParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            SequentialMapGroupRecord testValue = GetTestValue();

            bool testOutput = testValue.Equals(testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualsMethodWithSequentialMapGroupRecordParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(testValue.StartCode, testValue.EndCode, testValue.StartGlyphId);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualsMethodWithSequentialMapGroupRecordParameter_ReturnsFalse_IfParameterDiffersByStartCodeProperty()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            uint constrParam;
            do
            {
                constrParam = _rnd.NextUInt();
            } while (constrParam == testValue.StartCode);
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(constrParam, testValue.EndCode, testValue.StartGlyphId);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualsMethodWithSequentialMapGroupRecordParameter_ReturnsFalse_IfParameterDiffersByEndCodeProperty()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            uint constrParam;
            do
            {
                constrParam = _rnd.NextUInt();
            } while (constrParam == testValue.EndCode);
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(testValue.StartCode, constrParam, testValue.StartGlyphId);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualsMethodWithSequentialMapGroupRecordParameter_ReturnsFalse_IfParameterDiffersByStartGlyphIdProperty()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.StartGlyphId);
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(testValue.StartCode, testValue.EndCode, constrParam);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            SequentialMapGroupRecord testValue = GetTestValue();

            bool testOutput = testValue.Equals((object)testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(testValue.StartCode, testValue.EndCode, testValue.StartGlyphId);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByStartCodeProperty()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            uint constrParam;
            do
            {
                constrParam = _rnd.NextUInt();
            } while (constrParam == testValue.StartCode);
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(constrParam, testValue.EndCode, testValue.StartGlyphId);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByEndCodeProperty()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            uint constrParam;
            do
            {
                constrParam = _rnd.NextUInt();
            } while (constrParam == testValue.EndCode);
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(testValue.StartCode, constrParam, testValue.StartGlyphId);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByStartGlyphIdProperty()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.StartGlyphId);
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(testValue.StartCode, testValue.EndCode, constrParam);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            string testParam = _rnd.NextString(_rnd.Next(20));

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

        [TestMethod]
        public void SequentialMapGroupRecordStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceOnSameValue()
        {
            SequentialMapGroupRecord testValue0 = GetTestValue();
            SequentialMapGroupRecord testValue1 = new SequentialMapGroupRecord(testValue0.StartCode, testValue0.EndCode, testValue0.StartGlyphId);

            int testOutput0 = testValue0.GetHashCode();
            int testOutput1 = testValue1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualityOperator_ReturnsTrue_IfOperandsAreSameValue()
        {
            SequentialMapGroupRecord testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue == testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualityOperator_ReturnsTrue_IfOperandsAreConstructedFromSameData()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(testValue.StartCode, testValue.EndCode, testValue.StartGlyphId);

            bool testOutput = testValue == testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByStartCodeProperty()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            uint constrParam;
            do
            {
                constrParam = _rnd.NextUInt();
            } while (constrParam == testValue.StartCode);
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(constrParam, testValue.EndCode, testValue.StartGlyphId);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByEndCodeProperty()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            uint constrParam;
            do
            {
                constrParam = _rnd.NextUInt();
            } while (constrParam == testValue.EndCode);
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(testValue.StartCode, constrParam, testValue.StartGlyphId);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByStartGlyphIdProperty()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.StartGlyphId);
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(testValue.StartCode, testValue.EndCode, constrParam);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_InequalityOperator_ReturnsFalse_IfOperandsAreSameValue()
        {
            SequentialMapGroupRecord testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue != testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_InequalityOperator_ReturnsFalse_IfOperandsAreConstructedFromSameData()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(testValue.StartCode, testValue.EndCode, testValue.StartGlyphId);

            bool testOutput = testValue != testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByStartCodeProperty()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            uint constrParam;
            do
            {
                constrParam = _rnd.NextUInt();
            } while (constrParam == testValue.StartCode);
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(constrParam, testValue.EndCode, testValue.StartGlyphId);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByEndCodeProperty()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            uint constrParam;
            do
            {
                constrParam = _rnd.NextUInt();
            } while (constrParam == testValue.EndCode);
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(testValue.StartCode, constrParam, testValue.StartGlyphId);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SequentialMapGroupRecordStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByStartGlyphIdProperty()
        {
            SequentialMapGroupRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.StartGlyphId);
            SequentialMapGroupRecord testParam = new SequentialMapGroupRecord(testValue.StartCode, testValue.EndCode, constrParam);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
