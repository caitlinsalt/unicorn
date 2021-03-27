using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class HorizontalMetricRecordUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void HorizontalMetricRecordStruct_ParameterlessConstructor_SetsAdvanceWidthPropertyToZero()
        {
            HorizontalMetricRecord testOutput = new HorizontalMetricRecord();

            Assert.AreEqual((ushort)0, testOutput.AdvanceWidth);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_ParameterlessConstructor_SetsLeftSideBearingPropertyToZero()
        {
            HorizontalMetricRecord testOutput = new HorizontalMetricRecord();

            Assert.AreEqual((short)0, testOutput.LeftSideBearing);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_ConstructorWithUShortAndShortParameters_SetsAdvanceWidthPropertyToValueOfFirstParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            short testParam1 = _rnd.NextShort();

            HorizontalMetricRecord testOutput = new HorizontalMetricRecord(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.AdvanceWidth);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_ConstructorWithUShortAndShortParameters_SetsLeftSideBearingPropertyToValueOfSecondParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            short testParam1 = _rnd.NextShort();

            HorizontalMetricRecord testOutput = new HorizontalMetricRecord(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.LeftSideBearing);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_EqualsMethodWithHorizontalMetricRecordParameter_ReturnsTrue_IfParameterIsThis()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue = new HorizontalMetricRecord(constrParam0, constrParam1);

            bool testOutput = testValue.Equals(testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_EqualsMethodWithHorizontalMetricRecordParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue = new HorizontalMetricRecord(constrParam0, constrParam1);
            HorizontalMetricRecord testParam = new HorizontalMetricRecord(testValue.AdvanceWidth, testValue.LeftSideBearing);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_EqualsMethodWithHorizontalMetricRecordParameter_ReturnsFalse_IfParameterDiffersByAdvanceWidthProperty()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue = new HorizontalMetricRecord(constrParam0, constrParam1);
            ushort constrParam2;
            do
            {
                constrParam2 = _rnd.NextUShort();
            } while (constrParam2 == testValue.AdvanceWidth);
            HorizontalMetricRecord testParam = new HorizontalMetricRecord(constrParam2, testValue.LeftSideBearing);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_EqualsMethodWithHorizontalMetricRecordParameter_ReturnsFalse_IfParameterDiffersByLeftSideBearingProperty()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue = new HorizontalMetricRecord(constrParam0, constrParam1);
            short constrParam2;
            do
            {
                constrParam2 = _rnd.NextShort();
            } while (constrParam2 == testValue.LeftSideBearing);
            HorizontalMetricRecord testParam = new HorizontalMetricRecord(testValue.AdvanceWidth, constrParam2);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsThis()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue = new HorizontalMetricRecord(constrParam0, constrParam1);

            bool testOutput = testValue.Equals((object)testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue = new HorizontalMetricRecord(constrParam0, constrParam1);
            HorizontalMetricRecord testParam = new HorizontalMetricRecord(testValue.AdvanceWidth, testValue.LeftSideBearing);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByAdvanceWidthProperty()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue = new HorizontalMetricRecord(constrParam0, constrParam1);
            ushort constrParam2;
            do
            {
                constrParam2 = _rnd.NextUShort();
            } while (constrParam2 == testValue.AdvanceWidth);
            HorizontalMetricRecord testParam = new HorizontalMetricRecord(constrParam2, testValue.LeftSideBearing);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByLeftSideBearingProperty()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue = new HorizontalMetricRecord(constrParam0, constrParam1);
            short constrParam2;
            do
            {
                constrParam2 = _rnd.NextShort();
            } while (constrParam2 == testValue.LeftSideBearing);
            HorizontalMetricRecord testParam = new HorizontalMetricRecord(testValue.AdvanceWidth, constrParam2);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue = new HorizontalMetricRecord(constrParam0, constrParam1);
            string testParam = _rnd.NextString(_rnd.Next(50));

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceWithSameValue()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue0 = new HorizontalMetricRecord(constrParam0, constrParam1);
            HorizontalMetricRecord testValue1 = new HorizontalMetricRecord(constrParam0, constrParam1);

            int testOutput0 = testValue0.GetHashCode();
            int testOutput1 = testValue1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_EqualityOperator_ReturnsTrue_IfBothOperandsAreSameValue()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue = new HorizontalMetricRecord(constrParam0, constrParam1);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue == testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_EqualityOperator_ReturnsTrue_IfOperandsAreConstructedFromSameData()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue0 = new HorizontalMetricRecord(constrParam0, constrParam1);
            HorizontalMetricRecord testValue1 = new HorizontalMetricRecord(testValue0.AdvanceWidth, testValue0.LeftSideBearing);

            bool testOutput = testValue0 == testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByAdvanceWidthProperty()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue0 = new HorizontalMetricRecord(constrParam0, constrParam1);
            ushort constrParam2;
            do
            {
                constrParam2 = _rnd.NextUShort();
            } while (constrParam2 == testValue0.AdvanceWidth);
            HorizontalMetricRecord testValue1 = new HorizontalMetricRecord(constrParam2, testValue0.LeftSideBearing);

            bool testOutput = testValue0 == testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByLeftSideBearingProperty()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue0 = new HorizontalMetricRecord(constrParam0, constrParam1);
            short constrParam2;
            do
            {
                constrParam2 = _rnd.NextShort();
            } while (constrParam2 == testValue0.LeftSideBearing);
            HorizontalMetricRecord testValue1 = new HorizontalMetricRecord(testValue0.AdvanceWidth, constrParam2);

            bool testOutput = testValue0 == testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_InequalityOperator_ReturnsFalse_IfBothOperandsAreSameValue()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue = new HorizontalMetricRecord(constrParam0, constrParam1);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue != testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_InequalityOperator_ReturnsFalse_IfOperandsAreConstructedFromSameData()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue0 = new HorizontalMetricRecord(constrParam0, constrParam1);
            HorizontalMetricRecord testValue1 = new HorizontalMetricRecord(testValue0.AdvanceWidth, testValue0.LeftSideBearing);

            bool testOutput = testValue0 != testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByAdvanceWidthProperty()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue0 = new HorizontalMetricRecord(constrParam0, constrParam1);
            ushort constrParam2;
            do
            {
                constrParam2 = _rnd.NextUShort();
            } while (constrParam2 == testValue0.AdvanceWidth);
            HorizontalMetricRecord testValue1 = new HorizontalMetricRecord(constrParam2, testValue0.LeftSideBearing);

            bool testOutput = testValue0 != testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void HorizontalMetricRecordStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByLeftSideBearingProperty()
        {
            ushort constrParam0 = _rnd.NextUShort();
            short constrParam1 = _rnd.NextShort();
            HorizontalMetricRecord testValue0 = new HorizontalMetricRecord(constrParam0, constrParam1);
            short constrParam2;
            do
            {
                constrParam2 = _rnd.NextShort();
            } while (constrParam2 == testValue0.LeftSideBearing);
            HorizontalMetricRecord testValue1 = new HorizontalMetricRecord(testValue0.AdvanceWidth, constrParam2);

            bool testOutput = testValue0 != testValue1;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
