using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class VectorUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void VectorStruct_ParameterlessConstructor_SetsXPropertyToZero()
        {
            Vector testOutput = new Vector();

            Assert.AreEqual(0m, testOutput.X);
        }

        [TestMethod]
        public void VectorStruct_ParameterlessConstructor_SetsYPropertyToZero()
        {
            Vector testOutput = new Vector();

            Assert.AreEqual(0m, testOutput.Y);
        }

        [TestMethod]
        public void VectorStruct_ConstructorWithTwoDecimalParameters_SetsXPropertyToValueOfFirstParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();

            Vector testOutput = new Vector(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.X);
        }

        [TestMethod]
        public void VectorStruct_ConstructorWithTwoDecimalParameters_SetsYPropertyToValueOfSecondParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();

            Vector testOutput = new Vector(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Y);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithVectorParameter_ReturnsTrue_IfParameterIsThis()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);

            bool testOutput = testObject.Equals(testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithVectorParameter_ReturnsTrue_IfParameterWasConstructedFromSameData()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);
            Vector testParam0 = new Vector(testObject.X, testObject.Y);

            bool testOutput = testObject.Equals(testParam0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithVectorParameter_ReturnsFalse_IfParameterHasXPropertyThatDiffersFromThis()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject.X);
            Vector testParam0 = new Vector(constrParam2, testObject.Y);

            bool testOutput = testObject.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithVectorParameter_ReturnsFalse_IfParameterHasYPropertyThatDiffersFromThis()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject.Y);
            Vector testParam0 = new Vector(testObject.X, constrParam2);

            bool testOutput = testObject.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsThis()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);

            bool testOutput = testObject.Equals((object)testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterWasConstructedFromSameData()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);
            Vector testParam0 = new Vector(testObject.X, testObject.Y);

            bool testOutput = testObject.Equals((object)testParam0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasXPropertyThatDiffersFromThis()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject.X);
            Vector testParam0 = new Vector(constrParam2, testObject.Y);

            bool testOutput = testObject.Equals((object)testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasYPropertyThatDiffersFromThis()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject.Y);
            Vector testParam0 = new Vector(testObject.X, constrParam2);

            bool testOutput = testObject.Equals((object)testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);
            string testParam0 = _rnd.NextString(_rnd.Next(0, 20));

            bool testOutput = testObject.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceWithSameValue()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject0 = new Vector(constrParam0, constrParam1);
            Vector testObject1 = new Vector(testObject0.X, testObject0.Y);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void VectorStruct_EqualityOperator_ReturnsTrue_IfBothOperandsAreSameValue()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testObject == testObject;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualityOperator_ReturnsTrue_IfOperandsHaveSameProperties()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject0 = new Vector(constrParam0, constrParam1);
            Vector testObject1 = new Vector(testObject0.X, testObject0.Y);

            bool testOutput = testObject0 == testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentXProperties()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject0 = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject0.X);
            Vector testObject1 = new Vector(constrParam2, testObject0.Y);

            bool testOutput = testObject0 == testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentYProperties()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject0 = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject0.Y);
            Vector testObject1 = new Vector(testObject0.X, constrParam2);

            bool testOutput = testObject0 == testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_InequalityOperator_ReturnsFalse_IfBothOperandsAreSameValue()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testObject != testObject;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_InequalityOperator_ReturnsFalse_IfOperandsHaveSameProperties()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject0 = new Vector(constrParam0, constrParam1);
            Vector testObject1 = new Vector(testObject0.X, testObject0.Y);

            bool testOutput = testObject0 != testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentXProperties()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject0 = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject0.X);
            Vector testObject1 = new Vector(constrParam2, testObject0.Y);

            bool testOutput = testObject0 != testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentYProperties()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject0 = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject0.Y);
            Vector testObject1 = new Vector(testObject0.X, constrParam2);

            bool testOutput = testObject0 != testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_FromStringsMethod_ReturnsValueWithCorrectXProperty_IfBothParametersAreValid()
        {
            decimal testValue0 = _rnd.NextDecimal();
            string testParam0 = testValue0.ToString(CultureInfo.InvariantCulture);
            decimal testValue1 = _rnd.NextDecimal();
            string testParam1 = testValue1.ToString(CultureInfo.InvariantCulture);

            Vector testOutput = Vector.FromStrings(testParam0, testParam1);

            Assert.AreEqual(testValue0, testOutput.X);
        }

        [TestMethod]
        public void VectorStruct_FromStringsMethod_ReturnsValueWithCorrectYProperty_IfBothParametersAreValid()
        {
            decimal testValue0 = _rnd.NextDecimal();
            string testParam0 = testValue0.ToString(CultureInfo.InvariantCulture);
            decimal testValue1 = _rnd.NextDecimal();
            string testParam1 = testValue1.ToString(CultureInfo.InvariantCulture);

            Vector testOutput = Vector.FromStrings(testParam0, testParam1);

            Assert.AreEqual(testValue1, testOutput.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void VectorStruct_FromStringsMethod_ThrowsAfmFormatException_IfFirstParameterIsNotANumber()
        {
            string testParam0 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(10));
            decimal testValue1 = _rnd.NextDecimal();
            string testParam1 = testValue1.ToString(CultureInfo.InvariantCulture);

            _ = Vector.FromStrings(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void VectorStruct_FromStringsMethod_ThrowsAfmFormatException_IfSecondParameterIsNotANumber()
        {
            decimal testValue0 = _rnd.NextDecimal();
            string testParam0 = testValue0.ToString(CultureInfo.InvariantCulture);
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(10));

            _ = Vector.FromStrings(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void VectorStruct_FromStringsMethod_ThrowsAfmFormatException_IfNeitherParameterIsANumber()
        {
            string testParam0 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(10));
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(10));

            _ = Vector.FromStrings(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void VectorStruct_FromXStringMethod_ReturnsValueWithCorrectXProperty_IfParameterIsValid()
        {
            decimal testValue = _rnd.NextDecimal();
            string testParam = testValue.ToString(CultureInfo.InvariantCulture);

            Vector testOutput = Vector.FromXString(testParam);

            Assert.AreEqual(testValue, testOutput.X);
        }

        [TestMethod]
        public void VectorStruct_FromXStringMethod_ReturnsValueWithCorrectYProperty_IfParameterIsValid()
        {
            decimal testValue = _rnd.NextDecimal();
            string testParam = testValue.ToString(CultureInfo.InvariantCulture);

            Vector testOutput = Vector.FromXString(testParam);

            Assert.AreEqual(0m, testOutput.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void VectorStruct_FromXStringMethod_ThrowsAfmFormatException_IfParameterIsNotANumber()
        {
            string testParam = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(10));

            _ = Vector.FromXString(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void VectorStruct_FromYStringMethod_ReturnsValueWithCorrectXProperty_IfParameterIsValid()
        {
            decimal testValue = _rnd.NextDecimal();
            string testParam = testValue.ToString(CultureInfo.InvariantCulture);

            Vector testOutput = Vector.FromYString(testParam);

            Assert.AreEqual(0m, testOutput.X);
        }

        [TestMethod]
        public void VectorStruct_FromYStringMethod_ReturnsValueWithCorrectYProperty_IfParameterIsValid()
        {
            decimal testValue = _rnd.NextDecimal();
            string testParam = testValue.ToString(CultureInfo.InvariantCulture);

            Vector testOutput = Vector.FromYString(testParam);

            Assert.AreEqual(testValue, testOutput.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void VectorStruct_FromYStringMethod_ThrowsAfmFormatException_IfParameterIsNotANumber()
        {
            string testParam = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(10));

            _ = Vector.FromYString(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void VectorStruct_ToStringMethod_ReturnsCorrectResult()
        {
            decimal expectedX = _rnd.NextDecimal();
            decimal expectedY = _rnd.NextDecimal();
            string expectedValue = expectedX.ToString(CultureInfo.InvariantCulture) + " " + expectedY.ToString(CultureInfo.InvariantCulture);
            Vector testValue = new Vector(expectedX, expectedY);

            string testOutput = testValue.ToString();

            Assert.AreEqual(expectedValue, testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
