using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class SegmentSubheaderRecordUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static SegmentSubheaderRecord GetTestValue()
            => new SegmentSubheaderRecord(_rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextShort(), _rnd.Next());

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void SegmentSubheaderRecord_ParameterlessConstructor_SetsStartCodePropertyToZero()
        {
            SegmentSubheaderRecord testOutput = new SegmentSubheaderRecord();

            Assert.AreEqual((ushort)0, testOutput.StartCode);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_ParameterlessConstructor_SetsEndCodePropertyToZero()
        {
            SegmentSubheaderRecord testOutput = new SegmentSubheaderRecord();

            Assert.AreEqual((ushort)0, testOutput.EndCode);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_ParameterlessConstructor_SetsIdDeltaPropertyToZero()
        {
            SegmentSubheaderRecord testOutput = new SegmentSubheaderRecord();

            Assert.AreEqual((short)0, testOutput.IdDelta);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_ParameterlessConstructor_SetsStartOffsetPropertyToZero()
        {
            SegmentSubheaderRecord testOutput = new SegmentSubheaderRecord();

            Assert.AreEqual(0, testOutput.StartOffset);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_ConstructorWithUshortUshortShortAndIntParameters_SetsStartCodePropertyToValueOfFirstParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            short testParam2 = _rnd.NextShort();
            int testParam3 = _rnd.Next();

            SegmentSubheaderRecord testOutput = new SegmentSubheaderRecord(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam0, testOutput.StartCode);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_ConstructorWithUshortUshortShortAndIntParameters_SetsEndCodePropertyToValueOfSecondParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            short testParam2 = _rnd.NextShort();
            int testParam3 = _rnd.Next();

            SegmentSubheaderRecord testOutput = new SegmentSubheaderRecord(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam1, testOutput.EndCode);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_ConstructorWithUshortUshortShortAndIntParameters_SetsIdDeltaPropertyToValueOfThirdParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            short testParam2 = _rnd.NextShort();
            int testParam3 = _rnd.Next();

            SegmentSubheaderRecord testOutput = new SegmentSubheaderRecord(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam2, testOutput.IdDelta);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_ConstructorWithUshortUshortShortAndIntParameters_SetsStartOffsetPropertyToValueOfFourthParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            short testParam2 = _rnd.NextShort();
            int testParam3 = _rnd.Next();

            SegmentSubheaderRecord testOutput = new SegmentSubheaderRecord(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam3, testOutput.StartOffset);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualsMethodWithSegmentSubheaderRecordParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            SegmentSubheaderRecord testValue = GetTestValue();

            bool testOutput = testValue.Equals(testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualsMethodWithSegmentSubheaderRecordParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, testValue.EndCode, testValue.IdDelta, testValue.StartOffset);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualsMethodWithSegmentSubheaderRecordParameter_ReturnsFalse_IfParameterDiffersByStartCodeProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.StartCode);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(constrParam, testValue.EndCode, testValue.IdDelta, testValue.StartOffset);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualsMethodWithSegmentSubheaderRecordParameter_ReturnsFalse_IfParameterDiffersByEndCodeProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.EndCode);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, constrParam, testValue.IdDelta, testValue.StartOffset);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualsMethodWithSegmentSubheaderRecordParameter_ReturnsFalse_IfParameterDiffersByIdDeltaProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            short constrParam;
            do
            {
                constrParam = _rnd.NextShort();
            } while (constrParam == testValue.IdDelta);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, testValue.EndCode, constrParam, testValue.StartOffset);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualsMethodWithSegmentSubheaderRecordParameter_ReturnsFalse_IfParameterDiffersByStartOffsetProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            int constrParam;
            do
            {
                constrParam = _rnd.Next();
            } while (constrParam == testValue.StartCode);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, testValue.EndCode, testValue.IdDelta, constrParam);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            SegmentSubheaderRecord testValue = GetTestValue();

            bool testOutput = testValue.Equals((object)testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, testValue.EndCode, testValue.IdDelta, testValue.StartOffset);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByStartCodeProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.StartCode);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(constrParam, testValue.EndCode, testValue.IdDelta, testValue.StartOffset);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByEndCodeProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.EndCode);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, constrParam, testValue.IdDelta, testValue.StartOffset);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByIdDeltaProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            short constrParam;
            do
            {
                constrParam = _rnd.NextShort();
            } while (constrParam == testValue.IdDelta);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, testValue.EndCode, constrParam, testValue.StartOffset);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByStartOffsetProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            int constrParam;
            do
            {
                constrParam = _rnd.Next();
            } while (constrParam == testValue.StartCode);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, testValue.EndCode, testValue.IdDelta, constrParam);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            string testParam = _rnd.NextString(_rnd.Next(20));

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceOnSameValue()
        {
            SegmentSubheaderRecord testValue0 = GetTestValue();
            SegmentSubheaderRecord testValue1 = new SegmentSubheaderRecord(testValue0.StartCode, testValue0.EndCode, testValue0.IdDelta, testValue0.StartOffset);

            int testOutput0 = testValue0.GetHashCode();
            int testOutput1 = testValue1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualityOperator_ReturnsTrue_IfBothOperandsAreSameValue()
        {
            SegmentSubheaderRecord testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue == testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualityOperator_ReturnsTrue_IfOperandsAreConstructedFromSameData()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, testValue.EndCode, testValue.IdDelta, testValue.StartOffset);

            bool testOutput = testValue == testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualityOperator_ReturnsFalse_IfOperandsDifferByStartCodeProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.StartCode);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(constrParam, testValue.EndCode, testValue.IdDelta, testValue.StartOffset);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualityOperator_ReturnsFalse_IfOperandsDifferByEndCodeProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.EndCode);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, constrParam, testValue.IdDelta, testValue.StartOffset);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualityOperator_ReturnsFalse_IfOperatorsDifferByIdDeltaProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            short constrParam;
            do
            {
                constrParam = _rnd.NextShort();
            } while (constrParam == testValue.IdDelta);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, testValue.EndCode, constrParam, testValue.StartOffset);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_EqualityOperator_ReturnsFalse_IfOperandsDifferByStartOffsetProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            int constrParam;
            do
            {
                constrParam = _rnd.Next();
            } while (constrParam == testValue.StartCode);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, testValue.EndCode, testValue.IdDelta, constrParam);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_InequalityOperator_ReturnsFalse_IfBothOperandsAreSameValue()
        {
            SegmentSubheaderRecord testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue != testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_InequalityOperator_ReturnsFalse_IfOperandsAreConstructedFromSameData()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, testValue.EndCode, testValue.IdDelta, testValue.StartOffset);

            bool testOutput = testValue != testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_InequalityOperator_ReturnsTrue_IfOperandsDifferByStartCodeProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.StartCode);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(constrParam, testValue.EndCode, testValue.IdDelta, testValue.StartOffset);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_InequalityOperator_ReturnsTrue_IfOperandsDifferByEndCodeProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            ushort constrParam;
            do
            {
                constrParam = _rnd.NextUShort();
            } while (constrParam == testValue.EndCode);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, constrParam, testValue.IdDelta, testValue.StartOffset);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_InequalityOperator_ReturnsTrue_IfOperatorsDifferByIdDeltaProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            short constrParam;
            do
            {
                constrParam = _rnd.NextShort();
            } while (constrParam == testValue.IdDelta);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, testValue.EndCode, constrParam, testValue.StartOffset);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void SegmentSubheaderRecord_InequalityOperator_ReturnsTrue_IfOperandsDifferByStartOffsetProperty()
        {
            SegmentSubheaderRecord testValue = GetTestValue();
            int constrParam;
            do
            {
                constrParam = _rnd.Next();
            } while (constrParam == testValue.StartCode);
            SegmentSubheaderRecord testParam = new SegmentSubheaderRecord(testValue.StartCode, testValue.EndCode, testValue.IdDelta, constrParam);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
