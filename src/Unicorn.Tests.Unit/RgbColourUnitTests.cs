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
    public class RgbColourUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private double _redLevel;
        private double _greenLevel;
        private double _blueLevel;
        private RgbColour _testObject;
        private Mock<IUniColour> _otherColour;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            _redLevel = _rnd.NextDouble();
            _greenLevel = _rnd.NextDouble();
            _blueLevel = _rnd.NextDouble();
            _otherColour = new Mock<IUniColour>();
            _testObject = new RgbColour(_redLevel, _greenLevel, _blueLevel);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RgbColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfFirstParameterIsNegative()
        {
            _ = new RgbColour(_redLevel * -1, _greenLevel, _blueLevel);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RgbColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfFirstParameterIsGreaterThanOne()
        {
            _ = new RgbColour(_redLevel + 1.00001, _greenLevel, _blueLevel);

            Assert.Fail();
        }

        [TestMethod]
        public void GreyscaleColourClass_Constructor_SetsRedPropertyToValueOfFirstParameter()
        {
            RgbColour testObject = new(_redLevel, _greenLevel, _blueLevel);

            Assert.AreEqual(_redLevel, testObject.Red);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RgbColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfSecondParameterIsNegative()
        {
            _ = new RgbColour(_redLevel, _greenLevel * -1, _blueLevel);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RgbColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfSecondParameterIsGreaterThanOne()
        {
            _ = new RgbColour(_redLevel, _greenLevel + 1.00001, _blueLevel);

            Assert.Fail();
        }

        [TestMethod]
        public void RgbColourClass_Constructor_SetsGreenPropertyToValueOfSecondParameter()
        {
            RgbColour testObject = new(_redLevel, _greenLevel, _blueLevel);

            Assert.AreEqual(_greenLevel, testObject.Green);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RgbColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfThirdParameterIsNegative()
        {
            _ = new RgbColour(_redLevel, _greenLevel, _blueLevel * -1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RgbColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfThirdParameterIsGreaterThanOne()
        {
            _ = new RgbColour(_redLevel, _greenLevel, _blueLevel + 1.00001);

            Assert.Fail();
        }

        [TestMethod]
        public void RgbColourClass_Constructor_SetsBluePropertyToValueOfThirdParameter()
        {
            RgbColour testObject = new(_redLevel, _greenLevel, _blueLevel);

            Assert.AreEqual(_blueLevel, testObject.Blue);
        }

        [TestMethod]
        public void RgbColourClass_ColourSpaceNameProperty_EqualsDeviceRgb()
        {
            Assert.AreEqual("DeviceRGB", _testObject.ColourSpaceName);
        }

        [TestMethod]
        public void RgbColourClass_StrokeSelectionOperatorsMethod_ReturnsEmptySequence_IfParameterIsThis()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_testObject).ToArray();

            Assert.AreEqual(0, testOutput.Length);
        }

        [TestMethod]
        public void RgbColourClass_StrokeSelectionOperatorsMethod_ReturnsEmptySequence_IfParameterIsEqualToThis()
        {
            RgbColour testParam = new(_testObject.Red, _testObject.Green, _testObject.Blue);

            var testOutput = _testObject.StrokeSelectionOperators(testParam).ToArray();

            Assert.AreEqual(0, testOutput.Length);
        }

        [TestMethod]
        public void RgbColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceOfOneItem_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).ToArray();

            Assert.AreEqual(1, testOutput.Length);
        }

        [TestMethod]
        public void RgbColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorRG_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).First();

            Assert.AreEqual("RG", testOutput.Value);
        }

        [TestMethod]
        public void RgbColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithThreeOperands_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).First();

            Assert.AreEqual(3, testOutput.Operands.Count);
        }

        [TestMethod]
        public void RgbColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithFirstOperandEqualToRedProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[0] as PdfReal;
            Assert.AreEqual((decimal)_redLevel, operand.Value);
        }

        [TestMethod]
        public void RgbColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithSecondOperandEqualToGreenProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[1] as PdfReal;
            Assert.AreEqual((decimal)_greenLevel, operand.Value);
        }

        [TestMethod]
        public void RgbColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithThirdOperandEqualToBlueProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[2] as PdfReal;
            Assert.AreEqual((decimal)_blueLevel, operand.Value);
        }

        [TestMethod]
        public void RgbColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceOfOneItem_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).ToArray();

            Assert.AreEqual(1, testOutput.Length);
        }

        [TestMethod]
        public void RgbColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorRG_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).First();

            Assert.AreEqual("RG", testOutput.Value);
        }

        [TestMethod]
        public void RgbColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithThreeOperands_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).First();

            Assert.AreEqual(3, testOutput.Operands.Count);
        }

        [TestMethod]
        public void RgbColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithFirstOperandEqualToRedProperty_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[0] as PdfReal;
            Assert.AreEqual((decimal)_redLevel, operand.Value);
        }

        [TestMethod]
        public void RgbColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithSecondOperandEqualToGreenProperty_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[1] as PdfReal;
            Assert.AreEqual((decimal)_greenLevel, operand.Value);
        }

        [TestMethod]
        public void RgbColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithThirdOperandEqualToBlueProperty_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[2] as PdfReal;
            Assert.AreEqual((decimal)_blueLevel, operand.Value);
        }

        [TestMethod]
        public void RgbColourClass_NonStrokeSelectionOperatorsMethod_ReturnsEmptySequence_IfParameterIsThis()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_testObject).ToArray();

            Assert.AreEqual(0, testOutput.Length);
        }

        [TestMethod]
        public void RgbColourClass_NonStrokeSelectionOperatorsMethod_ReturnsEmptySequence_IfParameterIsEqualToThis()
        {
            RgbColour testParam = new(_testObject.Red, _testObject.Green, _testObject.Blue);

            var testOutput = _testObject.NonStrokeSelectionOperators(testParam).ToArray();

            Assert.AreEqual(0, testOutput.Length);
        }

        [TestMethod]
        public void RgbColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceOfOneItem_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).ToArray();

            Assert.AreEqual(1, testOutput.Length);
        }

        [TestMethod]
        public void RgbColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorrg_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).First();

            Assert.AreEqual("rg", testOutput.Value);
        }

        [TestMethod]
        public void RgbColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithThreeOperands_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).First();

            Assert.AreEqual(3, testOutput.Operands.Count);
        }

        [TestMethod]
        public void RgbColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithFirstOperandEqualToRedProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[0] as PdfReal;
            Assert.AreEqual((decimal)_redLevel, operand.Value);
        }

        [TestMethod]
        public void RgbColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithSecondOperandEqualToGreenProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[1] as PdfReal;
            Assert.AreEqual((decimal)_greenLevel, operand.Value);
        }

        [TestMethod]
        public void RgbColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithThirdOperandEqualToBlueProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[2] as PdfReal;
            Assert.AreEqual((decimal)_blueLevel, operand.Value);
        }

        [TestMethod]
        public void RgbColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceOfOneItem_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).ToArray();

            Assert.AreEqual(1, testOutput.Length);
        }

        [TestMethod]
        public void RgbColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorrg_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).First();

            Assert.AreEqual("rg", testOutput.Value);
        }

        [TestMethod]
        public void RgbColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithThreeOperands_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).First();

            Assert.AreEqual(3, testOutput.Operands.Count);
        }

        [TestMethod]
        public void RgbColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithFirstOperandEqualToRedProperty_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[0] as PdfReal;
            Assert.AreEqual((decimal)_redLevel, operand.Value);
        }

        [TestMethod]
        public void RgbColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithSecondOperandEqualToGreenProperty_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[1] as PdfReal;
            Assert.AreEqual((decimal)_greenLevel, operand.Value);
        }

        [TestMethod]
        public void RgbColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithThirdOperandEqualToBlueProperty_IfParameterIsADifferentIUniColourObject()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[2] as PdfReal;
            Assert.AreEqual((decimal)_blueLevel, operand.Value);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourFirst_ReturnsTrue_IfBothOperandsAreNull()
        {
            RgbColour operand0 = null;
            IUniColour operand1 = null;

#pragma warning disable CA1508 // Avoid dead conditional code
            bool testOutput = operand0 == operand1;
#pragma warning restore CA1508 // Avoid dead conditional code

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourFirst_ReturnsFalse_IfFirstOperandIsNull()
        {
            RgbColour operand0 = null;
            IUniColour operand1 = _otherColour.Object;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourFirst_ReturnsFalse_IfSecondOperandIsNull()
        {
            RgbColour operand0 = _testObject;
            IUniColour operand1 = null;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourFirst_ReturnsFalse_IfSecondOperandIsNotAGreyscaleColourObject()
        {
            RgbColour operand0 = _testObject;
            IUniColour operand1 = _otherColour.Object;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourFirst_ReturnsTrue_IfSecondOperandIsRgbColourObjectWithSameColourLevelsAsFirstOperand()
        {
            RgbColour operand0 = _testObject;
            IUniColour operand1 = new RgbColour(_redLevel, _greenLevel, _blueLevel);

            bool testOutput = operand0 == operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourFirst_ReturnsFalse_IfSecondOperandIsRgbColourObjectWithDifferentRedLevelToFirstOperand()
        {
            RgbColour operand0 = _testObject;
            IUniColour operand1 = new RgbColour(_rnd.NextDoubleNotInSet(_redLevel), _greenLevel, _blueLevel);

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourFirst_ReturnsFalse_IfSecondOperandIsRgbColourObjectWithDifferentGreenLevelToFirstOperand()
        {
            RgbColour operand0 = _testObject;
            IUniColour operand1 = new RgbColour(_redLevel, _rnd.NextDoubleNotInSet(_greenLevel), _blueLevel);

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourFirst_ReturnsFalse_IfSecondOperandIsRgbColourObjectWithDifferentBlueLevelToFirstOperand()
        {
            RgbColour operand0 = _testObject;
            IUniColour operand1 = new RgbColour(_redLevel, _greenLevel, _rnd.NextDoubleNotInSet(_blueLevel));

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourSecond_ReturnsTrue_IfBothOperandsAreNull()
        {
            IUniColour operand0 = null;
            RgbColour operand1 = null;

#pragma warning disable CA1508 // Avoid dead conditional code
            bool testOutput = operand0 == operand1;
#pragma warning restore CA1508 // Avoid dead conditional code

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourSecond_ReturnsFalse_IfFirstOperandIsNull()
        {
            IUniColour operand0 = null;
            RgbColour operand1 = _testObject;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourSecond_ReturnsFalse_IfSecondOperandIsNull()
        {
            IUniColour operand0 = _otherColour.Object;
            RgbColour operand1 = null;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourSecond_ReturnsFalse_IfFirstOperandIsNotAGreyscaleColourObject()
        {
            IUniColour operand0 = _otherColour.Object;
            RgbColour operand1 = _testObject;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourSecond_ReturnsTrue_IfSecondOperandIsRgbColourObjectWithSameColourLevelsAsFirstOperand()
        {
            IUniColour operand0 = _testObject;
            RgbColour operand1 = new(_redLevel, _greenLevel, _blueLevel);

            bool testOutput = operand0 == operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourSecond_ReturnsFalse_IfSecondOperandIsRgbColourObjectWithDifferentRedLevelToFirstOperand()
        {
            IUniColour operand0 = _testObject;
            RgbColour operand1 = new(_rnd.NextDoubleNotInSet(_redLevel), _greenLevel, _blueLevel);

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourSecond_ReturnsFalse_IfSecondOperandIsRgbColourObjectWithDifferentGreenLevelToFirstOperand()
        {
            IUniColour operand0 = _testObject;
            RgbColour operand1 = new(_redLevel, _rnd.NextDoubleNotInSet(_greenLevel), _blueLevel);

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualityOperatorWithRgbColourSecond_ReturnsFalse_IfSecondOperandIsRgbColourObjectWithDifferentBlueLevelToFirstOperand()
        {
            IUniColour operand0 = _testObject;
            RgbColour operand1 = new(_redLevel, _greenLevel, _rnd.NextDoubleNotInSet(_blueLevel));

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourFirst_ReturnsFalse_IfBothOperandsAreNull()
        {
            RgbColour operand0 = null;
            IUniColour operand1 = null;

#pragma warning disable CA1508 // Avoid dead conditional code
            bool testOutput = operand0 != operand1;
#pragma warning restore CA1508 // Avoid dead conditional code

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourFirst_ReturnsTrue_IfFirstOperandIsNull()
        {
            RgbColour operand0 = null;
            IUniColour operand1 = _otherColour.Object;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourFirst_ReturnsTrue_IfSecondOperandIsNull()
        {
            RgbColour operand0 = _testObject;
            IUniColour operand1 = null;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourFirst_ReturnsTrue_IfSecondOperandIsNotAnRgbColourObject()
        {
            RgbColour operand0 = _testObject;
            IUniColour operand1 = _otherColour.Object;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourFirst_ReturnsFalse_IfSecondOperandIsRgbColourObjectWithSameGreyLevelAsFirstOperand()
        {
            RgbColour operand0 = _testObject;
            IUniColour operand1 = new RgbColour(_redLevel, _greenLevel, _blueLevel);

            bool testOutput = operand0 != operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourFirst_ReturnsTruee_IfSecondOperandIsRgbColourObjectWithDifferentRedLevelToFirstOperand()
        {
            RgbColour operand0 = _testObject;
            IUniColour operand1 = new RgbColour(_rnd.NextDoubleNotInSet(_redLevel), _greenLevel, _blueLevel);

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourFirst_ReturnsTruee_IfSecondOperandIsRgbColourObjectWithDifferentGreenLevelToFirstOperand()
        {
            RgbColour operand0 = _testObject;
            IUniColour operand1 = new RgbColour(_redLevel, _rnd.NextDoubleNotInSet(_greenLevel), _blueLevel);

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourFirst_ReturnsTruee_IfSecondOperandIsRgbColourObjectWithDifferentBlueLevelToFirstOperand()
        {
            RgbColour operand0 = _testObject;
            IUniColour operand1 = new RgbColour(_redLevel, _greenLevel, _rnd.NextDoubleNotInSet(_blueLevel));

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourSecond_ReturnsFalse_IfBothOperandsAreNull()
        {
            IUniColour operand0 = null;
            RgbColour operand1 = null;

#pragma warning disable CA1508 // Avoid dead conditional code
            bool testOutput = operand0 != operand1;
#pragma warning restore CA1508 // Avoid dead conditional code

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourSecond_ReturnsTrue_IfFirstOperandIsNull()
        {
            IUniColour operand0 = null;
            RgbColour operand1 = _testObject;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourSecond_ReturnsTrue_IfSecondOperandIsNull()
        {
            IUniColour operand0 = _otherColour.Object;
            RgbColour operand1 = null;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourSecond_ReturnsTrue_IfFirstOperandIsNotAGreyscaleColourObject()
        {
            IUniColour operand0 = _otherColour.Object;
            RgbColour operand1 = _testObject;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourSecond_ReturnsFalse_IfSecondOperandIsRgbColourObjectWithSameColourLevelsAsFirstOperand()
        {
            IUniColour operand0 = _testObject;
            RgbColour operand1 = new(_redLevel, _greenLevel, _blueLevel);

            bool testOutput = operand0 != operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourSecond_ReturnsTrue_IfSecondOperandIsRgbColourObjectWithDifferentRedLevelToFirstOperand()
        {
            IUniColour operand0 = _testObject;
            RgbColour operand1 = new(_rnd.NextDoubleNotInSet(_redLevel), _greenLevel, _blueLevel);

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourSecond_ReturnsTrue_IfSecondOperandIsRgbColourObjectWithDifferentGreenLevelToFirstOperand()
        {
            IUniColour operand0 = _testObject;
            RgbColour operand1 = new(_redLevel, _rnd.NextDoubleNotInSet(_greenLevel), _blueLevel);

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_InequalityOperatorWithRgbColourSecond_ReturnsTrue_IfSecondOperandIsRgbColourObjectWithDifferentBlueLevelToFirstOperand()
        {
            IUniColour operand0 = _testObject;
            RgbColour operand1 = new(_redLevel, _greenLevel, _rnd.NextDoubleNotInSet(_blueLevel));

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithIUniColourParameter_ReturnsFalse_IfParameterIsNull()
        {
            IUniColour param0 = null;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithIUniColourParameter_ReturnsTrue_IfParameterIsThis()
        {
            IUniColour param0 = _testObject;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithIUniColourParameter_ReturnsTrue_IfParameterIsRgbColourObjectWithSameColourLevelsAsFirstOperand()
        {
            IUniColour param0 = new RgbColour(_redLevel, _greenLevel, _blueLevel);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithIUniColourParameter_ReturnsFalse_IfParameterIsRgbColourObjectWithDifferentRedLevelToFirstOperand()
        {
            IUniColour param0 = new RgbColour(_rnd.NextDoubleNotInSet(_redLevel), _greenLevel, _blueLevel);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithIUniColourParameter_ReturnsFalse_IfParameterIsRgbColourObjectWithDifferentGreenLevelToFirstOperand()
        {
            IUniColour param0 = new RgbColour(_redLevel, _rnd.NextDoubleNotInSet(_greenLevel), _blueLevel);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithIUniColourParameter_ReturnsFalse_IfParameterIsRgbColourObjectWithDifferentBlueLevelToFirstOperand()
        {
            IUniColour param0 = new RgbColour(_redLevel, _greenLevel, _rnd.NextDoubleNotInSet(_blueLevel));

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithIUniColourParameter_ReturnsFalse_IfParameterIsNotAnRgbColourObject()
        {
            IUniColour param0 = _otherColour.Object;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsNull()
        {
            object param0 = null;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsThis()
        {
            object param0 = _testObject;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsRgbColourObjectWithSameColourLevelsAsFirstOperand()
        {
            object param0 = new RgbColour(_redLevel, _greenLevel, _blueLevel);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsRgbColourObjectWithDifferentRedLevelToFirstOperand()
        {
            object param0 = new RgbColour(_rnd.NextDoubleNotInSet(_redLevel), _greenLevel, _blueLevel);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsRgbColourObjectWithDifferentGreenLevelToFirstOperand()
        {
            object param0 = new RgbColour(_redLevel, _rnd.NextDoubleNotInSet(_greenLevel), _blueLevel);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsRgbColourObjectWithDifferentBlueLevelToFirstOperand()
        {
            object param0 = new RgbColour(_redLevel, _greenLevel, _rnd.NextDoubleNotInSet(_blueLevel));

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsNotARgbColourObject()
        {
            object param0 = _otherColour.Object;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsAString()
        {
            object param0 = "Dim lliw";

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void RgbColourClass_GetHashCodeMethod_ReturnsDifferentValuesForDifferentColours()
        {
            RgbColour altTestObject = new(_rnd.NextDoubleNotInSet(_redLevel), _rnd.NextDoubleNotInSet(_greenLevel), _rnd.NextDoubleNotInSet(_blueLevel));

            int testOutput0 = _testObject.GetHashCode();
            int testOutput1 = altTestObject.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void RgbColourClass_GetHashCodeMethod_ReturnsSameValueForSameObject()
        {
            int testOutput0 = _testObject.GetHashCode();
            int testOutput1 = _testObject.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void RgbColourClass_GetHashCodeMethod_ReturnsSameValueForEqualObjects()
        {
            RgbColour altTestObject = new(_redLevel, _greenLevel, _blueLevel);

            int testOutput0 = _testObject.GetHashCode();
            int testOutput1 = altTestObject.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
