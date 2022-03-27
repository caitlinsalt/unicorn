using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Base;
using Unicorn.Base.Tests.Utility;
using Unicorn.Exceptions;
using Unicorn.Tests.Unit.TestHelpers;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;
using Unicorn.Writer.Streams;
using Unicorn.Writer.Structural;

namespace Unicorn.Tests.Unit.Writer.Structural
{
    [TestClass]
    public class PageGraphicsUnitTests
    {
        private readonly static Random _rnd = RandomProvider.Default;

        private readonly List<double> _transformedXParameters = new();
        private readonly List<double> _transformedYParameters = new();

        private int _transformerCalls;

        private PageGraphics _testObject;

        private PdfStream _testOutputStream;
        private Mock<IPdfPage> _mockPage;
        private Mock<IUniColour> _mockColour;
        private RgbColour _rgbColour;
        private GreyscaleColour _greyscaleColour;
        private CmykColour _cmykColour;
        private IUniColour _arbitraryColour;

        private double TransformParam(double val, List<double> store)
        {
            store.Add(val);
            return val * ++_transformerCalls;
        }

        private double TransformXParam(double val) => TransformParam(val, _transformedXParameters);

        private double TransformYParam(double val) => TransformParam(val, _transformedYParameters);

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void Setup()
        {
            _transformerCalls = 0;
            _transformedXParameters.Clear();
            _transformedYParameters.Clear();

            _testOutputStream = new(_rnd.Next(1, int.MaxValue));
            _mockPage = new Mock<IPdfPage>();
            _mockPage.Setup(p => p.ContentStream).Returns(_testOutputStream);

            _testObject = new(_mockPage.Object, TransformXParam, TransformYParam);

            _mockColour = new Mock<IUniColour>();
            _rgbColour = _rnd.NextRgbColour();
            _greyscaleColour = _rnd.NextGreyscaleColour();
            _cmykColour = _rnd.NextCmykColour();
            IUniColour[] allColours = new IUniColour[] { _mockColour.Object, _rgbColour, _greyscaleColour, _cmykColour };
            _arbitraryColour = _rnd.FromSet(allColours);
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PageGraphicsClass_Constructor_ThrowsArgumentNullExceptionIfFirstParameterIsNull()
        {
            IPdfPage testParam0 = null;
            Func<double, double> testParam2 = TransformXParam;
            Func<double, double> testParam3 = TransformYParam;

            PageGraphics testOutput = new(testParam0, testParam2, testParam3);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_Constructor_SetsPageStateToOpen()
        {
            IPdfPage testParam0 = _mockPage.Object;
            Func<double, double> testParam1 = TransformXParam;
            Func<double, double> testParam2 = TransformYParam;

            PageGraphics testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreEqual(PageState.Open, testOutput.PageState);
        }

        [TestMethod]
        [ExpectedException(typeof(PageClosedException))]
        public void PageGraphicsClass_SaveMethod_ThrowsPageClosedException_IfPageStateIsClosed()
        {
            _testObject.CloseGraphics();

            _ = _testObject.Save();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(PageClosedException))]
        public void PageGraphicsClass_RestoreMethod_ThrowsPageClosedException_IfPageStateIsClosed()
        {
            IGraphicsState testParam0 = new Mock<IGraphicsState>().Object;
            _testObject.CloseGraphics();

            _testObject.Restore(testParam0);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_CloseGraphicsMethod_SetsPageStateToClosed()
        {
            _testObject.CloseGraphics();

            Assert.AreEqual(PageState.Closed, _testObject.PageState);
        }

        [TestMethod]
        [ExpectedException(typeof(PageClosedException))]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_ThrowsPageClosedException_IfPageStateIsClosed()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            _testObject.CloseGraphics();

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(1)).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_CallsSecondParameterOfConstructorWithThirdParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedXParameters.Contains(testParam2));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_CallsThirdParameterOfConstructorWithSecondParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_CallsThirdParameterOfConstructorWithFourthParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedYParameters.Contains(testParam3));
        }

        // This test is to show that PageGraphics does not send out w and G operations unnecessarily.
        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwice()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);
            _testObject.DrawLine(testParam4, testParam5, testParam6, testParam7);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(1)).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam4 * 5), new PdfReal(testParam5 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam6 * 7), new PdfReal(testParam7 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        [ExpectedException(typeof(PageClosedException))]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleAndOneIUniColourParameters_ThrowsPageClosedException_IfPageStateIsClosed()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _mockColour.Object;
            _testObject.CloseGraphics();

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleAndOneIUniColourParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnceAndFifthParameterIsNotAnIColour()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _mockColour.Object;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(1)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleAndOneIUniColourParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnceAndFifthParameterIsGreyscaleColour()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _greyscaleColour;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(1)).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(_greyscaleColour.GreyLevel)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleAndOneIUniColourParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnceAndFifthParameterIsRgbColour()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _rgbColour;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(1)).WriteTo(expected);
            PdfOperator.SetDeviceRgbStrokingColour(new PdfReal(_rgbColour.Red), new PdfReal(_rgbColour.Green), new PdfReal(_rgbColour.Blue)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleAndOneIUniColourParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnceAndFifthParameterIsCmykColour()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _cmykColour;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(1)).WriteTo(expected);
            PdfOperator.SetDeviceCmykStrokingColour(new PdfReal(_cmykColour.Cyan), new PdfReal(_cmykColour.Magenta), new PdfReal(_cmykColour.Yellow), 
                new PdfReal(_cmykColour.Black)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleAndOneIUniColourParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _arbitraryColour;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleAndOneIUniColourParameters_CallsSecondParameterOfConstructorWithThirdParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _arbitraryColour;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedXParameters.Contains(testParam2));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleAndOneIUniColourParameters_CallsThirdParameterOfConstructorWithSecondParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _arbitraryColour;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleAndOneIUniColourParameters_CallsThirdParameterOfConstructorWithFourthParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _arbitraryColour;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedYParameters.Contains(testParam3));
        }

        // This test is to show that PageGraphics does not send out w and G operations unnecessarily.
        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleAndOneIUniColourParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceAndFifthParameterIsNotAnIColour()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _mockColour.Object;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            IUniColour testParam9 = _mockColour.Object;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);
            _testObject.DrawLine(testParam5, testParam6, testParam7, testParam8, testParam9);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(1)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam5 * 5), new PdfReal(testParam6 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam7 * 7), new PdfReal(testParam8 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleAndOneIUniColourParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceAndFifthParameterIsGreyscaleColour()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _greyscaleColour;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            IUniColour testParam9 = _greyscaleColour;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);
            _testObject.DrawLine(testParam5, testParam6, testParam7, testParam8, testParam9);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(1)).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(_greyscaleColour.GreyLevel)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam5 * 5), new PdfReal(testParam6 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam7 * 7), new PdfReal(testParam8 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleAndOneIUniColourParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceAndFifthParameterIsRgbColour()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _rgbColour;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            IUniColour testParam9 = _rgbColour;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);
            _testObject.DrawLine(testParam5, testParam6, testParam7, testParam8, testParam9);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(1)).WriteTo(expected);
            PdfOperator.SetDeviceRgbStrokingColour(new PdfReal(_rgbColour.Red), new PdfReal(_rgbColour.Green), new PdfReal(_rgbColour.Blue)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam5 * 5), new PdfReal(testParam6 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam7 * 7), new PdfReal(testParam8 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleAndOneIUniColourParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceAndFifthParameterIsCmykColour()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _cmykColour;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            IUniColour testParam9 = _cmykColour;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);
            _testObject.DrawLine(testParam5, testParam6, testParam7, testParam8, testParam9);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(1)).WriteTo(expected);
            PdfOperator.SetDeviceCmykStrokingColour(new PdfReal(_cmykColour.Cyan), new PdfReal(_cmykColour.Magenta), new PdfReal(_cmykColour.Yellow),
                new PdfReal(_cmykColour.Black)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam5 * 5), new PdfReal(testParam6 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam7 * 7), new PdfReal(testParam8 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        [ExpectedException(typeof(PageClosedException))]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_ThrowsPageClosedException_IfPageStateIsClosed()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            _testObject.CloseGraphics();

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_CallsSecondParameterOfConstructorWithThirdParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedXParameters.Contains(testParam2));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_CallsThirdParameterOfConstructorWithSecondParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_CallsThirdParameterOfConstructorWithFourthParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedYParameters.Contains(testParam3));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithDifferentFifthParameters()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            double testParam9 = _rnd.NextDouble() * 5;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);
            _testObject.DrawLine(testParam5, testParam6, testParam7, testParam8, testParam9);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.LineWidth(new PdfReal(testParam9)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam5 * 5), new PdfReal(testParam6 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam7 * 7), new PdfReal(testParam8 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithSameFifthParameters()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);
            _testObject.DrawLine(testParam5, testParam6, testParam7, testParam8, testParam4);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam5 * 5), new PdfReal(testParam6 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam7 * 7), new PdfReal(testParam8 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        [ExpectedException(typeof(PageClosedException))]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_ThrowsPageClosedException_IfPageStateIsClosed()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.Solid;
            _testObject.CloseGraphics();

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsSolid()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.Solid;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsDash()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.Dash;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.LineDashPattern(new PdfArray(new PdfReal(testParam4 * 3), new PdfReal(testParam4)), PdfInteger.Zero).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0m)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsDot()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.Dot;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.LineDashPattern(new PdfArray(new PdfReal(testParam4)), PdfInteger.Zero).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsDashDot()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.DashDot;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.LineDashPattern(new PdfArray(new PdfReal(testParam4 * 3), new PdfReal(testParam4), new PdfReal(testParam4), new PdfReal(testParam4)),
                PdfInteger.Zero).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsDashDotDot()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.DashDotDot;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.LineDashPattern(new PdfArray(new PdfReal(testParam4 * 3), new PdfReal(testParam4), new PdfReal(testParam4), new PdfReal(testParam4),
                new PdfReal(testParam4), new PdfReal(testParam4)), PdfInteger.Zero).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_CallsSecondParameterOfConstructorWithThirdParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.IsTrue(_transformedXParameters.Contains(testParam2));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_CallsThirdParameterOfConstructorWithSecondParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_CallsThirdParameterOfConstructorWithFourthParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.IsTrue(_transformedYParameters.Contains(testParam3));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithSameFifthAndSixthParameters()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            double testParam9 = _rnd.NextDouble() * 500;

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
            _testObject.DrawLine(testParam6, testParam7, testParam8, testParam9, testParam4, testParam5);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            if (testParam5 != UniDashStyle.Solid)
            {
                IPdfPrimitiveObject[] operands = testParam5.ToPdfObjects(testParam4);
                PdfOperator.LineDashPattern(operands[0] as PdfArray, operands[1] as PdfInteger).WriteTo(expected);
            }
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam6 * 5), new PdfReal(testParam7 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam8 * 7), new PdfReal(testParam9 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithDifferentFifthAndSameSixthParameters()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            double testParam9 = _rnd.NextDouble() * 500;
            double testParam10;
            do
            {
                testParam10 = _rnd.NextDouble() * 5;
            } while (testParam10 == testParam4);

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
            _testObject.DrawLine(testParam6, testParam7, testParam8, testParam9, testParam10, testParam5);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            if (testParam5 != UniDashStyle.Solid)
            {
                IPdfPrimitiveObject[] operands = testParam5.ToPdfObjects(testParam4);
                PdfOperator.LineDashPattern(operands[0] as PdfArray, operands[1] as PdfInteger).WriteTo(expected);
            }
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.LineWidth(new PdfReal(testParam10)).WriteTo(expected);
            if (testParam5 != UniDashStyle.Solid)
            {
                IPdfPrimitiveObject[] operands = testParam5.ToPdfObjects(testParam10);
                PdfOperator.LineDashPattern(operands[0] as PdfArray, operands[1] as PdfInteger).WriteTo(expected);
            }
            PdfOperator.StartPath(new PdfReal(testParam6 * 5), new PdfReal(testParam7 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam8 * 7), new PdfReal(testParam9 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithSameFifthAndDifferentSixthParameters()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            double testParam9 = _rnd.NextDouble() * 500;
            UniDashStyle testParam10;
            do
            {
                testParam10 = _rnd.NextUniDashStyle();
            } while (testParam5 == testParam10);

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
            _testObject.DrawLine(testParam6, testParam7, testParam8, testParam9, testParam4, testParam10);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            if (testParam5 != UniDashStyle.Solid)
            {
                IPdfPrimitiveObject[] operands0 = testParam5.ToPdfObjects(testParam4);
                PdfOperator.LineDashPattern(operands0[0] as PdfArray, operands0[1] as PdfInteger).WriteTo(expected);
            }
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            IPdfPrimitiveObject[] operands1 = testParam10.ToPdfObjects(testParam4);
            PdfOperator.LineDashPattern(operands1[0] as PdfArray, operands1[1] as PdfInteger).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam6 * 5), new PdfReal(testParam7 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam8 * 7), new PdfReal(testParam9 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithDifferentFifthAndSixthParameters()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            double testParam9 = _rnd.NextDouble() * 500;
            double testParam10;
            do
            {
                testParam10 = _rnd.NextDouble() * 5;
            } while (testParam10 == testParam4);
            UniDashStyle testParam11;
            do
            {
                testParam11 = _rnd.NextUniDashStyle();
            } while (testParam5 == testParam11);

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
            _testObject.DrawLine(testParam6, testParam7, testParam8, testParam9, testParam10, testParam11);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            if (testParam5 != UniDashStyle.Solid)
            {
                IPdfPrimitiveObject[] operands = testParam5.ToPdfObjects(testParam4);
                PdfOperator.LineDashPattern(operands[0] as PdfArray, operands[1] as PdfInteger).WriteTo(expected);
            }
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.LineWidth(new PdfReal(testParam10)).WriteTo(expected);
            IPdfPrimitiveObject[] operands1 = testParam11.ToPdfObjects(testParam10);
            PdfOperator.LineDashPattern(operands1[0] as PdfArray, operands1[1] as PdfInteger).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam6 * 5), new PdfReal(testParam7 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam8 * 7), new PdfReal(testParam9 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        [ExpectedException(typeof(PageClosedException))]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleIUniColourDoubleAndUniDashStyleParameters_ThrowsPageClosedException_IfPageStateIsClosed()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _mockColour.Object;
            double testParam5 = _rnd.NextDouble() * 5;
            UniDashStyle testParam6 = UniDashStyle.Solid;
            _testObject.CloseGraphics();

            _testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(PageClosedException))]
        public void PageGraphicsClass_DrawFilledPolygonMethod_ThrowsPageClosedException_IfPageStateIsClosed()
        {
            IEnumerable<UniPoint> testParam0 = null;
            IUniColour testParam1 = _mockColour.Object;
            IUniColour testParam2 = _mockColour.Object;
            _testObject.CloseGraphics();

            _testObject.DrawFilledPolygon(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(PageClosedException))]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_ThrowsPageClosedException_IfPageStateIsClosed()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            _testObject.CloseGraphics();

            _testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            _testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(1d)).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            _testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_CallsThirdParameterOfConstructorWithSumOfSecondAndFourthParameters_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            _testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1 + testParam3));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwice()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;

            _testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3);
            _testObject.DrawRectangle(testParam4, testParam5, testParam6, testParam7);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(1d)).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam4 * 3), new PdfReal((testParam5 + testParam7) * 4), new PdfReal(testParam6), new PdfReal(testParam7))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        [ExpectedException(typeof(PageClosedException))]
        public void PageGraphicsClass_DrawRectangleMethodWithFiveDoubleParameters_ThrowsPageClosedException_IfPageStateIsClosed()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            _testObject.CloseGraphics();

            _testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFiveDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            _testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFiveDoubleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            _testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFiveDoubleParameters_CallsThirdParameterOfConstructorWithSumOfSecondAndFourthParameters_IfCalledOnce()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            _testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1 + testParam3));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithSameFifthParameter()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;

            _testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);
            _testObject.DrawRectangle(testParam5, testParam6, testParam7, testParam8, testParam4);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam5 * 3), new PdfReal((testParam6 + testParam8) * 4), new PdfReal(testParam7), new PdfReal(testParam8))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithDifferentFifthParameter()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            double testParam9;
            do
            {
                testParam9 = _rnd.NextDouble() * 5;
            } while (testParam9 == testParam4);

            _testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);
            _testObject.DrawRectangle(testParam5, testParam6, testParam7, testParam8, testParam9);

            List<byte> expected = new();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.LineWidth(new PdfReal(testParam9)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam5 * 3), new PdfReal((testParam6 + testParam8) * 4), new PdfReal(testParam7), new PdfReal(testParam8))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        [ExpectedException(typeof(PageClosedException))]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleIUniColourAndDoubleParameters_ThrowsPageClosedException_IfPageStateIsClosed()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            IUniColour testParam4 = _mockColour.Object;
            double testParam5 = _rnd.NextDouble() * 5;
            _testObject.CloseGraphics();

            _testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(PageClosedException))]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleTwoIUniColourAndDoubleParameters_ThrowsPageClosedException_IfPageStateIsClosed()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            IUniColour testParam4 = _mockColour.Object;
            IUniColour testParam5 = _mockColour.Object;
            double testParam6 = _rnd.NextDouble() * 5;
            _testObject.CloseGraphics();

            _testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PageGraphicsClass_MeasureStringMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = null;

            _ = _testObject.MeasureString(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_MeasureStringMethod_CallsMeasureStringMethodOfSecondParameter_IfSecondParameterIsNotNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            UniTextSize expectedResult = new(_rnd.NextDouble() * 100, _rnd.NextDouble() * 100, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000,
                _rnd.NextDouble() * 1000);
            Mock<IFontDescriptor> mockFont = new();
            mockFont.Setup(f => f.MeasureString(It.IsAny<string>())).Returns(expectedResult);
            IFontDescriptor testParam1 = mockFont.Object;

            _ = _testObject.MeasureString(testParam0, testParam1);

            mockFont.Verify(f => f.MeasureString(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public void PageGraphicsClass_MeasureStringMethod_PassesFirstParameterToMeasureStringMethodOfSecondParameter_IfSecondParameterIsNotNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            UniTextSize expectedResult = new(_rnd.NextDouble() * 100, _rnd.NextDouble() * 100, _rnd.NextDouble() * 100, _rnd.NextDouble() * 100, _rnd.NextDouble() * 100);
            Mock<IFontDescriptor> mockFont = new();
            mockFont.Setup(f => f.MeasureString(It.IsAny<string>())).Returns(expectedResult);
            IFontDescriptor testParam1 = mockFont.Object;

            _ = _testObject.MeasureString(testParam0, testParam1);

            mockFont.Verify(f => f.MeasureString(testParam0), Times.Once());
        }

        [TestMethod]
        public void PageGraphicsClass_MeasureStringMethod_ReturnsValueReturnedByMeasureStringMethodOfSecondParameter_IfSecondParameterIsNotNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            UniTextSize expectedResult = new(_rnd.NextDouble() * 100, _rnd.NextDouble() * 100, _rnd.NextDouble() * 100, _rnd.NextDouble() * 100, _rnd.NextDouble() * 100);
            Mock<IFontDescriptor> mockFont = new();
            mockFont.Setup(f => f.MeasureString(It.IsAny<string>())).Returns(expectedResult);
            IFontDescriptor testParam1 = mockFont.Object;

            UniTextSize testOutput = _testObject.MeasureString(testParam0, testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(PageClosedException))]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_ThrowsPageClosedException_IfPageStateIsClosed()
        {
            _mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f => new PdfFont(_rnd.Next(1, int.MaxValue), f, null));
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            Mock<IFontDescriptor> mockFont = new();
            mockFont.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            IFontDescriptor testParam1 = mockFont.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            _testObject.CloseGraphics();

            _testObject.DrawString(testParam0, testParam1, testParam2, testParam3);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = null;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            _testObject.DrawString(testParam0, testParam1, testParam2, testParam3);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_CallsUseFontMethodOfFirstParameterOfConstructor_OnFirstCall()
        {
            _mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f => new PdfFont(_rnd.Next(1, int.MaxValue), f, null));
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            Mock<IFontDescriptor> mockFont = new();
            mockFont.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            IFontDescriptor testParam1 = mockFont.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            _testObject.DrawString(testParam0, testParam1, testParam2, testParam3);

            _mockPage.Verify(p => p.UseFont(It.IsAny<IFontDescriptor>()), Times.AtLeastOnce());
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_CallsUseFontMethodOfFirstParameterOfConstructorWithSecondParameter_OnFirstCall()
        {
            _mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f => new PdfFont(_rnd.Next(1, int.MaxValue), f, null));
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            Mock<IFontDescriptor> mockFont = new();
            mockFont.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            IFontDescriptor testParam1 = mockFont.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            _testObject.DrawString(testParam0, testParam1, testParam2, testParam3);

            _mockPage.Verify(p => p.UseFont(testParam1), Times.Once());
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_WritesExpectedResultToContentStreamPropertyOfFirstParameterOfConstructor_OnFirstCall()
        {
            double fontPointSize = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont = new();
            mockFont.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont.Setup(f => f.PointSize).Returns(fontPointSize);
            PdfFont internalFont = null;
            _mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f =>
            {
                internalFont = new PdfFont(_rnd.Next(1, int.MaxValue), f, null);
                return internalFont;
            });
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = mockFont.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            _testObject.DrawString(testParam0, testParam1, testParam2, testParam3);

            List<byte> expected = new();
            PdfOperator.SetDeviceGreyscaleNonStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartText().WriteTo(expected);
            PdfOperator.SetTextFont(internalFont.InternalName, new PdfReal(fontPointSize)).WriteTo(expected);
            PdfOperator.SetTextLocation(new PdfReal(testParam2), new PdfReal(testParam3 * 2)).WriteTo(expected);
            PdfOperator.DrawText(new PdfByteString(Encoding.ASCII.GetBytes(testParam0))).WriteTo(expected);
            PdfOperator.EndText().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_CallsUseFontMethodOfFirstParameterOfConstructorOnce_AfterTwoCallsWithSameSecondParameter()
        {
            double fontPointSize = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont = new();
            mockFont.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont.Setup(f => f.PointSize).Returns(fontPointSize);
            PdfFont internalFont = null;
            _mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f =>
            {
                internalFont = new PdfFont(_rnd.Next(1, int.MaxValue), f, null);
                return internalFont;
            });
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = mockFont.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            string testParam4 = _rnd.NextString(_rnd.Next(20));
            double testParam5 = _rnd.NextDouble() * 1000;
            double testParam6 = _rnd.NextDouble() * 1000;

            _testObject.DrawString(testParam0, testParam1, testParam2, testParam3);
            _testObject.DrawString(testParam4, testParam1, testParam5, testParam6);

            _mockPage.Verify(p => p.UseFont(It.IsAny<IFontDescriptor>()), Times.Once());
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_WritesExpectedResultToContentStreamPropertyOfFirstParameterOfConstructor_AfterTwoFirstWithSameSecondParameter()
        {
            double fontPointSize = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont = new();
            mockFont.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont.Setup(f => f.PointSize).Returns(fontPointSize);
            PdfFont internalFont = null;
            _mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f =>
            {
                internalFont = new PdfFont(_rnd.Next(1, int.MaxValue), f, null);
                return internalFont;
            });
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = mockFont.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            string testParam4 = _rnd.NextString(_rnd.Next(20));
            double testParam5 = _rnd.NextDouble() * 1000;
            double testParam6 = _rnd.NextDouble() * 1000;

            _testObject.DrawString(testParam0, testParam1, testParam2, testParam3);
            _testObject.DrawString(testParam4, testParam1, testParam5, testParam6);

            List<byte> expected = new();
            PdfOperator.SetDeviceGreyscaleNonStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartText().WriteTo(expected);
            PdfOperator.SetTextFont(internalFont.InternalName, new PdfReal(fontPointSize)).WriteTo(expected);
            PdfOperator.SetTextLocation(new PdfReal(testParam2), new PdfReal(testParam3 * 2)).WriteTo(expected);
            PdfOperator.DrawText(new PdfByteString(Encoding.ASCII.GetBytes(testParam0))).WriteTo(expected);
            PdfOperator.EndText().WriteTo(expected);
            PdfOperator.StartText().WriteTo(expected);
            PdfOperator.SetTextLocation(new PdfReal(testParam5 * 3), new PdfReal(testParam6 * 4)).WriteTo(expected);
            PdfOperator.DrawText(new PdfByteString(Encoding.ASCII.GetBytes(testParam4))).WriteTo(expected);
            PdfOperator.EndText().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_CallsUseFontMethodOfFirstParameterOfConstructorTwice_AfterTwoCallsWithDifferentSecondParameter()
        {
            double fontPointSize0 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont0 = new();
            mockFont0.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont0.Setup(f => f.PointSize).Returns(fontPointSize0);
            double fontPointSize1 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont1 = new();
            mockFont1.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont1.Setup(f => f.PointSize).Returns(fontPointSize1);
            _mockPage.Setup(p => p.ContentStream).Returns(_testOutputStream);
            PdfFont internalFont0 = null;
            PdfFont internalFont1 = null;
            _mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f =>
            {
                PdfFont internalFont = new(_rnd.Next(1, int.MaxValue), f, null);
                if (f == mockFont0.Object)
                {
                    internalFont0 = internalFont;
                }
                else if (f == mockFont1.Object)
                {
                    internalFont1 = internalFont;
                }
                return internalFont;
            });
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = mockFont0.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            string testParam4 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam5 = mockFont1.Object;
            double testParam6 = _rnd.NextDouble() * 1000;
            double testParam7 = _rnd.NextDouble() * 1000;

            _testObject.DrawString(testParam0, testParam1, testParam2, testParam3);
            _testObject.DrawString(testParam4, testParam5, testParam6, testParam7);

            _mockPage.Verify(p => p.UseFont(It.IsAny<IFontDescriptor>()), Times.Exactly(2));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_CallsUseFontMethodOfFirstParameterOfConstructorOnceWithSecondParameterOfFirstCall_AfterTwoCallsWithDifferentSecondParameter()
        {
            double fontPointSize0 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont0 = new();
            mockFont0.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont0.Setup(f => f.PointSize).Returns(fontPointSize0);
            double fontPointSize1 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont1 = new();
            mockFont1.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont1.Setup(f => f.PointSize).Returns(fontPointSize1);
            PdfFont internalFont0 = null;
            PdfFont internalFont1 = null;
            _mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f =>
            {
                PdfFont internalFont = new(_rnd.Next(1, int.MaxValue), f, null);
                if (f == mockFont0.Object)
                {
                    internalFont0 = internalFont;
                }
                else if (f == mockFont1.Object)
                {
                    internalFont1 = internalFont;
                }
                return internalFont;
            });
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = mockFont0.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            string testParam4 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam5 = mockFont1.Object;
            double testParam6 = _rnd.NextDouble() * 1000;
            double testParam7 = _rnd.NextDouble() * 1000;

            _testObject.DrawString(testParam0, testParam1, testParam2, testParam3);
            _testObject.DrawString(testParam4, testParam5, testParam6, testParam7);

            _mockPage.Verify(p => p.UseFont(testParam1), Times.Once());
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_CallsUseFontMethodOfFirstParameterOfConstructorOnceWithSecondParameterOfSecondCall_AfterTwoCallsWithDifferentSecondParameter()
        {
            double fontPointSize0 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont0 = new();
            mockFont0.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont0.Setup(f => f.PointSize).Returns(fontPointSize0);
            double fontPointSize1 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont1 = new();
            mockFont1.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont1.Setup(f => f.PointSize).Returns(fontPointSize1);
            PdfFont internalFont0 = null;
            PdfFont internalFont1 = null;
            _mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f =>
            {
                PdfFont internalFont = new(_rnd.Next(1, int.MaxValue), f, null);
                if (f == mockFont0.Object)
                {
                    internalFont0 = internalFont;
                }
                else if (f == mockFont1.Object)
                {
                    internalFont1 = internalFont;
                }
                return internalFont;
            });
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = mockFont0.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            string testParam4 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam5 = mockFont1.Object;
            double testParam6 = _rnd.NextDouble() * 1000;
            double testParam7 = _rnd.NextDouble() * 1000;

            _testObject.DrawString(testParam0, testParam1, testParam2, testParam3);
            _testObject.DrawString(testParam4, testParam5, testParam6, testParam7);

            _mockPage.Verify(p => p.UseFont(testParam5), Times.Once());
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_WritesExpectedResultToContentStreamPropertyOfFirstParameterOfConstructor_AfterTwoFirstWithDifferentSecondParameter()
        {
            double fontPointSize0 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont0 = new();
            mockFont0.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont0.Setup(f => f.PointSize).Returns(fontPointSize0);
            double fontPointSize1 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont1 = new();
            mockFont1.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont1.Setup(f => f.PointSize).Returns(fontPointSize1);
            PdfFont internalFont0 = null;
            PdfFont internalFont1 = null;
            _mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f =>
            {
                PdfFont internalFont = new(_rnd.Next(1, int.MaxValue), f, null);
                if (f == mockFont0.Object)
                {
                    internalFont0 = internalFont;
                }
                else if (f == mockFont1.Object)
                {
                    internalFont1 = internalFont;
                }
                return internalFont;
            });
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = mockFont0.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            string testParam4 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam5 = mockFont1.Object;
            double testParam6 = _rnd.NextDouble() * 1000;
            double testParam7 = _rnd.NextDouble() * 1000;

            _testObject.DrawString(testParam0, testParam1, testParam2, testParam3);
            _testObject.DrawString(testParam4, testParam5, testParam6, testParam7);

            List<byte> expected = new();
            PdfOperator.SetDeviceGreyscaleNonStrokingColour(new PdfReal(0)).WriteTo(expected);
            PdfOperator.StartText().WriteTo(expected);
            PdfOperator.SetTextFont(internalFont0.InternalName, new PdfReal(fontPointSize0)).WriteTo(expected);
            PdfOperator.SetTextLocation(new PdfReal(testParam2), new PdfReal(testParam3 * 2)).WriteTo(expected);
            PdfOperator.DrawText(new PdfByteString(Encoding.ASCII.GetBytes(testParam0))).WriteTo(expected);
            PdfOperator.EndText().WriteTo(expected);
            PdfOperator.StartText().WriteTo(expected);
            PdfOperator.SetTextFont(internalFont1.InternalName, new PdfReal(fontPointSize1)).WriteTo(expected);
            PdfOperator.SetTextLocation(new PdfReal(testParam6 * 3), new PdfReal(testParam7 * 4)).WriteTo(expected);
            PdfOperator.DrawText(new PdfByteString(Encoding.ASCII.GetBytes(testParam4))).WriteTo(expected);
            PdfOperator.EndText().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, _testOutputStream);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
