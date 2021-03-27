using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Afm;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class DirectionMetricsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DirectionMetricsStruct_ParameterlessConstructor_SetsUnderlinePositionPropertyToNull()
        {
            DirectionMetrics testOutput = new DirectionMetrics();

            Assert.IsNull(testOutput.UnderlinePosition);
        }

        [TestMethod]
        public void DirectionMetricsStruct_ParameterlessConstructor_SetsUnderlineThicknessPropertyToNull()
        {
            DirectionMetrics testOutput = new DirectionMetrics();

            Assert.IsNull(testOutput.UnderlineThickness);
        }

        [TestMethod]
        public void DirectionMetricsStruct_ParameterlessConstructor_SetsItalicAnglePropertyToNull()
        {
            DirectionMetrics testOutput = new DirectionMetrics();

            Assert.IsNull(testOutput.ItalicAngle);
        }

        [TestMethod]
        public void DirectionMetricsStruct_ParameterlessConstructor_SetsCharWidthPropertyToNull()
        {
            DirectionMetrics testOutput = new DirectionMetrics();

            Assert.IsNull(testOutput.CharWidth);
        }

        [TestMethod]
        public void DirectionMetricsStruct_ParameterlessConstructor_SetsIsFixedWidthPropertyToFalse()
        {
            DirectionMetrics testOutput = new DirectionMetrics();

            Assert.IsFalse(testOutput.IsFixedPitch);
        }

        [TestMethod]
        public void DirectionMetricsStruct_ConstructorWithThreeNullableDecimalNullableVectorAndNullableBoolParameters_SetsUnderlinePositionPropertyToValueOfFirstParameter()
        {
            decimal? testParam0 = _rnd.NextDecimal();
            decimal? testParam1 = _rnd.NextDecimal();
            decimal? testParam2 = _rnd.NextDecimal();
            Vector? testParam3 = _rnd.NextNullableAfmVector();
            bool? testParam4 = _rnd.NextNullableBoolean();

            DirectionMetrics testOutput = new DirectionMetrics(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam0, testOutput.UnderlinePosition);
        }

        [TestMethod]
        public void DirectionMetricsStruct_ConstructorWithThreeNullableDecimalNullableVectorAndNullableBoolParameters_SetsUnderlineThicknessPropertyToValueOfSecondParameter()
        {
            decimal? testParam0 = _rnd.NextDecimal();
            decimal? testParam1 = _rnd.NextDecimal();
            decimal? testParam2 = _rnd.NextDecimal();
            Vector? testParam3 = _rnd.NextNullableAfmVector();
            bool? testParam4 = _rnd.NextNullableBoolean();

            DirectionMetrics testOutput = new DirectionMetrics(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam1, testOutput.UnderlineThickness);
        }

        [TestMethod]
        public void DirectionMetricsStruct_ConstructorWithThreeNullableDecimalNullableVectorAndNullableBoolParameters_SetsItalicAnglePropertyToValueOfThirdParameter()
        {
            decimal? testParam0 = _rnd.NextDecimal();
            decimal? testParam1 = _rnd.NextDecimal();
            decimal? testParam2 = _rnd.NextDecimal();
            Vector? testParam3 = _rnd.NextNullableAfmVector();
            bool? testParam4 = _rnd.NextNullableBoolean();

            DirectionMetrics testOutput = new DirectionMetrics(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam2, testOutput.ItalicAngle);
        }

        [TestMethod]
        public void DirectionMetricsStruct_ConstructorWithThreeNullableDecimalNullableVectorAndNullableBoolParameters_SetsCharWidthPropertyToValueOfFourthParameter()
        {
            decimal? testParam0 = _rnd.NextDecimal();
            decimal? testParam1 = _rnd.NextDecimal();
            decimal? testParam2 = _rnd.NextDecimal();
            Vector? testParam3 = _rnd.NextNullableAfmVector();
            bool? testParam4 = _rnd.NextNullableBoolean();

            DirectionMetrics testOutput = new DirectionMetrics(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam3, testOutput.CharWidth);
        }

        [TestMethod]
        public void DirectionMetricsStruct_ConstructorWithThreeNullableDecimalNullableVectorAndNullableBoolParameters_SetsIsFixedPitchPropertyToValueOfFifthParameter_IfFifthParameterIsNotNull()
        {
            decimal? testParam0 = _rnd.NextDecimal();
            decimal? testParam1 = _rnd.NextDecimal();
            decimal? testParam2 = _rnd.NextDecimal();
            Vector? testParam3 = _rnd.NextNullableAfmVector();
            bool? testParam4 = _rnd.NextBoolean();

            DirectionMetrics testOutput = new DirectionMetrics(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam4.Value, testOutput.IsFixedPitch);
        }

        [TestMethod]
        public void DirectionMetricsStruct_ConstructorWithThreeNullableDecimalNullableVectorAndNullableBoolParameters_SetsIsFixedPitchPropertyToFalse_IfFourthParameterIsNullAndFifthParameterIsNull()
        {
            decimal? testParam0 = _rnd.NextDecimal();
            decimal? testParam1 = _rnd.NextDecimal();
            decimal? testParam2 = _rnd.NextDecimal();
            Vector? testParam3 = null;
            bool? testParam4 = null;

            DirectionMetrics testOutput = new DirectionMetrics(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsFalse(testOutput.IsFixedPitch);
        }

        [TestMethod]
        public void DirectionMetricsStruct_ConstructorWithThreeNullableDecimalNullableVectorAndNullableBoolParameters_SetsIsFixedPitchPropertyToTrue_IfFourthParameterIsNotNullAndFifthParameterIsNull()
        {
            decimal? testParam0 = _rnd.NextDecimal();
            decimal? testParam1 = _rnd.NextDecimal();
            decimal? testParam2 = _rnd.NextDecimal();
            Vector? testParam3 = _rnd.NextAfmVector();
            bool? testParam4 = null;

            DirectionMetrics testOutput = new DirectionMetrics(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(testOutput.IsFixedPitch);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithDirectionMetricsParameter_ReturnsTrue_IfParameterIsThis()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);

            bool testOutput = testObject.Equals(testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithDirectionMetricsParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, testObject.ItalicAngle,
                testObject.CharWidth, constrParam4);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithDirectionMetricsParameter_ReturnsFalse_IfParameterDiffersByUnderlinePositionProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            decimal? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableDecimal();
            } while (constrParam5 == testObject.UnderlinePosition);
            DirectionMetrics testParam = new DirectionMetrics(constrParam5, testObject.UnderlineThickness, testObject.ItalicAngle, testObject.CharWidth, constrParam4);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithDirectionMetricsParameter_ReturnsFalse_IfParameterDiffersByUnderlineThicknessProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            decimal? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableDecimal();
            } while (constrParam5 == testObject.UnderlineThickness);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, constrParam5, testObject.ItalicAngle, testObject.CharWidth, constrParam4);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithDirectionMetricsParameter_ReturnsFalse_IfParameterDiffersByItalicAngleProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            decimal? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableDecimal();
            } while (constrParam5 == testObject.ItalicAngle);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, constrParam5, testObject.CharWidth, 
                constrParam4);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithDirectionMetricsParameter_ReturnsFalse_IfParameterDiffersByCharWidthProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            Vector? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableAfmVector();
            } while (constrParam5 == testObject.CharWidth);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, testObject.ItalicAngle, constrParam5, 
                constrParam4);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithDirectionMetricsParameter_ReturnsFalse_IfParameterDiffersByIsFixedPitchProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool constrParam4 = _rnd.NextBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            bool constrParam5 = !constrParam4;
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, testObject.ItalicAngle, testObject.CharWidth, 
                constrParam5);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsThis()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);

            bool testOutput = testObject.Equals((object)testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, testObject.ItalicAngle,
                testObject.CharWidth, constrParam4);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByUnderlinePositionProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            decimal? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableDecimal();
            } while (constrParam5 == testObject.UnderlinePosition);
            DirectionMetrics testParam = new DirectionMetrics(constrParam5, testObject.UnderlineThickness, testObject.ItalicAngle, testObject.CharWidth, constrParam4);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByUnderlineThicknessProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            decimal? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableDecimal();
            } while (constrParam5 == testObject.UnderlineThickness);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, constrParam5, testObject.ItalicAngle, testObject.CharWidth, constrParam4);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByItalicAngleProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            decimal? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableDecimal();
            } while (constrParam5 == testObject.ItalicAngle);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, constrParam5, testObject.CharWidth,
                constrParam4);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByCharWidthProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            Vector? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableAfmVector();
            } while (constrParam5 == testObject.CharWidth);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, testObject.ItalicAngle, constrParam5,
                constrParam4);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByIsFixedPitchProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool constrParam4 = _rnd.NextBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            bool constrParam5 = !constrParam4;
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, testObject.ItalicAngle, testObject.CharWidth,
                constrParam5);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void DirectionMetricsStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool constrParam4 = _rnd.NextBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            string testParam = _rnd.NextString(_rnd.Next(1, 20));

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

        [TestMethod]
        public void DirectionMetricsStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceWithSameValue()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool constrParam4 = _rnd.NextBoolean();
            DirectionMetrics testObject0 = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            DirectionMetrics testObject1 = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualityOperator_ReturnsTrue_IfBothOperandsAreSameValue()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testObject == testObject;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualityOperator_ReturnsTrue_IfBothOperandsAreConstructedFromSameData()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, testObject.ItalicAngle,
                testObject.CharWidth, constrParam4);

            bool testOutput = testObject == testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByUnderlinePositionProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            decimal? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableDecimal();
            } while (constrParam5 == testObject.UnderlinePosition);
            DirectionMetrics testParam = new DirectionMetrics(constrParam5, testObject.UnderlineThickness, testObject.ItalicAngle, testObject.CharWidth, constrParam4);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByUnderlineThicknessProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            decimal? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableDecimal();
            } while (constrParam5 == testObject.UnderlineThickness);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, constrParam5, testObject.ItalicAngle, testObject.CharWidth, constrParam4);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByItalicAngleProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            decimal? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableDecimal();
            } while (constrParam5 == testObject.ItalicAngle);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, constrParam5, testObject.CharWidth,
                constrParam4);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByCharWidthProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            Vector? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableAfmVector();
            } while (constrParam5 == testObject.CharWidth);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, testObject.ItalicAngle, constrParam5,
                constrParam4);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByIsFixedPitchProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool constrParam4 = _rnd.NextBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            bool constrParam5 = !constrParam4;
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, testObject.ItalicAngle, testObject.CharWidth,
                constrParam5);

            bool testOutput = testObject == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_InequalityOperator_ReturnsFalse_IfBothOperandsAreSameValue()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testObject != testObject;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_InequalityOperator_ReturnsFalse_IfBothOperandsAreConstructedFromSameData()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, testObject.ItalicAngle,
                testObject.CharWidth, constrParam4);

            bool testOutput = testObject != testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByUnderlinePositionProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            decimal? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableDecimal();
            } while (constrParam5 == testObject.UnderlinePosition);
            DirectionMetrics testParam = new DirectionMetrics(constrParam5, testObject.UnderlineThickness, testObject.ItalicAngle, testObject.CharWidth, constrParam4);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByUnderlineThicknessProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            decimal? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableDecimal();
            } while (constrParam5 == testObject.UnderlineThickness);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, constrParam5, testObject.ItalicAngle, testObject.CharWidth, constrParam4);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByItalicAngleProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            decimal? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableDecimal();
            } while (constrParam5 == testObject.ItalicAngle);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, constrParam5, testObject.CharWidth,
                constrParam4);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByCharWidthProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool? constrParam4 = _rnd.NextNullableBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            Vector? constrParam5;
            do
            {
                constrParam5 = _rnd.NextNullableAfmVector();
            } while (constrParam5 == testObject.CharWidth);
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, testObject.ItalicAngle, constrParam5,
                constrParam4);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByIsFixedPitchProperty()
        {
            decimal? constrParam0 = _rnd.NextDecimal();
            decimal? constrParam1 = _rnd.NextDecimal();
            decimal? constrParam2 = _rnd.NextDecimal();
            Vector? constrParam3 = _rnd.NextAfmVector();
            bool constrParam4 = _rnd.NextBoolean();
            DirectionMetrics testObject = new DirectionMetrics(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            bool constrParam5 = !constrParam4;
            DirectionMetrics testParam = new DirectionMetrics(testObject.UnderlinePosition, testObject.UnderlineThickness, testObject.ItalicAngle, testObject.CharWidth,
                constrParam5);

            bool testOutput = testObject != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DirectionMetricsStruct_FromLinesMethod_ReturnsValueWithCorrectUnderlinePositionProperty_IfDataIsValidAndIncludesUnderlinePositionKey()
        {
            decimal expectedValue = _rnd.NextDecimal();
            string[] testParam = new[]
            {
                $"UnderlinePosition {expectedValue.ToString(CultureInfo.InvariantCulture)}",
                $"UnderlineThickness {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"ItalicAngle {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
            };

            DirectionMetrics testOutput = DirectionMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.UnderlinePosition.Value);
        }

        [TestMethod]
        public void DirectionMetricsStruct_FromLinesMethod_ReturnsValueWithUnderlinePositionPropertyEqualToNull_IfDataIsValidAndDoesNotIncludeUnderlinePositionKey()
        {
            string[] testParam = new[]
            {
                $"UnderlineThickness {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"ItalicAngle {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
            };

            DirectionMetrics testOutput = DirectionMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.UnderlinePosition);
        }

        [TestMethod]
        public void DirectionMetricsStruct_FromLinesMethod_ReturnsValueWithCorrectUnderlineThicknessProperty_IfDataIsValidAndIncludesUnderlineThicknessKey()
        {
            decimal expectedValue = _rnd.NextDecimal();
            string[] testParam = new[]
            {
                $"UnderlinePosition {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"UnderlineThickness {expectedValue.ToString(CultureInfo.InvariantCulture)}",
                $"ItalicAngle {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
            };

            DirectionMetrics testOutput = DirectionMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.UnderlineThickness.Value);
        }

        [TestMethod]
        public void DirectionMetricsStruct_FromLinesMethod_ReturnsValueWithUnderlineThicknessPropertyEqualToNull_IfDataIsValidAndDoesNotIncludeUnderlineThicknessKey()
        {
            string[] testParam = new[]
            {
                $"UnderlinePosition {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"ItalicAngle {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
            };

            DirectionMetrics testOutput = DirectionMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.UnderlineThickness);
        }

        [TestMethod]
        public void DirectionMetricsStruct_FromLinesMethod_ReturnsValueWithCorrectItalicAngleProperty_IfDataIsValidAndIncludesItalicAngleKey()
        {
            decimal expectedValue = _rnd.NextDecimal();
            string[] testParam = new[]
            {
                $"UnderlinePosition {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"UnderlineThickness {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"ItalicAngle {expectedValue.ToString(CultureInfo.InvariantCulture)}",
            };

            DirectionMetrics testOutput = DirectionMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.ItalicAngle.Value);
        }

        [TestMethod]
        public void DirectionMetricsStruct_FromLinesMethod_ReturnsValueWithItalicAnglePropertyEqualToNull_IfDataIsValidAndDoesNotIncludeItalicAngleKey()
        {
            string[] testParam = new[]
            {
                $"UnderlinePosition {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"UnderlineThickness {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
            };

            DirectionMetrics testOutput = DirectionMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.ItalicAngle);
        }

        [TestMethod]
        public void DirectionMetricsStruct_FromLinesMethod_ReturnsValueWithCharWidthPropertyWithCorrectXProperty_IfDataIsValidAndIncludesCharWidthKey()
        {
            decimal expectedValue = _rnd.NextDecimal();
            string[] testParam = new[]
            {
                $"UnderlinePosition {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"UnderlineThickness {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"ItalicAngle {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"CharWidth {expectedValue.ToString(CultureInfo.InvariantCulture)} {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
            };

            DirectionMetrics testOutput = DirectionMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.CharWidth.Value.X);
        }

        [TestMethod]
        public void DirectionMetricsStruct_FromLinesMethod_ReturnsValueWithCharWidthPropertyWithCorrectYProperty_IfDataIsValidAndIncludesCharWidthKey()
        {
            decimal expectedValue = _rnd.NextDecimal();
            string[] testParam = new[]
            {
                $"UnderlinePosition {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"UnderlineThickness {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"ItalicAngle {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"CharWidth {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)} {expectedValue.ToString(CultureInfo.InvariantCulture)}",
            };

            DirectionMetrics testOutput = DirectionMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.CharWidth.Value.Y);
        }

        [TestMethod]
        public void DirectionMetricsStruct_FromLinesMethod_ReturnsValueWithIsFixedPitchPropertyEqualToTrue_IfDataIsValidIncludesCharWidthKeyAndDoesNotIncludeIsFixedPitchKey()
        {
            string[] testParam = new[]
            {
                $"UnderlinePosition {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"UnderlineThickness {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"ItalicAngle {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"CharWidth {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)} {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
            };

            DirectionMetrics testOutput = DirectionMetrics.FromLines(testParam);

            Assert.IsTrue(testOutput.IsFixedPitch);
        }

        [TestMethod]
        public void DirectionMetricsStruct_FromLinesMethod_ReturnsValueWithIsFixedPitchPropertyEqualToTrue_IfDataIsValidIncludesCharWidthKeyAndIncludesIsFixedPitchKeyWithValueTrue()
        {
            string[] testParam = new[]
            {
                $"UnderlinePosition {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"UnderlineThickness {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"ItalicAngle {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"CharWidth {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)} {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                "IsFixedPitch true",
            };

            DirectionMetrics testOutput = DirectionMetrics.FromLines(testParam);

            Assert.IsTrue(testOutput.IsFixedPitch);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void DirectionMetricsStruct_FromLinesMethod_ThrowsAfmFormatException_IfDataIsValidIncludesCharWidthKeyAndIncludesIsFixedPitchKeyWithValueFalse()
        {
            string[] testParam = new[]
            {
                $"UnderlinePosition {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"UnderlineThickness {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"ItalicAngle {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"CharWidth {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)} {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                "IsFixedPitch false",
            };

            _ = DirectionMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void DirectionMetricsStruct_FromLinesMethod_ReturnsValueWithIsFixedPitchPropertyEqualToTrue_IfDataIsValidIncludesIsFixedPitchKeyWithValueTrueAndDoesNotIncludeCharWidthKey()
        {
            string[] testParam = new[]
            {
                $"UnderlinePosition {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"UnderlineThickness {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"ItalicAngle {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                "IsFixedPitch true",
            };

            DirectionMetrics testOutput = DirectionMetrics.FromLines(testParam);

            Assert.IsTrue(testOutput.IsFixedPitch);
        }

        [TestMethod]
        public void DirectionMetricsStruct_FromLinesMethod_ReturnsValueWithIsFixedPitchPropertyEqualToFalse_IfDataIsValidIncludesIsFixedPitchKeyWithValueFalseAndDoesNotIncludeCharWidthKey()
        {
            string[] testParam = new[]
            {
                $"UnderlinePosition {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"UnderlineThickness {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"ItalicAngle {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                "IsFixedPitch false",
            };

            DirectionMetrics testOutput = DirectionMetrics.FromLines(testParam);

            Assert.IsFalse(testOutput.IsFixedPitch);
        }

        [TestMethod]
        public void DirectionMetricsStruct_FromLinesMethod_ReturnsValueWithIsFixedPitchPropertyEqualToFalse_IfDataIsValidAndDoesNotIncludeIsFixedPitchKeyOrCharWidthKey()
        {
            string[] testParam = new[]
            {
                $"UnderlinePosition {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"UnderlineThickness {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
                $"ItalicAngle {_rnd.NextDecimal().ToString(CultureInfo.InvariantCulture)}",
            };

            DirectionMetrics testOutput = DirectionMetrics.FromLines(testParam);

            Assert.IsFalse(testOutput.IsFixedPitch);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
