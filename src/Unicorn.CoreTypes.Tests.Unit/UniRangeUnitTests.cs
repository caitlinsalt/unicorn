using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;

namespace Unicorn.CoreTypes.Tests.Unit
{
    [TestClass]
    public class UniRangeUnitTests
    {
        private static Random _rnd = new Random();

#pragma warning disable CA5394 // Do not use insecure randomness

        private static UniRange GetTestValue() => new UniRange(_rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000);

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void UniRangeStruct_ParameterlessConstructor_SetsStartPropertyToZero()
        {
            UniRange testValue = new UniRange();

            Assert.AreEqual(0d, testValue.Start);
        }

        [TestMethod]
        public void UniRangeStruct_ParameterlessConstructor_SetsEndPropertyToZero()
        {
            UniRange testValue = new UniRange();

            Assert.AreEqual(0d, testValue.End);
        }


        [TestMethod]
        public void UniRangeStruct_ConstructorWithTwoDoubleParameters_SetsStartPropertyToValueOfFirstParameter()
        {
            double testValue = _rnd.NextDouble();
            UniRange testObject = new UniRange(testValue, _rnd.NextDouble());

            Assert.AreEqual(testValue, testObject.Start);
        }

        [TestMethod]
        public void UniRangeStruct_ConstructorWithTwoDoubleParameters_SetsEndPropertyToValueOfSecondParameter()
        {
            double testValue = _rnd.NextDouble();
            UniRange testObject = new UniRange(_rnd.NextDouble(), testValue);

            Assert.AreEqual(testValue, testObject.End);
        }

        [TestMethod]
        public void UniRangeStruct_SizeProperty_ReturnsCorrectValue()
        {
            double testValue = _rnd.NextDouble();
            double startValue = _rnd.NextDouble();
            UniRange testObject = new UniRange(startValue, startValue + testValue);

            double testOutput = testObject.Size;

            Assert.AreEqual(testValue, testOutput, 0.00000001);
        }

        [TestMethod]
        public void UniRangeStruct_EqualsMethodWithUniRangeParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            UniRange testValue = GetTestValue();

            bool testOutput = testValue.Equals(testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_EqualsMethodWithUniRangeParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            UniRange testValue = GetTestValue();
            UniRange testParam = new UniRange(testValue.Start, testValue.End);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_EqualsMethodWithUniRangeParameter_ReturnsFalse_IfParameterDiffersByStartProperty()
        {
            UniRange testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.Start);
            UniRange testParam = new UniRange(constrParam, testValue.End);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_EqualsMethodWithUniRangeParameter_ReturnsFalse_IfParameterDiffersByEndProperty()
        {
            UniRange testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.End);
            UniRange testParam = new UniRange(testValue.Start, constrParam);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            UniRange testValue = GetTestValue();

            bool testOutput = testValue.Equals((object)testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            UniRange testValue = GetTestValue();
            UniRange testParam = new UniRange(testValue.Start, testValue.End);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByStartProperty()
        {
            UniRange testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.Start);
            UniRange testParam = new UniRange(constrParam, testValue.End);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByEndProperty()
        {
            UniRange testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.End);
            UniRange testParam = new UniRange(testValue.Start, constrParam);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            UniRange testValue = GetTestValue();
            string testParam = _rnd.NextString(_rnd.Next(20));

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceOnSameValue()
        {
            UniRange testValue0 = GetTestValue();
            UniRange testValue1 = new UniRange(testValue0.Start, testValue0.End);

            int testOutput0 = testValue0.GetHashCode();
            int testOutput1 = testValue1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void UniRangeStruct_EqualityOperator_ReturnsTrue_IfOperandsAreSameValue()
        {
            UniRange testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue == testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_EqualityOperator_ReturnsTrue_IfOperandsAreConstructedFromSameData()
        {
            UniRange testValue = GetTestValue();
            UniRange testParam = new UniRange(testValue.Start, testValue.End);

            bool testOutput = testValue == testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByStartProperty()
        {
            UniRange testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.Start);
            UniRange testParam = new UniRange(constrParam, testValue.End);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByEndProperty()
        {
            UniRange testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.End);
            UniRange testParam = new UniRange(testValue.Start, constrParam);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_InequalityOperator_ReturnsFalse_IfOperandsAreSameValue()
        {
            UniRange testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue != testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_InequalityOperator_ReturnsFalse_IfOperandsAreConstructedFromSameData()
        {
            UniRange testValue = GetTestValue();
            UniRange testParam = new UniRange(testValue.Start, testValue.End);

            bool testOutput = testValue != testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByStartProperty()
        {
            UniRange testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.Start);
            UniRange testParam = new UniRange(constrParam, testValue.End);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRangeStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByEndProperty()
        {
            UniRange testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.End);
            UniRange testParam = new UniRange(testValue.Start, constrParam);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
