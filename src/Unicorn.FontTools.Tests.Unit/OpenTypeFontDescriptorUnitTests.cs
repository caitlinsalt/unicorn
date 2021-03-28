using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Base;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.OpenType.Interfaces;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit
{
    [TestClass]
    public class OpenTypeFontDescriptorUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static HorizontalHeaderTable GetHheaTable() => new(_rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), 
            _rnd.NextUShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(),
            _rnd.NextUShort());

        private static OS2MetricsTable GetOS2MetricsTableVersion0() => new(_rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(),
            _rnd.NextOpenTypeEmbeddingPermissionsFlags(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), 
            _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextOpenTypeIBMFamily(), _rnd.NextOpenTypePanoseFamily(), 
            _rnd.NextOpenTypeUnicodeRanges(), _rnd.NextTag(), _rnd.NextOpenTypeOS2StyleFlags(), _rnd.NextUShort(), _rnd.NextUShort());

        private static OS2MetricsTable GetOS2MetricsTable(EmbeddingPermissions? embeddingPermissions = null)
        {
            embeddingPermissions ??= _rnd.NextOpenTypeEmbeddingPermissionsFlags();
            return new(_rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), embeddingPermissions.Value, _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), 
                _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), 
                _rnd.NextOpenTypeIBMFamily(), _rnd.NextOpenTypePanoseFamily(), _rnd.NextOpenTypeUnicodeRanges(), _rnd.NextTag(), _rnd.NextOpenTypeOS2StyleFlags(), 
                _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), 
                _rnd.NextOpenTypeSupportedCodePages(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), 
                _rnd.NextUShort());
        }

        private static HeaderTable GetHeaderTable(short? xMin, short? xMax, short? yMin, short? yMax)
        {
            xMin ??= _rnd.NextShort();
            xMax ??= _rnd.NextShort();
            yMin ??= _rnd.NextShort();
            yMax ??= _rnd.NextShort();

            return new(_rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextDecimal(), _rnd.NextUInt(), _rnd.NextUInt(), _rnd.NextFontFlags(), _rnd.NextUShort(), 
                _rnd.NextDateTime(), _rnd.NextDateTime(), xMin.Value, yMin.Value, xMax.Value, yMax.Value, _rnd.NextMacStyleFlags(), _rnd.NextUShort(), 
                _rnd.NextFontDirectionHint(), _rnd.NextBoolean(), _rnd.NextShort());
        }

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
            Mock<IOpenTypeFont> mockFont = new();
            string expectedData = _rnd.NextString(_rnd.Next(1, 64));
            mockFont.Setup(f => f.Filename).Returns(expectedData);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1);

            string testOutput = testObject.UnderlyingKey;

            Assert.AreEqual($"OpenType_{expectedData}", testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscentProperty_HasValueDerivedFromAscenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockHorizontalHeaderTable.Ascender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Macintosh };

            double testOutput = testObject.Ascent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscentProperty_HasValueDerivedFromAscenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockHorizontalHeaderTable.Ascender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Windows };

            double testOutput = testObject.Ascent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscentProperty_HasValueDerivedFromAscenderPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockOs2MetricsTable.Ascender.Value / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Windows };

            double testOutput = testObject.Ascent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescentProperty_HasValueDerivedFromDescenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockHorizontalHeaderTable.Descender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Macintosh };

            double testOutput = testObject.Descent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescentProperty_HasValueDerivedFromDescenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockHorizontalHeaderTable.Descender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Windows };

            double testOutput = testObject.Descent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescentProperty_HasValueDerivedFromDescenderPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockOs2MetricsTable.Descender.Value / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Windows };

            double testOutput = testObject.Descent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_InterlineSpacingProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 - testParam1 * (mockHorizontalHeaderTable.Ascender - mockHorizontalHeaderTable.Descender) / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Macintosh };

            double testOutput = testObject.InterlineSpacing;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_InterlineSpacingProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 - testParam1 * (mockHorizontalHeaderTable.Ascender - mockHorizontalHeaderTable.Descender) / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Windows };

            double testOutput = testObject.InterlineSpacing;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_InterlineSpacingProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 - testParam1 * (mockOs2MetricsTable.Ascender.Value - mockOs2MetricsTable.Descender.Value) / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Windows };

            double testOutput = testObject.InterlineSpacing;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_EmptyStringMetricsProperty_HasWidthPropertyEqualToZero()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 - testParam1 * (mockOs2MetricsTable.Ascender.Value - mockOs2MetricsTable.Descender.Value) / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            double testOutput = testObject.EmptyStringMetrics.Width;

            Assert.AreEqual(0d, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_EmptyStringMetricsProperty_HasTotalHeightPropertyEqualToSecondParameterOfConstructor()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 - testParam1 * (mockOs2MetricsTable.Ascender.Value - mockOs2MetricsTable.Descender.Value) / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            double testOutput = testObject.EmptyStringMetrics.LineHeight;

            Assert.AreEqual(testParam1, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_HeightAboveBaselinePropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = (testParam1 * mockHorizontalHeaderTable.Ascender / mockDesignUnits) +
                (testParam1 - testParam1 * (mockHorizontalHeaderTable.Ascender - mockHorizontalHeaderTable.Descender) / mockDesignUnits) / 2;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Macintosh };

            double testOutput = testObject.EmptyStringMetrics.HeightAboveBaseline;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_HeightAboveBaselinePropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = (testParam1 * mockHorizontalHeaderTable.Ascender / mockDesignUnits) +
                (testParam1 - testParam1 * (mockHorizontalHeaderTable.Ascender - mockHorizontalHeaderTable.Descender) / mockDesignUnits) / 2;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Windows };

            double testOutput = testObject.EmptyStringMetrics.HeightAboveBaseline;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_HeightAboveBaselinePropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = (testParam1 * mockOs2MetricsTable.Ascender.Value / mockDesignUnits) +
                (testParam1 - testParam1 * (mockOs2MetricsTable.Ascender.Value - mockOs2MetricsTable.Descender.Value) / mockDesignUnits) / 2;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Windows };

            double testOutput = testObject.EmptyStringMetrics.HeightAboveBaseline;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockHorizontalHeaderTable.Ascender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Macintosh };

            double testOutput = testObject.EmptyStringMetrics.AscenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockHorizontalHeaderTable.Ascender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Windows };

            double testOutput = testObject.EmptyStringMetrics.AscenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockOs2MetricsTable.Ascender.Value / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Windows };

            double testOutput = testObject.EmptyStringMetrics.AscenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromDescenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = -testParam1 * mockHorizontalHeaderTable.Descender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Macintosh };

            double testOutput = testObject.EmptyStringMetrics.DescenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromDescenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = -testParam1 * mockHorizontalHeaderTable.Descender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Windows };

            double testOutput = testObject.EmptyStringMetrics.DescenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromDescenderPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = -testParam1 * mockOs2MetricsTable.Descender.Value / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new(testParam0, testParam1) { CalculationStyle = CalculationStyle.Windows };

            double testOutput = testObject.EmptyStringMetrics.DescenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructor_IfOS2MetricsTableIsVersion0()
        {
            Mock<IOpenTypeFont> mockFont = new();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;

            _ = testObject.GetNormalSpaceWidth(testParam0);

            mockFont.Verify(f => f.AdvanceWidth(It.IsAny<PlatformId>(), It.IsAny<long>()), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructorWithFirstParameterEqualToWindows_IfOS2MetricsTableIsVersion0()
        {
            Mock<IOpenTypeFont> mockFont = new();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;

            _ = testObject.GetNormalSpaceWidth(testParam0);

            mockFont.Verify(f => f.AdvanceWidth(PlatformId.Windows, It.IsAny<long>()), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructorWithSecondParameterEqualTo32_IfOS2MetricsTableIsVersion0()
        {
            Mock<IOpenTypeFont> mockFont = new();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;

            _ = testObject.GetNormalSpaceWidth(testParam0);

            mockFont.Verify(f => f.AdvanceWidth(It.IsAny<PlatformId>(), 32), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_ReturnsValueDerivedFromReturnValueOfAdvanceWidthMethodOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfOS2MetricsTableIsVersion0()
        {
            Mock<IOpenTypeFont> mockFont = new();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            int mockCharacterWidth = _rnd.Next();
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            mockFont.Setup(f => f.AdvanceWidth(It.IsAny<PlatformId>(), It.IsAny<long>())).Returns(mockCharacterWidth);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;
            double expectedValue = constrParam1 * mockCharacterWidth / mockDesignUnits;

            double testOutput = testObject.GetNormalSpaceWidth(testParam0);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructor_IfOS2MetricsTableIsVersion5()
        {
            Mock<IOpenTypeFont> mockFont = new();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;

            _ = testObject.GetNormalSpaceWidth(testParam0);

            mockFont.Verify(f => f.AdvanceWidth(It.IsAny<PlatformId>(), It.IsAny<long>()), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructorWithFirstParameterEqualToWindows_IfOS2MetricsTableIsVersion5()
        {
            Mock<IOpenTypeFont> mockFont = new();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;

            _ = testObject.GetNormalSpaceWidth(testParam0);

            mockFont.Verify(f => f.AdvanceWidth(PlatformId.Windows, It.IsAny<long>()), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructorWithSecondParameterEqualToBreakCharPropertyOfOS2MetricsTable_IfOS2MetricsTableIsVersion5()
        {
            Mock<IOpenTypeFont> mockFont = new();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;

            _ = testObject.GetNormalSpaceWidth(testParam0);

            mockFont.Verify(f => f.AdvanceWidth(It.IsAny<PlatformId>(), mockOs2MetricsTable.BreakChar.Value), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_ReturnsValueDerivedFromReturnValueOfAdvanceWidthMethodOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfOS2MetricsTableIsVersion5()
        {
            Mock<IOpenTypeFont> mockFont = new();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            int mockCharacterWidth = _rnd.Next();
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            mockFont.Setup(f => f.AdvanceWidth(It.IsAny<PlatformId>(), It.IsAny<long>())).Returns(mockCharacterWidth);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;
            double expectedValue = constrParam1 * mockCharacterWidth / mockDesignUnits;

            double testOutput = testObject.GetNormalSpaceWidth(testParam0);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_BoundingBoxProperty_HasValueWithMinXPropertyDerivedFromXMinPropertyOfHeaderPropertyOfFirstParameterOfConstructor()
        {
            Mock<IOpenTypeFont> mockFont = new();
            short mockXmin = _rnd.NextShort();
            HeaderTable mockHeaderTable = GetHeaderTable(mockXmin, null, null, null);
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.Header).Returns(mockHeaderTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            double expectedValue = 1000 * mockXmin / (double)mockDesignUnits;

            double testOutput = testObject.BoundingBox.MinX;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_BoundingBoxProperty_HasValueWithMinYPropertyDerivedFromYMinPropertyOfHeaderPropertyOfFirstParameterOfConstructor()
        {
            Mock<IOpenTypeFont> mockFont = new();
            short mockYmin = _rnd.NextShort();
            HeaderTable mockHeaderTable = GetHeaderTable(null, null, mockYmin, null);
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.Header).Returns(mockHeaderTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            double expectedValue = 1000 * mockYmin / (double)mockDesignUnits;

            double testOutput = testObject.BoundingBox.MinY;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_BoundingBoxProperty_HasValueWithWidthPropertyDerivedFromXMinAndXMaxPropertiesOfHeaderPropertyOfFirstParameterOfConstructor()
        {
            Mock<IOpenTypeFont> mockFont = new();
            short mockXmin = _rnd.NextShort();
            short mockXmax = _rnd.NextShort();
            HeaderTable mockHeaderTable = GetHeaderTable(mockXmin, mockXmax, null, null);
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.Header).Returns(mockHeaderTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            double expectedValue = 1000 * (mockXmax - mockXmin) / (double)mockDesignUnits;

            double testOutput = testObject.BoundingBox.Width;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_BoundingBoxProperty_HasValueWithHeightPropertyDerivedFromYMinAndYMaxPropertiesOfHeaderPropertyOfFirstParameterOfConstructor()
        {
            Mock<IOpenTypeFont> mockFont = new();
            short mockYmin = _rnd.NextShort();
            short mockYmax = _rnd.NextShort();
            HeaderTable mockHeaderTable = GetHeaderTable(null, null, mockYmin, mockYmax);
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.Header).Returns(mockHeaderTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            double expectedValue = 1000 * (mockYmax - mockYmin) / (double)mockDesignUnits;

            double testOutput = testObject.BoundingBox.Height;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_CapHeightProperty_HasValueDerivedFromCapHeightPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructor_IfCapHeightPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorIsPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new();
            OS2MetricsTable mockOS2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOS2MetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            decimal expectedValue = (decimal)(1000 * mockOS2MetricsTable.CapHeight.Value / (double)mockDesignUnits);

            decimal testOutput = testObject.CapHeight;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_ItalicAngleProperty_ReturnsValueOfItalicAnglePropertyOfPostScriptDatapropertyOfFirstParameterOfConstructor()
        {
            Mock<IOpenTypeFont> mockFont = new();
            PostScriptTable mockPostScriptData = GetPostScriptTable();
            mockFont.Setup(f => f.PostScriptData).Returns(mockPostScriptData);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            decimal expectedValue = mockPostScriptData.ItalicAngle;

            decimal testOutput = testObject.ItalicAngle;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_VerticalStemThicknessProperty_ReturnsZero()
        {
            Mock<IOpenTypeFont> mockFont = new();
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            decimal expectedValue = 0m;

            decimal testOutput = testObject.VerticalStemThickness;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresFullDescriptionProperty_ReturnsTrue()
        {
            Mock<IOpenTypeFont> mockFont = new();
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            bool expectedValue = true;

            bool testOutput = testObject.RequiresFullDescription;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsTrue_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsInstallable()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Installable);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            bool expectedValue = true;

            bool testOutput = testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsFalse_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsBitMapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            bool expectedValue = false;

            bool testOutput = testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsFalse_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestricted()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Restricted);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            bool expectedValue = false;

            bool testOutput = testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsFalse_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestrictedAndBitMapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            bool expectedValue = false;

            bool testOutput = testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsTrue_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrinting()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            bool expectedValue = true;

            bool testOutput = testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsFalse_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrintingAndBitMapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing | EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            bool expectedValue = false;

            bool testOutput = testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsTrue_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditable()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            bool expectedValue = true;

            bool testOutput = testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_RequiresEmbeddingProperty_ReturnsFalse_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditableAndBitMapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable | EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            bool expectedValue = false;

            bool testOutput = testObject.RequiresEmbedding;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsFontFile2_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsInstallable()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Installable);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            string expectedValue = "FontFile2";

            string testOutput = testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsEmptyString_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsBitmapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            string expectedValue = "";

            string testOutput = testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsFontFile2_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrinting()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            string expectedValue = "FontFile2";

            string testOutput = testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsEmptyString_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrintingAndBitmapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing | EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            string expectedValue = "";

            string testOutput = testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsFontFile2_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditable()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            string expectedValue = "FontFile2";

            string testOutput = testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsEmptyString_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditableAndBitmapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable | EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            string expectedValue = "";

            string testOutput = testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsEmptyString_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestricted()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Restricted);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            string expectedValue = "";

            string testOutput = testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingKeyProperty_ReturnsEmptyString_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestrictedAndBitmapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Restricted | EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            string expectedValue = "";

            string testOutput = testObject.EmbeddingKey;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsLengthPropertyOfFirstParameterOfConstructor_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsInstallable()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Installable);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            long expectedValue = _rnd.Next();
            mockFont.Setup(f => f.Length).Returns(expectedValue);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            long testOutput = testObject.EmbeddingLength;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsZero_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsBitmapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            long expectedValue = _rnd.Next();
            mockFont.Setup(f => f.Length).Returns(expectedValue);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            long testOutput = testObject.EmbeddingLength;

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsLengthPropertyOfFirstParameterOfConstructor_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrinting()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            long expectedValue = _rnd.Next();
            mockFont.Setup(f => f.Length).Returns(expectedValue);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            long testOutput = testObject.EmbeddingLength;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsZero_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrintingAndBitmapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing | EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            long expectedValue = _rnd.Next();
            mockFont.Setup(f => f.Length).Returns(expectedValue);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            long testOutput = testObject.EmbeddingLength;

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsLengthPropertyOfFirstParameterOfConstructor_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditable()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            long expectedValue = _rnd.Next();
            mockFont.Setup(f => f.Length).Returns(expectedValue);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            long testOutput = testObject.EmbeddingLength;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsZero_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditableAndBitmapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable | EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            long expectedValue = _rnd.Next();
            mockFont.Setup(f => f.Length).Returns(expectedValue);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            long testOutput = testObject.EmbeddingLength;

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsZero_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestricted()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Restricted);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            long expectedValue = _rnd.Next();
            mockFont.Setup(f => f.Length).Returns(expectedValue);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            long testOutput = testObject.EmbeddingLength;

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingLengthProperty_ReturnsZero_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestrictedAndBitmapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Restricted | EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            long expectedValue = _rnd.Next();
            mockFont.Setup(f => f.Length).Returns(expectedValue);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            long testOutput = testObject.EmbeddingLength;

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsFirstParameterOfConstructor_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsInstallable()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Installable);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            IEnumerable<byte> testOutput = testObject.EmbeddingData;

            Assert.AreEqual(constrParam0, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsEmptyArray_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsBitmapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            IEnumerable<byte> testOutput = testObject.EmbeddingData;

            Assert.AreNotEqual(constrParam0, testOutput);
            Assert.AreEqual(0, testOutput.Count());
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsFirstParameterOfConstructor_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditable()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            IEnumerable<byte> testOutput = testObject.EmbeddingData;

            Assert.AreEqual(constrParam0, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsEmptyArray_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsEditableAndBitmapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Editable | EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            IEnumerable<byte> testOutput = testObject.EmbeddingData;

            Assert.AreNotEqual(constrParam0, testOutput);
            Assert.AreEqual(0, testOutput.Count());
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsFirstParameterOfConstructor_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrinting()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            IEnumerable<byte> testOutput = testObject.EmbeddingData;

            Assert.AreEqual(constrParam0, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsEmptyArray_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsPrintingBitmapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Printing | EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            IEnumerable<byte> testOutput = testObject.EmbeddingData;

            Assert.AreNotEqual(constrParam0, testOutput);
            Assert.AreEqual(0, testOutput.Count());
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsEmptyArray_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestricted()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Restricted);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            IEnumerable<byte> testOutput = testObject.EmbeddingData;

            Assert.AreNotEqual(constrParam0, testOutput);
            Assert.AreEqual(0, testOutput.Count());
        }

        [TestMethod]
        public void OpenTypeFontDescriptorClass_EmbeddingDataProperty_ReturnsEmptyArray_IfEmbeddingFlagsPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorEqualsRestrictedAndBitmapOnly()
        {
            OS2MetricsTable mockMetricsTable = GetOS2MetricsTable(EmbeddingPermissions.Restricted | EmbeddingPermissions.BitmapOnly);
            Mock<IOpenTypeFont> mockFont = new();
            mockFont.Setup(f => f.OS2Metrics).Returns(mockMetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };

            IEnumerable<byte> testOutput = testObject.EmbeddingData;

            Assert.AreNotEqual(constrParam0, testOutput);
            Assert.AreEqual(0, testOutput.Count());
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
