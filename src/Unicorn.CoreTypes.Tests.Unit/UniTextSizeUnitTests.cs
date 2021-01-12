using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.CoreTypes.Tests.Utility.Extensions;

namespace Unicorn.CoreTypes.Tests.Unit
{
    [TestClass]
    public class UniTextSizeUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static UniTextSize GetTestValue()
        {
            return _rnd.NextUniTextSize();
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void UniTextSizeClass_ParameterlessConstructor_SetsWidthPropertyToZero()
        {
            UniTextSize testOutput = new UniTextSize();

            Assert.AreEqual(0d, testOutput.Width);
        }

        [TestMethod]
        public void UniTextSizeClass_ParameterlessConstructor_SetsTotalHeightPropertyToZero()
        {
            UniTextSize testOutput = new UniTextSize();

            Assert.AreEqual(0d, testOutput.LineHeight);
        }

        [TestMethod]
        public void UniTextSizeClass_ParameterlessConstructor_SetsHeightAboveBaselinePropertyToZero()
        {
            UniTextSize testOutput = new UniTextSize();

            Assert.AreEqual(0d, testOutput.HeightAboveBaseline);
        }

        [TestMethod]
        public void UniTextSizeClass_ParameterlessConstructor_SetsHeightBelowBaselinePropertyToZero()
        {
            UniTextSize testOutput = new UniTextSize();

            Assert.AreEqual(0d, testOutput.HeightBelowBaseline);
        }

        [TestMethod]
        public void UniTextSizeClass_ParameterlessConstructor_SetsAscenderHeightPropertyToZero()
        {
            UniTextSize testOutput = new UniTextSize();

            Assert.AreEqual(0d, testOutput.AscenderHeight);
        }

        [TestMethod]
        public void UniTextSizeClass_ParameterlessConstructor_SetsDescenderHeightPropertyToZero()
        {
            UniTextSize testOutput = new UniTextSize();

            Assert.AreEqual(0d, testOutput.DescenderHeight);
        }

        [TestMethod]
        public void UniTextSizeClass_ConstructorWithFiveDoubleParameters_SetsWidthPropertyToValueOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;

            UniTextSize testOutput = new UniTextSize(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam0, testOutput.Width);
        }

        [TestMethod]
        public void UniTextSizeClass_ConstructorWithFiveDoubleParameters_SetsTotalHeightPropertyToValueOfSecondParameter()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;

            UniTextSize testOutput = new UniTextSize(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam1, testOutput.LineHeight);
        }

        [TestMethod]
        public void UniTextSizeClass_ConstructorWithFiveDoubleParameters_SetsHeightAboveBaselinePropertyToValueOfThirdParameter()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;

            UniTextSize testOutput = new UniTextSize(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam2, testOutput.HeightAboveBaseline);
        }

        [TestMethod]
        public void UniTextSizeClass_ConstructorWithFiveDoubleParameters_SetsHeightBelowPropertyToDifferenceBetweenSecondAndThirdParameters()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;

            UniTextSize testOutput = new UniTextSize(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam1 - testParam2, testOutput.HeightBelowBaseline);
        }

        [TestMethod]
        public void UniTextSizeClass_ConstructorWithFiveDoubleParameters_SetsAscenderHeightPropertyToValueOfFourthParameter()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;

            UniTextSize testOutput = new UniTextSize(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam3, testOutput.AscenderHeight);
        }

        [TestMethod]
        public void UniTextSizeClass_ConstructorWithFiveDoubleParameters_SetsDescenderHeightPropertyToValueOfFifthParameter()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;

            UniTextSize testOutput = new UniTextSize(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam4, testOutput.DescenderHeight);
        }

        [TestMethod]
        public void UniTextSizeClass_MaxHeightAboveBaselineProperty_EqualsAscenderHeightProperty_IfAscenderHeightPropertyIsGreaterThanHeightAboveBaselineProperty()
        {
            double constrParam0 = _rnd.NextDouble() * 500;
            double constrParam1 = _rnd.NextDouble() * 500;
            double constrParam2 = _rnd.NextDouble() * 500;
            double constrParam3 = constrParam2 + _rnd.NextDouble() * 500;
            double constrParam4 = _rnd.NextDouble() * 500;  
            UniTextSize testObject = new UniTextSize(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);

            Assert.AreEqual(testObject.AscenderHeight, testObject.MaxHeightAboveBaseline);
        }

        [TestMethod]
        public void UniTextSizeClass_MaxHeightAboveBaselineProperty_EqualsHeightAboveBaselineProperty_IfAscenderHeightPropertyIsLessThanHeightAboveBaselineProperty()
        {
            double constrParam0 = _rnd.NextDouble() * 500;
            double constrParam1 = _rnd.NextDouble() * 500;
            double constrParam3 = _rnd.NextDouble() * 500;
            double constrParam2 = constrParam3 + _rnd.NextDouble() * 500;
            double constrParam4 = _rnd.NextDouble() * 500;
            UniTextSize testObject = new UniTextSize(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);

            Assert.AreEqual(testObject.HeightAboveBaseline, testObject.MaxHeightAboveBaseline);
        }

        [TestMethod]
        public void UniTextSizeClass_MaxHeightAboveBaselineProperty_EqualsAscenderHeightProperty_IfAscenderHeightPropertyIsEqualToHeightAboveBaselineProperty()
        {
            double constrParam0 = _rnd.NextDouble() * 500;
            double constrParam1 = _rnd.NextDouble() * 500;
            double constrParam2 = _rnd.NextDouble() * 500;
            double constrParam3 = constrParam2;
            double constrParam4 = _rnd.NextDouble() * 500;
            UniTextSize testObject = new UniTextSize(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);

            Assert.AreEqual(testObject.AscenderHeight, testObject.MaxHeightAboveBaseline);
        }

        [TestMethod]
        public void UniTextSizeClass_MaxHeightBelowBaselineProperty_EqualsDescenderHeightProperty_IfDescenderHeightPropertyIsGreaterThanHeightBelowBaselineProperty()
        {
            double constrParam0 = _rnd.NextDouble() * 500;
            double constrParam2 = _rnd.NextDouble() * 500;
            double constrParam1 = constrParam2 + _rnd.NextDouble() * 500;
            double constrParam3 = _rnd.NextDouble() * 500;
            double constrParam4 = (constrParam1 - constrParam2) + _rnd.NextDouble() * 500;
            UniTextSize testObject = new UniTextSize(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);

            Assert.AreEqual(testObject.DescenderHeight, testObject.MaxHeightBelowBaseline);
        }

        [TestMethod]
        public void UniTextSizeClass_MaxHeightBelowBaselineProperty_EqualsHeightBelowBaselineProperty_IfDescenderHeightPropertyIsLessThanHeightBelowBaselineProperty()
        {
            double constrParam0 = _rnd.NextDouble() * 500;
            double constrParam2 = _rnd.NextDouble() * 500;
            double constrParam1 = constrParam2 + _rnd.NextDouble() * 500;
            double constrParam3 = _rnd.NextDouble() * 500;
            double constrParam4 = (constrParam1 - constrParam2) - _rnd.NextDouble() * 500;
            UniTextSize testObject = new UniTextSize(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);

            Assert.AreEqual(testObject.HeightBelowBaseline, testObject.MaxHeightBelowBaseline);
        }

        [TestMethod]
        public void UniTextSizeClass_MaxHeightBelowBaselineProperty_EqualsDescenderHeightProperty_IfDescenderHeightPropertyIsEqualToHeightBelowBaselineProperty()
        {
            double constrParam0 = _rnd.NextDouble() * 500;
            double constrParam2 = _rnd.NextDouble() * 500;
            double constrParam1 = constrParam2 + _rnd.NextDouble() * 500;
            double constrParam3 = _rnd.NextDouble() * 500;
            double constrParam4 = constrParam1 - constrParam2;
            UniTextSize testObject = new UniTextSize(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);

            Assert.AreEqual(testObject.DescenderHeight, testObject.MaxHeightBelowBaseline);
        }

        [TestMethod]
        public void UniTextSizeClass_MaxHeightProperty_EqualsMaxHeightAboveBaselinePropertyPlusMaxHeightBelowBaselineProperty()
        {
            double constrParam0 = _rnd.NextDouble() * 500;
            double constrParam1 = _rnd.NextDouble() * 500;
            double constrParam2 = _rnd.NextDouble() * 500;
            double constrParam3 = _rnd.NextDouble() * 500;
            double constrParam4 = _rnd.NextDouble() * 500;
            UniTextSize testObject = new UniTextSize(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);

            Assert.AreEqual(testObject.MaxHeightAboveBaseline + testObject.MaxHeightBelowBaseline, testObject.MaxHeight);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithUniTextSizeParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            UniTextSize testValue = GetTestValue();

            bool testOutput = testValue.Equals(testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithUniTextSizeParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            UniTextSize testValue = GetTestValue();
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, testValue.HeightAboveBaseline, testValue.AscenderHeight, 
                testValue.DescenderHeight);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithUniTextSizeParameter_ReturnsFalse_IfParameterDiffersByWidthProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.Width);
            UniTextSize testParam = new UniTextSize(constrParam, testValue.LineHeight, testValue.HeightAboveBaseline, testValue.AscenderHeight, 
                testValue.DescenderHeight);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithUniTextSizeParameter_ReturnsFalse_IfParameterDiffersByTotalHeightProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.LineHeight);
            UniTextSize testParam = new UniTextSize(testValue.Width, constrParam, testValue.HeightAboveBaseline, testValue.AscenderHeight, testValue.DescenderHeight);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithUniTextSizeParameter_ReturnsFalse_IfParameterDiffersByHeightAboveBaselineProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.HeightAboveBaseline);
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, constrParam, testValue.AscenderHeight, testValue.DescenderHeight);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithUniTextSizeParameter_ReturnsFalse_IfParameterDiffersByAscenderHeightProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.AscenderHeight);
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, testValue.HeightAboveBaseline, constrParam, testValue.DescenderHeight);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithUniTextSizeParameter_ReturnsFalse_IfParameterDiffersByDescenderHeightProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.DescenderHeight);
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, testValue.HeightAboveBaseline, testValue.AscenderHeight, constrParam);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            UniTextSize testValue = GetTestValue();

            bool testOutput = testValue.Equals((object)testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            UniTextSize testValue = GetTestValue();
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, testValue.HeightAboveBaseline, testValue.AscenderHeight,
                testValue.DescenderHeight);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByWidthProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.Width);
            UniTextSize testParam = new UniTextSize(constrParam, testValue.LineHeight, testValue.HeightAboveBaseline, testValue.AscenderHeight,
                testValue.DescenderHeight);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByTotalHeightProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.LineHeight);
            UniTextSize testParam = new UniTextSize(testValue.Width, constrParam, testValue.HeightAboveBaseline, testValue.AscenderHeight, testValue.DescenderHeight);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByHeightAboveBaselineProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.HeightAboveBaseline);
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, constrParam, testValue.AscenderHeight, testValue.DescenderHeight);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByAscenderHeightProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.AscenderHeight);
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, testValue.HeightAboveBaseline, constrParam, testValue.DescenderHeight);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByDescenderHeightProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.DescenderHeight);
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, testValue.HeightAboveBaseline, testValue.AscenderHeight, constrParam);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            UniTextSize testValue = GetTestValue();
            string testParam = _rnd.NextString(_rnd.Next(20));

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceOnSameValue()
        {
            UniTextSize testValue0 = GetTestValue();
            UniTextSize testValue1 = new UniTextSize(testValue0.Width, testValue0.LineHeight, testValue0.HeightAboveBaseline, testValue0.AscenderHeight,
                testValue0.DescenderHeight);

            int testOutput0 = testValue0.GetHashCode();
            int testOutput1 = testValue1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualityOperator_ReturnsTrue_IfOperandsAreSameValue()
        {
            UniTextSize testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue == testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualityOperator_ReturnsTrue_IfOperandsAreConstructedFromSameData()
        {
            UniTextSize testValue = GetTestValue();
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, testValue.HeightAboveBaseline, testValue.AscenderHeight,
                testValue.DescenderHeight);

            bool testOutput = testValue == testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualityOperator_ReturnsFalse_IfOperandsDifferByWidthProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.Width);
            UniTextSize testParam = new UniTextSize(constrParam, testValue.LineHeight, testValue.HeightAboveBaseline, testValue.AscenderHeight,
                testValue.DescenderHeight);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualityOperator_ReturnsFalse_IfOperandsDifferByTotalHeightProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.LineHeight);
            UniTextSize testParam = new UniTextSize(testValue.Width, constrParam, testValue.HeightAboveBaseline, testValue.AscenderHeight, testValue.DescenderHeight);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualityOperator_ReturnsFalse_IfOperandsDifferByHeightAboveBaselineProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.HeightAboveBaseline);
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, constrParam, testValue.AscenderHeight, testValue.DescenderHeight);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualityOperator_ReturnsFalse_IfOperandsDifferByAscenderHeightProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.AscenderHeight);
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, testValue.HeightAboveBaseline, constrParam, testValue.DescenderHeight);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_EqualityOperator_ReturnsFalse_IfOperandsDifferByDescenderHeightProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.DescenderHeight);
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, testValue.HeightAboveBaseline, testValue.AscenderHeight, constrParam);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_InequalityOperator_ReturnsFalse_IfOperandsAreSameValue()
        {
            UniTextSize testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue != testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_InequalityOperator_ReturnsFalse_IfOperandsAreConstructedFromSameData()
        {
            UniTextSize testValue = GetTestValue();
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, testValue.HeightAboveBaseline, testValue.AscenderHeight,
                testValue.DescenderHeight);

            bool testOutput = testValue != testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_InequalityOperator_ReturnsTrue_IfOperandsDifferByWidthProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.Width);
            UniTextSize testParam = new UniTextSize(constrParam, testValue.LineHeight, testValue.HeightAboveBaseline, testValue.AscenderHeight,
                testValue.DescenderHeight);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_InequalityOperator_ReturnsTrue_IfOperandsDifferByTotalHeightProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.LineHeight);
            UniTextSize testParam = new UniTextSize(testValue.Width, constrParam, testValue.HeightAboveBaseline, testValue.AscenderHeight, testValue.DescenderHeight);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_InequalityOperator_ReturnsTrue_IfOperandsDifferByHeightAboveBaselineProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.HeightAboveBaseline);
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, constrParam, testValue.AscenderHeight, testValue.DescenderHeight);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_InequalityOperator_ReturnsTrue_IfOperandsDifferByAscenderHeightProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.AscenderHeight);
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, testValue.HeightAboveBaseline, constrParam, testValue.DescenderHeight);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniTextSizeClass_InequalityOperator_ReturnsTrue_IfOperandsDifferByDescenderHeightProperty()
        {
            UniTextSize testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 50;
            } while (constrParam == testValue.DescenderHeight);
            UniTextSize testParam = new UniTextSize(testValue.Width, testValue.LineHeight, testValue.HeightAboveBaseline, testValue.AscenderHeight, constrParam);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
