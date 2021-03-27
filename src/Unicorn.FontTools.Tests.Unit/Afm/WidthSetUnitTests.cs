using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class WidthSetUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void WidthSetStruct_ParameterlessConstructor_SetsGeneralPropertyToNull()
        {
            WidthSet testObject = new WidthSet();

            Assert.IsNull(testObject.General);
        }

        [TestMethod]
        public void WidthSetStruct_ParameterlessConstructor_SetsDirection0PropertyToNull()
        {
            WidthSet testObject = new WidthSet();

            Assert.IsNull(testObject.Direction0);
        }

        [TestMethod]
        public void WidthSetStruct_ParameterlessConstructor_SetsDirection1PropertyToNull()
        {
            WidthSet testObject = new WidthSet();

            Assert.IsNull(testObject.Direction1);
        }

        [TestMethod]
        public void WidthSetStruct_ConstructorWithThreeNullableDecimalParameters_SetsGeneralPropertyToValueOfFirstParameter()
        {
            decimal? testParam0 = _rnd.NextNullableDecimal();
            decimal? testParam1 = _rnd.NextNullableDecimal();
            decimal? testParam2 = _rnd.NextNullableDecimal();

            WidthSet testOutput = new WidthSet(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam0, testOutput.General);
        }

        [TestMethod]
        public void WidthSetStruct_ConstructorWithThreeNullableDecimalParameters_SetsDirection0PropertyToValueOfSecondParameter()
        {
            decimal? testParam0 = _rnd.NextNullableDecimal();
            decimal? testParam1 = _rnd.NextNullableDecimal();
            decimal? testParam2 = _rnd.NextNullableDecimal();

            WidthSet testOutput = new WidthSet(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam1, testOutput.Direction0);
        }

        [TestMethod]
        public void WidthSetStruct_ConstructorWithThreeNullableDecimalParameters_SetsDirection1PropertyToValueOfThirdParameter()
        {
            decimal? testParam0 = _rnd.NextNullableDecimal();
            decimal? testParam1 = _rnd.NextNullableDecimal();
            decimal? testParam2 = _rnd.NextNullableDecimal();

            WidthSet testOutput = new WidthSet(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam2, testOutput.Direction1);
        }

        [TestMethod]
        public void WidthSetStruct_EqualsMethodWithWidthSetParameter_ReturnsTrue_IfParameterIsThis()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue = new WidthSet(constrParam0, constrParam1, constrParam2);

            bool testOutput = testValue.Equals(testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_EqualsMethodWithWidthSetParameter_ReturnsTrue_IfParameterIsConstructedFromSameDataAsThis()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue = new WidthSet(constrParam0, constrParam1, constrParam2);
            WidthSet testParam0 = new WidthSet(testValue.General, testValue.Direction0, testValue.Direction1);

            bool testOutput = testValue.Equals(testParam0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_EqualsMethodWithWidthSetParameter_ReturnsFalse_IfParameterHasDifferentGeneralProperty()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue = new WidthSet(constrParam0, constrParam1, constrParam2);
            decimal? constrParam3;
            do
            {
                constrParam3 = _rnd.NextNullableDecimal();
            } while (constrParam3 == testValue.General);
            WidthSet testParam0 = new WidthSet(constrParam3, testValue.Direction0, testValue.Direction1);

            bool testOutput = testValue.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_EqualsMethodWithWidthSetParameter_ReturnsFalse_IfParameterHasDifferentDirection0Property()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue = new WidthSet(constrParam0, constrParam1, constrParam2);
            decimal? constrParam3;
            do
            {
                constrParam3 = _rnd.NextNullableDecimal();
            } while (constrParam3 == testValue.Direction0);
            WidthSet testParam0 = new WidthSet(testValue.General, constrParam3, testValue.Direction1);

            bool testOutput = testValue.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_EqualsMethodWithWidthSetParameter_ReturnsFalse_IfParameterHasDifferentDirection1Property()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue = new WidthSet(constrParam0, constrParam1, constrParam2);
            decimal? constrParam3;
            do
            {
                constrParam3 = _rnd.NextNullableDecimal();
            } while (constrParam3 == testValue.Direction1);
            WidthSet testParam0 = new WidthSet(testValue.General, testValue.Direction0, constrParam3);

            bool testOutput = testValue.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsThis()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue = new WidthSet(constrParam0, constrParam1, constrParam2);

            bool testOutput = testValue.Equals((object)testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameDataAsThis()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue = new WidthSet(constrParam0, constrParam1, constrParam2);
            WidthSet testParam0 = new WidthSet(testValue.General, testValue.Direction0, testValue.Direction1);

            bool testOutput = testValue.Equals((object)testParam0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasDifferentGeneralProperty()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue = new WidthSet(constrParam0, constrParam1, constrParam2);
            decimal? constrParam3;
            do
            {
                constrParam3 = _rnd.NextNullableDecimal();
            } while (constrParam3 == testValue.General);
            WidthSet testParam0 = new WidthSet(constrParam3, testValue.Direction0, testValue.Direction1);

            bool testOutput = testValue.Equals((object)testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasDifferentDirection0Property()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue = new WidthSet(constrParam0, constrParam1, constrParam2);
            decimal? constrParam3;
            do
            {
                constrParam3 = _rnd.NextNullableDecimal();
            } while (constrParam3 == testValue.Direction0);
            WidthSet testParam0 = new WidthSet(testValue.General, constrParam3, testValue.Direction1);

            bool testOutput = testValue.Equals((object)testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasDifferentDirection1Property()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue = new WidthSet(constrParam0, constrParam1, constrParam2);
            decimal? constrParam3;
            do
            {
                constrParam3 = _rnd.NextNullableDecimal();
            } while (constrParam3 == testValue.Direction1);
            WidthSet testParam0 = new WidthSet(testValue.General, testValue.Direction0, constrParam3);

            bool testOutput = testValue.Equals((object)testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue = new WidthSet(constrParam0, constrParam1, constrParam2);
            string testParam0 = _rnd.NextString(_rnd.Next(20));

            bool testOutput = testValue.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceWithSameValue()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue0 = new WidthSet(constrParam0, constrParam1, constrParam2);
            WidthSet testValue1 = new WidthSet(testValue0.General, testValue0.Direction0, testValue0.Direction1);

            int testOutput0 = testValue0.GetHashCode();
            int testOutput1 = testValue1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void WidthSetStruct_EqualityOperator_ReturnsTrue_IfBothOperandsAreSameValue()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue0 = new WidthSet(constrParam0, constrParam1, constrParam2);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue0 == testValue0;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_EqualityOperator_ReturnsTrue_IfOperandsHaveSameProperties()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue0 = new WidthSet(constrParam0, constrParam1, constrParam2);
            WidthSet testValue1 = new WidthSet(testValue0.General, testValue0.Direction0, testValue0.Direction1);

            bool testOutput = testValue0 == testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentGeneralProperties()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue0 = new WidthSet(constrParam0, constrParam1, constrParam2);
            decimal? constrParam3;
            do
            {
                constrParam3 = _rnd.NextNullableDecimal();
            } while (constrParam3 == testValue0.General);
            WidthSet testValue1 = new WidthSet(constrParam3, testValue0.Direction0, testValue0.Direction1);

            bool testOutput = testValue0 == testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentDirection0Properties()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue0 = new WidthSet(constrParam0, constrParam1, constrParam2);
            decimal? constrParam3;
            do
            {
                constrParam3 = _rnd.NextNullableDecimal();
            } while (constrParam3 == testValue0.Direction0);
            WidthSet testValue1 = new WidthSet(testValue0.General, constrParam3, testValue0.Direction1);

            bool testOutput = testValue0 == testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentDirection1Properties()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue0 = new WidthSet(constrParam0, constrParam1, constrParam2);
            decimal? constrParam3;
            do
            {
                constrParam3 = _rnd.NextNullableDecimal();
            } while (constrParam3 == testValue0.Direction1);
            WidthSet testValue1 = new WidthSet(testValue0.General, testValue0.Direction0, constrParam3);

            bool testOutput = testValue0 == testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_InequalityOperator_ReturnsFalse_IfBothOperandsAreSameValue()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue0 = new WidthSet(constrParam0, constrParam1, constrParam2);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue0 != testValue0;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_InequalityOperator_ReturnsFalse_IfOperandsHaveSameProperties()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue0 = new WidthSet(constrParam0, constrParam1, constrParam2);
            WidthSet testValue1 = new WidthSet(testValue0.General, testValue0.Direction0, testValue0.Direction1);

            bool testOutput = testValue0 != testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentGeneralProperties()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue0 = new WidthSet(constrParam0, constrParam1, constrParam2);
            decimal? constrParam3;
            do
            {
                constrParam3 = _rnd.NextNullableDecimal();
            } while (constrParam3 == testValue0.General);
            WidthSet testValue1 = new WidthSet(constrParam3, testValue0.Direction0, testValue0.Direction1);

            bool testOutput = testValue0 != testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentDirection0Properties()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue0 = new WidthSet(constrParam0, constrParam1, constrParam2);
            decimal? constrParam3;
            do
            {
                constrParam3 = _rnd.NextNullableDecimal();
            } while (constrParam3 == testValue0.Direction0);
            WidthSet testValue1 = new WidthSet(testValue0.General, constrParam3, testValue0.Direction1);

            bool testOutput = testValue0 != testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void WidthSetStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentDirection1Properties()
        {
            decimal? constrParam0 = _rnd.NextNullableDecimal();
            decimal? constrParam1 = _rnd.NextNullableDecimal();
            decimal? constrParam2 = _rnd.NextNullableDecimal();
            WidthSet testValue0 = new WidthSet(constrParam0, constrParam1, constrParam2);
            decimal? constrParam3;
            do
            {
                constrParam3 = _rnd.NextNullableDecimal();
            } while (constrParam3 == testValue0.Direction1);
            WidthSet testValue1 = new WidthSet(testValue0.General, testValue0.Direction0, constrParam3);

            bool testOutput = testValue0 != testValue1;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
