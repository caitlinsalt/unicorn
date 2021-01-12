using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.CoreTypes.Tests.Utility.Extensions;

namespace Unicorn.CoreTypes.Tests.Unit
{
    [TestClass]
    public class UniSizeUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static UniSize GetUniSize() => _rnd.NextUniSize();

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void UniSizeStruct_ParameterlessConstructor_SetsWidthPropertyToZero()
        {
            UniSize testOutput = new UniSize();

            Assert.AreEqual(0d, testOutput.Width);
        }

        [TestMethod]
        public void UniSizeStruct_ParameterlessConstructor_SetsHeightPropertyToZero()
        {
            UniSize testOutput = new UniSize();

            Assert.AreEqual(0d, testOutput.Height);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void UniSizeStruct_ConstructorWithTwoDoubleParameters_SetsWidthPropertyToEqualFirstParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;

            UniSize testOutput = new UniSize(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.Width);
        }

        [TestMethod]
        public void UniSizeStruct_ConstructorWithTwoDoubleParameters_SetsHeightPropertyToEqualSecondParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;

            UniSize testOutput = new UniSize(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Height);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

        [TestMethod]
        public void UniSizeStruct_ConstructorWithTwoDecimalParameters_SetsWidthPropertyToEqualFirstParameter()
        {
            decimal testParam0 = _rnd.NextDecimal() * 1000;
            decimal testParam1 = _rnd.NextDecimal() * 1000;

            UniSize testOutput = new UniSize(testParam0, testParam1);

            Assert.AreEqual((double)testParam0, testOutput.Width);
        }

        [TestMethod]
        public void UniSizeStruct_ConstructorWithTwoDecimalParameters_SetsHeightPropertyToEqualSecondParameter()
        {
            decimal testParam0 = _rnd.NextDecimal() * 1000;
            decimal testParam1 = _rnd.NextDecimal() * 1000;

            UniSize testOutput = new UniSize(testParam0, testParam1);

            Assert.AreEqual((double)testParam1, testOutput.Height);
        }

        [TestMethod]
        public void UniSizeStruct_EqualsMethodWithUniSizeParameter_ReturnsFalse_IfParameterHasDifferentWidthAndHeightPropertiesToValue()
        {
            UniSize testObject = GetUniSize();
            UniSize testParam;
            do
            {
                testParam = GetUniSize();
            } while (testParam.Width == testObject.Width || testParam.Height == testObject.Height);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void UniSizeStruct_EqualsMethodWithUniSizeParameter_ReturnsFalse_IfParameterHasSameWidthAndDifferentHeightPropertiesToValue()
        {
            UniSize testObject = GetUniSize();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testObject.Height);
            UniSize testParam = new UniSize(testObject.Width, constrParam);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniSizeStruct_EqualsMethodWithUniSizeParameter_ReturnsFalse_IfParameterHasDifferentWidthAndSameHeightPropertiesToValue()
        {
            UniSize testObject = GetUniSize();
            double constrParam;
            UniSize testParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testObject.Width);
            testParam = new UniSize(constrParam, testObject.Height);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

        [TestMethod]
        public void UniSizeStruct_EqualsMethodWithUniSizeParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            UniSize testObject = GetUniSize();
            UniSize testParam = testObject;

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniSizeStruct_EqualsMethodWithUniSizeParameter_ReturnsTrue_IfParameterIsDifferentValueWithSameWidthAndSameHeightProperties()
        {
            UniSize testObject = GetUniSize();
            UniSize testParam = new UniSize(testObject.Width, testObject.Height);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

#pragma warning disable CA1508 // Avoid dead conditional code

        [TestMethod]
        public void UniSizeStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsNull()
        {
            UniSize testObject = GetUniSize();
            object testParam = null;

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA1508 // Avoid dead conditional code

        [TestMethod]
        public void UniSizeStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsUniSizeValueWithDifferentWidthAndHeightPropertiesToValue()
        {
            UniSize testObject = GetUniSize();
            UniSize testParam;
            do
            {
                testParam = GetUniSize();
            } while (testParam.Width == testObject.Width || testParam.Height == testObject.Height);
            object testParam0 = testParam;

            bool testOutput = testObject.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void UniSizeStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsUniSizeValueWithSameWidthAndDifferentHeightPropertiesToValue()
        {
            UniSize testObject = GetUniSize();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testObject.Height);
            UniSize testParam = new UniSize(testObject.Width, constrParam);
            object testParam0 = testParam;

            bool testOutput = testObject.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniSizeStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsUniSizeValueWithDifferentWidthAndSameHeightPropertiesToValue()
        {
            UniSize testObject = GetUniSize();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testObject.Width);
            UniSize testParam = new UniSize(constrParam, testObject.Height);
            object testParam0 = testParam;

            bool testOutput = testObject.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

        [TestMethod]
        public void UniSizeStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            UniSize testObject = GetUniSize();
            object testParam = testObject;

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniSizeStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsDifferentUniSizeValueWithSameWidthAndSameHeightProperties()
        {
            UniSize testObject = GetUniSize();
            object testParam = new UniSize(testObject.Width, testObject.Height);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void UniSizeStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsNotAUniSizeValue()
        {
            UniSize testObject = GetUniSize();
            object testParam = _rnd.NextString(_rnd.Next(50));

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

        [TestMethod]
        public void UniSizeStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwice()
        {
            UniSize testObject = GetUniSize();

            int testOutput0 = testObject.GetHashCode();
            int testOutput1 = testObject.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void UniSizeStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledOnTwoValuesWithSameWidthAndHeightProperties()
        {
            UniSize testObject0 = GetUniSize();
            UniSize testObject1 = new UniSize(testObject0.Width, testObject0.Height);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void UniSizeSutrct_GetHashCodeMethod_ReturnsDifferentValue_IfCalledOnTwoValuesWithDifferentWidthAndHeightProperties()
        {
            UniSize testObject0 = GetUniSize();
            UniSize testObject1 = new UniSize(testObject0.Width + 100, testObject0.Height + 100);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void UniSizeStruct_GetHashCodeMethod_ReturnsDifferentValue_IfCalledOnTwoValuesWithDifferentWidthAndSameHeightProperties()
        {
            UniSize testObject0 = GetUniSize();
            UniSize testObject1 = new UniSize(testObject0.Width + 100, testObject0.Height);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void UniSizeStruct_GetHashCodeMethod_ReturnsDifferentValue_IfCalledOnTwoValuesWithSameWidthAndDifferentHeightProperties()
        {
            UniSize testObject0 = GetUniSize();
            UniSize testObject1 = new UniSize(testObject0.Width, testObject0.Height + 100);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void UniSizeStruct_AdditionOperator_ReturnsValueWithWidthPropertyEqualToSumOfWidthPropertiesOfOperands()
        {
            UniSize testOp0 = GetUniSize();
            UniSize testOp1 = GetUniSize();

            UniSize testOutput = testOp0 + testOp1;

            Assert.AreEqual(testOp0.Width + testOp1.Width, testOutput.Width);
        }

        [TestMethod]
        public void UniSizeStruct_AdditionOperator_ReturnsValueWithHeightPropertyEqualToSumOfHeightPropertiesOfOperands()
        {
            UniSize testOp0 = GetUniSize();
            UniSize testOp1 = GetUniSize();

            UniSize testOutput = testOp0 + testOp1;

            Assert.AreEqual(testOp0.Height + testOp1.Height, testOutput.Height);
        }

        [TestMethod]
        public void UniSizeStruct_AddMethod_ReturnsValueWithWidthPropertyEqualToSumOfWidthPropertiesOfOperands()
        {
            UniSize testParam0 = GetUniSize();
            UniSize testParam1 = GetUniSize();

            UniSize testOutput = UniSize.Add(testParam0, testParam1);

            Assert.AreEqual(testParam0.Width + testParam1.Width, testOutput.Width);
        }

        [TestMethod]
        public void UniSizeStruct_AddMethod_ReturnsValueWithHeightPropertyEqualToSumOfHeightPropertiesOfOperands()
        {
            UniSize testParam0 = GetUniSize();
            UniSize testParam1 = GetUniSize();

            UniSize testOutput = UniSize.Add(testParam0, testParam1);

            Assert.AreEqual(testParam0.Height + testParam1.Height, testOutput.Height);
        }

        [TestMethod]
        public void UniSizeStruct_EqualityOperator_ReturnsTrue_IfBothOperandsAreSameValue()
        {
            UniSize testParam0 = GetUniSize();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testParam0 == testParam0;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniSizeStruct_EqualityOperator_ReturnsTrue_IfBothOperandsHaveSameProperties()
        {
            UniSize testParam0 = GetUniSize();
            UniSize testParam1 = new UniSize(testParam0.Width, testParam0.Height);

            bool testOutput = testParam0 == testParam1;

            Assert.IsTrue(testOutput);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void UniSizeStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByWidthProperty()
        {
            UniSize testParam0 = GetUniSize();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testParam0.Width);
            UniSize testParam1 = new UniSize(constrParam, testParam0.Height);

            bool testOutput = testParam0 == testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniSizeStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByHeightProperty()
        {
            UniSize testParam0 = GetUniSize();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testParam0.Height);
            UniSize testParam1 = new UniSize(testParam0.Width, constrParam);

            bool testOutput = testParam0 == testParam1;

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CS1718 // Comparison made to same variable

        [TestMethod]
        public void UniSizeStruct_InequalityOperator_ReturnsFalse_IfBothOperandsAreSameValue()
        {
            UniSize testParam0 = GetUniSize();

            bool testOutput = testParam0 != testParam0;

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CS1718 // Comparison made to same variable

        [TestMethod]
        public void UniSizeStruct_InequalityOperator_ReturnsFalse_IfBothOperandsHaveSameProperties()
        {
            UniSize testParam0 = GetUniSize();
            UniSize testParam1 = new UniSize(testParam0.Width, testParam0.Height);

            bool testOutput = testParam0 != testParam1;

            Assert.IsFalse(testOutput);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void UniSizeStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByWidthProperty()
        {
            UniSize testParam0 = GetUniSize();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testParam0.Width);
            UniSize testParam1 = new UniSize(constrParam, testParam0.Height);

            bool testOutput = testParam0 != testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniSizeStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByHeightProperty()
        {
            UniSize testParam0 = GetUniSize();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testParam0.Height);
            UniSize testParam1 = new UniSize(testParam0.Width, constrParam);

            bool testOutput = testParam0 != testParam1;

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
