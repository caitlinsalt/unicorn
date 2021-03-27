using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Unicorn.FontTools.Afm;
using Unicorn.FontTools.Tests.Unit.TestHelpers;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class StandardFontMetricsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void StandardFontMetricsClass_CourierProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.Courier;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_CourierProperty_HasFontNamePropertyEqualToCourier()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.Courier;

            Assert.AreEqual("Courier", testOutput.FontName);
        }

        [TestMethod]
        public void StandardFontMetricsClass_CourierBoldProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.CourierBold;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_CourierBoldProperty_HasFontNamePropertyEqualToCourierBold()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.CourierBold;

            Assert.AreEqual("Courier-Bold", testOutput.FontName);
        }

        [TestMethod]
        public void StandardFontMetricsClass_CourierBoldObliqueProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.CourierBoldOblique;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_CourierBoldObliqueProperty_HasFontNamePropertyEqualToCourierBoldOblique()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.CourierBoldOblique;

            Assert.AreEqual("Courier-BoldOblique", testOutput.FontName);
        }

        [TestMethod]
        public void StandardFontMetricsClass_CourierObliqueProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.CourierOblique;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_CourierObliqueProperty_HasFontNamePropertyEqualToCourierOblique()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.CourierOblique;

            Assert.AreEqual("Courier-Oblique", testOutput.FontName);
        }

        [TestMethod]
        public void StandardFontMetricsClass_HelveticaProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.Helvetica;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_HelveticaProperty_HasFontNamePropertyEqualToHelvetica()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.Helvetica;

            Assert.AreEqual("Helvetica", testOutput.FontName);
        }

        [TestMethod]
        public void StandardFontMetricsClass_HelveticaBoldProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.HelveticaBold;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_HelveticaBoldProperty_HasFontNamePropertyEqualToHelveticaBold()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.HelveticaBold;

            Assert.AreEqual("Helvetica-Bold", testOutput.FontName);
        }

        [TestMethod]
        public void StandardFontMetricsClass_HelveticaBoldObliqueProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.HelveticaBoldOblique;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_HelveticaBoldObliqueProperty_HasFontNamePropertyEqualToHelveticaBoldOblique()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.HelveticaBoldOblique;

            Assert.AreEqual("Helvetica-BoldOblique", testOutput.FontName);
        }

        [TestMethod]
        public void StandardFontMetricsClass_HelveticaObliqueProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.HelveticaOblique;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_HelveticaObliqueProperty_HasFontNamePropertyEqualToHelveticaOblique()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.HelveticaOblique;

            Assert.AreEqual("Helvetica-Oblique", testOutput.FontName);
        }

        [TestMethod]
        public void StandardFontMetricsClass_SymbolProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.Symbol;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_SymbolProperty_HasFontNamePropertyEqualToSymbol()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.Symbol;

            Assert.AreEqual("Symbol", testOutput.FontName);
        }

        [TestMethod]
        public void StandardFontMetricsClass_TimesBoldProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.TimesBold;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_TimesBoldProperty_HasFontNamePropertyEqualToTimesBold()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.TimesBold;

            Assert.AreEqual("Times-Bold", testOutput.FontName);
        }

        [TestMethod]
        public void StandardFontMetricsClass_TimesBoldItalicProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.TimesBoldItalic;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_TimesBoldItalicProperty_HasFontNamePropertyEqualToTimesBoldItalic()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.TimesBoldItalic;

            Assert.AreEqual("Times-BoldItalic", testOutput.FontName);
        }

        [TestMethod]
        public void StandardFontMetricsClass_TimesItalicProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.TimesItalic;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_TimesItalicProperty_HasFontNamePropertyEqualToTimesItalic()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.TimesItalic;

            Assert.AreEqual("Times-Italic", testOutput.FontName);
        }

        [TestMethod]
        public void StandardFontMetricsClass_TimesRomanProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.TimesRoman;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_TimesRomanProperty_HasFontNamePropertyEqualToTimesRoman()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.TimesRoman;

            Assert.AreEqual("Times-Roman", testOutput.FontName);
        }

        [TestMethod]
        public void StandardFontMetricsClass_ZapfDingbatsProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.ZapfDingbats;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_ZapfDingbatsProperty_HasFontNamePropertyEqualToZapfDingbats()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.ZapfDingbats;

            Assert.AreEqual("ZapfDingbats", testOutput.FontName);
        }

        [TestMethod]
        public void StandardFontMetricsClass_GetSupportedFontNamesMethod_ReturnsCorrectData()
        {
            string[] expectedData = StandardFontHelpers.StandardFontNames;

            string[] testOutput = StandardFontMetrics.GetSupportedFontNames().ToArray();

            Assert.AreEqual(expectedData.Length, testOutput.Length);
            foreach (string fn in expectedData)
            {
                Assert.IsNotNull(testOutput.Single(s => s == fn));
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores
    }
}
