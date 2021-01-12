using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.CoreTypes.Tests.Utility.Extensions;

namespace Unicorn.CoreTypes.Tests.Unit
{
    [TestClass]
    public class UniMatrixUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static UniMatrix GetTestValue() => _rnd.NextUniMatrix();

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void UniMatrixStruct_ParameterlessConstructor_SetsR0C0PropertyToZero()
        {
            UniMatrix testOutput = new UniMatrix();

            Assert.AreEqual(0d, testOutput.R0C0);
        }

        [TestMethod]
        public void UniMatrixStruct_ParameterlessConstructor_SetsR0C1PropertyToZero()
        {
            UniMatrix testOutput = new UniMatrix();

            Assert.AreEqual(0d, testOutput.R0C1);
        }

        [TestMethod]
        public void UniMatrixStruct_ParameterlessConstructor_SetsR1C0PropertyToZero()
        {
            UniMatrix testOutput = new UniMatrix();

            Assert.AreEqual(0d, testOutput.R1C0);
        }

        [TestMethod]
        public void UniMatrixStruct_ParameterlessConstructor_SetsR1C1PropertyToZero()
        {
            UniMatrix testOutput = new UniMatrix();

            Assert.AreEqual(0d, testOutput.R1C1);
        }

        [TestMethod]
        public void UniMatrixStruct_ParameterlessConstructor_SetsR2C0PropertyToZero()
        {
            UniMatrix testOutput = new UniMatrix();

            Assert.AreEqual(0d, testOutput.R2C0);
        }

        [TestMethod]
        public void UniMatrixStruct_ParameterlessConstructor_SetsR2C1PropertyToZero()
        {
            UniMatrix testOutput = new UniMatrix();

            Assert.AreEqual(0d, testOutput.R2C1);
        }

        [TestMethod]
        public void UniMatrixStruct_ConstructorWithSixDoubleParameters_SetsR0C0PropertyToValueOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            double testParam4 = _rnd.NextDouble() * 1000;
            double testParam5 = _rnd.NextDouble() * 1000;

            UniMatrix testOutput = new UniMatrix(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam0, testOutput.R0C0);
        }

        [TestMethod]
        public void UniMatrixStruct_ConstructorWithSixDoubleParameters_SetsR0C1PropertyToValueOfSecondParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            double testParam4 = _rnd.NextDouble() * 1000;
            double testParam5 = _rnd.NextDouble() * 1000;

            UniMatrix testOutput = new UniMatrix(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam1, testOutput.R0C1);
        }

        [TestMethod]
        public void UniMatrixStruct_ConstructorWithSixDoubleParameters_SetsR1C0PropertyToValueOfThirdParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            double testParam4 = _rnd.NextDouble() * 1000;
            double testParam5 = _rnd.NextDouble() * 1000;

            UniMatrix testOutput = new UniMatrix(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam2, testOutput.R1C0);
        }

        [TestMethod]
        public void UniMatrixStruct_ConstructorWithSixDoubleParameters_SetsR1C1PropertyToValueOfFourthParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            double testParam4 = _rnd.NextDouble() * 1000;
            double testParam5 = _rnd.NextDouble() * 1000;

            UniMatrix testOutput = new UniMatrix(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam3, testOutput.R1C1);
        }

        [TestMethod]
        public void UniMatrixStruct_ConstructorWithSixDoubleParameters_SetsR2C0PropertyToValueOfFifthParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            double testParam4 = _rnd.NextDouble() * 1000;
            double testParam5 = _rnd.NextDouble() * 1000;

            UniMatrix testOutput = new UniMatrix(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam4, testOutput.R2C0);
        }

        [TestMethod]
        public void UniMatrixStruct_ConstructorWithSixDoubleParameters_SetsR2C1PropertyToValueOfSixthParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            double testParam4 = _rnd.NextDouble() * 1000;
            double testParam5 = _rnd.NextDouble() * 1000;

            UniMatrix testOutput = new UniMatrix(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam5, testOutput.R2C1);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithUniMatrixParameter_ReturnsTrue_IfParameterIsSameValueAsThis()
        {
            UniMatrix testValue = GetTestValue();

            bool testOutput = testValue.Equals(testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithUniMatrixParameter_ReturnsTrue_IfParameterIsConstructedFromSameDataAsValue()
        {
            UniMatrix testValue = GetTestValue();
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithUniMatrixParameter_ReturnsFalse_IfParameterDiffersByR0C0Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R0C0);
            UniMatrix testParam = new UniMatrix(constrParam, testValue.R0C1, testValue.R1C0, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithUniMatrixParameter_ReturnsFalse_IfParameterDiffersByR0C1Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R0C1);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, constrParam, testValue.R1C0, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithUniMatrixParameter_ReturnsFalse_IfParameterDiffersByR1C0Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R1C0);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, constrParam, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithUniMatrixParameter_ReturnsFalse_IfParameterDiffersByR1C1Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R1C1);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, constrParam, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithUniMatrixParameter_ReturnsFalse_IfParameterDiffersByR2C0Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R2C0);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, testValue.R1C1, constrParam, testValue.R2C1);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithUniMatrixParameter_ReturnsFalse_IfParameterDiffersByR2C1Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R2C1);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, testValue.R1C1, testValue.R2C0, constrParam);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsSameValueAsThis()
        {
            UniMatrix testValue = GetTestValue();

            bool testOutput = testValue.Equals((object)testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameDataAsValue()
        {
            UniMatrix testValue = GetTestValue();
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByR0C0Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R0C0);
            UniMatrix testParam = new UniMatrix(constrParam, testValue.R0C1, testValue.R1C0, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByR0C1Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R0C1);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, constrParam, testValue.R1C0, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByR1C0Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R1C0);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, constrParam, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByR1C1Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R1C1);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, constrParam, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByR2C0Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R2C0);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, testValue.R1C1, constrParam, testValue.R2C1);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByR2C1Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R2C1);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, testValue.R1C1, testValue.R2C0, constrParam);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            UniMatrix testValue = GetTestValue();
            string testParam = _rnd.NextString(_rnd.Next(20));

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceOnSameValue()
        {
            UniMatrix testValue0 = GetTestValue();
            UniMatrix testValue1 = new UniMatrix(testValue0.R0C0, testValue0.R0C1, testValue0.R1C0, testValue0.R1C1, testValue0.R2C0, testValue0.R2C1);

            int testOutput0 = testValue0.GetHashCode();
            int testOutput1 = testValue1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualsOperator_ReturnsTrue_IfOperandsAreSameValue()
        {
            UniMatrix testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue == testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualityOperator_ReturnsTrue_IfOperandsAreConstructedFromSameData()
        {
            UniMatrix testValue = GetTestValue();
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue == testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByR0C0Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R0C0);
            UniMatrix testParam = new UniMatrix(constrParam, testValue.R0C1, testValue.R1C0, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByR0C1Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R0C1);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, constrParam, testValue.R1C0, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByR1C0Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R1C0);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, constrParam, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByR1C1Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R1C1);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, constrParam, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByR2C0Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R2C0);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, testValue.R1C1, constrParam, testValue.R2C1);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByR2C1Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R2C1);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, testValue.R1C1, testValue.R2C0, constrParam);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_InequalsOperator_ReturnsFalse_IfOperandsAreSameValue()
        {
            UniMatrix testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue != testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_InequalityOperator_ReturnsFalse_IfOperandsAreConstructedFromSameData()
        {
            UniMatrix testValue = GetTestValue();
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue != testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByR0C0Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R0C0);
            UniMatrix testParam = new UniMatrix(constrParam, testValue.R0C1, testValue.R1C0, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByR0C1Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R0C1);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, constrParam, testValue.R1C0, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByR1C0Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R1C0);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, constrParam, testValue.R1C1, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_INequalityOperator_ReturnsTrue_IfOperandsDifferByR1C1Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R1C1);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, constrParam, testValue.R2C0, testValue.R2C1);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByR2C0Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R2C0);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, testValue.R1C1, constrParam, testValue.R2C1);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByR2C1Property()
        {
            UniMatrix testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 100;
            } while (constrParam == testValue.R2C1);
            UniMatrix testParam = new UniMatrix(testValue.R0C0, testValue.R0C1, testValue.R1C0, testValue.R1C1, testValue.R2C0, constrParam);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplicationOperatorWithTwoUniMatrixOperands_ReturnsValueWithCorrectR0C0Property()
        {
            UniMatrix testValue0 = GetTestValue();
            UniMatrix testValue1 = GetTestValue();

            UniMatrix testOutput = testValue0 * testValue1;

            double expectedValue = testValue0.R0C0 * testValue1.R0C0 + testValue0.R0C1 * testValue1.R1C0;
            Assert.AreEqual(expectedValue, testOutput.R0C0);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplicationOperatorWithTwoUniMatrixOperands_ReturnsValueWithCorrectR0C1Property()
        {
            UniMatrix testValue0 = GetTestValue();
            UniMatrix testValue1 = GetTestValue();

            UniMatrix testOutput = testValue0 * testValue1;

            double expectedValue = testValue0.R0C0 * testValue1.R0C1 + testValue0.R0C1 * testValue1.R1C1;
            Assert.AreEqual(expectedValue, testOutput.R0C1);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplicationOperatorWithTwoUniMatrixOperands_ReturnsValueWithCorrectR1C0Property()
        {
            UniMatrix testValue0 = GetTestValue();
            UniMatrix testValue1 = GetTestValue();

            UniMatrix testOutput = testValue0 * testValue1;

            double expectedValue = testValue0.R1C0 * testValue1.R0C0 + testValue0.R1C1 * testValue1.R1C0;
            Assert.AreEqual(expectedValue, testOutput.R1C0);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplicationOperatorWithTwoUniMatrixOperands_ReturnsValueWithCorrectR1C1Property()
        {
            UniMatrix testValue0 = GetTestValue();
            UniMatrix testValue1 = GetTestValue();

            UniMatrix testOutput = testValue0 * testValue1;

            double expectedValue = testValue0.R1C0 * testValue1.R0C1 + testValue0.R1C1 * testValue1.R1C1;
            Assert.AreEqual(expectedValue, testOutput.R1C1);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplicationOperatorWithTwoUniMatrixOperands_ReturnsValueWithCorrectR2C0Property()
        {
            UniMatrix testValue0 = GetTestValue();
            UniMatrix testValue1 = GetTestValue();

            UniMatrix testOutput = testValue0 * testValue1;

            double expectedValue = testValue0.R2C0 * testValue1.R0C0 + testValue0.R2C1 * testValue1.R1C0 + testValue1.R2C0;
            Assert.AreEqual(expectedValue, testOutput.R2C0);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplicationOperatorWithTwoUniMatrixOperands_ReturnsValueWithCorrectR2C1Property()
        {
            UniMatrix testValue0 = GetTestValue();
            UniMatrix testValue1 = GetTestValue();

            UniMatrix testOutput = testValue0 * testValue1;

            double expectedValue = testValue0.R2C0 * testValue1.R0C1 + testValue0.R2C1 * testValue1.R1C1 + testValue1.R2C1;
            Assert.AreEqual(expectedValue, testOutput.R2C1);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplyMethodWithTwoUniMatrixParameters_ReturnsValueWithCorrectR0C0Property()
        {
            UniMatrix testValue0 = GetTestValue();
            UniMatrix testValue1 = GetTestValue();

            UniMatrix testOutput = UniMatrix.Multiply(testValue0, testValue1);

            double expectedValue = testValue0.R0C0 * testValue1.R0C0 + testValue0.R0C1 * testValue1.R1C0;
            Assert.AreEqual(expectedValue, testOutput.R0C0);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplyMethodWithTwoUniMatrixParameters_ReturnsValueWithCorrectR0C1Property()
        {
            UniMatrix testValue0 = GetTestValue();
            UniMatrix testValue1 = GetTestValue();

            UniMatrix testOutput = UniMatrix.Multiply(testValue0, testValue1);

            double expectedValue = testValue0.R0C0 * testValue1.R0C1 + testValue0.R0C1 * testValue1.R1C1;
            Assert.AreEqual(expectedValue, testOutput.R0C1);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplyMethodWithTwoUniMatrixParameters_ReturnsValueWithCorrectR1C0Property()
        {
            UniMatrix testValue0 = GetTestValue();
            UniMatrix testValue1 = GetTestValue();

            UniMatrix testOutput = UniMatrix.Multiply(testValue0, testValue1);

            double expectedValue = testValue0.R1C0 * testValue1.R0C0 + testValue0.R1C1 * testValue1.R1C0;
            Assert.AreEqual(expectedValue, testOutput.R1C0);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplyMethodWithTwoUniMatrixParameters_ReturnsValueWithCorrectR1C1Property()
        {
            UniMatrix testValue0 = GetTestValue();
            UniMatrix testValue1 = GetTestValue();

            UniMatrix testOutput = UniMatrix.Multiply(testValue0, testValue1);

            double expectedValue = testValue0.R1C0 * testValue1.R0C1 + testValue0.R1C1 * testValue1.R1C1;
            Assert.AreEqual(expectedValue, testOutput.R1C1);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplyMethodWithTwoUniMatrixParameters_ReturnsValueWithCorrectR2C0Property()
        {
            UniMatrix testValue0 = GetTestValue();
            UniMatrix testValue1 = GetTestValue();

            UniMatrix testOutput = UniMatrix.Multiply(testValue0, testValue1);

            double expectedValue = testValue0.R2C0 * testValue1.R0C0 + testValue0.R2C1 * testValue1.R1C0 + testValue1.R2C0;
            Assert.AreEqual(expectedValue, testOutput.R2C0);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplyMethodWithTwoUniMatrixParameters_ReturnsValueWithCorrectR2C1Property()
        {
            UniMatrix testValue0 = GetTestValue();
            UniMatrix testValue1 = GetTestValue();

            UniMatrix testOutput = UniMatrix.Multiply(testValue0, testValue1);

            double expectedValue = testValue0.R2C0 * testValue1.R0C1 + testValue0.R2C1 * testValue1.R1C1 + testValue1.R2C1;
            Assert.AreEqual(expectedValue, testOutput.R2C1);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplicationOperatorWithUniPointAndUniMatrixOperands_ReturnsValueWithCorrectXProperty()
        {
            UniPoint testValue0 = _rnd.NextUniPoint();
            UniMatrix testValue1 = GetTestValue();

            UniPoint testOutput = testValue0 * testValue1;

            double expectedValue = testValue0.X * testValue1.R0C0 + testValue0.Y * testValue1.R1C0 + testValue1.R2C0;
            Assert.AreEqual(expectedValue, testOutput.X);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplicationOperatorWithUniPointAndUniMatrixOperands_ReturnsValueWithCorrectYProperty()
        {
            UniPoint testValue0 = _rnd.NextUniPoint();
            UniMatrix testValue1 = GetTestValue();

            UniPoint testOutput = testValue0 * testValue1;

            double expectedValue = testValue0.X * testValue1.R0C1 + testValue0.Y * testValue1.R1C1 + testValue1.R2C1;
            Assert.AreEqual(expectedValue, testOutput.Y);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplyMethodWithUniPointAndUniMatrixParameters_ReturnsValueWithCorrectXProperty()
        {
            UniPoint testValue0 = _rnd.NextUniPoint();
            UniMatrix testValue1 = GetTestValue();

            UniPoint testOutput = UniMatrix.Multiply(testValue0, testValue1);

            double expectedValue = testValue0.X * testValue1.R0C0 + testValue0.Y * testValue1.R1C0 + testValue1.R2C0;
            Assert.AreEqual(expectedValue, testOutput.X);
        }

        [TestMethod]
        public void UniMatrixStruct_MultiplyMethodWithUniPointAndUniMatrixParameters_ReturnsValueWithCorrectYProperty()
        {
            UniPoint testValue0 = _rnd.NextUniPoint();
            UniMatrix testValue1 = GetTestValue();

            UniPoint testOutput = UniMatrix.Multiply(testValue0, testValue1);

            double expectedValue = testValue0.X * testValue1.R0C1 + testValue0.Y * testValue1.R1C1 + testValue1.R2C1;
            Assert.AreEqual(expectedValue, testOutput.Y);
        }

        [TestMethod]
        public void UniMatrixStruct_TranslationMethod_ReturnsValueWithR0C0PropertyEqualTo1()
        {
            UniPoint testParam = _rnd.NextUniPoint();

            UniMatrix testOutput = UniMatrix.Translation(testParam);

            Assert.AreEqual(1d, testOutput.R0C0);
        }

        [TestMethod]
        public void UniMatrixStruct_TranslationMethod_ReturnsValueWithR0C1PropertyEqualTo0()
        {
            UniPoint testParam = _rnd.NextUniPoint();

            UniMatrix testOutput = UniMatrix.Translation(testParam);

            Assert.AreEqual(0d, testOutput.R0C1);
        }

        [TestMethod]
        public void UniMatrixStruct_TranslationMethod_ReturnsValueWithR1C0PropertyEqualTo0()
        {
            UniPoint testParam = _rnd.NextUniPoint();

            UniMatrix testOutput = UniMatrix.Translation(testParam);

            Assert.AreEqual(0d, testOutput.R1C0);
        }

        [TestMethod]
        public void UniMatrixStruct_TranslationMethod_ReturnsValueWithR1C1PropertyEqualTo1()
        {
            UniPoint testParam = _rnd.NextUniPoint();

            UniMatrix testOutput = UniMatrix.Translation(testParam);

            Assert.AreEqual(1d, testOutput.R1C1);
        }

        [TestMethod]
        public void UniMatrixStruct_TranslationMethod_ReturnsValueWithR2C0PropertyEqualToXPropertyOfParameter()
        {
            UniPoint testParam = _rnd.NextUniPoint();

            UniMatrix testOutput = UniMatrix.Translation(testParam);

            Assert.AreEqual(testParam.X, testOutput.R2C0);
        }

        [TestMethod]
        public void UniMatrixStruct_TranslationMethod_ReturnsValueWithR2C1PropertyEqualToYPropertyOfParameter()
        {
            UniPoint testParam = _rnd.NextUniPoint();

            UniMatrix testOutput = UniMatrix.Translation(testParam);

            Assert.AreEqual(testParam.Y, testOutput.R2C1);
        }

        [TestMethod]
        public void UniMatrixStruct_RotationMethod_ReturnsValueWithR0C0PropertyEqualToCosineOfParameter()
        {
            double testParam = _rnd.NextDouble() * 4 * Math.PI * (_rnd.NextBoolean() ? 1 : -1);

            UniMatrix testOutput = UniMatrix.Rotation(testParam);

            double expectedValue = Math.Cos(testParam);
            Assert.AreEqual(expectedValue, testOutput.R0C0);
        }

        [TestMethod]
        public void UniMatrixStruct_RotationMethod_ReturnsValueWithR0C1PropertyEqualToSineOfParameter()
        {
            double testParam = _rnd.NextDouble() * 4 * Math.PI * (_rnd.NextBoolean() ? 1 : -1);

            UniMatrix testOutput = UniMatrix.Rotation(testParam);

            double expectedValue = Math.Sin(testParam);
            Assert.AreEqual(expectedValue, testOutput.R0C1);
        }

        [TestMethod]
        public void UniMatrixStruct_RotationMethod_ReturnsValueWithR1C0PropertyEqualToNegativeSineOfParameter()
        {
            double testParam = _rnd.NextDouble() * 4 * Math.PI * (_rnd.NextBoolean() ? 1 : -1);

            UniMatrix testOutput = UniMatrix.Rotation(testParam);

            double expectedValue = -Math.Sin(testParam);
            Assert.AreEqual(expectedValue, testOutput.R1C0);
        }

        [TestMethod]
        public void UniMatrixStruct_RotationMethod_ReturnsValueWithR1C1PropertyEqualToCosineOfParameter()
        {
            double testParam = _rnd.NextDouble() * 4 * Math.PI * (_rnd.NextBoolean() ? 1 : -1);

            UniMatrix testOutput = UniMatrix.Rotation(testParam);

            double expectedValue = Math.Cos(testParam);
            Assert.AreEqual(expectedValue, testOutput.R1C1);
        }

        [TestMethod]
        public void UniMatrixStruct_RotationMethod_ReturnsValueWithR2C0PropertyEqualTo0()
        {
            double testParam = _rnd.NextDouble() * 4 * Math.PI * (_rnd.NextBoolean() ? 1 : -1);

            UniMatrix testOutput = UniMatrix.Rotation(testParam);

            Assert.AreEqual(0d, testOutput.R2C0);
        }

        [TestMethod]
        public void UniMatrixStruct_RotationMethod_ReturnsValueWithR2C1PropertyEqualTo0()
        {
            double testParam = _rnd.NextDouble() * 4 * Math.PI * (_rnd.NextBoolean() ? 1 : -1);

            UniMatrix testOutput = UniMatrix.Rotation(testParam);

            Assert.AreEqual(0d, testOutput.R2C1);
        }

        [TestMethod]
        public void UniMatrixStruct_RotationAtMethod_ReturnsValueWithR0C0PropertyEqualToCosineOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble() * 4 * Math.PI * (_rnd.NextBoolean() ? 1 : -1);
            UniPoint testParam1 = _rnd.NextUniPoint();

            UniMatrix testOutput = UniMatrix.RotationAt(testParam0, testParam1);

            double expectedValue = Math.Cos(testParam0);
            Assert.AreEqual(expectedValue, testOutput.R0C0);
        }

        [TestMethod]
        public void UniMatrixStruct_RotationAtMethod_ReturnsValueWithR0C1PropertyEqualToSineOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble() * 4 * Math.PI * (_rnd.NextBoolean() ? 1 : -1);
            UniPoint testParam1 = _rnd.NextUniPoint();

            UniMatrix testOutput = UniMatrix.RotationAt(testParam0, testParam1);

            double expectedValue = Math.Sin(testParam0);
            Assert.AreEqual(expectedValue, testOutput.R0C1);
        }

        [TestMethod]
        public void UniMatrixStruct_RotationAtMethod_ReturnsValueWithR1C0PropertyEqualToNegativeSineOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble() * 4 * Math.PI * (_rnd.NextBoolean() ? 1 : -1);
            UniPoint testParam1 = _rnd.NextUniPoint();

            UniMatrix testOutput = UniMatrix.RotationAt(testParam0, testParam1);

            double expectedValue = -Math.Sin(testParam0);
            Assert.AreEqual(expectedValue, testOutput.R1C0);
        }

        [TestMethod]
        public void UniMatrixStruct_RotationAtMethod_ReturnsValueWithR1C1PropertyEqualToCosineOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble() * 4 * Math.PI * (_rnd.NextBoolean() ? 1 : -1);
            UniPoint testParam1 = _rnd.NextUniPoint();

            UniMatrix testOutput = UniMatrix.RotationAt(testParam0, testParam1);

            double expectedValue = Math.Cos(testParam0);
            Assert.AreEqual(expectedValue, testOutput.R1C1);
        }

        [TestMethod]
        public void UniMatrixStruct_RotationAtMethod_ReturnsValueWithR2C0PropertyWithCorrectValue()
        {
            double testParam0 = _rnd.NextDouble() * 4 * Math.PI * (_rnd.NextBoolean() ? 1 : -1);
            UniPoint testParam1 = _rnd.NextUniPoint();

            UniMatrix testOutput = UniMatrix.RotationAt(testParam0, testParam1);

            double expectedValue = testParam1.X - ((testParam1.X * Math.Cos(testParam0)) - (testParam1.Y * Math.Sin(testParam0)));
            Assert.AreEqual(expectedValue, testOutput.R2C0);
        }

        [TestMethod]
        public void UniMatrixStruct_RotationAtMethod_ReturnsValueWithR2C1PropertyWithCorrectValue()
        {
            double testParam0 = _rnd.NextDouble() * 4 * Math.PI * (_rnd.NextBoolean() ? 1 : -1);
            UniPoint testParam1 = _rnd.NextUniPoint();

            UniMatrix testOutput = UniMatrix.RotationAt(testParam0, testParam1);

            double expectedValue = testParam1.Y - ((testParam1.X * Math.Sin(testParam0)) + (testParam1.Y * Math.Cos(testParam0)));
            Assert.AreEqual(expectedValue, testOutput.R2C1);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
