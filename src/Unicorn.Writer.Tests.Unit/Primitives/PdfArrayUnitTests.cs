using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Providers;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;
using Unicorn.Writer.Tests.Unit.TestHelpers;

namespace Unicorn.Writer.Tests.Unit.Primitives
{
    [TestClass]
    public class PdfArrayUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        private static IEnumerable<IPdfPrimitiveObject> GetPdfPrimitiveObjects(int? count = null)
        {
            if (!count.HasValue)
            {
                count = _rnd.Next(16) + 1;
            }
            for (int i = 0; i < count; ++i)
            {
                yield return _rnd.NextPdfPrimitive();
            }
        }

        [TestMethod]
        public void PdfArrayClass_LengthProperty_EqualsNumberOfElementsPassedToConstructor()
        {
            List<IPdfPrimitiveObject> testObjectContents = GetPdfPrimitiveObjects().ToList();

            PdfArray testObject = new PdfArray(testObjectContents);

            Assert.AreEqual(testObjectContents.Count, testObject.Length);
        }

        [TestMethod]
        public void PdfArrayClass_Indexer_ReturnsCorrectElementAtEachIndex()
        {
            List<IPdfPrimitiveObject> testObjectContents = GetPdfPrimitiveObjects().ToList();

            PdfArray testObject = new PdfArray(testObjectContents);

            for (int i = 0; i < testObjectContents.Count; ++i)
            {
                Assert.AreSame(testObjectContents[i], testObject[i]);
            }
        }

        [TestMethod]
        public void PdfArrayClass_ByteLengthProperty_HasCorrectValueWhenArrayIsEmpty()
        {
            // The correct value for this test is 3: "[]\r".
            PdfArray testObject = new PdfArray(Array.Empty<IPdfPrimitiveObject>());

            Assert.AreEqual(3, testObject.ByteLength);
        }

        [TestMethod]
        public void PdfArrayClass_ByteLengthProperty_HasCorrectValueWhenArrayContainsOneItem()
        {
            List<IPdfPrimitiveObject> testObjectContents = GetPdfPrimitiveObjects(1).ToList();

            PdfArray testObject = new PdfArray(testObjectContents);

            // This only works for definite because  GetPdfPrimitiveObjects() uses RandomExtensions.NextPdfPrimitive() which cannot (at present!) return anything with a ByteLength
            // long enough to trigger adding a line ending.
            Assert.AreEqual(testObjectContents[0].ByteLength + 3, testObject.ByteLength);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
