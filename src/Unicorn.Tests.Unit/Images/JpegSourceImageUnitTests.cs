using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading.Tasks;
using Unicorn.Images;

namespace Unicorn.Tests.Unit.Images
{
    [TestClass]
    public class JpegSourceImageUnitTests
    {

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            Stream testParam = null;
            JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(testParam).ConfigureAwait(false);

            Assert.Fail();
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
