using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Tests.Utility.Providers;
using Unicorn.Base;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class PlainTextTableCellUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private Mock<IFontDescriptor> _mockFont;
        private Mock<IGraphicsContext> _mockContext;
        private PlainTextTableCell _testObject;

        [TestInitialize]
        public void TestSetup()
        {
            _mockFont = new Mock<IFontDescriptor>();
            _mockContext = new Mock<IGraphicsContext>();
            _mockContext.Setup(c => c.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>()))
                .Returns(new UniTextSize(SizeParameter(), SizeParameter(), SizeParameter(), SizeParameter(), SizeParameter()));
            _testObject = new PlainTextTableCell("", _mockFont.Object, _mockContext.Object);
        }

#pragma warning disable CA5394 // Do not use insecure randomness
        private static double SizeParameter() => _rnd.NextDouble() * 1000;
#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlainTextTableCellClass_MeasureSizeMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            _testObject.MeasureSize(null);

            Assert.Fail();
        }

        [TestMethod]
        public void PlainTextTableCellClass_MeasureSizeMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            try
            {
                _testObject.MeasureSize(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("context", ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlainTextTableCellClass_DrawContentsAtMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            _testObject.DrawContentsAt(null, SizeParameter(), SizeParameter());

            Assert.Fail();
        }

        [TestMethod]
        public void PlainTextTableCellClass_DrawContentsAtMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            try
            {
                _testObject.DrawContentsAt(null, SizeParameter(), SizeParameter());
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("context", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
