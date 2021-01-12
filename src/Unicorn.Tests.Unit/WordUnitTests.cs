using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class WordUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static Word GetTestObject()
        {
            Mock<IFontDescriptor> mockFont = new Mock<IFontDescriptor>();
            Mock<IGraphicsContext> mockContext = new Mock<IGraphicsContext>();
            mockContext.Setup(m => m.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>()))
                .Returns(new UniTextSize(_rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000,
                    _rnd.NextDouble() * 1000));
            return new Word("", mockFont.Object, mockContext.Object, _rnd.NextDouble() * 10);
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WordClass_DrawAtMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            Word testObject = GetTestObject();
            IGraphicsContext testParam0 = null;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;

            testObject.DrawAt(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void WordClass_DrawAtMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            Word testObject = GetTestObject();
            IGraphicsContext testParam0 = null;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;

            try
            {
                testObject.DrawAt(testParam0, testParam1, testParam2);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("context", ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WordClass_MakeWordsMethod_ThrowsArgumentNullException_IfFirstParameterIsNotNullAndSecondParameterIsNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(300));
            IFontDescriptor testParam1 = null;
            IGraphicsContext testParam2 = new Mock<IGraphicsContext>().Object;

            _ = Word.MakeWords(testParam0, testParam1, testParam2).ToArray();

            Assert.Fail();
        }

        [TestMethod]
        public void WordClass_MakeWordsMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNotNullAndSecondParameterIsNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(300));
            IFontDescriptor testParam1 = null;
            IGraphicsContext testParam2 = new Mock<IGraphicsContext>().Object;

            try
            {
                _ = Word.MakeWords(testParam0, testParam1, testParam2).ToArray();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("font", ex.ParamName);
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
