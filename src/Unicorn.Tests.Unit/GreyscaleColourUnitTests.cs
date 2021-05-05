using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Base;
using Unicorn.Writer.Primitives;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class GreyscaleColourUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private double _greyLevel;
        private GreyscaleColour _testObject;
        private Mock<IUniColour> _otherColour;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            _greyLevel = _rnd.NextDouble();
            _otherColour = new Mock<IUniColour>();
            _testObject = new GreyscaleColour(_greyLevel);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GreyscaleColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfParameterIsNegative()
        {
            _ = new GreyscaleColour(_greyLevel * -1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GreyscaleColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfParameterIsGreaterThanOne()
        {
            _ = new GreyscaleColour(_greyLevel + 1);

            Assert.Fail();
        }

        [TestMethod]
        public void GreyscaleColourClass_Constructor_SetsGreyLevelPropertyToValueOfParameter()
        {
            GreyscaleColour testObject = new(_greyLevel);

            Assert.AreEqual(_greyLevel, testObject.GreyLevel);
        }

        [TestMethod]
        public void GreyscaleColourClass_ColourSpaceNameProperty_EqualsDeviceGrayscale()
        {
            Assert.AreEqual("DeviceGrayscale", _testObject.ColourSpaceName);
        }

        [TestMethod]
        public void GreyscaleColourClass_StrokeSelectionOperatorsMethod_ReturnsEmptySequence_IfParameterIsThis()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_testObject).ToArray();

            Assert.AreEqual(0, testOutput.Length);
        }

        [TestMethod]
        public void GreyscaleColourClass_StrokeSelectionOperatorsMethod_ReturnsEmptySequence_IfParameterIsEqualToThis()
        {
            GreyscaleColour testParam = new(_testObject.GreyLevel);

            var testOutput = _testObject.StrokeSelectionOperators(testParam).ToArray();

            Assert.AreEqual(0, testOutput.Length);
        }

        [TestMethod]
        public void GreyscaleColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceOfOneItem_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).ToArray();

            Assert.AreEqual(1, testOutput.Length);
        }

        [TestMethod]
        public void GreyscaleColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorG_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).First();

            Assert.AreEqual("G", testOutput.Value);
        }

        [TestMethod]
        public void GreyscaleColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithOneOperand_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).First();

            Assert.AreEqual(1, testOutput.Operands.Count);
        }

        [TestMethod]
        public void GreyscaleColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithOperandEqualToGreyLevelProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[0] as PdfReal;
            Assert.AreEqual((decimal)_greyLevel, operand.Value);
        }

        [TestMethod]
        public void GreyscaleColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceOfOneItem_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).ToArray();

            Assert.AreEqual(1, testOutput.Length);
        }

        [TestMethod]
        public void GreyscaleColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorG_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).First();

            Assert.AreEqual("G", testOutput.Value);
        }

        [TestMethod]
        public void GreyscaleColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithOneOperand_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).First();

            Assert.AreEqual(1, testOutput.Operands.Count);
        }

        [TestMethod]
        public void GreyscaleColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithOperandEqualToGreyLevelProperty_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[0] as PdfReal;
            Assert.AreEqual((decimal)_greyLevel, operand.Value);
        }

        [TestMethod]
        public void GreyscaleColourClass_NonStrokeSelectionOperatorsMethod_ReturnsEmptySequence_IfParameterIsThis()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_testObject).ToArray();

            Assert.AreEqual(0, testOutput.Length);
        }

        [TestMethod]
        public void GreyscaleColourClass_NonStrokeSelectionOperatorsMethod_ReturnsEmptySequence_IfParameterIsEqualToThis()
        {
            GreyscaleColour testParam = new(_testObject.GreyLevel);

            var testOutput = _testObject.NonStrokeSelectionOperators(testParam).ToArray();

            Assert.AreEqual(0, testOutput.Length);
        }

        [TestMethod]
        public void GreyscaleColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceOfOneItem_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).ToArray();

            Assert.AreEqual(1, testOutput.Length);
        }

        [TestMethod]
        public void GreyscaleColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorg_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).First();

            Assert.AreEqual("g", testOutput.Value);
        }

        [TestMethod]
        public void GreyscaleColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithOneOperand_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).First();

            Assert.AreEqual(1, testOutput.Operands.Count);
        }

        [TestMethod]
        public void GreyscaleColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithOperandEqualToGreyLevelProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[0] as PdfReal;
            Assert.AreEqual((decimal)_greyLevel, operand.Value);
        }

        [TestMethod]
        public void GreyscaleColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceOfOneItem_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).ToArray();

            Assert.AreEqual(1, testOutput.Length);
        }

        [TestMethod]
        public void GreyscaleColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorg_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).First();

            Assert.AreEqual("g", testOutput.Value);
        }

        [TestMethod]
        public void GreyscaleColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithOneOperand_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).First();

            Assert.AreEqual(1, testOutput.Operands.Count);
        }

        [TestMethod]
        public void GreyscaleColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithOperandEqualToGreyLevelProperty_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[0] as PdfReal;
            Assert.AreEqual((decimal)_greyLevel, operand.Value);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualityOperatorWithGreyscaleColourFirst_ReturnsTrue_IfBothOperandsAreNull()
        {
            GreyscaleColour operand0 = null;
            IUniColour operand1 = null;

#pragma warning disable CA1508 // Avoid dead conditional code
            bool testOutput = operand0 == operand1;
#pragma warning restore CA1508 // Avoid dead conditional code

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualityOperatorWithGreyscaleColourFirst_ReturnsFalse_IfFirstOperandIsNull()
        {
            GreyscaleColour operand0 = null;
            IUniColour operand1 = _otherColour.Object;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualityOperatorWithGreyscaleColourFirst_ReturnsFalse_IfSecondOperandIsNull()
        {
            GreyscaleColour operand0 = _testObject;
            IUniColour operand1 = null;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualityOperatorWithGreyscaleColourFirst_ReturnsFalse_IfSecondOperandIsNotAGreyscaleColourObject()
        {
            GreyscaleColour operand0 = _testObject;
            IUniColour operand1 = _otherColour.Object;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualityOperatorWithGreyscaleColourFirst_ReturnsTrue_IfSecondOperandIsGreyscaleColourObjectWithSameGreyLevelAsFirstOperand()
        {
            GreyscaleColour operand0 = _testObject;
            IUniColour operand1 = new GreyscaleColour(_greyLevel);

            bool testOutput = operand0 == operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualityOperatorWithGreyscaleColourFirst_ReturnsFalse_IfSecondOperandIsGreyscaleColourObjectWithDifferentGreyLevelToFirstOperand()
        {
            GreyscaleColour operand0 = _testObject;
            IUniColour operand1 = new GreyscaleColour(_rnd.NextDoubleNotInSet(_greyLevel));

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualityOperatorWithGreyscaleColourSecond_ReturnsTrue_IfBothOperandsAreNull()
        {
            IUniColour operand0 = null;
            GreyscaleColour operand1 = null;

#pragma warning disable CA1508 // Avoid dead conditional code
            bool testOutput = operand0 == operand1;
#pragma warning restore CA1508 // Avoid dead conditional code

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualityOperatorWithGreyscaleColourSecond_ReturnsFalse_IfFirstOperandIsNull()
        {
            IUniColour operand0 = null;
            GreyscaleColour operand1 = _testObject;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualityOperatorWithGreyscaleColourSecond_ReturnsFalse_IfSecondOperandIsNull()
        {
            IUniColour operand0 = _otherColour.Object;
            GreyscaleColour operand1 = null;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualityOperatorWithGreyscaleColourSecond_ReturnsFalse_IfFirstOperandIsNotAGreyscaleColourObject()
        {
            IUniColour operand0 = _otherColour.Object;
            GreyscaleColour operand1 = _testObject;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualityOperatorWithGreyscaleColourSecond_ReturnsTrue_IfSecondOperandIsGreyscaleColourObjectWithSameGreyLevelAsFirstOperand()
        {
            IUniColour operand0 = _testObject;
            GreyscaleColour operand1 = new(_greyLevel);

            bool testOutput = operand0 == operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualityOperatorWithGreyscaleColourSecond_ReturnsFalse_IfSecondOperandIsGreyscaleColourObjectWithDifferentGreyLevelToFirstOperand()
        {
            IUniColour operand0 = _testObject;
            GreyscaleColour operand1 = new(_rnd.NextDoubleNotInSet(_greyLevel));

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_InequalityOperatorWithGreyscaleColourFirst_ReturnsFalse_IfBothOperandsAreNull()
        {
            GreyscaleColour operand0 = null;
            IUniColour operand1 = null;

#pragma warning disable CA1508 // Avoid dead conditional code
            bool testOutput = operand0 != operand1;
#pragma warning restore CA1508 // Avoid dead conditional code

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_InequalityOperatorWithGreyscaleColourFirst_ReturnsTrue_IfFirstOperandIsNull()
        {
            GreyscaleColour operand0 = null;
            IUniColour operand1 = _otherColour.Object;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_InequalityOperatorWithGreyscaleColourFirst_ReturnsTrue_IfSecondOperandIsNull()
        {
            GreyscaleColour operand0 = _testObject;
            IUniColour operand1 = null;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_InequalityOperatorWithGreyscaleColourFirst_ReturnsTrue_IfSecondOperandIsNotAGreyscaleColourObject()
        {
            GreyscaleColour operand0 = _testObject;
            IUniColour operand1 = _otherColour.Object;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_InequalityOperatorWithGreyscaleColourFirst_ReturnsFalse_IfSecondOperandIsGreyscaleColourObjectWithSameGreyLevelAsFirstOperand()
        {
            GreyscaleColour operand0 = _testObject;
            IUniColour operand1 = new GreyscaleColour(_greyLevel);

            bool testOutput = operand0 != operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_InequalityOperatorWithGreyscaleColourFirst_ReturnsTruee_IfSecondOperandIsGreyscaleColourObjectWithDifferentGreyLevelToFirstOperand()
        {
            GreyscaleColour operand0 = _testObject;
            IUniColour operand1 = new GreyscaleColour(_rnd.NextDoubleNotInSet(_greyLevel));

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_InequalityOperatorWithGreyscaleColourSecond_ReturnsFalse_IfBothOperandsAreNull()
        {
            IUniColour operand0 = null;
            GreyscaleColour operand1 = null;

#pragma warning disable CA1508 // Avoid dead conditional code
            bool testOutput = operand0 != operand1;
#pragma warning restore CA1508 // Avoid dead conditional code

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_InequalityOperatorWithGreyscaleColourSecond_ReturnsTrue_IfFirstOperandIsNull()
        {
            IUniColour operand0 = null;
            GreyscaleColour operand1 = _testObject;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_InequalityOperatorWithGreyscaleColourSecond_ReturnsTrue_IfSecondOperandIsNull()
        {
            IUniColour operand0 = _otherColour.Object;
            GreyscaleColour operand1 = null;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_InequalityOperatorWithGreyscaleColourSecond_ReturnsTrue_IfFirstOperandIsNotAGreyscaleColourObject()
        {
            IUniColour operand0 = _otherColour.Object;
            GreyscaleColour operand1 = _testObject;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_InequalityOperatorWithGreyscaleColourSecond_ReturnsFalse_IfSecondOperandIsGreyscaleColourObjectWithSameGreyLevelAsFirstOperand()
        {
            IUniColour operand0 = _testObject;
            GreyscaleColour operand1 = new(_greyLevel);

            bool testOutput = operand0 != operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_InequalityOperatorWithGreyscaleColourSecond_ReturnsTrue_IfSecondOperandIsGreyscaleColourObjectWithDifferentGreyLevelToFirstOperand()
        {
            IUniColour operand0 = _testObject;
            GreyscaleColour operand1 = new(_rnd.NextDoubleNotInSet(_greyLevel));

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualsMethodWithIUniColourParameter_ReturnsFalse_IfParameterIsNull()
        {
            IUniColour param0 = null;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualsMethodWithIUniColourParameter_ReturnsTrue_IfParameterIsThis()
        {
            IUniColour param0 = _testObject;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualsMethodWithIUniColourParameter_ReturnsTrue_IfParameterIsGreyscaleColourObjectWithSameGreyLevelAsFirstOperand()
        {
            IUniColour param0 = new GreyscaleColour(_greyLevel);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualsMethodWithIUniColourParameter_ReturnsFalse_IfParameterIsGreyscaleColourObjectWithDifferentGreyLevelToFirstOperand()
        {
            IUniColour param0 = new GreyscaleColour(_rnd.NextDoubleNotInSet(_greyLevel));

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualsMethodWithIUniColourParameter_ReturnsFalse_IfParameterIsNotAGreyscaleColourObject()
        {
            IUniColour param0 = _otherColour.Object;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsNull()
        {
            object param0 = null;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsThis()
        {
            object param0 = _testObject;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsGreyscaleColourObjectWithSameGreyLevelAsFirstOperand()
        {
            object param0 = new GreyscaleColour(_greyLevel);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsGreyscaleColourObjectWithDifferentGreyLevelToFirstOperand()
        {
            object param0 = new GreyscaleColour(_rnd.NextDoubleNotInSet(_greyLevel));

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsNotAGreyscaleColourObject()
        {
            object param0 = _otherColour.Object;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsAString()
        {
            object param0 = "Dim lliw";

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void GreyscaleColourClass_GetHashCodeMethod_ReturnsDifferentValuesForDifferentColours()
        {
            GreyscaleColour altTestObject = new(_rnd.NextDoubleNotInSet(_greyLevel));

            int testOutput0 = _testObject.GetHashCode();
            int testOutput1 = altTestObject.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void GreyscaleColourClass_GetHashCodeMethod_ReturnsSameValueForSameObject()
        {
            int testOutput0 = _testObject.GetHashCode();
            int testOutput1 = _testObject.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void GreyscaleColourClass_GetHashCodeMethod_ReturnsSameValueForEqualObjects()
        {
            GreyscaleColour altTestObject = new(_greyLevel);

            int testOutput0 = _testObject.GetHashCode();
            int testOutput1 = altTestObject.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void GreyscaleColourClass_BlackProperty_HasGreyLevelPropertyEqualToZero()
        {
            Assert.AreEqual(0d, GreyscaleColour.Black.GreyLevel);
        }

        [TestMethod]
        public void GreyscaleColourClass_WhiteProperty_HasGreyLevelPropertyEqualToOne()
        {
            Assert.AreEqual(1d, GreyscaleColour.White.GreyLevel);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
