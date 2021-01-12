using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class PlainTextTableCellUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static PlainTextTableCell GetTestObject()
        {
            Mock<IFontDescriptor> mockFont = new Mock<IFontDescriptor>();
            Mock<IGraphicsContext> mockContext = new Mock<IGraphicsContext>();
            mockContext.Setup(m => m.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>()))
                .Returns(new UniTextSize(_rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000,
                    _rnd.NextDouble() * 1000));
            return new PlainTextTableCell("", mockFont.Object, mockContext.Object);
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlainTextTableCellClass_MeasureSizeMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            PlainTextTableCell testObject = GetTestObject();

            testObject.MeasureSize(null);

            Assert.Fail();
        }

        [TestMethod]
        public void PlainTextTableCellClass_MeasureSizeMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            PlainTextTableCell testObject = GetTestObject();

            try
            {
                testObject.MeasureSize(null);
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
            PlainTextTableCell testObject = GetTestObject();
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;

            testObject.DrawContentsAt(null, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PlainTextTableCellClass_DrawContentsAtMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            PlainTextTableCell testObject = GetTestObject();
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;

            try
            {
                testObject.DrawContentsAt(null, testParam1, testParam2);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("context", ex.ParamName);
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
