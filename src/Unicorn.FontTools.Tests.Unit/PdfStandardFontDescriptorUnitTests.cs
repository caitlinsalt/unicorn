using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Afm;
using Unicorn.FontTools.Tests.Unit.TestHelpers;

namespace Unicorn.FontTools.Tests.Unit
{
    [TestClass]
    public class PdfStandardFontDescriptorUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void PdfStandardFontDescriptorClass_Constructor_SetsPointSizePropertyToSecondParameter()
        {
            AfmFontMetrics testParam0 = null;
            double testParam1 = _rnd.NextDouble() * 20;

            PdfStandardFontDescriptor testOutput = new PdfStandardFontDescriptor(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.PointSize);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfStandardFontDescriptorClass_GetByNameMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            string testParam0 = null;
            double testParam1 = _rnd.NextDouble() * 20;

            _ = PdfStandardFontDescriptor.GetByName(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FontException))]
        public void PdfStandardFontDescriptorClass_GetByNameMethod_ThrowsFontException_IfFirstParameterIsEmptyString()
        {
            string testParam0 = "";
            double testParam1 = _rnd.NextDouble() * 20;

            _ = PdfStandardFontDescriptor.GetByName(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FontException))]
        public void PdfStandardFontDescriptorClass_GetByNameMethod_ThrowsFontException_IfFirstParameterIsWhitespace()
        {
            string testParam0 = _rnd.NextString(" \t\n\r", _rnd.Next(1, 20));
            double testParam1 = _rnd.NextDouble() * 20;

            _ = PdfStandardFontDescriptor.GetByName(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FontException))]
        public void PdfStandardFontDescriptorClass_GetByNameMethod_ThrowsFontException_IfFirstParameterIsNotRecognisedName()
        {
            string testParam0;
            do
            {
                testParam0 = _rnd.NextString(_rnd.Next(1, 20));
            } while (StandardFontHelpers.StandardFontNames.Contains(testParam0));
            double testParam1 = _rnd.NextDouble() * 20;

            _ = PdfStandardFontDescriptor.GetByName(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfStandardFontDescriptorClass_GetByNameMethod_ReturnsNonNullObject_IfFirstParameterIsValidName()
        {
            string testParam0 = StandardFontHelpers.StandardFontNames[_rnd.Next(StandardFontHelpers.StandardFontNames.Length)];
            double testParam1 = _rnd.NextDouble() * 20;

            PdfStandardFontDescriptor testOutput = PdfStandardFontDescriptor.GetByName(testParam0, testParam1);

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void PdfStandardFontDescriptorClass_GetByNameMethod_ReturnsObjectWithPointSizePropertyEqualToSecondParameter_IfFirstParameterIsValidName()
        {
            string testParam0 = StandardFontHelpers.StandardFontNames[_rnd.Next(StandardFontHelpers.StandardFontNames.Length)];
            double testParam1 = _rnd.NextDouble() * 20;

            PdfStandardFontDescriptor testOutput = PdfStandardFontDescriptor.GetByName(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.PointSize);
        }

        [TestMethod]
        public void PdfStandardFontDescriptorClass_GetSupportedFontNamesMethod_ReturnsCorrectData()
        {
            string[] expectedData = StandardFontHelpers.StandardFontNames;

            string[] testOutput = PdfStandardFontDescriptor.GetSupportedFontNames().ToArray();

            Assert.AreEqual(expectedData.Length, testOutput.Length);
            foreach (string fn in expectedData)
            {
                Assert.IsNotNull(testOutput.Single(s => s == fn));
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
