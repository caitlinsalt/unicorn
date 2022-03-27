using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Base;
using Unicorn.Writer.Primitives;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class CmykColourUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private double _cyanValue;
        private double _magentaValue;
        private double _yellowValue;
        private double _blackValue;
        private CmykColour _testObject;
        private Mock<IUniColour> _otherColour;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            _cyanValue = _rnd.NextDouble();
            _magentaValue = _rnd.NextDouble();
            _blackValue = _rnd.NextDouble();
            _yellowValue = _rnd.NextDouble();
            _testObject = new CmykColour(_cyanValue, _magentaValue, _yellowValue, _blackValue);
            _otherColour = new Mock<IUniColour>();
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CmykColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfFirstParameterIsNegative()
        {
            _ = new CmykColour(_cyanValue * -1, _magentaValue, _yellowValue, _blackValue);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CmykColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfFirstParameterIsGreaterThanOne()
        {
            _ = new CmykColour(_cyanValue + 1, _magentaValue, _yellowValue, _blackValue);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CmykColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfSecondParameterIsNegative()
        {
            _ = new CmykColour(_cyanValue, _magentaValue * -1, _yellowValue, _blackValue);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CmykColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfSecondParameterIsGreaterThanOne()
        {
            _ = new CmykColour(_cyanValue, _magentaValue + 1, _yellowValue, _blackValue);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CmykColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfThirdParameterIsNegative()
        {
            _ = new CmykColour(_cyanValue, _magentaValue, _yellowValue * -1, _blackValue);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CmykColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfThirdParameterIsGreaterThanOne()
        {
            _ = new CmykColour(_cyanValue, _magentaValue, _yellowValue + 1, _blackValue);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CmykColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfFourthParameterIsNegative()
        {
            _ = new CmykColour(_cyanValue, _magentaValue, _yellowValue, _blackValue * -1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CmykColourClass_Constructor_ThrowsArgumentOutOfRangeException_IfFourthParameterIsGreaterThanOne()
        {
            _ = new CmykColour(_cyanValue, _magentaValue, _yellowValue, _blackValue + 1);

            Assert.Fail();
        }

        [TestMethod]
        public void CmykColourClass_Constructor_SetsCyanPropertyToValueOfFirstParameter()
        {
            CmykColour testObject = new(_cyanValue, _magentaValue, _yellowValue, _blackValue);

            Assert.AreEqual(_cyanValue, testObject.Cyan);
        }

        [TestMethod]
        public void CmykColourClass_Constructor_SetsMagentaPropertyToValueOfSecondParameter()
        {
            CmykColour testObject = new(_cyanValue, _magentaValue, _yellowValue, _blackValue);

            Assert.AreEqual(_magentaValue, testObject.Magenta);
        }

        [TestMethod]
        public void CmykColourClass_Constructor_SetsYellowPropertyToValueOfThirdParameter()
        {
            CmykColour testObject = new(_cyanValue, _magentaValue, _yellowValue, _blackValue);

            Assert.AreEqual(_yellowValue, testObject.Yellow);
        }

        [TestMethod]
        public void CmykColourClass_Constructor_SetsBlackPropertyToValueOfFourthParameter()
        {
            CmykColour testObject = new(_cyanValue, _magentaValue, _yellowValue, _blackValue);

            Assert.AreEqual(_blackValue, testObject.Black);
        }

        [TestMethod]
        public void CmykColourClass_ColourSpaceNameProperty_EqualsDeviceCmyk()
        {
            Assert.AreEqual("DeviceCMYK", _testObject.ColourSpaceName);
        }

        [TestMethod]
        public void CmykColourClass_BitsPerComponentProperty_Equals8()
        {
            Assert.AreEqual(8, _testObject.BitsPerComponent);
        }

        [TestMethod]
        public void CmykColourClass_ComponentDataProperty_HasFourElements()
        {
            IEnumerable<byte> testOutput = _testObject.ComponentData;

            Assert.AreEqual(4, testOutput.Count());
        }

        [TestMethod]
        public void CmykColourClass_ComponentDataProperty_FirstElementIsEqualToExpectedValue()
        {
            int expectedValue = _rnd.Next(byte.MaxValue + 1);
            var testObject = new CmykColour(expectedValue / 256d, _testObject.Magenta, _testObject.Yellow, _testObject.Black);

            IEnumerable<byte> testOutput = testObject.ComponentData;

            Assert.AreEqual(expectedValue, testOutput.First());
        }

        [TestMethod]
        public void CmykColourClass_ComponentDataProperty_SecondElementIsEqualToExpectedValue()
        {
            int expectedValue = _rnd.Next(byte.MaxValue);
            var testObject = new CmykColour(_testObject.Cyan, expectedValue / 256d, _testObject.Yellow, _testObject.Black);

            IEnumerable<byte> testOutput = testObject.ComponentData;

            Assert.AreEqual(expectedValue, testOutput.Skip(1).First());
        }

        [TestMethod]
        public void CmykColourClass_ComponentDataProperty_ThirdElementIsEqualToExpectedValue()
        {
            int expectedValue = _rnd.Next(byte.MaxValue);
            var testObject = new CmykColour(_testObject.Cyan, _testObject.Magenta, expectedValue / 256d, _testObject.Black);

            IEnumerable<byte> testOutput = testObject.ComponentData;

            Assert.AreEqual(expectedValue, testOutput.Skip(2).First());
        }

        [TestMethod]
        public void CmykColourClass_ComponentDataProperty_FourthElementIsEqualToExpectedValue()
        {
            int expectedValue = _rnd.Next(byte.MaxValue);
            var testObject = new CmykColour(_testObject.Cyan, _testObject.Magenta, _testObject.Yellow, expectedValue / 256d);

            IEnumerable<byte> testOutput = testObject.ComponentData;

            Assert.AreEqual(expectedValue, testOutput.Skip(3).First());
        }

#pragma warning restore CA5394 // Do not use insecure randomness

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsEmptySequence_IfParameterIsThis()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_testObject).ToArray();

            Assert.AreEqual(0, testOutput.Length);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsEmptySequence_IfParameterIsEqualToThis()
        {
            var testParam = new CmykColour(_cyanValue, _magentaValue, _yellowValue, _blackValue);

            var testOutput = _testObject.StrokeSelectionOperators(testParam).ToArray();

            Assert.AreEqual(0, testOutput.Length);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceOfOneElement_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).ToArray();

            Assert.AreEqual(1, testOutput.Length);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorK_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).First();

            Assert.AreEqual("K", testOutput.Value);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContaininsPdfOperatorWithFourOperands_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).First();

            Assert.AreEqual(4, testOutput.Operands.Count);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithFirstOperandEqualToCyanProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[0] as PdfReal;
            Assert.AreEqual((decimal)_cyanValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithSecondOperandEqualToMagentaProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[1] as PdfReal;
            Assert.AreEqual((decimal)_magentaValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithThirdOperandEqualToYellowProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[2] as PdfReal;
            Assert.AreEqual((decimal)_yellowValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithFourthOperandEqualToBlackProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.StrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[3] as PdfReal;
            Assert.AreEqual((decimal)_blackValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceOfOneElement_IfParameterIsAnotherColour()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).ToArray();

            Assert.AreEqual(1, testOutput.Length);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorK_IfParameterIsAnotherColour()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).First();

            Assert.AreEqual("K", testOutput.Value);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContaininsPdfOperatorWithFourOperands_IfParameterIsAnotherColour()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).First();

            Assert.AreEqual(4, testOutput.Operands.Count);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithFirstOperandEqualToCyanProperty_IfParameterIsAnotherColour()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[0] as PdfReal;
            Assert.AreEqual((decimal)_cyanValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithSecondOperandEqualToMagentaProperty_IfParameterIsAnotherColour()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[1] as PdfReal;
            Assert.AreEqual((decimal)_magentaValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithThirdOperandEqualToYellowProperty_IfParameterIsAnotherColour()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[2] as PdfReal;
            Assert.AreEqual((decimal)_yellowValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_StrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithFourthOperandEqualToBlackProperty_IfParameterIsAnotherColour()
        {
            var testOutput = _testObject.StrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[3] as PdfReal;
            Assert.AreEqual((decimal)_blackValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsEmptySequence_IfParameterIsThis()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_testObject).ToArray();

            Assert.AreEqual(0, testOutput.Length);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsEmptySequence_IfParameterIsEqualToThis()
        {
            var testParam = new CmykColour(_cyanValue, _magentaValue, _yellowValue, _blackValue);

            var testOutput = _testObject.NonStrokeSelectionOperators(testParam).ToArray();

            Assert.AreEqual(0, testOutput.Length);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceOfOneElement_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).ToArray();

            Assert.AreEqual(1, testOutput.Length);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatork_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).First();

            Assert.AreEqual("k", testOutput.Value);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContaininsPdfOperatorWithFourOperands_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).First();

            Assert.AreEqual(4, testOutput.Operands.Count);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithFirstOperandEqualToCyanProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[0] as PdfReal;
            Assert.AreEqual((decimal)_cyanValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithSecondOperandEqualToMagentaProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[1] as PdfReal;
            Assert.AreEqual((decimal)_magentaValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithThirdOperandEqualToYellowProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[2] as PdfReal;
            Assert.AreEqual((decimal)_yellowValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithFourthOperandEqualToBlackProperty_IfParameterIsNull()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(null).First();

            var operand = testOutput.Operands[3] as PdfReal;
            Assert.AreEqual((decimal)_blackValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceOfOneElement_IfParameterIsAnotherColour()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).ToArray();

            Assert.AreEqual(1, testOutput.Length);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatork_IfParameterIsAnotherColour()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).First();

            Assert.AreEqual("k", testOutput.Value);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContaininsPdfOperatorWithFourOperands_IfParameterIsAnotherColour()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).First();

            Assert.AreEqual(4, testOutput.Operands.Count);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithFirstOperandEqualToCyanProperty_IfParameterIsAnotherColour()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[0] as PdfReal;
            Assert.AreEqual((decimal)_cyanValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithSecondOperandEqualToMagentaProperty_IfParameterIsAnotherColour()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[1] as PdfReal;
            Assert.AreEqual((decimal)_magentaValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithThirdOperandEqualToYellowProperty_IfParameterIsAnotherColour()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[2] as PdfReal;
            Assert.AreEqual((decimal)_yellowValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_NonStrokeSelectionOperatorsMethod_ReturnsSequenceContainingPdfOperatorWithFourthOperandEqualToBlackProperty_IfParameterIsAnotherColour()
        {
            var testOutput = _testObject.NonStrokeSelectionOperators(_otherColour.Object).First();

            var operand = testOutput.Operands[3] as PdfReal;
            Assert.AreEqual((decimal)_blackValue, operand.Value);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourFirst_ReturnsTrue_IfBothOperandsAreNull()
        {
            CmykColour operand0 = null;
            IUniColour operand1 = null;

#pragma warning disable CA1508 // Avoid dead conditional code
            bool testOutput = operand0 == operand1;
#pragma warning restore CA1508 // Avoid dead conditional code

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourFirst_ReturnsFalse_IfFirstOperandIsNull()
        {
            CmykColour operand0 = null;
            IUniColour operand1 = _otherColour.Object;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourFirst_ReturnsFalse_IfSecondOperandIsNull()
        {
            CmykColour operand0 = _testObject;
            IUniColour operand1 = null;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourFirst_ReturnsTrue_IfSecondOperandIsCmykColourObjectWithSameColourLevels()
        {
            CmykColour operand0 = _testObject;
            IUniColour operand1 = new CmykColour(_testObject.Cyan, _testObject.Magenta, _testObject.Yellow, _testObject.Black);

            bool testOutput = operand0 == operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourFirst_ReturnsFalse_IfSecondOperandIsCmykColourObjectWithDifferentCyanLevel()
        {
            CmykColour operand0 = _testObject;
            IUniColour operand1 = new CmykColour(_rnd.NextDoubleNotInSet(_testObject.Cyan), _testObject.Magenta, _testObject.Yellow, _testObject.Black);

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourFirst_ReturnsFalse_IfSecondOperandIsCmykColourObjectWithDifferentMagentaLevel()
        {
            CmykColour operand0 = _testObject;
            IUniColour operand1 = new CmykColour(_testObject.Cyan, _rnd.NextDoubleNotInSet(_testObject.Magenta), _testObject.Yellow, _testObject.Black);

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourFirst_ReturnsFalse_IfSecondOperandIsCmykColourObjectWithDifferentYellowLevel()
        {
            CmykColour operand0 = _testObject;
            IUniColour operand1 = new CmykColour(_testObject.Cyan, _testObject.Magenta, _rnd.NextDoubleNotInSet(_testObject.Yellow), _testObject.Black);

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourFirst_ReturnsFalse_IfSecondOperandIsCmykColourObjectWithDifferentBlackLevel()
        {
            CmykColour operand0 = _testObject;
            IUniColour operand1 = new CmykColour(_testObject.Cyan, _testObject.Magenta, _testObject.Yellow, _rnd.NextDoubleNotInSet(_testObject.Black));

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourSecond_ReturnsTrue_IfBothOperandsAreNull()
        {
            IUniColour operand0 = null;
            CmykColour operand1 = null;

#pragma warning disable CA1508 // Avoid dead conditional code
            bool testOutput = operand0 == operand1;
#pragma warning restore CA1508 // Avoid dead conditional code

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourSecond_ReturnsFalse_IfFirstOperandIsNull()
        {
            IUniColour operand0 = null;
            CmykColour operand1 = _testObject;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourSecond_ReturnsFalse_IfSecondOperandIsNull()
        {
            IUniColour operand0 = _otherColour.Object;
            CmykColour operand1 = null;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourSecond_ReturnsTrue_IfSecondOperandIsCmykColourObjectWithSameColourLevels()
        {
            IUniColour operand0 = _testObject;
            CmykColour operand1 = new(_testObject.Cyan, _testObject.Magenta, _testObject.Yellow, _testObject.Black);

            bool testOutput = operand0 == operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourSecond_ReturnsFalse_IfSecondOperandIsCmykColourObjectWithDifferentCyanLevel()
        {
            IUniColour operand0 = _testObject;
            CmykColour operand1 = new(_rnd.NextDoubleNotInSet(_testObject.Cyan), _testObject.Magenta, _testObject.Yellow, _testObject.Black);

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourSecond_ReturnsFalse_IfSecondOperandIsCmykColourObjectWithDifferentMagentaLevel()
        {
            IUniColour operand0 = _testObject;
            CmykColour operand1 = new(_testObject.Cyan, _rnd.NextDoubleNotInSet(_testObject.Magenta), _testObject.Yellow, _testObject.Black);

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourSecond_ReturnsFalse_IfSecondOperandIsCmykColourObjectWithDifferentYellowLevel()
        {
            IUniColour operand0 = _testObject;
            CmykColour operand1 = new(_testObject.Cyan, _testObject.Magenta, _rnd.NextDoubleNotInSet(_testObject.Yellow), _testObject.Black);

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualityOperatorWithCmykColourSecond_ReturnsFalse_IfSecondOperandIsCmykColourObjectWithDifferentBlackLevel()
        {
            IUniColour operand0 = _testObject;
            CmykColour operand1 = new(_testObject.Cyan, _testObject.Magenta, _testObject.Yellow, _rnd.NextDoubleNotInSet(_testObject.Black));

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourFirst_ReturnsFalse_IfBothOperandsAreNull()
        {
            CmykColour operand0 = null;
            IUniColour operand1 = null;

#pragma warning disable CA1508 // Avoid dead conditional code
            bool testOutput = operand0 != operand1;
#pragma warning restore CA1508 // Avoid dead conditional code

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourFirst_ReturnsTrue_IfFirstOperandIsNull()
        {
            CmykColour operand0 = null;
            IUniColour operand1 = _otherColour.Object;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourFirst_ReturnsTrue_IfSecondOperandIsNull()
        {
            CmykColour operand0 = _testObject;
            IUniColour operand1 = null;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourFirst_ReturnsFalse_IfSecondOperandIsCmykColourObjectWithSameColourLevels()
        {
            CmykColour operand0 = _testObject;
            IUniColour operand1 = new CmykColour(_testObject.Cyan, _testObject.Magenta, _testObject.Yellow, _testObject.Black);

            bool testOutput = operand0 != operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourFirst_ReturnsTrue_IfSecondOperandIsCmykColourObjectWithDifferentCyanLevel()
        {
            CmykColour operand0 = _testObject;
            IUniColour operand1 = new CmykColour(_rnd.NextDoubleNotInSet(_testObject.Cyan), _testObject.Magenta, _testObject.Yellow, _testObject.Black);

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourFirst_ReturnsTrue_IfSecondOperandIsCmykColourObjectWithDifferentMagentaLevel()
        {
            CmykColour operand0 = _testObject;
            IUniColour operand1 = new CmykColour(_testObject.Cyan, _rnd.NextDoubleNotInSet(_testObject.Magenta), _testObject.Yellow, _testObject.Black);

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourFirst_ReturnsTrue_IfSecondOperandIsCmykColourObjectWithDifferentYellowLevel()
        {
            CmykColour operand0 = _testObject;
            IUniColour operand1 = new CmykColour(_testObject.Cyan, _testObject.Magenta, _rnd.NextDoubleNotInSet(_testObject.Yellow), _testObject.Black);

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourFirst_ReturnsTrue_IfSecondOperandIsCmykColourObjectWithDifferentBlackLevel()
        {
            CmykColour operand0 = _testObject;
            IUniColour operand1 = new CmykColour(_testObject.Cyan, _testObject.Magenta, _testObject.Yellow, _rnd.NextDoubleNotInSet(_testObject.Black));

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourSecond_ReturnsFalse_IfBothOperandsAreNull()
        {
            IUniColour operand0 = null;
            CmykColour operand1 = null;

#pragma warning disable CA1508 // Avoid dead conditional code
            bool testOutput = operand0 != operand1;
#pragma warning restore CA1508 // Avoid dead conditional code

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourSecond_ReturnsTrue_IfFirstOperandIsNull()
        {
            IUniColour operand0 = null;
            CmykColour operand1 = _testObject;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourSecond_ReturnsTrue_IfSecondOperandIsNull()
        {
            IUniColour operand0 = _otherColour.Object;
            CmykColour operand1 = null;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourSecond_ReturnsFalse_IfSecondOperandIsCmykColourObjectWithSameColourLevels()
        {
            IUniColour operand0 = _testObject;
            CmykColour operand1 = new(_testObject.Cyan, _testObject.Magenta, _testObject.Yellow, _testObject.Black);

            bool testOutput = operand0 != operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourSecond_ReturnsTrue_IfSecondOperandIsCmykColourObjectWithDifferentCyanLevel()
        {
            IUniColour operand0 = _testObject;
            CmykColour operand1 = new(_rnd.NextDoubleNotInSet(_testObject.Cyan), _testObject.Magenta, _testObject.Yellow, _testObject.Black);

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourSecond_ReturnsTrue_IfSecondOperandIsCmykColourObjectWithDifferentMagentaLevel()
        {
            IUniColour operand0 = _testObject;
            CmykColour operand1 = new(_testObject.Cyan, _rnd.NextDoubleNotInSet(_testObject.Magenta), _testObject.Yellow, _testObject.Black);

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourSecond_ReturnsTrue_IfSecondOperandIsCmykColourObjectWithDifferentYellowLevel()
        {
            IUniColour operand0 = _testObject;
            CmykColour operand1 = new(_testObject.Cyan, _testObject.Magenta, _rnd.NextDoubleNotInSet(_testObject.Yellow), _testObject.Black);

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_InequalityOperatorWithCmykColourSecond_ReturnsTrue_IfSecondOperandIsCmykColourObjectWithDifferentBlackLevel()
        {
            IUniColour operand0 = _testObject;
            CmykColour operand1 = new(_testObject.Cyan, _testObject.Magenta, _testObject.Yellow, _rnd.NextDoubleNotInSet(_testObject.Black));

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithIUniColourParameter_ReturnsFalse_IfParameterIsNull()
        {
            IUniColour param0 = null;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithIUniColourParameter_ReturnsFalse_IfParameterIsNotACmykColourObject()
        {
            IUniColour param0 = _otherColour.Object;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithIUniColourParameter_ReturnsTrue_IfParameterIsThis()
        {
            bool testOutput = _testObject.Equals(_testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithIUniColourParameter_ReturnsTrue_IfParameterIsCmykColourObjectWithSameColourLevels()
        {
            IUniColour param0 = new CmykColour(_testObject.Cyan, _testObject.Magenta, _testObject.Yellow, _testObject.Black);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColour_EqualsMethodWithIUniColourParameter_ReturnsFalse_IfParameterIsCmykColourObjectWithDifferentCyanLevel()
        {
            IUniColour param0 = new CmykColour(_rnd.NextDoubleNotInSet(_testObject.Cyan), _testObject.Magenta, _testObject.Yellow, _testObject.Black);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithIUniColourParameter_ReturnsFalse_IfParameterIsCmykColourObjectWithDifferentMagentaLevel()
        {
            IUniColour param0 = new CmykColour(_testObject.Cyan, _rnd.NextDoubleNotInSet(_testObject.Magenta), _testObject.Yellow, _testObject.Black);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithIUniColourParameter_ReturnsFalse_IfParameterIsCmykColourObjectWithDifferentYellowLevel()
        {
            IUniColour param0 = new CmykColour(_testObject.Cyan, _testObject.Magenta, _rnd.NextDoubleNotInSet(_testObject.Yellow), _testObject.Black);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithIUniColourParameter_ReturnsFalse_IfParameterIsCmykColourObjectWithDifferentBlackLevel()
        {
            IUniColour param0 = new CmykColour(_testObject.Cyan, _testObject.Magenta, _testObject.Yellow, _rnd.NextDoubleNotInSet(_testObject.Black));

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsNull()
        {
            object param0 = null;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsNotACmykColourObject()
        {
            object param0 = _otherColour.Object;

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsNotAnIUniColourObject()
        {
            object param0 = "Dim lliw";

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsThis()
        {
            bool testOutput = _testObject.Equals((object)_testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsCmykColourObjectWithSameColourLevels()
        {
            object param0 = new CmykColour(_testObject.Cyan, _testObject.Magenta, _testObject.Yellow, _testObject.Black);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsCmykColourObjectWithDifferentCyanLevel()
        {
            object param0 = new CmykColour(_rnd.NextDoubleNotInSet(_testObject.Cyan), _testObject.Magenta, _testObject.Yellow, _testObject.Black);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsCmykColourObjectWithDifferentMagentaLevel()
        {
            object param0 = new CmykColour(_testObject.Cyan, _rnd.NextDoubleNotInSet(_testObject.Magenta), _testObject.Yellow, _testObject.Black);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsCmykColourObjectWithDifferentYellowLevel()
        {
            object param0 = new CmykColour(_testObject.Cyan, _testObject.Magenta, _rnd.NextDoubleNotInSet(_testObject.Yellow), _testObject.Black);

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void CmykColourClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsCmykColourObjectWithDifferentBlackLevel()
        {
            object param0 = new CmykColour(_testObject.Cyan, _testObject.Magenta, _testObject.Yellow, _rnd.NextDoubleNotInSet(_testObject.Black));

            bool testOutput = _testObject.Equals(param0);

            Assert.IsFalse(testOutput);
        }

        // Warning: this method has an approx 1/2bn chance of failing due to hash collision.
        [TestMethod]
        public void CmykColourClass_GetHashCodeMethod_ReturnsDifferentValueForTwoDifferentColours()
        {
            CmykColour altTestObject = new(_rnd.NextDoubleNotInSet(_testObject.Cyan), _rnd.NextDoubleNotInSet(_testObject.Magenta), 
                _rnd.NextDoubleNotInSet(_testObject.Yellow), _rnd.NextDoubleNotInSet(_testObject.Black));

            int testOutput0 = _testObject.GetHashCode();
            int testOutput1 = altTestObject.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void CmykColourClass_GetHashCodeMethod_ReturnsSameValueWhenCalledTwiceOnSameObject()
        {
            int testOutput0 = _testObject.GetHashCode();
            int testOutput1 = _testObject.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void CmykColourClass_GetHashCodeMethod_ReturnsSameValueWhenCalledOnEqualObjects()
        {
            CmykColour altTestObject = new(_testObject.Cyan, _testObject.Magenta, _testObject.Yellow, _testObject.Black);

            int testOutput0 = _testObject.GetHashCode();
            int testOutput1 = altTestObject.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
