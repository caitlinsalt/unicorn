using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class BoundingBoxUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void BoundingBoxStruct_ParameterlessConstructor_SetsLeftPropertyToZero()
        {
            BoundingBox testOutput = new BoundingBox();

            Assert.AreEqual(0, testOutput.Left);
        }

        [TestMethod]
        public void BoundingBoxStruct_ParameterlessConstructor_SetsRightPropertyToZero()
        {
            BoundingBox testOutput = new BoundingBox();

            Assert.AreEqual(0, testOutput.Right);
        }

        [TestMethod]
        public void BoundingBoxStruct_ParameterlessConstructor_SetsBottomPropertyToZero()
        {
            BoundingBox testOutput = new BoundingBox();

            Assert.AreEqual(0, testOutput.Bottom);
        }

        [TestMethod]
        public void BoundingBoxStruct_ParameterlessConstructor_SetsTopPropertyToZero()
        {
            BoundingBox testOutput = new BoundingBox();

            Assert.AreEqual(0, testOutput.Top);
        }

        [TestMethod]
        public void BoundingBoxStruct_ConstructorWithFourDecimalParameters_SetsLeftPropertyToValueOfFirstParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();

            BoundingBox testOutput = new BoundingBox(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam0, testOutput.Left);
        }

        [TestMethod]
        public void BoundingBoxStruct_ConstructorWithFourDecimalParameters_SetsBottomPropertyToValueOfSecondParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();

            BoundingBox testOutput = new BoundingBox(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam1, testOutput.Bottom);
        }

        [TestMethod]
        public void BoundingBoxStruct_ConstructorWithFourDecimalParameters_SetsRightPropertyToValueOfThirdParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();

            BoundingBox testOutput = new BoundingBox(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam2, testOutput.Right);
        }

        [TestMethod]
        public void BoundingBoxStruct_ConstructorWithFourDecimalParameters_SetsTopPropertyToValueOfFourthParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();

            BoundingBox testOutput = new BoundingBox(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam3, testOutput.Top);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualsMethodWithBoundingBoxParameter_ReturnsTrue_IfPassedThisAsParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);

            bool testOutput = testObject.Equals(testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualsMethodWithBoundingBoxParameter_ReturnsTrue_IfPassedValueConstructedFromSameDataAsParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            BoundingBox other = new BoundingBox(testObject.Left, testObject.Bottom, testObject.Right, testObject.Top);

            bool testOutput = testObject.Equals(other);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualsMethodWithBoundingBoxParameter_ReturnsFalse_IfParameterHasLeftPropertyThatDiffersFromThis()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject.Left);
            BoundingBox other = new BoundingBox(testParam4, testObject.Bottom, testObject.Right, testObject.Top);

            bool testOutput = testObject.Equals(other);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualsMethodWithBoundingBoxParameter_ReturnsFalse_IfParameterHasBottomPropertyThatDiffersFromThis()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject.Bottom);
            BoundingBox other = new BoundingBox(testObject.Left, testParam4, testObject.Right, testObject.Top);

            bool testOutput = testObject.Equals(other);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualsMethodWithBoundingBoxParameter_ReturnsFalse_IfParameterHasRightPropertyThatDiffersFromThis()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject.Right);
            BoundingBox other = new BoundingBox(testObject.Left, testObject.Bottom, testParam4, testObject.Top);

            bool testOutput = testObject.Equals(other);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualsMethodWithBoundingBoxParameter_ReturnsFalse_IfParameterHasTopPropertyThatDiffersFromThis()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject.Top);
            BoundingBox other = new BoundingBox(testObject.Left, testObject.Bottom, testObject.Right, testParam4);

            bool testOutput = testObject.Equals(other);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfPassedThisAsParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);

            bool testOutput = testObject.Equals((object)testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfPassedValueConstructedFromSameDataAsParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            BoundingBox other = new BoundingBox(testObject.Left, testObject.Bottom, testObject.Right, testObject.Top);

            bool testOutput = testObject.Equals((object)other);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasLeftPropertyThatDiffersFromThis()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject.Left);
            BoundingBox other = new BoundingBox(testParam4, testObject.Bottom, testObject.Right, testObject.Top);

            bool testOutput = testObject.Equals((object)other);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasBottomPropertyThatDiffersFromThis()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject.Bottom);
            BoundingBox other = new BoundingBox(testObject.Left, testParam4, testObject.Right, testObject.Top);

            bool testOutput = testObject.Equals((object)other);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasRightPropertyThatDiffersFromThis()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject.Right);
            BoundingBox other = new BoundingBox(testObject.Left, testObject.Bottom, testParam4, testObject.Top);

            bool testOutput = testObject.Equals((object)other);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasTopPropertyThatDiffersFromThis()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject.Top);
            BoundingBox other = new BoundingBox(testObject.Left, testObject.Bottom, testObject.Right, testParam4);

            bool testOutput = testObject.Equals((object)other);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            string other = testObject.ToString();

            bool testOutput = testObject.Equals(other);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceWithSameParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            BoundingBox other = new BoundingBox(testObject.Left, testObject.Bottom, testObject.Right, testObject.Top);

            int testOutput0 = testObject.GetHashCode();
            int testOutput1 = other.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void BoundingBoxStruct_ToStringMethod_ReturnsCorrectExpectedOutput()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            string expectedOutput = testParam0.ToString(CultureInfo.InvariantCulture) + " " + testParam1.ToString(CultureInfo.InvariantCulture) + " " + 
                testParam2.ToString(CultureInfo.InvariantCulture) + " " + testParam3.ToString(CultureInfo.InvariantCulture);

            string testOutput = testObject.ToString();

            Assert.AreEqual(expectedOutput, testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualityOperator_ReturnsTrue_IfBothOperandsAreSameValue()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testObject == testObject;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualityOperator_ReturnsTrue_IfBothOperandsHaveSameProperties()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject0 = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            BoundingBox testObject1 = new BoundingBox(testObject0.Left, testObject0.Bottom, testObject0.Right, testObject0.Top);

            bool testOutput = testObject0 == testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentLeftProperties()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject0 = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject0.Left);
            BoundingBox testObject1 = new BoundingBox(testParam4, testObject0.Bottom, testObject0.Right, testObject0.Top);

            bool testOutput = testObject0 == testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentBottomProperties()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject0 = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject0.Bottom);
            BoundingBox testObject1 = new BoundingBox(testObject0.Left, testParam4, testObject0.Right, testObject0.Top);

            bool testOutput = testObject0 == testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentRightProperties()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject0 = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject0.Right);
            BoundingBox testObject1 = new BoundingBox(testObject0.Left, testObject0.Bottom, testParam4, testObject0.Top);

            bool testOutput = testObject0 == testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentTopProperties()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject0 = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject0.Top);
            BoundingBox testObject1 = new BoundingBox(testObject0.Left, testObject0.Bottom, testObject0.Right, testParam4);

            bool testOutput = testObject0 == testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_InequalityOperator_ReturnsTrue_IfBothOperandsAreSameValue()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject = new BoundingBox(testParam0, testParam1, testParam2, testParam3);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testObject != testObject;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_InequalityOperator_ReturnsTrue_IfBothOperandsHaveSameProperties()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject0 = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            BoundingBox testObject1 = new BoundingBox(testObject0.Left, testObject0.Bottom, testObject0.Right, testObject0.Top);

            bool testOutput = testObject0 != testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_InequalityOperator_ReturnsFalse_IfOperandsHaveDifferentLeftProperties()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject0 = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject0.Left);
            BoundingBox testObject1 = new BoundingBox(testParam4, testObject0.Bottom, testObject0.Right, testObject0.Top);

            bool testOutput = testObject0 != testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_InequalityOperator_ReturnsFalse_IfOperandsHaveDifferentBottomProperties()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject0 = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject0.Bottom);
            BoundingBox testObject1 = new BoundingBox(testObject0.Left, testParam4, testObject0.Right, testObject0.Top);

            bool testOutput = testObject0 != testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_InequalityOperator_ReturnsFalse_IfOperandsHaveDifferentRightProperties()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject0 = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject0.Right);
            BoundingBox testObject1 = new BoundingBox(testObject0.Left, testObject0.Bottom, testParam4, testObject0.Top);

            bool testOutput = testObject0 != testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_InequalityOperator_ReturnsFalse_IfOperandsHaveDifferentTopProperties()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();
            decimal testParam2 = _rnd.NextDecimal();
            decimal testParam3 = _rnd.NextDecimal();
            BoundingBox testObject0 = new BoundingBox(testParam0, testParam1, testParam2, testParam3);
            decimal testParam4;
            do
            {
                testParam4 = _rnd.NextDecimal();
            } while (testParam4 == testObject0.Top);
            BoundingBox testObject1 = new BoundingBox(testObject0.Left, testObject0.Bottom, testObject0.Right, testParam4);

            bool testOutput = testObject0 != testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void BoundingBoxStruct_FromStringsMethod_ReturnsValueWithCorrectLeftProperty_IfAllParametersAreValid()
        {
            decimal testValue0 = _rnd.NextDecimal();
            decimal testValue1 = _rnd.NextDecimal();
            decimal testValue2 = _rnd.NextDecimal();
            decimal testValue3 = _rnd.NextDecimal();
            string testParam0 = testValue0.ToString(CultureInfo.InvariantCulture);
            string testParam1 = testValue1.ToString(CultureInfo.InvariantCulture);
            string testParam2 = testValue2.ToString(CultureInfo.InvariantCulture);
            string testParam3 = testValue3.ToString(CultureInfo.InvariantCulture);

            BoundingBox testOutput = BoundingBox.FromStrings(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testValue0, testOutput.Left);
        }

        [TestMethod]
        public void BoundingBoxStruct_FromStringsMethod_ReturnsValueWithCorrectBottomProperty_IfAllParametersAreValid()
        {
            decimal testValue0 = _rnd.NextDecimal();
            decimal testValue1 = _rnd.NextDecimal();
            decimal testValue2 = _rnd.NextDecimal();
            decimal testValue3 = _rnd.NextDecimal();
            string testParam0 = testValue0.ToString(CultureInfo.InvariantCulture);
            string testParam1 = testValue1.ToString(CultureInfo.InvariantCulture);
            string testParam2 = testValue2.ToString(CultureInfo.InvariantCulture);
            string testParam3 = testValue3.ToString(CultureInfo.InvariantCulture);

            BoundingBox testOutput = BoundingBox.FromStrings(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testValue1, testOutput.Bottom);
        }

        [TestMethod]
        public void BoundingBoxStruct_FromStringsMethod_ReturnsValueWithCorrectRightProperty_IfAllParametersAreValid()
        {
            decimal testValue0 = _rnd.NextDecimal();
            decimal testValue1 = _rnd.NextDecimal();
            decimal testValue2 = _rnd.NextDecimal();
            decimal testValue3 = _rnd.NextDecimal();
            string testParam0 = testValue0.ToString(CultureInfo.InvariantCulture);
            string testParam1 = testValue1.ToString(CultureInfo.InvariantCulture);
            string testParam2 = testValue2.ToString(CultureInfo.InvariantCulture);
            string testParam3 = testValue3.ToString(CultureInfo.InvariantCulture);

            BoundingBox testOutput = BoundingBox.FromStrings(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testValue2, testOutput.Right);
        }

        [TestMethod]
        public void BoundingBoxStruct_FromStringsMethod_ReturnsValueWithCorrectTopProperty_IfAllParametersAreValid()
        {
            decimal testValue0 = _rnd.NextDecimal();
            decimal testValue1 = _rnd.NextDecimal();
            decimal testValue2 = _rnd.NextDecimal();
            decimal testValue3 = _rnd.NextDecimal();
            string testParam0 = testValue0.ToString(CultureInfo.InvariantCulture);
            string testParam1 = testValue1.ToString(CultureInfo.InvariantCulture);
            string testParam2 = testValue2.ToString(CultureInfo.InvariantCulture);
            string testParam3 = testValue3.ToString(CultureInfo.InvariantCulture);

            BoundingBox testOutput = BoundingBox.FromStrings(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testValue3, testOutput.Top);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void BoundingBoxStruct_FromStringsMethod_ThrowsAfmFormatException_IfFirstParameterIsNotANumber()
        {
            decimal testValue1 = _rnd.NextDecimal();
            decimal testValue2 = _rnd.NextDecimal();
            decimal testValue3 = _rnd.NextDecimal();
            string testParam0 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam1 = testValue1.ToString(CultureInfo.InvariantCulture);
            string testParam2 = testValue2.ToString(CultureInfo.InvariantCulture);
            string testParam3 = testValue3.ToString(CultureInfo.InvariantCulture);

            _ = BoundingBox.FromStrings(testParam0, testParam1, testParam2, testParam3);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void BoundingBoxStruct_FromStringsMethod_ThrowsAfmFormatException_IfSecondParameterIsNotANumber()
        {
            decimal testValue0 = _rnd.NextDecimal();
            decimal testValue2 = _rnd.NextDecimal();
            decimal testValue3 = _rnd.NextDecimal();
            string testParam0 = testValue0.ToString(CultureInfo.InvariantCulture);
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam2 = testValue2.ToString(CultureInfo.InvariantCulture);
            string testParam3 = testValue3.ToString(CultureInfo.InvariantCulture);

            _ = BoundingBox.FromStrings(testParam0, testParam1, testParam2, testParam3);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void BoundingBoxStruct_FromStringsMethod_ThrowsAfmFormatException_IfThirdParameterIsNotANumber()
        {
            decimal testValue0 = _rnd.NextDecimal();
            decimal testValue1 = _rnd.NextDecimal();
            decimal testValue3 = _rnd.NextDecimal();
            string testParam0 = testValue0.ToString(CultureInfo.InvariantCulture);
            string testParam1 = testValue1.ToString(CultureInfo.InvariantCulture);
            string testParam2 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam3 = testValue3.ToString(CultureInfo.InvariantCulture);

            _ = BoundingBox.FromStrings(testParam0, testParam1, testParam2, testParam3);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void BoundingBoxStruct_FromStringsMethod_ThrowsAfmFormatException_IfFourthParameterIsNotANumber()
        {
            decimal testValue0 = _rnd.NextDecimal();
            decimal testValue1 = _rnd.NextDecimal();
            decimal testValue2 = _rnd.NextDecimal();
            string testParam0 = testValue0.ToString(CultureInfo.InvariantCulture);
            string testParam1 = testValue1.ToString(CultureInfo.InvariantCulture);
            string testParam2 = testValue2.ToString(CultureInfo.InvariantCulture);
            string testParam3 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));

            _ = BoundingBox.FromStrings(testParam0, testParam1, testParam2, testParam3);

            Assert.Fail();
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
