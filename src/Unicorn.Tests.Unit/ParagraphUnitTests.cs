using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Base;
using Unicorn.Base.Tests.Utility;
using Unicorn.Tests.Unit.TestHelpers;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class ParagraphUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private MarginSet _testMargins;
        private Paragraph _testObject;

        [TestInitialize]
        public void SetUpTest()
        {
            _testMargins = _rnd.NextMarginSet();
            _testObject = new(_rnd.NextDouble(1000), _rnd.NextNullableDouble(1000), _rnd.NextOrientation(), _rnd.NextHorizontalAlignment(),
                _rnd.NextVerticalAlignment(), _testMargins);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        private List<Line> GetLines(Func<double, List<Line>, Line> lineCreator)
        {
            int lineCount = _rnd.Next(1, 50);
            List<Line> lines = new();
            for (int i = 0; i < lineCount; ++i)
            {
                lines.Add(lineCreator(_testObject.MaximumWidth, lines));
            }
            return lines;
        }

        private List<Line> GetLines() => GetLines((w, x) => LineOfAnyWidth(w));

        private static Line LineOfAnyWidth(double w) => _rnd.NextBoolean() ? _rnd.NextLineOverWidth(w) : _rnd.NextLineUnderWidth(w);

        private List<Line> GetLinesUnderWidth() => GetLines((w, x) => _rnd.NextLineUnderWidth(w));

        private List<Line> GetLinesWithAtLeastOneOverWidth()
        {
            List<Line> lines = GetLines();
            if (lines.All(n => n.MinWidth < _testObject.MaximumWidth))
            {
                lines.Add(_rnd.NextLineOverWidth(_testObject.MaximumWidth));
            }
            return lines;
        }

        private List<Line> GetLinesUnderHeight(Func<double, List<Line>, Line> lineCreator)
        {
            if (!_testObject.MaximumHeight.HasValue)
            {
                return GetLines(lineCreator);
            }
            List<Line> lines = new();
            while (true)
            {
                Line newLine = lineCreator(_testObject.MaximumWidth, lines);
                if (lines.Sum(n => n.ContentHeight) + newLine.ContentHeight > _testObject.MaximumHeight.Value)
                {
                    if (lines.Any())
                    {
                        return lines;
                    }
                }
                else
                {
                    lines.Add(newLine);
                }
            }
        }

        private List<Line> GetLinesUnderHeight() => GetLinesUnderHeight((w, x) => LineOfAnyWidth(w));

        private List<Line> GetLinesJustOverHeight(Func<double, List<Line>, Line> lineCreator)
        {
            if (!_testObject.MaximumHeight.HasValue)
            {
                return GetLines(lineCreator);
            }
            List<Line> lines = new();
            while (lines.Sum(n => n.ContentHeight) < _testObject.MaximumHeight.Value)
            {
                lines.Add(lineCreator(_testObject.MaximumWidth, lines));
            }
            return lines;
        }

        private List<Line> GetLinesJustOverHeight() => GetLinesJustOverHeight((w, x) => LineOfAnyWidth(w));

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ParagraphClass_ComputedHeightProperty_EqualsMaximumHeightProperty_IfMaximumHeightPropertyIsNotNull()
        {
            double constrParam0 = _rnd.NextDouble(1000);
            double? constrParam1 = _rnd.NextDouble(1000);
            Paragraph testObject = new(constrParam0, constrParam1);

            Assert.AreEqual(testObject.MaximumHeight.Value, testObject.ComputedHeight);
        }

        [TestMethod]
        public void ParagraphClass_ComputedHeightProperty_EqualsContentHeightProperty_IfMaximumHeightPropertyIsNull()
        {
            _testObject.MaximumHeight = null;
            _testObject.AddLines(GetLines());

            Assert.AreEqual(_testObject.ContentHeight, _testObject.ComputedHeight);
        }

        [TestMethod]
        public void ParagraphClass_ContentHeightProperty_EqualsSumOfLineContentHeightPropertiesPlusMarginTopAndMarginBottomProperties()
        {
            List<Line> testContent = GetLines();
            _testObject.AddLines(testContent);
            double expectedResult = testContent.Sum(n => n.ContentHeight) + _testMargins.Top + _testMargins.Bottom;

            double testOutput = _testObject.ContentHeight;

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void ParagraphClass_ContentWidthProperty_EqualsSumOfMarginLeftAndMarginRightProperties_IfParagraphContainsNoLines()
        {
            double testOutput = _testObject.ContentWidth;

            Assert.AreEqual(_testMargins.Left + _testMargins.Right, testOutput);
        }

        [TestMethod]
        public void ParagraphClass_ContentWidthProperty_EqualsLargestMinWidthPropertyOfAnyLinePlusMarginLeftAndMarginRightProperties_IfParagraphContainsLines()
        {
            List<Line> testContent = GetLines();
            _testObject.AddLines(testContent);
            double expectedResult = testContent.Max(n => n.MinWidth) + _testMargins.Left + _testMargins.Right;

            double testOutput = _testObject.ContentWidth;

            Assert.AreEqual(expectedResult, testOutput, 0.000000001);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleAndNullableDoubleParameters_SetsMaximumWidthPropertyToValueOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);

            Paragraph testOutput = new(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.MaximumWidth);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleAndNullableDoubleParameters_SetsMaximumHeightPropertyToValueOfSecondParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);

            Paragraph testOutput = new(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.MaximumHeight);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleAndNullableDoubleParameters_CreatesEmptyParagraph()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);

            Paragraph testOutput = new(testParam0, testParam1);

            Assert.AreEqual(0, testOutput.Lines.Count);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleAndNullableDoubleParameters_CreatesParagraphWithZeroTopMargin()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);

            Paragraph testOutput = new(testParam0, testParam1);

            Assert.AreEqual(0, testOutput.Margins.Top);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleAndNullableDoubleParameters_CreatesParagraphWithZeroRightMargin()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);

            Paragraph testOutput = new(testParam0, testParam1);

            Assert.AreEqual(0, testOutput.Margins.Right);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleAndNullableDoubleParameters_CreatesParagraphWithZeroBottomMargin()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);

            Paragraph testOutput = new(testParam0, testParam1);

            Assert.AreEqual(0, testOutput.Margins.Bottom);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleAndNullableDoubleParameters_CreatesParagraphWithZeroLeftMargin()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);

            Paragraph testOutput = new(testParam0, testParam1);

            Assert.AreEqual(0, testOutput.Margins.Left);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentAndVerticalAlignmentParameters_SetsMaximumWidthPropertyEqualToFirstParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam0, testOutput.MaximumWidth);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentAndVerticalAlignmentParameters_SetsMaximumHeightPropertyEqualToSecondParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam1, testOutput.MaximumHeight);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentAndVerticalAlignmentParameters_SetsOrientationPropertyEqualToThirdParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam2, testOutput.Orientation);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentAndVerticalAlignmentParameters_SetsHorizontalAlignmentPropertyEqualToFourthParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam3, testOutput.HorizontalAlignment);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentAndVerticalAlignmentParameters_SetsVerticalAlignmentPropertyEqualToFifthParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam4, testOutput.VerticalAlignment);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentAndVerticalAlignmentParameters_CreatesEmptyParagraph()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(0, testOutput.Lines.Count);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentAndVerticalAlignmentParameters_SetsMarginsTopPropertyEqualToZero()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(0, testOutput.Margins.Top);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentAndVerticalAlignmentParameters_SetsMarginsLeftPropertyEqualToZero()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(0, testOutput.Margins.Left);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentAndVerticalAlignmentParameters_SetsMarginsBottomPropertyEqualToZero()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(0, testOutput.Margins.Bottom);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentAndVerticalAlignmentParameters_SetsMarginsRightPropertyEqualToZero()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(0, testOutput.Margins.Right);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentVerticalAlignmentAndMarginSetParameters_SetsMaximumWidthPropertyEqualToFirstParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();
            MarginSet testParam5 = _rnd.NextMarginSet();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam0, testOutput.MaximumWidth);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentVerticalAlignmentAndMarginSetParameters_SetsMaximumHeightPropertyEqualToSecondParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();
            MarginSet testParam5 = _rnd.NextMarginSet();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam1, testOutput.MaximumHeight);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentVerticalAlignmentAndMarginSetParameters_SetsOrientationPropertyEqualToThirdParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();
            MarginSet testParam5 = _rnd.NextMarginSet();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam2, testOutput.Orientation);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentVerticalAlignmentAndMarginSetParameters_SetsHorizontalAlignmentPropertyEqualToFourthParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();
            MarginSet testParam5 = _rnd.NextMarginSet();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam3, testOutput.HorizontalAlignment);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentVerticalAlignmentAndMarginSetParameters_SetsVerticalALignmentPropertyEqualToFifthParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();
            MarginSet testParam5 = _rnd.NextMarginSet();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam4, testOutput.VerticalAlignment);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentVerticalAlignmentAndMarginSetParameters_SetsMarginsTopPropertyEqualToTopPropertyOfSixthParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();
            MarginSet testParam5 = _rnd.NextMarginSet();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam5.Top, testOutput.Margins.Top);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentVerticalAlignmentAndMarginSetParameters_SetsMarginsRightPropertyEqualToRightPropertyOfSixthParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();
            MarginSet testParam5 = _rnd.NextMarginSet();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam5.Right, testOutput.Margins.Right);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentVerticalAlignmentAndMarginSetParameters_SetsMarginsBottomPropertyEqualToBottomPropertyOfSixthParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();
            MarginSet testParam5 = _rnd.NextMarginSet();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam5.Bottom, testOutput.Margins.Bottom);
        }

        [TestMethod]
        public void ParagraphClass_ConstructorWithDoubleNullableDoubleOrientationHorizontalAlignmentVerticalAlignmentAndMarginSetParameters_SetsMarginsLegtPropertyEqualToLeftPropertyOfSixthParameter()
        {
            double testParam0 = _rnd.NextDouble(1000);
            double? testParam1 = _rnd.NextNullableDouble(1000);
            Orientation testParam2 = _rnd.NextOrientation();
            HorizontalAlignment testParam3 = _rnd.NextHorizontalAlignment();
            VerticalAlignment testParam4 = _rnd.NextVerticalAlignment();
            MarginSet testParam5 = _rnd.NextMarginSet();

            Paragraph testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam5.Left, testOutput.Margins.Left);
        }

        [TestMethod]
        public void ParagraphClass_AddLinesMethod_AddsCorrectNumberOfLines()
        {
            List<Line> testLines = GetLines();

            _testObject.AddLines(testLines);

            Assert.AreEqual(testLines.Count, _testObject.Lines.Count);
        }

        [TestMethod]
        public void ParagraphClass_AddLinesMethod_AddsCorrectLinesInOrder()
        {
            List<Line> testLines = GetLines();

            _testObject.AddLines(testLines);

            for (int i = 0; i < testLines.Count; ++i)
            {
                Assert.AreSame(testLines[i], _testObject.Lines[i]);
            }
        }

        [TestMethod]
        public void ParagraphClass_AddLinesMethod_SetsOverspillWidthPropertyToFalse_IfAllLineWidthsAreLessThanMaximumWidth()
        {
            List<Line> testLines = GetLinesUnderWidth();

            _testObject.AddLines(testLines);

            Assert.IsFalse(_testObject.OverspillWidth);
        }

        [TestMethod]
        public void ParagraphClass_AddLinesMethod_SetsOverspillWidthPropertyToTrue_IfAtLeastOneLineWidthIsGreaterThanMaximumWidth()
        {
            List<Line> testLines = GetLinesWithAtLeastOneOverWidth();

            _testObject.AddLines(testLines);

            Assert.IsTrue(_testObject.OverspillWidth);
        }

        [TestMethod]
        public void ParagraphClass_AddLinesMethod_SetsOverspillHeightPropertyToFalse_IfMaximumHeightIsNotNullAndSumOfAllLineHeightsIsLessThanMaximumHeight()
        {
            _testObject.MaximumHeight = _rnd.NextDouble(1000);
            List<Line> testLines = GetLinesUnderHeight();

            _testObject.AddLines(testLines);

            Assert.IsFalse(_testObject.OverspillHeight);
        }

        [TestMethod]
        public void ParagraphClass_AddLinesMethod_SetsOverspillHeightPropertyToTrue_IfMaximumHeightIsNotNullAndSumOfAllLineHeightsIsGreaterThanMaximumHeight()
        {
            _testObject.MaximumHeight = _rnd.NextDouble(1000);
            List<Line> testLines = GetLinesJustOverHeight();

            _testObject.AddLines(testLines);

            Assert.IsTrue(_testObject.OverspillHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParagraphClass_DrawAtMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            double testParam1 = _rnd.NextDouble(1000);
            double testParam2 = _rnd.NextDouble(1000);

            _testObject.DrawAt(null, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void ParagraphClass_DrawAtMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            double testParam1 = _rnd.NextDouble(1000);
            double testParam2 = _rnd.NextDouble(1000);

            try
            {
                _testObject.DrawAt(null, testParam1, testParam2);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("context", ex.ParamName);
            }
        }

        [TestMethod]
        public void ParagraphClass_SplitMethod_ReturnsNull_IfOverspillHeightPropertyIsFalse()
        {
            List<Line> testData = GetLinesUnderHeight();
            _testObject.AddLines(testData);
            double? testParam0 = _rnd.NextNullableDouble();
            WidowsAndOrphans testParam1 = _rnd.NextWidowsAndOrphans();

            var testOutput = _testObject.Split(testParam0, testParam1);

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void ParagraphClass_SplitMethod_DoesNotChangeLinesInTestObject_IfOverspillHeightPropertyIsFalse()
        {
            List<Line> testData = GetLinesUnderHeight();
            _testObject.AddLines(testData);
            double? testParam0 = _rnd.NextNullableDouble();
            WidowsAndOrphans testParam1 = _rnd.NextWidowsAndOrphans();

            _ = _testObject.Split(testParam0, testParam1);

            Assert.AreEqual(testData.Count, _testObject.Lines.Count);
            for (int i = 0; i < testData.Count; ++i)
            {
                Assert.AreSame(testData[i], _testObject.Lines[i]);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
