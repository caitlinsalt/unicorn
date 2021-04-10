using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType.Utility;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit.OpenType.Utility
{
    [TestClass]
    public class DumpColumnUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DumpColumnStruct_ConstructorWithTwoParameters_SetsHeaderTextPropertyToValueOfFirstParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 20));
            DumpAlignment testParam1 = _rnd.NextDumpAlignment();

            DumpColumn testOutput = new(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.HeaderText);
        }

        [TestMethod]
        public void DumpColumnStruct_ConstructorWithTwoParameters_SetsAlignmentPropertyToValueOfSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 20));
            DumpAlignment testParam1 = _rnd.NextDumpAlignment();

            DumpColumn testOutput = new(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Alignment);
        }

        [TestMethod]
        public void DumpColumnStruct_ConstructorWithOneParameter_SetsHeaderTextPropertyToValueOfParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 20));

            DumpColumn testOutput = new(testParam0);

            Assert.AreEqual(testParam0, testOutput.HeaderText);
        }

        [TestMethod]
        public void DumpColumnStruct_ConstructorWithOneParameter_SetsAlignmentPropertyToLeft()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 20));

            DumpColumn testOutput = new(testParam0);

            Assert.AreEqual(DumpAlignment.Left, testOutput.Alignment);
        }

        [TestMethod]
        public void DumpColumnStruct_ConstructorWithNoParameters_SetsHeaderTextPropertyToNull()
        {
            DumpColumn testOutput = new();

            Assert.IsNull(testOutput.HeaderText);
        }

        [TestMethod]
        public void DumpColumnStruct_ConstructorWithNoParameters_SetsAlignmentPropertyToLeft()
        {
            DumpColumn testOutput = new();

            Assert.AreEqual(DumpAlignment.Left, testOutput.Alignment);
        }

        [TestMethod]
        public void DumpColumnStruct_EqualityOperator_ReturnsTrue_IfBothPropertiesOfBothOperandsAreEqual()
        {
            DumpColumn testOperand0 = _rnd.NextDumpColumn();
            DumpColumn testOperand1 = new(testOperand0.HeaderText, testOperand0.Alignment);

            bool testOutput = testOperand0 == testOperand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DumpColumnStruct_EqualityOperator_ReturnsFalse_IfHeaderTextPropertiesDiffer()
        {
            DumpColumn testOperand0 = _rnd.NextDumpColumn();
            string testOperand1Name;
            do
            {
                testOperand1Name = _rnd.NextString(_rnd.Next(1, 40));
            } while (testOperand0.HeaderText == testOperand1Name);
            DumpColumn testOperand1 = new(testOperand1Name, testOperand0.Alignment);

            bool testOutput = testOperand0 == testOperand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DumpColumnStruct_EqualityOperator_ReturnsFalse_IfAlignmentPropertiesDiffer()
        {
            DumpColumn testOperand0 = _rnd.NextDumpColumn();
            DumpColumn testOperand1 = new(testOperand0.HeaderText, testOperand0.Alignment.Opposite());

            bool testOutput = testOperand0 == testOperand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DumpColumnStruct_EqualsMethodWithDumpColumnParameter_ReturnsTrue_IfBothPropertiesOfBothOperandsAreEqual()
        {
            DumpColumn testValue = _rnd.NextDumpColumn();
            DumpColumn testParam = new(testValue.HeaderText, testValue.Alignment);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DumpColumnStruct_EqualsMethodWithDumpColumnParameter_ReturnsFalse_IfHeaderTextPropertyDiffers()
        {
            DumpColumn testValue = _rnd.NextDumpColumn();
            string testParamName;
            do
            {
                testParamName = _rnd.NextString(_rnd.Next(1, 40));
            } while (testParamName == testValue.HeaderText);
            DumpColumn testParam = new(testParamName, testValue.Alignment);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DumpColumnStruct_EqualsMethodWithDumpColumnParameter_ReturnsFalse_IfAlignmentPropertyDiffers()
        {
            DumpColumn testValue = _rnd.NextDumpColumn();
            DumpColumn testParam = new(testValue.HeaderText, testValue.Alignment.Opposite());

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DumpColumnStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfBothPropertiesOfBothOperandsAreEqual()
        {
            DumpColumn testValue = _rnd.NextDumpColumn();
            object testParam = new DumpColumn(testValue.HeaderText, testValue.Alignment);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DumpColumnStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfHeaderTextPropertyDiffers()
        {
            DumpColumn testValue = _rnd.NextDumpColumn();
            string testParamName;
            do
            {
                testParamName = _rnd.NextString(_rnd.Next(1, 40));
            } while (testParamName == testValue.HeaderText);
            object testParam = new DumpColumn(testParamName, testValue.Alignment);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DumpColumnStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfAlignmentPropertyDiffers()
        {
            DumpColumn testValue = _rnd.NextDumpColumn();
            object testParam = new DumpColumn(testValue.HeaderText, testValue.Alignment.Opposite());

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DumpColumnStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            DumpColumn testValue = _rnd.NextDumpColumn();

            bool testOutput = testValue.Equals(testValue.HeaderText);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DumpColumnStruct_InequalityOperator_ReturnsFalse_IfBothPropertiesOfBothOperandsAreEqual()
        {
            DumpColumn testOperand0 = _rnd.NextDumpColumn();
            DumpColumn testOperand1 = new(testOperand0.HeaderText, testOperand0.Alignment);

            bool testOutput = testOperand0 != testOperand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DumpColumnStruct_InequalityOperator_ReturnsTrue_IfHeaderTextPropertiesDiffer()
        {
            DumpColumn testOperand0 = _rnd.NextDumpColumn();
            string testOperand1Name;
            do
            {
                testOperand1Name = _rnd.NextString(_rnd.Next(1, 40));
            } while (testOperand0.HeaderText == testOperand1Name);
            DumpColumn testOperand1 = new(testOperand1Name, testOperand0.Alignment);

            bool testOutput = testOperand0 != testOperand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DumpColumnStruct_InequalityOperator_ReturnsTrue_IfAlignmentPropertiesDiffer()
        {
            DumpColumn testOperand0 = _rnd.NextDumpColumn();
            DumpColumn testOperand1 = new(testOperand0.HeaderText, testOperand0.Alignment.Opposite());

            bool testOutput = testOperand0 != testOperand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DumpColumnStruct_GetHashcodeMethod_ReturnsSameValue_IfCalledTwiceWithSameValue()
        {
            DumpColumn testObject0 = _rnd.NextDumpColumn();
            DumpColumn testObject1 = new DumpColumn(testObject0.HeaderText, testObject0.Alignment);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
