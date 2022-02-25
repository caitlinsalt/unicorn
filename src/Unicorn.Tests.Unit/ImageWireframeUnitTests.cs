using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Base;
using Unicorn.CoreTypes;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class ImageWireframeUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private ImageWireframe _testObject;

        [TestInitialize]
        public void SetUpTest()
        {
            _testObject = new ImageWireframe(_rnd.NextDouble(500), _rnd.NextDouble(500));
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ImageWireframeClass_ConstructorWithTwoDoubleParameters_SetsWidthPropertyToValueOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble(500);
            double testParam1 = _rnd.NextDouble(500);

            var testOutput = new ImageWireframe(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.Width);
        }

        [TestMethod]
        public void ImageWireframeClass_ConstructorWithTwoDoubleParameters_SetsHeightPropertyToValueOfSecondParameter()
        {
            double testParam0 = _rnd.NextDouble(500);
            double testParam1 = _rnd.NextDouble(500);

            var testOutput = new ImageWireframe(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Height);
        }

        [TestMethod]
        public void ImageWireframeClass_ConstructorWithTwoDoubleParameters_SetsContentHeightPropertyToValueOfSecondParameter()
        {
            double testParam0 = _rnd.NextDouble(500);
            double testParam1 = _rnd.NextDouble(500);

            var testOutput = new ImageWireframe(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.ContentHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ImageWireframeClass_ConstructorWithDoubleISourceImageAndMarginSetParameters_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            double testParam0 = _rnd.NextDouble(500);
            ISourceImage testParam1 = null;
            MarginSet testParam2 = null;

            _ = new ImageWireframe(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void ImageWireframeClass_ConstructorWithDoubleISourceImageAndMarginSetParameters_SetsWidthPropertyToValueOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble(500);
            Mock<ISourceImage> testParam1 = new();
            MarginSet testParam2 = null;
            double expectedHeight = _rnd.NextDouble(500);
            testParam1.Setup(i => i.AspectRatio).Returns(testParam0 / expectedHeight);

            var testOutput = new ImageWireframe(testParam0, testParam1.Object, testParam2);

            Assert.AreEqual(testParam0, testOutput.Width);
        }

        [TestMethod]
        public void ImageWireframeClass_ConstructorWithDoubleISourceImageAndMarginSetParameters_SetsHeightPropertyToCorrectValue()
        {
            double testParam0 = _rnd.NextDouble(500);
            Mock<ISourceImage> testParam1 = new();
            MarginSet testParam2 = null;
            double expectedHeight = _rnd.NextDouble(500);
            testParam1.Setup(i => i.AspectRatio).Returns(testParam0 / expectedHeight);

            var testOutput = new ImageWireframe(testParam0, testParam1.Object, testParam2);

            Assert.AreEqual(expectedHeight, testOutput.Height, 0.00000001);
        }

        [TestMethod]
        public void ImageWireframeClass_ConstructorWithDoubleISourceImageAndMarginSetParameters_SetsContentHeightPropertyToExpectedValue()
        {
            double testParam0 = _rnd.NextDouble(500);
            Mock<ISourceImage> testParam1 = new();
            MarginSet testParam2 = null;
            double expectedHeight = _rnd.NextDouble(500);
            testParam1.Setup(i => i.AspectRatio).Returns(testParam0 / expectedHeight);

            var testOutput = new ImageWireframe(testParam0, testParam1.Object, testParam2);

            Assert.AreEqual(expectedHeight, testOutput.ContentHeight, 0.00000001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ImageWireframeClass_DrawAtMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            IGraphicsContext testParam0 = null;
            double testParam1 = _rnd.NextDouble(500);
            double testParam2 = _rnd.NextDouble(500);

            _testObject.DrawAt(testParam0, testParam1, testParam2);
        }

        [TestMethod]
        public void ImageWireframeClass_DrawAtMethod_CallsDrawRectangleMethodOfFirstParamter_IfFirstParameterIsNotNull()
        {
            Mock<IGraphicsContext> mockTestParam0 = new();
            double testParam1 = _rnd.NextDouble(500);
            double testParam2 = _rnd.NextDouble(500);

            _testObject.DrawAt(mockTestParam0.Object, testParam1, testParam2);

            mockTestParam0.Verify(c => c.DrawRectangle(testParam1, testParam2, _testObject.Width, _testObject.Height));
        }

        [TestMethod]
        public void ImageWireframeClass_DrawAtMethod_CallsDrawLineMethodOfFirstParameterToDrawLineFromTopLeftToBottomRight_IfFirstParameterIsNotNull()
        {
            Mock<IGraphicsContext> mockTestParam0 = new();
            double testParam1 = _rnd.NextDouble(500);
            double testParam2 = _rnd.NextDouble(500);
            double expectedBottomRightX = testParam1 + _testObject.Width;
            double expectedBottomRightY = testParam2 + _testObject.Height;

            _testObject.DrawAt(mockTestParam0.Object, testParam1, testParam2);

            mockTestParam0.Verify(c => c.DrawLine(testParam1, testParam2, expectedBottomRightX, expectedBottomRightY));
        }

        [TestMethod]
        public void ImageWireframeClass_DrawAtMethod_CallsDrawLineMethodOfFirstParameterToDrawLineFromTopRightToBottomLeft_IfFirstParameterIsNotNull()
        {
            Mock<IGraphicsContext> mockTestParam0 = new();
            double testParam1 = _rnd.NextDouble(500);
            double testParam2 = _rnd.NextDouble(500);
            double expectedTopRightX = testParam1 + _testObject.Width;
            double expectedBottomLeftY = testParam2 + _testObject.Height;

            _testObject.DrawAt(mockTestParam0.Object, testParam1, testParam2);

            mockTestParam0.Verify(c => c.DrawLine(expectedTopRightX, testParam2, testParam1, expectedBottomLeftY));
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
