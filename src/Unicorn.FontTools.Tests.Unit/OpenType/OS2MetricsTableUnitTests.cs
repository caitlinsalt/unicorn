using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit.OpenType
{
    [TestClass]
    public class OS2MetricsTableUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static OS2MetricsTable GetVersion0AppleVariantTable()
            => new(_rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextOpenTypeEmbeddingPermissionsFlags(), _rnd.NextShort(), _rnd.NextShort(),
                _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(),
                _rnd.NextOpenTypeIBMFamily(), _rnd.NextOpenTypePanoseFamily(), _rnd.NextOpenTypeUnicodeRanges(), _rnd.NextTag(), _rnd.NextOpenTypeOS2StyleProperties(),
                _rnd.NextUShort(), _rnd.NextUShort());

        private static OS2MetricsTable GetVersion0MsVariantTable()
            => new(_rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextOpenTypeEmbeddingPermissionsFlags(), _rnd.NextShort(), _rnd.NextShort(),
                _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(),
                _rnd.NextOpenTypeIBMFamily(), _rnd.NextOpenTypePanoseFamily(), _rnd.NextOpenTypeUnicodeRanges(), _rnd.NextTag(), _rnd.NextOpenTypeOS2StyleProperties(),
                _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort());

        private static OS2MetricsTable GetVersion0Table() => _rnd.NextBoolean() ? GetVersion0AppleVariantTable() : GetVersion0MsVariantTable();

        private static OS2MetricsTable GetVersion1Table()
            => new(_rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextOpenTypeEmbeddingPermissionsFlags(), _rnd.NextShort(), _rnd.NextShort(),
                _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(),
                _rnd.NextOpenTypeIBMFamily(), _rnd.NextOpenTypePanoseFamily(), _rnd.NextOpenTypeUnicodeRanges(), _rnd.NextTag(), _rnd.NextOpenTypeOS2StyleProperties(),
                _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), 
                _rnd.NextOpenTypeSupportedCodePages());

#pragma warning disable CA5394 // Do not use insecure randomness

        private static OS2MetricsTable GetVersion2To4Table()
            => new(_rnd.Next(2, 5), _rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextOpenTypeEmbeddingPermissionsFlags(), _rnd.NextShort(),
                _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), 
                _rnd.NextShort(), _rnd.NextOpenTypeIBMFamily(), _rnd.NextOpenTypePanoseFamily(), _rnd.NextOpenTypeUnicodeRanges(), _rnd.NextTag(), 
                _rnd.NextOpenTypeOS2StyleProperties(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort(), 
                _rnd.NextUShort(), _rnd.NextOpenTypeSupportedCodePages(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort());

        private static OS2MetricsTable GetVersion5Table()
            => new(_rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextOpenTypeEmbeddingPermissionsFlags(), _rnd.NextShort(), _rnd.NextShort(), 
                _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), 
                _rnd.NextOpenTypeIBMFamily(), _rnd.NextOpenTypePanoseFamily(), _rnd.NextOpenTypeUnicodeRanges(), _rnd.NextTag(), _rnd.NextOpenTypeOS2StyleProperties(), 
                _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), 
                _rnd.NextOpenTypeSupportedCodePages(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), 
                _rnd.NextUShort(), _rnd.NextUShort());

        private static OS2MetricsTable GetTable()
        {
            Func<OS2MetricsTable>[] generators =
                new Func<OS2MetricsTable>[] { GetVersion0AppleVariantTable, GetVersion0MsVariantTable, GetVersion1Table, GetVersion2To4Table, GetVersion5Table };
            return (generators[_rnd.Next(generators.Length)])();
        }

        private static OS2MetricsTable GetVersion1OrAboveTable()
        {
            Func<OS2MetricsTable>[] generators = new Func<OS2MetricsTable>[] { GetVersion1Table, GetVersion2To4Table, GetVersion5Table };
            return (generators[_rnd.Next(generators.Length)])();
        }

#pragma warning restore CA5394 // Do not use insecure randomness

        private static OS2MetricsTable GetVersion2OrAboveTable() => _rnd.NextBoolean() ? GetVersion2To4Table() : GetVersion5Table();

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObject()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingNameOfTable()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains("OS/2", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithTwoColumns()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            Assert.AreEqual(2, testOutput.BlockHeader.Count);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFirstColumnNamedField()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            Assert.AreEqual("Field", testOutput.BlockHeader[0].HeaderText);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockHeaderWithFirstColumnNamedValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            Assert.AreEqual("Value", testOutput.BlockHeader[1].HeaderText);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectVersionValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "Version");
            Assert.AreEqual(testObject.Version.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectAverageCharWidthValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "AverageCharWidth");
            Assert.AreEqual(testObject.AverageCharWidth.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectWeightClassValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "WeightClass");
            Assert.AreEqual(testObject.WeightClass.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectWidthClassValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "WidthClass");
            Assert.AreEqual(testObject.WidthClass.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectEmbeddingPermissionsValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "EmbeddingPermissions");
            Assert.AreEqual(testObject.EmbeddingPermissions.ToString(), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectSubscriptXSizeValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "SubscriptXSize");
            Assert.AreEqual(testObject.SubscriptXSize.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectSubscriptXOffsetValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "SubscriptXOffset");
            Assert.AreEqual(testObject.SubscriptXOffset.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectSubscriptYSizeValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "SubscriptYSize");
            Assert.AreEqual(testObject.SubscriptYSize.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectSubscriptYOffsetValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "SubscriptYOffset");
            Assert.AreEqual(testObject.SubscriptYOffset.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectSuperscriptXSizeValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "SuperscriptXSize");
            Assert.AreEqual(testObject.SuperscriptXSize.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectSuperscriptXOffsetValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "SuperscriptXOffset");
            Assert.AreEqual(testObject.SuperscriptXOffset.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectSuperscriptYSizeValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "SuperscriptYSize");
            Assert.AreEqual(testObject.SuperscriptYSize.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectSuperscriptYOffsetValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "SuperscriptYOffset");
            Assert.AreEqual(testObject.SuperscriptYOffset.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectStrikeoutSizeValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "StrikeoutSize");
            Assert.AreEqual(testObject.StrikeoutSize.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectStrikeoutPositionValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "StrikeoutPosition");
            Assert.AreEqual(testObject.StrikeoutPosition.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectIBMFontFamilyValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "IBMFontFamily");
            Assert.AreEqual(testObject.IBMFontFamily.ToString(), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectPanoseFontFamilyValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "PanoseFontFamily");
            Assert.AreEqual(testObject.PanoseFontFamily.ToString(), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectUnicodeRangesValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "UnicodeRanges");
            Assert.AreEqual(testObject.UnicodeRanges.ToString(), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectVendorIdValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "VendorId");
            Assert.AreEqual(testObject.VendorId.ToString(), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectFontSelectionValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "FontSelection");
            Assert.AreEqual(testObject.FontSelection.ToString(), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectMinCodePointValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MinCodePoint");
            Assert.AreEqual(testObject.MinCodePoint.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectMaxCodePointValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxCodePoint");
            Assert.AreEqual(testObject.MaxCodePoint.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingAscenderPropertyOfNotPopulated_IfTableIsVersion0AppleVariant()
        {
            var testObject = GetVersion0AppleVariantTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "Ascender");
            Assert.AreEqual("Not populated", testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingDescenderPropertyOfNotPopulated_IfTableIsVersion0AppleVariant()
        {
            var testObject = GetVersion0AppleVariantTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "Descender");
            Assert.AreEqual("Not populated", testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingLineGapPropertyOfNotPopulated_IfTableIsVersion0AppleVariant()
        {
            var testObject = GetVersion0AppleVariantTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "LineGap");
            Assert.AreEqual("Not populated", testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingWindowsAscenderPropertyOfNotPopulated_IfTableIsVersion0AppleVariant()
        {
            var testObject = GetVersion0AppleVariantTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "WindowsAscender");
            Assert.AreEqual("Not populated", testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingWindowsDescenderPropertyOfNotPopulated_IfTableIsVersion0AppleVariant()
        {
            var testObject = GetVersion0AppleVariantTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "WindowsDescender");
            Assert.AreEqual("Not populated", testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectAscenderProperty_IfTableIsVersion0MsVariant()
        {
            var testObject = GetVersion0MsVariantTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "Ascender");
            Assert.AreEqual(testObject.Ascender.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectDescenderProperty_IfTableIsVersion0MsVariant()
        {
            var testObject = GetVersion0MsVariantTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "Descender");
            Assert.AreEqual(testObject.Descender.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectLineGapProperty_IfTableIsVersion0MsVariant()
        {
            var testObject = GetVersion0MsVariantTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "LineGap");
            Assert.AreEqual(testObject.LineGap.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectWindowsAscenderProperty_IfTableIsVersion0MsVariant()
        {
            var testObject = GetVersion0MsVariantTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "WindowsAscender");
            Assert.AreEqual(testObject.WindowsAscender.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectWindowsDescenderProperty_IfTableIsVersion0MsVariant()
        {
            var testObject = GetVersion0MsVariantTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "WindowsDescender");
            Assert.AreEqual(testObject.WindowsDescender.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContaining27Records_IfTableIsVersion0()
        {
            var testObject = GetVersion0Table();

            var testOutput = testObject.Dump();

            Assert.AreEqual(27, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectAscenderProperty_IfTableIsVersion1OrAbove()
        {
            var testObject = GetVersion1OrAboveTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "Ascender");
            Assert.AreEqual(testObject.Ascender.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectDescenderProperty_IfTableIsVersion1OrAbove()
        {
            var testObject = GetVersion1OrAboveTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "Descender");
            Assert.AreEqual(testObject.Descender.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectLineGapProperty_IfTableIsVersion1OrAbove()
        {
            var testObject = GetVersion1OrAboveTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "LineGap");
            Assert.AreEqual(testObject.LineGap.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectWindowsAscenderProperty_IfTableIsVersion1OrAbove()
        {
            var testObject = GetVersion1OrAboveTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "WindowsAscender");
            Assert.AreEqual(testObject.WindowsAscender.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectWindowsDescenderProperty_IfTableIsVersion1OrAbove()
        {
            var testObject = GetVersion1OrAboveTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "WindowsDescender");
            Assert.AreEqual(testObject.WindowsDescender.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectCodePagesProperty_IfTableIsVersion1OrAbove()
        {
            var testObject = GetVersion1OrAboveTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "CodePages");
            Assert.AreEqual(testObject.CodePages.ToString(), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContaining28Records_IfTableIsVersion1()
        {
            var testObject = GetVersion1Table();

            var testOutput = testObject.Dump();

            Assert.AreEqual(28, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectXHeightProperty_IfTableIsVersion2OrAbove()
        {
            var testObject = GetVersion2OrAboveTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "XHeight");
            Assert.AreEqual(testObject.XHeight.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectCapHeightProperty_IfTableIsVersion2OrAbove()
        {
            var testObject = GetVersion2OrAboveTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "CapHeight");
            Assert.AreEqual(testObject.CapHeight.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectDefaultCharProperty_IfTableIsVersion2OrAbove()
        {
            var testObject = GetVersion2OrAboveTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "DefaultChar");
            Assert.AreEqual(testObject.DefaultChar.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectBreakCharProperty_IfTableIsVersion2OrAbove()
        {
            var testObject = GetVersion2OrAboveTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "BreakChar");
            Assert.AreEqual(testObject.BreakChar.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectMaxContextProperty_IfTableIsVersion2OrAbove()
        {
            var testObject = GetVersion2OrAboveTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxContext");
            Assert.AreEqual(testObject.MaxContext.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContaining33Records_IfTableIsVersion23Or4()
        {
            var testObject = GetVersion2To4Table();

            var testOutput = testObject.Dump();

            Assert.AreEqual(33, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectUpperOpticalPointSizeProperty_IfTableIsVersion5()
        {
            var testObject = GetVersion5Table();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "UpperOpticalPointSize");
            Assert.AreEqual(testObject.UpperOpticalPointSize.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContainingCorrectLowerOpticalPointSizeProperty_IfTableIsVersion5()
        {
            var testObject = GetVersion5Table();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "LowerOpticalPointSize");
            Assert.AreEqual(testObject.LowerOpticalPointSize.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithBlockDataContaining35Records_IfTableIsVersion5()
        {
            var testObject = GetVersion5Table();

            var testOutput = testObject.Dump();

            Assert.AreEqual(35, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void OS2MetricsTableClass_DumpMethod_ReturnsObjectWithNoNestedBlocks()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            Assert.AreEqual(0, testOutput.NestedData.Count());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
