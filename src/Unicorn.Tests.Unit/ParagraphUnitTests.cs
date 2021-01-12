using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class ParagraphUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParagraphClass_DrawAtMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            Paragraph testObject = new Paragraph(_rnd.NextDouble() * 1000, null);
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;

            testObject.DrawAt(null, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void ParagraphClass_DrawAtMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            Paragraph testObject = new Paragraph(_rnd.NextDouble() * 1000, null);
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;

            try
            {
                testObject.DrawAt(null, testParam1, testParam2);
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
