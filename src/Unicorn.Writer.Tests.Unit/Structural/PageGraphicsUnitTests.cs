using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;
using Unicorn.CoreTypes.Tests.Utility.Extensions;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;
using Unicorn.Writer.Structural;
using Unicorn.Writer.Tests.Unit.TestHelpers;

namespace Unicorn.Writer.Tests.Unit.Structural
{
    [TestClass]
    public class PageGraphicsUnitTests
    {
        private readonly static Random _rnd = RandomProvider.Default;

        private readonly List<double> _transformedXParameters = new List<double>();
        private readonly List<double> _transformedYParameters = new List<double>();

        private int _transformerCalls;

        private double TransformParam(double val, List<double> store)
        {
            store.Add(val);
            return val * ++_transformerCalls;
        }

        private double TransformXParam(double val) => TransformParam(val, _transformedXParameters);

        private double TransformYParam(double val) => TransformParam(val, _transformedYParameters);

        [TestInitialize]
        public void Setup()
        {
            _transformerCalls = 0;
            _transformedXParameters.Clear();
            _transformedYParameters.Clear();
        }

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PageGraphicsClass_Constructor_ThrowsArgumentNullExceptionIfFirstParameterIsNull()
        {
            IPdfPage testParam0 = null;
            Func<double, double> testParam2 = TransformXParam;
            Func<double, double> testParam3 = TransformYParam;

            PageGraphics testOutput = new PageGraphics(testParam0, testParam2, testParam3);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(1)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_CallsSecondParameterOfConstructorWithThirdParameter_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedXParameters.Contains(testParam2));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_CallsThirdParameterOfConstructorWithSecondParameter_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_CallsThirdParameterOfConstructorWithFourthParameter_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedYParameters.Contains(testParam3));
        }

        // This test is to show that PageGraphics does not send out w operations unnecessarily.
        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwice()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);
            testObject.DrawLine(testParam4, testParam5, testParam6, testParam7);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(1)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam4 * 5), new PdfReal(testParam5 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam6 * 7), new PdfReal(testParam7 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_CallsSecondParameterOfConstructorWithThirdParameter_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedXParameters.Contains(testParam2));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_CallsThirdParameterOfConstructorWithSecondParameter_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_CallsThirdParameterOfConstructorWithFourthParameter_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedYParameters.Contains(testParam3));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithDifferentFifthParameters()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
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

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);
            testObject.DrawLine(testParam5, testParam6, testParam7, testParam8, testParam9);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.LineWidth(new PdfReal(testParam9)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam5 * 5), new PdfReal(testParam6 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam7 * 7), new PdfReal(testParam8 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithSameFifthParameters()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);
            testObject.DrawLine(testParam5, testParam6, testParam7, testParam8, testParam4);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam5 * 5), new PdfReal(testParam6 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam7 * 7), new PdfReal(testParam8 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsSolid()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.Solid;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsDash()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.Dash;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.LineDashPattern(new PdfArray(new PdfReal(testParam4 * 3), new PdfReal(testParam4)), PdfInteger.Zero).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsDot()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.Dot;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.LineDashPattern(new PdfArray(new PdfReal(testParam4)), PdfInteger.Zero).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsDashDot()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.DashDot;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.LineDashPattern(new PdfArray(new PdfReal(testParam4 * 3), new PdfReal(testParam4), new PdfReal(testParam4), new PdfReal(testParam4)), 
                PdfInteger.Zero).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsDashDotDot()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.DashDotDot;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.LineDashPattern(new PdfArray(new PdfReal(testParam4 * 3), new PdfReal(testParam4), new PdfReal(testParam4), new PdfReal(testParam4), 
                new PdfReal(testParam4), new PdfReal(testParam4)), PdfInteger.Zero).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_CallsSecondParameterOfConstructorWithThirdParameter_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.IsTrue(_transformedXParameters.Contains(testParam2));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_CallsThirdParameterOfConstructorWithSecondParameter_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_CallsThirdParameterOfConstructorWithFourthParameter_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedYParameters.Contains(testParam3));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithSameFifthAndSixthParameters()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
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

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
            testObject.DrawLine(testParam6, testParam7, testParam8, testParam9, testParam4, testParam5);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            if (testParam5 != UniDashStyle.Solid)
            {
                IPdfPrimitiveObject[] operands = testParam5.ToPdfObjects(testParam4);
                PdfOperator.LineDashPattern(operands[0] as PdfArray, operands[1] as PdfInteger).WriteTo(expected);
            }
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam6 * 5), new PdfReal(testParam7 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam8 * 7), new PdfReal(testParam9 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithDifferentFifthAndSameSixthParameters()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
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

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
            testObject.DrawLine(testParam6, testParam7, testParam8, testParam9, testParam10, testParam5);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            if (testParam5 != UniDashStyle.Solid)
            {
                IPdfPrimitiveObject[] operands = testParam5.ToPdfObjects(testParam4);
                PdfOperator.LineDashPattern(operands[0] as PdfArray, operands[1] as PdfInteger).WriteTo(expected);
            }
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
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithSameFifthAndDifferentSixthParameters()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
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

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
            testObject.DrawLine(testParam6, testParam7, testParam8, testParam9, testParam4, testParam10);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            if (testParam5 != UniDashStyle.Solid)
            {
                IPdfPrimitiveObject[] operands0 = testParam5.ToPdfObjects(testParam4);
                PdfOperator.LineDashPattern(operands0[0] as PdfArray, operands0[1] as PdfInteger).WriteTo(expected);
            }
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            IPdfPrimitiveObject[] operands1 = testParam10.ToPdfObjects(testParam4);
            PdfOperator.LineDashPattern(operands1[0] as PdfArray, operands1[1] as PdfInteger).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam6 * 5), new PdfReal(testParam7 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam8 * 7), new PdfReal(testParam9 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithDifferentFifthAndSixthParameters()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
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

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
            testObject.DrawLine(testParam6, testParam7, testParam8, testParam9, testParam10, testParam11);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            if (testParam5 != UniDashStyle.Solid)
            {
                IPdfPrimitiveObject[] operands = testParam5.ToPdfObjects(testParam4);
                PdfOperator.LineDashPattern(operands[0] as PdfArray, operands[1] as PdfInteger).WriteTo(expected);
            }
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.LineWidth(new PdfReal(testParam10)).WriteTo(expected);
            IPdfPrimitiveObject[] operands1 = testParam11.ToPdfObjects(testParam10);
            PdfOperator.LineDashPattern(operands1[0] as PdfArray, operands1[1] as PdfInteger).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam6 * 5), new PdfReal(testParam7 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam8 * 7), new PdfReal(testParam9 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(1d)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_CallsThirdParameterOfConstructorWithSumOfSecondAndFourthParameters_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1 + testParam3));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwice()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3);
            testObject.DrawRectangle(testParam4, testParam5, testParam6, testParam7);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(1d)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam4 * 3), new PdfReal((testParam5 + testParam7) * 4), new PdfReal(testParam6), new PdfReal(testParam7))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFiveDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFiveDoubleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFiveDoubleParameters_CallsThirdParameterOfConstructorWithSumOfSecondAndFourthParameters_IfCalledOnce()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1 + testParam3));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithSameFifthParameter()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);
            testObject.DrawRectangle(testParam5, testParam6, testParam7, testParam8, testParam4);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam5 * 3), new PdfReal((testParam6 + testParam8) * 4), new PdfReal(testParam7), new PdfReal(testParam8))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_WritesCorrectValueToContentStreamPropertyOfFirstParameterOfConstructor_IfCalledTwiceWithDifferentFifthParameter()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> constrParam0Base = new Mock<IPdfPage>();
            constrParam0Base.Setup(p => p.ContentStream).Returns(constrParam1);
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0Base.Object, constrParam2, constrParam3);
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

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);
            testObject.DrawRectangle(testParam5, testParam6, testParam7, testParam8, testParam9);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.LineWidth(new PdfReal(testParam9)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam5 * 3), new PdfReal((testParam6 + testParam8) * 4), new PdfReal(testParam7), new PdfReal(testParam8))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PageGraphicsClass_MeasureStringMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            IPdfPage constrParam0 = new Mock<IPdfPage>().Object;
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam2, constrParam3);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = null;

            _ = testObject.MeasureString(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_MeasureStringMethod_CallsMeasureStringMethodOfSecondParameter_IfSecondParameterIsNotNull()
        {
            IPdfPage constrParam0 = new Mock<IPdfPage>().Object;
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam2, constrParam3);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            UniTextSize expectedResult = new UniTextSize(_rnd.NextDouble() * 100, _rnd.NextDouble() * 100, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, 
                _rnd.NextDouble() * 1000);
            Mock<IFontDescriptor> mockFont = new Mock<IFontDescriptor>();
            mockFont.Setup(f => f.MeasureString(It.IsAny<string>())).Returns(expectedResult);
            IFontDescriptor testParam1 = mockFont.Object;

            _ = testObject.MeasureString(testParam0, testParam1);

            mockFont.Verify(f => f.MeasureString(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public void PageGraphicsClass_MeasureStringMethod_PassesFirstParameterToMeasureStringMethodOfSecondParameter_IfSecondParameterIsNotNull()
        {
            IPdfPage constrParam0 = new Mock<IPdfPage>().Object;
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam2, constrParam3);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            UniTextSize expectedResult = new UniTextSize(_rnd.NextDouble() * 100, _rnd.NextDouble() * 100, _rnd.NextDouble() * 100, _rnd.NextDouble() * 100, 
                _rnd.NextDouble() * 100);
            Mock<IFontDescriptor> mockFont = new Mock<IFontDescriptor>();
            mockFont.Setup(f => f.MeasureString(It.IsAny<string>())).Returns(expectedResult);
            IFontDescriptor testParam1 = mockFont.Object;

            _ = testObject.MeasureString(testParam0, testParam1);

            mockFont.Verify(f => f.MeasureString(testParam0), Times.Once());
        }

        [TestMethod]
        public void PageGraphicsClass_MeasureStringMethod_ReturnsValueReturnedByMeasureStringMethodOfSecondParameter_IfSecondParameterIsNotNull()
        {
            IPdfPage constrParam0 = new Mock<IPdfPage>().Object;
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam2, constrParam3);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            UniTextSize expectedResult = new UniTextSize(_rnd.NextDouble() * 100, _rnd.NextDouble() * 100, _rnd.NextDouble() * 100, _rnd.NextDouble() * 100, 
                _rnd.NextDouble() * 100);
            Mock<IFontDescriptor> mockFont = new Mock<IFontDescriptor>();
            mockFont.Setup(f => f.MeasureString(It.IsAny<string>())).Returns(expectedResult);
            IFontDescriptor testParam1 = mockFont.Object;

            UniTextSize testOutput = testObject.MeasureString(testParam0, testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            IPdfPage constrParam0 = new Mock<IPdfPage>().Object;
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam2, constrParam3);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = null;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            testObject.DrawString(testParam0, testParam1, testParam2, testParam3);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_CallsUseFontMethodOfFirstParameterOfConstructor_OnFirstCall()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> mockPage = new Mock<IPdfPage>();
            mockPage.Setup(p => p.ContentStream).Returns(constrParam1);
            mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f => new PdfFont(_rnd.Next(1, int.MaxValue), f, null));
            IPdfPage constrParam0 = mockPage.Object;
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam2, constrParam3);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            Mock<IFontDescriptor> mockFont = new Mock<IFontDescriptor>();
            mockFont.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            IFontDescriptor testParam1 = mockFont.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            testObject.DrawString(testParam0, testParam1, testParam2, testParam3);

            mockPage.Verify(p => p.UseFont(It.IsAny<IFontDescriptor>()), Times.AtLeastOnce());
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_CallsUseFontMethodOfFirstParameterOfConstructorWithSecondParameter_OnFirstCall()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Mock<IPdfPage> mockPage = new Mock<IPdfPage>();
            mockPage.Setup(p => p.ContentStream).Returns(constrParam1);
            mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f => new PdfFont(_rnd.Next(1, int.MaxValue), f, null));
            IPdfPage constrParam0 = mockPage.Object;
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam2, constrParam3);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            Mock<IFontDescriptor> mockFont = new Mock<IFontDescriptor>();
            mockFont.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            IFontDescriptor testParam1 = mockFont.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            testObject.DrawString(testParam0, testParam1, testParam2, testParam3);

            mockPage.Verify(p => p.UseFont(testParam1), Times.Once());
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_WritesExpectedResultToContentStreamPropertyOfFirstParameterOfConstructor_OnFirstCall()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            double fontPointSize = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont = new Mock<IFontDescriptor>();
            mockFont.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont.Setup(f => f.PointSize).Returns(fontPointSize);
            Mock<IPdfPage> mockPage = new Mock<IPdfPage>();
            mockPage.Setup(p => p.ContentStream).Returns(constrParam1);
            PdfFont internalFont = null;
            mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f =>
            {
                internalFont = new PdfFont(_rnd.Next(1, int.MaxValue), f, null);
                return internalFont;
            });
            IPdfPage constrParam0 = mockPage.Object;
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam2, constrParam3);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = mockFont.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            testObject.DrawString(testParam0, testParam1, testParam2, testParam3);

            List<byte> expected = new List<byte>();
            PdfOperator.StartText().WriteTo(expected);
            PdfOperator.SetTextFont(internalFont.InternalName, new PdfReal(fontPointSize)).WriteTo(expected);
            PdfOperator.SetTextLocation(new PdfReal(testParam2), new PdfReal(testParam3 * 2)).WriteTo(expected);
            PdfOperator.DrawText(new PdfByteString(Encoding.ASCII.GetBytes(testParam0))).WriteTo(expected);
            PdfOperator.EndText().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_CallsUseFontMethodOfFirstParameterOfConstructorOnce_AfterTwoCallsWithSameSecondParameter()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            double fontPointSize = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont = new Mock<IFontDescriptor>();
            mockFont.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont.Setup(f => f.PointSize).Returns(fontPointSize);
            Mock<IPdfPage> mockPage = new Mock<IPdfPage>();
            mockPage.Setup(p => p.ContentStream).Returns(constrParam1);
            PdfFont internalFont = null;
            mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f =>
            {
                internalFont = new PdfFont(_rnd.Next(1, int.MaxValue), f, null);
                return internalFont;
            });
            IPdfPage constrParam0 = mockPage.Object;
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam2, constrParam3);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = mockFont.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            string testParam4 = _rnd.NextString(_rnd.Next(20));
            double testParam5 = _rnd.NextDouble() * 1000;
            double testParam6 = _rnd.NextDouble() * 1000;

            testObject.DrawString(testParam0, testParam1, testParam2, testParam3);
            testObject.DrawString(testParam4, testParam1, testParam5, testParam6);

            mockPage.Verify(p => p.UseFont(It.IsAny<IFontDescriptor>()), Times.Once());
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_WritesExpectedResultToContentStreamPropertyOfFirstParameterOfConstructor_AfterTwoFirstWithSameSecondParameter()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            double fontPointSize = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont = new Mock<IFontDescriptor>();
            mockFont.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont.Setup(f => f.PointSize).Returns(fontPointSize);
            Mock<IPdfPage> mockPage = new Mock<IPdfPage>();
            mockPage.Setup(p => p.ContentStream).Returns(constrParam1);
            PdfFont internalFont = null;
            mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f =>
            {
                internalFont = new PdfFont(_rnd.Next(1, int.MaxValue), f, null);
                return internalFont;
            });
            IPdfPage constrParam0 = mockPage.Object;
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam2, constrParam3);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = mockFont.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            string testParam4 = _rnd.NextString(_rnd.Next(20));
            double testParam5 = _rnd.NextDouble() * 1000;
            double testParam6 = _rnd.NextDouble() * 1000;

            testObject.DrawString(testParam0, testParam1, testParam2, testParam3);
            testObject.DrawString(testParam4, testParam1, testParam5, testParam6);

            List<byte> expected = new List<byte>();
            PdfOperator.StartText().WriteTo(expected);
            PdfOperator.SetTextFont(internalFont.InternalName, new PdfReal(fontPointSize)).WriteTo(expected);
            PdfOperator.SetTextLocation(new PdfReal(testParam2), new PdfReal(testParam3 * 2)).WriteTo(expected);
            PdfOperator.DrawText(new PdfByteString(Encoding.ASCII.GetBytes(testParam0))).WriteTo(expected);
            PdfOperator.EndText().WriteTo(expected);
            PdfOperator.StartText().WriteTo(expected);
            PdfOperator.SetTextLocation(new PdfReal(testParam5 * 3), new PdfReal(testParam6 * 4)).WriteTo(expected);
            PdfOperator.DrawText(new PdfByteString(Encoding.ASCII.GetBytes(testParam4))).WriteTo(expected);
            PdfOperator.EndText().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_CallsUseFontMethodOfFirstParameterOfConstructorTwice_AfterTwoCallsWithDifferentSecondParameter()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            double fontPointSize0 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont0 = new Mock<IFontDescriptor>();
            mockFont0.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont0.Setup(f => f.PointSize).Returns(fontPointSize0);
            double fontPointSize1 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont1 = new Mock<IFontDescriptor>();
            mockFont1.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont1.Setup(f => f.PointSize).Returns(fontPointSize1);
            Mock<IPdfPage> mockPage = new Mock<IPdfPage>();
            mockPage.Setup(p => p.ContentStream).Returns(constrParam1);
            PdfFont internalFont0 = null;
            PdfFont internalFont1 = null;
            mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f =>
            {
                PdfFont internalFont = new PdfFont(_rnd.Next(1, int.MaxValue), f, null);
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
            IPdfPage constrParam0 = mockPage.Object;
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam2, constrParam3);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = mockFont0.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            string testParam4 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam5 = mockFont1.Object;
            double testParam6 = _rnd.NextDouble() * 1000;
            double testParam7 = _rnd.NextDouble() * 1000;

            testObject.DrawString(testParam0, testParam1, testParam2, testParam3);
            testObject.DrawString(testParam4, testParam5, testParam6, testParam7);

            mockPage.Verify(p => p.UseFont(It.IsAny<IFontDescriptor>()), Times.Exactly(2));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_CallsUseFontMethodOfFirstParameterOfConstructorOnceWithSecondParameterOfFirstCall_AfterTwoCallsWithDifferentSecondParameter()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            double fontPointSize0 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont0 = new Mock<IFontDescriptor>();
            mockFont0.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont0.Setup(f => f.PointSize).Returns(fontPointSize0);
            double fontPointSize1 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont1 = new Mock<IFontDescriptor>();
            mockFont1.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont1.Setup(f => f.PointSize).Returns(fontPointSize1);
            Mock<IPdfPage> mockPage = new Mock<IPdfPage>();
            mockPage.Setup(p => p.ContentStream).Returns(constrParam1);
            PdfFont internalFont0 = null;
            PdfFont internalFont1 = null;
            mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f =>
            {
                PdfFont internalFont = new PdfFont(_rnd.Next(1, int.MaxValue), f, null);
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
            IPdfPage constrParam0 = mockPage.Object;
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam2, constrParam3);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = mockFont0.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            string testParam4 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam5 = mockFont1.Object;
            double testParam6 = _rnd.NextDouble() * 1000;
            double testParam7 = _rnd.NextDouble() * 1000;

            testObject.DrawString(testParam0, testParam1, testParam2, testParam3);
            testObject.DrawString(testParam4, testParam5, testParam6, testParam7);

            mockPage.Verify(p => p.UseFont(testParam1), Times.Once());
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_CallsUseFontMethodOfFirstParameterOfConstructorOnceWithSecondParameterOfSecondCall_AfterTwoCallsWithDifferentSecondParameter()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            double fontPointSize0 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont0 = new Mock<IFontDescriptor>();
            mockFont0.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont0.Setup(f => f.PointSize).Returns(fontPointSize0);
            double fontPointSize1 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont1 = new Mock<IFontDescriptor>();
            mockFont1.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont1.Setup(f => f.PointSize).Returns(fontPointSize1);
            Mock<IPdfPage> mockPage = new Mock<IPdfPage>();
            mockPage.Setup(p => p.ContentStream).Returns(constrParam1);
            PdfFont internalFont0 = null;
            PdfFont internalFont1 = null;
            mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f =>
            {
                PdfFont internalFont = new PdfFont(_rnd.Next(1, int.MaxValue), f, null);
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
            IPdfPage constrParam0 = mockPage.Object;
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam2, constrParam3);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = mockFont0.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            string testParam4 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam5 = mockFont1.Object;
            double testParam6 = _rnd.NextDouble() * 1000;
            double testParam7 = _rnd.NextDouble() * 1000;

            testObject.DrawString(testParam0, testParam1, testParam2, testParam3);
            testObject.DrawString(testParam4, testParam5, testParam6, testParam7);

            mockPage.Verify(p => p.UseFont(testParam5), Times.Once());
        }

        [TestMethod]
        public void PageGraphicsClass_DrawStringMethodWithStringIFontDescriptorDoubleAndDoubleParameters_WritesExpectedResultToContentStreamPropertyOfFirstParameterOfConstructor_AfterTwoFirstWithDifferentSecondParameter()
        {
            PdfStream constrParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            double fontPointSize0 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont0 = new Mock<IFontDescriptor>();
            mockFont0.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont0.Setup(f => f.PointSize).Returns(fontPointSize0);
            double fontPointSize1 = _rnd.NextDouble() * 20;
            Mock<IFontDescriptor> mockFont1 = new Mock<IFontDescriptor>();
            mockFont1.Setup(f => f.PreferredEncoding).Returns(Encoding.ASCII);
            mockFont1.Setup(f => f.PointSize).Returns(fontPointSize1);
            Mock<IPdfPage> mockPage = new Mock<IPdfPage>();
            mockPage.Setup(p => p.ContentStream).Returns(constrParam1);
            PdfFont internalFont0 = null;
            PdfFont internalFont1 = null;
            mockPage.Setup(p => p.UseFont(It.IsAny<IFontDescriptor>())).Returns<IFontDescriptor>(f =>
            {
                PdfFont internalFont = new PdfFont(_rnd.Next(1, int.MaxValue), f, null);
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
            IPdfPage constrParam0 = mockPage.Object;
            Func<double, double> constrParam2 = TransformXParam;
            Func<double, double> constrParam3 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam2, constrParam3);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = mockFont0.Object;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;
            string testParam4 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam5 = mockFont1.Object;
            double testParam6 = _rnd.NextDouble() * 1000;
            double testParam7 = _rnd.NextDouble() * 1000;

            testObject.DrawString(testParam0, testParam1, testParam2, testParam3);
            testObject.DrawString(testParam4, testParam5, testParam6, testParam7);

            List<byte> expected = new List<byte>();
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
            AssertionHelpers.AssertSameElements(expected, constrParam1);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
