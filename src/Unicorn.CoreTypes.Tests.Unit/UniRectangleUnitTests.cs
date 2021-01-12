using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.CoreTypes.Tests.Utility.Extensions;

namespace Unicorn.CoreTypes.Tests.Unit
{
    [TestClass]
    public class UniRectangleUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static UniRectangle GetTestValue() => new UniRectangle(_rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextUniSize());

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void UniRectangleStruct_ParameterlessConstructor_SetsMinXPropertyToZero()
        {
            UniRectangle testValue = new UniRectangle();

            Assert.AreEqual(0d, testValue.MinX);
        }

        [TestMethod]
        public void UniRectangleStruct_ParameterlessConstructor_SetsMinYPropertyToZero()
        {
            UniRectangle testValue = new UniRectangle();

            Assert.AreEqual(0d, testValue.MinY);
        }

        [TestMethod]
        public void UniRectangleStruct_ParameterlessConstructor_SetsSizePropertyToDefaultValue()
        {
            UniRectangle testValue = new UniRectangle();

            Assert.AreEqual(default, testValue.Size);
        }

        [TestMethod]
        public void UniRectangleStruct_ParameterlessConstructor_SetsWidthPropertyToZero()
        {
            UniRectangle testValue = new UniRectangle();

            Assert.AreEqual(0d, testValue.Width);
        }

        [TestMethod]
        public void UniRectangleStruct_ParameterlessConstructor_SetsHeightPropertyToZero()
        {
            UniRectangle testValue = new UniRectangle();

            Assert.AreEqual(0d, testValue.Height);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithFourDoubleParameters_SetsMinXPropertyToValueOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam0, testOutput.MinX);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithFourDoubleParameters_SetsMinYPropertyToValueOfSecondParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam1, testOutput.MinY);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithFourDoubleParameters_SetsWidthPropertyToValueOfThirdParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam2, testOutput.Width);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithFourDoubleParameters_SetsHeightPropertyToValueOfFourthParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam3, testOutput.Height);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithFourDoubleParameters_SetsSizePropertyToValueDerivedFromThirdAndFourthParameters()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(new UniSize(testParam2, testParam3), testOutput.Size);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithFourDecimalParameters_SetsMinXPropertyToValueOfFirstParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual((double)testParam0, testOutput.MinX);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithFourDecimalParameters_SetsMinYPropertyToValueOfSecondParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual((double)testParam1, testOutput.MinY);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithFourDecimalParameters_SetsWidthPropertyToValueOfThirdParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual((double)testParam2, testOutput.Width);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithFourDecimalParameters_SetsHeightPropertyToValueOfFourthParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual((double)testParam3, testOutput.Height);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithFourDecimalParameters_SetsSizePropertyToValueDerivedFromThirdAndFourthParameters()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(new UniSize(testParam2, testParam3), testOutput.Size);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithDoubleDoubleAndUniSizeParameters_SetsMinXPropertyToValueOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            UniSize testParam2 = _rnd.NextUniSize();

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam0, testOutput.MinX);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithDoubleDoubleAndUniSizeParameters_SetsMinYPropertyToValueOfSecondParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            UniSize testParam2 = _rnd.NextUniSize();

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam1, testOutput.MinY);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithDoubleDoubleAndUniSizeParameters_SetsSizePropertyToValueOfThirdParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            UniSize testParam2 = _rnd.NextUniSize();

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam2, testOutput.Size);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithDoubleDoubleAndUniSizeParameters_SetsWidthPropertyToValueDerivedFromThirdParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            UniSize testParam2 = _rnd.NextUniSize();

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam2.Width, testOutput.Width);
        }

        [TestMethod]
        public void UniRectangleStruct_ConstructorWithDoubleDoubleAndUniSizeParameters_SetsHeightPropertyToValueDerivedFromThirdParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            UniSize testParam2 = _rnd.NextUniSize();

            UniRectangle testOutput = new UniRectangle(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam2.Height, testOutput.Height);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualsMethodWithUniRectangleParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            UniRectangle testValue = GetTestValue();

            bool testOutput = testValue.Equals(testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualsMethodWithUniRectangleParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            UniRectangle testValue = GetTestValue();
            UniRectangle testParam = new UniRectangle(testValue.MinX, testValue.MinY, testValue.Size);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualsMethodWithUniRectangleParameter_ReturnsFalse_IfParameterDiffersByLeftProperty()
        {
            UniRectangle testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.MinX);
            UniRectangle testParam = new UniRectangle(constrParam, testValue.MinY, testValue.Size);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualsMethodWithUniRectangleParameter_ReturnsFalse_IfParameterDiffersByTopProperty()
        {
            UniRectangle testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.MinY);
            UniRectangle testParam = new UniRectangle(testValue.MinX, constrParam, testValue.Size);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualsMethodWithUniRectangleParameter_ReturnsFalse_IfParameterDiffersBySizeProperty()
        {
            UniRectangle testValue = GetTestValue();
            UniSize constrParam;
            do
            {
                constrParam = _rnd.NextUniSize();
            } while (constrParam == testValue.Size);
            UniRectangle testParam = new UniRectangle(testValue.MinX, testValue.MinY, constrParam);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            UniRectangle testValue = GetTestValue();

            bool testOutput = testValue.Equals((object)testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            UniRectangle testValue = GetTestValue();
            UniRectangle testParam = new UniRectangle(testValue.MinX, testValue.MinY, testValue.Size);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByLeftProperty()
        {
            UniRectangle testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.MinX);
            UniRectangle testParam = new UniRectangle(constrParam, testValue.MinY, testValue.Size);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByTopProperty()
        {
            UniRectangle testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.MinY);
            UniRectangle testParam = new UniRectangle(testValue.MinX, constrParam, testValue.Size);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersBySizeProperty()
        {
            UniRectangle testValue = GetTestValue();
            UniSize constrParam;
            do
            {
                constrParam = _rnd.NextUniSize();
            } while (constrParam == testValue.Size);
            UniRectangle testParam = new UniRectangle(testValue.MinX, testValue.MinY, constrParam);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsAUniSizeValue()
        {
            UniRectangle testValue = GetTestValue();
            UniSize testParam = testValue.Size;

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceOnSameValue()
        {
            UniRectangle testValue0 = GetTestValue();
            UniRectangle testValue1 = new UniRectangle(testValue0.MinX, testValue0.MinY, testValue0.Size);

            int testOutput0 = testValue0.GetHashCode();
            int testOutput1 = testValue1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualityOperator_ReturnsTrue_IfOperandsAreSameValue()
        {
            UniRectangle testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue == testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualityOperator_ReturnsTrue_IfOperandsAreConstructedFromSameData()
        {
            UniRectangle testValue = GetTestValue();
            UniRectangle testParam = new UniRectangle(testValue.MinX, testValue.MinY, testValue.Size);

            bool testOutput = testValue == testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByLeftProperty()
        {
            UniRectangle testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.MinX);
            UniRectangle testParam = new UniRectangle(constrParam, testValue.MinY, testValue.Size);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByTopProperty()
        {
            UniRectangle testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.MinY);
            UniRectangle testParam = new UniRectangle(testValue.MinX, constrParam, testValue.Size);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferBySizeProperty()
        {
            UniRectangle testValue = GetTestValue();
            UniSize constrParam;
            do
            {
                constrParam = _rnd.NextUniSize();
            } while (constrParam == testValue.Size);
            UniRectangle testParam = new UniRectangle(testValue.MinX, testValue.MinY, constrParam);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_InequalityOperator_ReturnsFalse_IfOperandsAreSameValue()
        {
            UniRectangle testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue != testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_InequalityOperator_ReturnsFalse_IfOperandsAreConstructedFromSameData()
        {
            UniRectangle testValue = GetTestValue();
            UniRectangle testParam = new UniRectangle(testValue.MinX, testValue.MinY, testValue.Size);

            bool testOutput = testValue != testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByLeftProperty()
        {
            UniRectangle testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.MinX);
            UniRectangle testParam = new UniRectangle(constrParam, testValue.MinY, testValue.Size);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByTopProperty()
        {
            UniRectangle testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.MinY);
            UniRectangle testParam = new UniRectangle(testValue.MinX, constrParam, testValue.Size);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniRectangleStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferBySizeProperty()
        {
            UniRectangle testValue = GetTestValue();
            UniSize constrParam;
            do
            {
                constrParam = _rnd.NextUniSize();
            } while (constrParam == testValue.Size);
            UniRectangle testParam = new UniRectangle(testValue.MinX, testValue.MinY, constrParam);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
