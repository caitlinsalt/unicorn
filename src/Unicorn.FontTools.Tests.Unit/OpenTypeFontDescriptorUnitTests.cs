using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Base;
using Unicorn.FontTools.CharacterEncoding;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.OpenType.Interfaces;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit
{
    [TestClass]
    public class OpenTypeFontDescriptorUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private Mock<IOpenTypeFont> _mockFont;
        private long _fontLength;
        private string _mockFontFilename;
        private double _mockPointSize;
        private int _mockDesignScale;
        private byte _firstDefinedGlyph;
        private byte _lastDefinedGlyph;
        private HorizontalHeaderTable _horizontalHeaderTable;
        private OS2MetricsTable _oS2MetricsTable;
        private Mock<IGraphicsContext> _mockGraphicsContext;
        private int _mockCharacterWidth;
        private HeaderTable _headerTable;
        private short _xMin;
        private short _xMax;
        private short _yMin;
        private short _yMax;
        private PostScriptTable _postScriptTable;

        private OpenTypeFontDescriptor _testObject;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void InitialiseTest()
        {
            _mockFont = new Mock<IOpenTypeFont>();
            _fontLength = _rnd.Next();
            _mockFont.Setup(f => f.Length).Returns(_fontLength);
            _mockFontFilename = _rnd.NextString(_rnd.Next(1, 64));
            _mockFont.Setup(f => f.Filename).Returns(_mockFontFilename);
            _mockPointSize = _rnd.NextDouble() * 40;
            _mockDesignScale = _rnd.Next(1, 16384);
            _mockFont.Setup(f => f.DesignUnitsPerEm).Returns(_mockDesignScale);
            _mockCharacterWidth = _rnd.Next();
            _mockFont.Setup(f => f.AdvanceWidth(It.IsAny<PlatformId>(), It.IsAny<long>())).Returns(_mockCharacterWidth);
            _firstDefinedGlyph = _rnd.NextByte(32, byte.MaxValue - 2);
            _lastDefinedGlyph = _rnd.NextByte(_firstDefinedGlyph, byte.MaxValue);
            NormaliseFirstAndLastGlyphs();
            _mockFont.Setup(f => f.HasGlyphDefined(It.IsAny<PlatformId>(), It.IsAny<long>()))
                .Returns<PlatformId, long>((p, cp) =>
                {
                    byte? reversed = ReverseMap(PdfCharacterMappingDictionary.WinAnsiEncoding, cp);
                    return reversed.HasValue && reversed.Value >= _firstDefinedGlyph && reversed.Value <= _lastDefinedGlyph;
                });

            _horizontalHeaderTable = GetHheaTable();
            _mockFont.Setup(f => f.HorizontalHeader).Returns(_horizontalHeaderTable);

            _xMin = _rnd.NextShort();
            _xMax = _rnd.NextShort();
            _yMin = _rnd.NextShort();
            _yMax = _rnd.NextShort();
            _headerTable = GetHeaderTable();
            _mockFont.Setup(f => f.Header).Returns(_headerTable);

            _oS2MetricsTable = GetOS2MetricsTable();
            _mockFont.Setup(f => f.OS2Metrics).Returns(() => _oS2MetricsTable);

            _postScriptTable = GetPostScriptTable();
            _mockFont.Setup(f => f.PostScriptData).Returns(_postScriptTable);

            _mockGraphicsContext = new Mock<IGraphicsContext>();

            _testObject = new OpenTypeFontDescriptor(_mockFont.Object, _mockPointSize) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
        }

        private static byte? ReverseMap(PdfCharacterMappingDictionary map, long val) => map.Any(e => e.Value == val) ? map.First(e => e.Value == val).Key : null;

        private static IEnumerable<byte> ReverseMapAll(PdfCharacterMappingDictionary map, byte val)
        {
            var mapped = map.Transform(val);
            return map.Where(e => e.Value == mapped).Select(e => e.Key);
        }

        // This is required because the encoding maps several single-byte codepoints to the same Unicode codepoint.  Therefore, if the code arbitrarily decides that
        // for a particular test the last mapped byte is, say, 127, the code will also say that byte 173 is mapped, because both map to Unicode codepoint 0x2022.
        private void NormaliseFirstAndLastGlyphs()
        {
            NormaliseFirstAndLastGlyphsOnce();
            NormaliseFirstAndLastGlyphsOnce();
        }

        private void NormaliseFirstAndLastGlyphsOnce()
        {
            IList<byte> allMappedBytes = AllMappedBytes();
            _firstDefinedGlyph = allMappedBytes.Min();
            allMappedBytes = AllMappedBytes();
            _lastDefinedGlyph = allMappedBytes.Max();
        }

        private IEnumerable<byte> GetDefinedRange()
        {
            List<byte> bl = new();
            byte b = _firstDefinedGlyph;
            while (b <= _lastDefinedGlyph && b >= _firstDefinedGlyph)
            {
                bl.Add(b++);
            }
            return bl;
        }

        private IList<byte> AllMappedBytes() => GetDefinedRange().SelectMany(b => ReverseMapAll(PdfCharacterMappingDictionary.WinAnsiEncoding, b)).ToList();

#pragma warning restore CA5394 // Do not use insecure randomness

        private static HorizontalHeaderTable GetHheaTable() => new(_rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), 
            _rnd.NextUShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(),
            _rnd.NextUShort());

        private static OS2MetricsTable GetOS2MetricsTableVersion0() => new(_rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(),
            _rnd.NextOpenTypeEmbeddingPermissionsFlags(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), 
            _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextOpenTypeIBMFamily(), _rnd.NextOpenTypePanoseFamily(), 
            _rnd.NextOpenTypeUnicodeRanges(), _rnd.NextTag(), _rnd.NextOpenTypeOS2StyleProperties(), _rnd.NextUShort(), _rnd.NextUShort());

        private static OS2MetricsTable GetOS2MetricsTable(EmbeddingPermissions? embeddingPermissions = null)
        {
            embeddingPermissions ??= _rnd.NextOpenTypeEmbeddingPermissionsFlags();
            return new(_rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), embeddingPermissions.Value, _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), 
                _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), 
                _rnd.NextOpenTypeIBMFamily(), _rnd.NextOpenTypePanoseFamily(), _rnd.NextOpenTypeUnicodeRanges(), _rnd.NextTag(), _rnd.NextOpenTypeOS2StyleProperties(), 
                _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), 
                _rnd.NextOpenTypeSupportedCodePages(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), 
                _rnd.NextUShort());
        }

        private HeaderTable GetHeaderTable() 
            => new(_rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextDecimal(), _rnd.NextUInt(), _rnd.NextUInt(), _rnd.NextFontProperties(), _rnd.NextUShort(), 
                _rnd.NextDateTime(), _rnd.NextDateTime(), _xMin, _yMin, _xMax, _yMax, _rnd.NextMacStyleProperties(), _rnd.NextUShort(), _rnd.NextFontDirectionHint(), 
                _rnd.NextBoolean(), _rnd.NextShort());

        private static PostScriptTable GetPostScriptTable() => new(PostScriptTableVersion.One, _rnd.NextDecimal(), _rnd.NextShort(), _rnd.NextShort(), 
            _rnd.NextBoolean(), _rnd.NextUInt(), _rnd.NextUInt(), _rnd.NextUInt(), _rnd.NextUInt());

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void OpenTypeFontDescriptor_Constructor_SetsPointSizePropertyToValueOfSecondParameter()
        {
            IOpenTypeFont testParam0 = new Mock<IOpenTypeFont>().Object;
            double testParam1 = _rnd.NextDouble() * 48;

            OpenTypeFontDescriptor testOutput = new(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.PointSize);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_Constructor_SetsCalculationStylePropertyToWindows()
        {
            IOpenTypeFont testParam0 = new Mock<IOpenTypeFont>().Object;
            double testParam1 = _rnd.NextDouble() * 48;

            OpenTypeFontDescriptor testOutput = new(testParam0, testParam1);

            Assert.AreEqual(CalculationStyle.Windows, testOutput.CalculationStyle);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_UnderlyingKeyProperty_HasValueDerivedFromFilenamePropertyOfFirstParameterOfConstructor()
        {
            string testOutput = _testObject.UnderlyingKey;

            Assert.AreEqual($"OpenType_{_mockFontFilename}", testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscentProperty_HasValueDerivedFromAscenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            double expectedValue = _mockPointSize * _horizontalHeaderTable.Ascender / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Macintosh;

            double testOutput = _testObject.Ascent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscentProperty_HasValueDerivedFromAscenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsWindowsAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            _oS2MetricsTable = GetOS2MetricsTableVersion0();
            double expectedValue = _mockPointSize * _horizontalHeaderTable.Ascender / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.Ascent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscentProperty_HasValueDerivedFromAscenderPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsWindowsAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            double expectedValue = _mockPointSize * _oS2MetricsTable.Ascender.Value / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.Ascent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscentGlyphUnitsProperty_HasValueDerivedFromAscenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            double expectedValue = 1000 * _horizontalHeaderTable.Ascender / (double)_mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Macintosh;

            double testOutput = _testObject.AscentGlyphUnits;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscentGlyphUnitsProperty_HasValueDerivedFromAscenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsWindowsAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            _oS2MetricsTable = GetOS2MetricsTableVersion0();
            double expectedValue = 1000 * _horizontalHeaderTable.Ascender / (double)_mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.AscentGlyphUnits;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscentGlyphUnitsProperty_HasValueDerivedFromAscenderPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsWindowsAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            double expectedValue = 1000 * _oS2MetricsTable.Ascender.Value / (double)_mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.AscentGlyphUnits;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescentProperty_HasValueDerivedFromDescenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            double expectedValue = _mockPointSize * _horizontalHeaderTable.Descender / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Macintosh;

            double testOutput = _testObject.Descent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescentProperty_HasValueDerivedFromDescenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsWindowsAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            _oS2MetricsTable = GetOS2MetricsTableVersion0();
            double expectedValue = _mockPointSize * _horizontalHeaderTable.Descender / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.Descent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescentProperty_HasValueDerivedFromDescenderPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsWindowsAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            double expectedValue = _mockPointSize * _oS2MetricsTable.Descender.Value / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.Descent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescentGlyphUnitsProperty_HasValueDerivedFromDescenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            double expectedValue = 1000 * _horizontalHeaderTable.Descender / (double)_mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Macintosh;

            double testOutput = _testObject.DescentGlyphUnits;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescentGlyphUnitsProperty_HasValueDerivedFromDescenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsWindowsAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            _oS2MetricsTable = GetOS2MetricsTableVersion0();
            double expectedValue = 1000 * _horizontalHeaderTable.Descender / (double)_mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.DescentGlyphUnits;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescentGlyphUnitsProperty_HasValueDerivedFromDescenderPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsWindowsAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            double expectedValue = 1000 * _oS2MetricsTable.Descender.Value / (double)_mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.DescentGlyphUnits;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_InterlineSpacingProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            double expectedValue = _mockPointSize - _mockPointSize * (_horizontalHeaderTable.Ascender - _horizontalHeaderTable.Descender) / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Macintosh;

            double testOutput = _testObject.InterlineSpacing;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_InterlineSpacingProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            _oS2MetricsTable = GetOS2MetricsTableVersion0();
            double expectedValue = _mockPointSize - _mockPointSize * (_horizontalHeaderTable.Ascender - _horizontalHeaderTable.Descender) / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.InterlineSpacing;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_InterlineSpacingProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            double expectedValue = _mockPointSize - _mockPointSize * (_oS2MetricsTable.Ascender.Value - _oS2MetricsTable.Descender.Value) / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.InterlineSpacing;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_EmptyStringMetricsProperty_HasWidthPropertyEqualToZero()
        {
            double testOutput = _testObject.EmptyStringMetrics.Width;

            Assert.AreEqual(0d, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_EmptyStringMetricsProperty_HasTotalHeightPropertyEqualToSecondParameterOfConstructor()
        {
            double testOutput = _testObject.EmptyStringMetrics.LineHeight;

            Assert.AreEqual(_mockPointSize, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_HeightAboveBaselinePropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            double expectedValue = (_mockPointSize * _horizontalHeaderTable.Ascender / _mockDesignScale) +
                (_mockPointSize - _mockPointSize * (_horizontalHeaderTable.Ascender - _horizontalHeaderTable.Descender) / _mockDesignScale) / 2;
            _testObject.CalculationStyle = CalculationStyle.Macintosh;

            double testOutput = _testObject.EmptyStringMetrics.HeightAboveBaseline;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_HeightAboveBaselinePropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            _oS2MetricsTable = GetOS2MetricsTableVersion0();
            double expectedValue = (_mockPointSize * _horizontalHeaderTable.Ascender / _mockDesignScale) +
                (_mockPointSize - _mockPointSize * (_horizontalHeaderTable.Ascender - _horizontalHeaderTable.Descender) / _mockDesignScale) / 2;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.EmptyStringMetrics.HeightAboveBaseline;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_HeightAboveBaselinePropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            double expectedValue = (_mockPointSize * _oS2MetricsTable.Ascender.Value / _mockDesignScale) +
                (_mockPointSize - _mockPointSize * (_oS2MetricsTable.Ascender.Value - _oS2MetricsTable.Descender.Value) / _mockDesignScale) / 2;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.EmptyStringMetrics.HeightAboveBaseline;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            double expectedValue = _mockPointSize * _horizontalHeaderTable.Ascender / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Macintosh;

            double testOutput = _testObject.EmptyStringMetrics.AscenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            _oS2MetricsTable = GetOS2MetricsTableVersion0();
            double expectedValue = _mockPointSize * _horizontalHeaderTable.Ascender / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.EmptyStringMetrics.AscenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            double expectedValue = _mockPointSize * _oS2MetricsTable.Ascender.Value / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.EmptyStringMetrics.AscenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromDescenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            double expectedValue = -_mockPointSize * _horizontalHeaderTable.Descender / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Macintosh;

            double testOutput = _testObject.EmptyStringMetrics.DescenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromDescenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            _oS2MetricsTable = GetOS2MetricsTableVersion0();
            double expectedValue = -_mockPointSize * _horizontalHeaderTable.Descender / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.EmptyStringMetrics.DescenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromDescenderPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            double expectedValue = -_mockPointSize * _oS2MetricsTable.Descender.Value / _mockDesignScale;
            _testObject.CalculationStyle = CalculationStyle.Windows;

            double testOutput = _testObject.EmptyStringMetrics.DescenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructor_IfOS2MetricsTableIsVersion0()
        {
            _oS2MetricsTable = GetOS2MetricsTableVersion0();
            IGraphicsContext testParam0 = _mockGraphicsContext.Object;

            _ = _testObject.GetNormalSpaceWidth(testParam0);

            _mockFont.Verify(f => f.AdvanceWidth(It.IsAny<PlatformId>(), It.IsAny<long>()), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructorWithFirstParameterEqualToWindows_IfOS2MetricsTableIsVersion0()
        {
            _oS2MetricsTable = GetOS2MetricsTableVersion0();
            IGraphicsContext testParam0 = _mockGraphicsContext.Object;

            _ = _testObject.GetNormalSpaceWidth(testParam0);

            _mockFont.Verify(f => f.AdvanceWidth(PlatformId.Windows, It.IsAny<long>()), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructorWithSecondParameterEqualTo32_IfOS2MetricsTableIsVersion0()
        {
            _oS2MetricsTable = GetOS2MetricsTableVersion0();
            IGraphicsContext testParam0 = _mockGraphicsContext.Object;

            _ = _testObject.GetNormalSpaceWidth(testParam0);

            _mockFont.Verify(f => f.AdvanceWidth(It.IsAny<PlatformId>(), 32), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_ReturnsValueDerivedFromReturnValueOfAdvanceWidthMethodOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfOS2MetricsTableIsVersion0()
        {
            _oS2MetricsTable = GetOS2MetricsTableVersion0();
            IGraphicsContext testParam0 = _mockGraphicsContext.Object;
            double expectedValue = _mockPointSize * _mockCharacterWidth / _mockDesignScale;

            double testOutput = _testObject.GetNormalSpaceWidth(testParam0);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructor_IfOS2MetricsTableIsVersion5()
        {
            IGraphicsContext testParam0 = _mockGraphicsContext.Object;

            _ = _testObject.GetNormalSpaceWidth(testParam0);

            _mockFont.Verify(f => f.AdvanceWidth(It.IsAny<PlatformId>(), It.IsAny<long>()), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructorWithFirstParameterEqualToWindows_IfOS2MetricsTableIsVersion5()
        {
            IGraphicsContext testParam0 = _mockGraphicsContext.Object;

            _ = _testObject.GetNormalSpaceWidth(testParam0);

            _mockFont.Verify(f => f.AdvanceWidth(PlatformId.Windows, It.IsAny<long>()), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructorWithSecondParameterEqualToBreakCharPropertyOfOS2MetricsTable_IfOS2MetricsTableIsVersion5()
        {
            IGraphicsContext testParam0 = _mockGraphicsContext.Object;

            _ = _testObject.GetNormalSpaceWidth(testParam0);

            _mockFont.Verify(f => f.AdvanceWidth(It.IsAny<PlatformId>(), _oS2MetricsTable.BreakChar.Value), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_ReturnsValueDerivedFromReturnValueOfAdvanceWidthMethodOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfOS2MetricsTableIsVersion5()
        {
            IGraphicsContext testParam0 = _mockGraphicsContext.Object;
            double expectedValue = _mockPointSize * _mockCharacterWidth / _mockDesignScale;

            double testOutput = _testObject.GetNormalSpaceWidth(testParam0);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_BoundingBoxProperty_HasValueWithMinXPropertyDerivedFromXMinPropertyOfHeaderPropertyOfFirstParameterOfConstructor()
        {
            double expectedValue = 1000 * _xMin / (double)_mockDesignScale;

            double testOutput = _testObject.BoundingBox.MinX;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_BoundingBoxProperty_HasValueWithMinYPropertyDerivedFromYMinPropertyOfHeaderPropertyOfFirstParameterOfConstructor()
        {
            double expectedValue = 1000 * _yMin / (double)_mockDesignScale;

            double testOutput = _testObject.BoundingBox.MinY;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_BoundingBoxProperty_HasValueWithWidthPropertyDerivedFromXMinAndXMaxPropertiesOfHeaderPropertyOfFirstParameterOfConstructor()
        {
            double expectedValue = 1000 * (_xMax - _xMin) / (double)_mockDesignScale;

            double testOutput = _testObject.BoundingBox.Width;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_BoundingBoxProperty_HasValueWithHeightPropertyDerivedFromYMinAndYMaxPropertiesOfHeaderPropertyOfFirstParameterOfConstructor()
        {
            double expectedValue = 1000 * (_yMax - _yMin) / (double)_mockDesignScale;

            double testOutput = _testObject.BoundingBox.Height;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_CapHeightProperty_HasValueDerivedFromCapHeightPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructor_IfCapHeightPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorIsPopulated()
        {
            decimal expectedValue = (decimal)(1000 * _oS2MetricsTable.CapHeight.Value / (double)_mockDesignScale);

            decimal testOutput = _testObject.CapHeight;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_ItalicAngleProperty_ReturnsValueOfItalicAnglePropertyOfPostScriptDatapropertyOfFirstParameterOfConstructor()
        {
            decimal expectedValue = _postScriptTable.ItalicAngle;

            decimal testOutput = _testObject.ItalicAngle;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_VerticalStemThicknessProperty_ReturnsZero()
        {
            decimal expectedValue = 0m;

            decimal testOutput = _testObject.VerticalStemThickness;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresFullDescriptionProperty_ReturnsTrue()
        {
            bool expectedValue = true;

            bool testOutput = _testObject.RequiresFullDescription;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsTrue_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsInstallable()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Installable);
            bool expectedValue = true;

            bool testOutput = _testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsFalse_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsBitMapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.BitmapOnly);
            bool expectedValue = false;

            bool testOutput = _testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsFalse_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestricted()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Restricted);
            bool expectedValue = false;

            bool testOutput = _testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsFalse_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestrictedAndBitMapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.BitmapOnly);
            bool expectedValue = false;

            bool testOutput = _testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsTrue_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrinting()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing);
            bool expectedValue = true;

            bool testOutput = _testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsFalse_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrintingAndBitMapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing | EmbeddingPermissions.BitmapOnly);
            bool expectedValue = false;

            bool testOutput = _testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsTrue_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditable()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable);
            bool expectedValue = true;

            bool testOutput = _testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsFalse_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditableAndBitMapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable | EmbeddingPermissions.BitmapOnly);
            bool expectedValue = false;

            bool testOutput = _testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsFontFile2_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsInstallable()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Installable);
            string expectedValue = "FontFile2";

            string testOutput = _testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsEmptyString_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsBitmapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.BitmapOnly);
            string expectedValue = "";

            string testOutput = _testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsFontFile2_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrinting()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing);
            string expectedValue = "FontFile2";

            string testOutput = _testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsEmptyString_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrintingAndBitmapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing | EmbeddingPermissions.BitmapOnly);
            string expectedValue = "";

            string testOutput = _testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsFontFile2_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditable()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable);
            string expectedValue = "FontFile2";

            string testOutput = _testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsEmptyString_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditableAndBitmapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable | EmbeddingPermissions.BitmapOnly);
            string expectedValue = "";

            string testOutput = _testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsEmptyString_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestricted()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Restricted);
            string expectedValue = "";

            string testOutput = _testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsEmptyString_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestrictedAndBitmapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Restricted | EmbeddingPermissions.BitmapOnly);
            string expectedValue = "";

            string testOutput = _testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsLengthPropertyOfFirstParameterOfConstructor_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsInstallable()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Installable);
            long expectedValue = _fontLength;

            long testOutput = _testObject.EmbeddingLength;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsZero_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsBitmapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.BitmapOnly);

            long testOutput = _testObject.EmbeddingLength;

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsLengthPropertyOfFirstParameterOfConstructor_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrinting()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing);
            long expectedValue = _fontLength;

            long testOutput = _testObject.EmbeddingLength;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsZero_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrintingAndBitmapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing | EmbeddingPermissions.BitmapOnly);

            long testOutput = _testObject.EmbeddingLength;

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsLengthPropertyOfFirstParameterOfConstructor_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditable()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable);
            long expectedValue = _fontLength;

            long testOutput = _testObject.EmbeddingLength;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsZero_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditableAndBitmapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable | EmbeddingPermissions.BitmapOnly);

            long testOutput = _testObject.EmbeddingLength;

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsZero_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestricted()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Restricted);

            long testOutput = _testObject.EmbeddingLength;

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsZero_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestrictedAndBitmapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Restricted | EmbeddingPermissions.BitmapOnly);

            long testOutput = _testObject.EmbeddingLength;

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsFirstParameterOfConstructor_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsInstallable()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Installable);

            IEnumerable<byte> testOutput = _testObject.EmbeddingData;

            Assert.AreEqual(_mockFont.Object, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsEmptyArray_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsBitmapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.BitmapOnly);

            IEnumerable<byte> testOutput = _testObject.EmbeddingData;

            Assert.AreNotEqual(_mockFont, testOutput);
            Assert.AreEqual(0, testOutput.Count());
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsFirstParameterOfConstructor_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditable()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable);

            IEnumerable<byte> testOutput = _testObject.EmbeddingData;

            Assert.AreEqual(_mockFont.Object, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsEmptyArray_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditableAndBitmapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable | EmbeddingPermissions.BitmapOnly);

            IEnumerable<byte> testOutput = _testObject.EmbeddingData;

            Assert.AreNotEqual(_mockFont, testOutput);
            Assert.AreEqual(0, testOutput.Count());
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsFirstParameterOfConstructor_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrinting()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing);

            IEnumerable<byte> testOutput = _testObject.EmbeddingData;

            Assert.AreEqual(_mockFont.Object, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsEmptyArray_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrintingBitmapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing | EmbeddingPermissions.BitmapOnly);

            IEnumerable<byte> testOutput = _testObject.EmbeddingData;

            Assert.AreNotEqual(_mockFont, testOutput);
            Assert.AreEqual(0, testOutput.Count());
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsEmptyArray_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestricted()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Restricted);

            IEnumerable<byte> testOutput = _testObject.EmbeddingData;

            Assert.AreNotEqual(_mockFont, testOutput);
            Assert.AreEqual(0, testOutput.Count());
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsEmptyArray_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestrictedAndBitmapOnly()
        {
            _oS2MetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Restricted | EmbeddingPermissions.BitmapOnly);

            IEnumerable<byte> testOutput = _testObject.EmbeddingData;

            Assert.AreNotEqual(_mockFont, testOutput);
            Assert.AreEqual(0, testOutput.Count());
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_ImplementationProperty_EqualsOpenType()
        {
            FontImplementation testOutput = _testObject.Implementation;

            Assert.AreEqual(FontImplementation.OpenType, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_GetSpecialSubtypeMethod_ReturnsTrueType()
        {
            string testOutput = _testObject.GetSpecialSubtypeName();

            Assert.AreEqual("TrueType", testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_PreferredEncodingNameMethod_EqualsWinAnsiEncoding()
        {
            string testOutput = _testObject.PreferredEncodingName;

            Assert.AreEqual("WinAnsiEncoding", testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_FirstMappedByteMethod_ReturnsCorrectValueBasedOnUnderlyingFontData()
        {
            byte testOutput = _testObject.FirstMappedByte();

            Assert.AreEqual(_firstDefinedGlyph, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_LastMappedByteMethod_ReturnsCorrectValueBasedOnUnderlyingFontData()
        {
            byte testOutput = _testObject.LastMappedByte();

            Assert.AreEqual(_lastDefinedGlyph, testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
