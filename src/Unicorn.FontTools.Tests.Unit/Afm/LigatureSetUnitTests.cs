using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Afm;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class LigatureSetUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void LigatureSetStruct_ParameterlessConstructor_SetsFirstPropertyToNull()
        {
            LigatureSet testOutput = new LigatureSet();

            Assert.IsNull(testOutput.First);
        }

        [TestMethod]
        public void LigatureSetStruct_ParameterlessConstructor_SetsSecondPropertyToNull()
        {
            LigatureSet testOutput = new LigatureSet();

            Assert.IsNull(testOutput.Second);
        }

        [TestMethod]
        public void LigatureSetStruct_ParameterlessConstructor_SetsLigaturePropertyToNull()
        {
            LigatureSet testOutput = new LigatureSet();

            Assert.IsNull(testOutput.Ligature);
        }

        [TestMethod]
        public void LigatureSetStruct_ConstructorWithThreeCharacterParameters_SetsFirstPropertyToBeFirstParameter()
        {
            Character testParam0 = _rnd.NextAfmCharacter();
            Character testParam1 = _rnd.NextAfmCharacter();
            Character testParam2 = _rnd.NextAfmCharacter();

            LigatureSet testOutput = new LigatureSet(testParam0, testParam1, testParam2);

            Assert.AreSame(testParam0, testOutput.First);
        }

        [TestMethod]
        public void LigatureSetStruct_ConstructorWithThreeCharacterParameters_SetsSecondPropertyToBeSecondParameter()
        {
            Character testParam0 = _rnd.NextAfmCharacter();
            Character testParam1 = _rnd.NextAfmCharacter();
            Character testParam2 = _rnd.NextAfmCharacter();

            LigatureSet testOutput = new LigatureSet(testParam0, testParam1, testParam2);

            Assert.AreSame(testParam1, testOutput.Second);
        }

        [TestMethod]
        public void LigatureSetStruct_ConstructorWithThreeCharacterParameters_SetsLigaturePropertyToBeThirdParameter()
        {
            Character testParam0 = _rnd.NextAfmCharacter();
            Character testParam1 = _rnd.NextAfmCharacter();
            Character testParam2 = _rnd.NextAfmCharacter();

            LigatureSet testOutput = new LigatureSet(testParam0, testParam1, testParam2);

            Assert.AreSame(testParam2, testOutput.Ligature);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualsMethodWithLigatureSetParameter_ReturnsTrue_IfParameterIsThis()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue = new LigatureSet(constrParam0, constrParam1, constrParam2);

            bool testOutput = testValue.Equals(testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualsMethodWithLigatureSetParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testParam0 = new LigatureSet(testValue.First, testValue.Second, testValue.Ligature);

            bool testOutput = testValue.Equals(testParam0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualsMethodWithLigatureSetParameter_ReturnsFalse_IfParameterDiffersInFirstProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testParam0 = new LigatureSet(_rnd.NextAfmCharacter(), testValue.Second, testValue.Ligature);

            bool testOutput = testValue.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualsMethodWithLigatureSetParameter_ReturnsFalse_IfParameterDiffersInSecondProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testParam0 = new LigatureSet(testValue.First, _rnd.NextAfmCharacter(), testValue.Ligature);

            bool testOutput = testValue.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualsMethodWithLigatureSetParameter_ReturnsFalse_IfParameterDiffersInLigatureProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testParam0 = new LigatureSet(testValue.First, testValue.Second, _rnd.NextAfmCharacter());

            bool testOutput = testValue.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsThis()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue = new LigatureSet(constrParam0, constrParam1, constrParam2);

            bool testOutput = testValue.Equals((object)testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testParam0 = new LigatureSet(testValue.First, testValue.Second, testValue.Ligature);

            bool testOutput = testValue.Equals((object)testParam0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersInFirstProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testParam0 = new LigatureSet(_rnd.NextAfmCharacter(), testValue.Second, testValue.Ligature);

            bool testOutput = testValue.Equals((object)testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersInSecondProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testParam0 = new LigatureSet(testValue.First, _rnd.NextAfmCharacter(), testValue.Ligature);

            bool testOutput = testValue.Equals((object)testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersInLigatureProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testParam0 = new LigatureSet(testValue.First, testValue.Second, _rnd.NextAfmCharacter());

            bool testOutput = testValue.Equals((object)testParam0);

            Assert.IsFalse(testOutput);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void LigatureSetStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue = new LigatureSet(constrParam0, constrParam1, constrParam2);
            string testParam0 = _rnd.NextString(_rnd.Next(255));

            bool testOutput = testValue.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

        [TestMethod]
        public void LigatureSetStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceWithSameValue()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue0 = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testValue1 = new LigatureSet(testValue0.First, testValue0.Second, testValue0.Ligature);

            int testOutput0 = testValue0.GetHashCode();
            int testOutput1 = testValue1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualityOperator_ReturnsTrue_IfBothOperandsAreSameValue()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue = new LigatureSet(constrParam0, constrParam1, constrParam2);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue == testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualityOperator_ReturnsTrue_IfOperandsHaveSameProperties()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue0 = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testValue1 = new LigatureSet(testValue0.First, testValue0.Second, testValue0.Ligature);

            bool testOutput = testValue0 == testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentFirstProperties()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue0 = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testValue1 = new LigatureSet(_rnd.NextAfmCharacter(), testValue0.Second, testValue0.Ligature);

            bool testOutput = testValue0 == testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentSecondProperties()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue0 = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testValue1 = new LigatureSet(testValue0.First, _rnd.NextAfmCharacter(), testValue0.Ligature);

            bool testOutput = testValue0 == testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentLigatureProperties()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue0 = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testValue1 = new LigatureSet(testValue0.First, testValue0.Second, _rnd.NextAfmCharacter());

            bool testOutput = testValue0 == testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_InequalityOperator_ReturnFalse_IfBothOperandsAreSameValue()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue = new LigatureSet(constrParam0, constrParam1, constrParam2);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue != testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_InequalityOperator_ReturnsFalse_IfOperandsHaveSameProperties()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue0 = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testValue1 = new LigatureSet(testValue0.First, testValue0.Second, testValue0.Ligature);

            bool testOutput = testValue0 != testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentFirstProperties()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue0 = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testValue1 = new LigatureSet(_rnd.NextAfmCharacter(), testValue0.Second, testValue0.Ligature);

            bool testOutput = testValue0 != testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentSecondProperties()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue0 = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testValue1 = new LigatureSet(testValue0.First, _rnd.NextAfmCharacter(), testValue0.Ligature);

            bool testOutput = testValue0 != testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void LigatureSetStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentLigatureProperties()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Character constrParam2 = _rnd.NextAfmCharacter();
            LigatureSet testValue0 = new LigatureSet(constrParam0, constrParam1, constrParam2);
            LigatureSet testValue1 = new LigatureSet(testValue0.First, testValue0.Second, _rnd.NextAfmCharacter());

            bool testOutput = testValue0 != testValue1;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
